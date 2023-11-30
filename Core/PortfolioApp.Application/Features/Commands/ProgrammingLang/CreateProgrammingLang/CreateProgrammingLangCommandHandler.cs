using System.Text;
using MediatR;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Features.Commands.ProgrammingLang.CreateProgrammingLang;

public class CreateProgrammingLangCommandHandler : IRequestHandler<CreateProgrammingLangCommandRequest, CommonResponse<bool>>
{
    private readonly IProgrammingLanguageWriteRepository _programmingLanguageWriteRepository;

    public CreateProgrammingLangCommandHandler(IProgrammingLanguageWriteRepository programmingLanguageWriteRepository)
    {
        _programmingLanguageWriteRepository = programmingLanguageWriteRepository;
    }

    public async Task<CommonResponse<bool>> Handle(CreateProgrammingLangCommandRequest request, CancellationToken cancellationToken)
    {

        await _programmingLanguageWriteRepository.AddAsync(new ProgrammingLanguage
        {
            Name = request.Name,
            Level = request.Level,
            LanguageImg = Encoding.UTF8.GetBytes(request.LanguageImage),
            Description = request.Description 
        });


            var addedData = await _programmingLanguageWriteRepository.SaveAsync();


        return new()
        {
            Data = addedData > 0,
            ResponseStatus = ResponseStatus.Success
        };
    }
}

public class CreateProgrammingLangCommandRequest : IRequest<CommonResponse<bool>>
{
    public string Name { get; set; }
    public int Level { get; set; }
    public string LanguageImage { get; set; }
    public string Description { get; set; }
}

//public class CreateProgrammingLangCommandResponse
//{
//    public CommonResponse<bool> CommonResponse { get; set; }
//}