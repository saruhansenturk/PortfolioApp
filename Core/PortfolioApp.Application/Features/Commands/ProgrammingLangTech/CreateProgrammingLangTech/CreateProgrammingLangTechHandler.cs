using System.Text;
using MediatR;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Features.Commands.ProgrammingLangTech.CreateProgrammingLangTech
{
    public class CreateProgrammingLangTechHandler : IRequestHandler<CreateProgrammingLangTechRequest, CommonResponse<bool>>
    {
        private readonly IProgrammingLanguageTechWriteRepository _programmingLanguageTechWriteRepository;
        private readonly IProgrammingLanguageReadRepository _programmingLanguageReadRepository;
        public CreateProgrammingLangTechHandler(IProgrammingLanguageTechWriteRepository programmingLanguageTechWriteRepository, IProgrammingLanguageReadRepository programmingLanguageReadRepository)
        {
            _programmingLanguageTechWriteRepository = programmingLanguageTechWriteRepository;
            _programmingLanguageReadRepository = programmingLanguageReadRepository;
        }

        public async Task<CommonResponse<bool>> Handle(CreateProgrammingLangTechRequest request, CancellationToken cancellationToken)
        {
            var addedEntity = await _programmingLanguageTechWriteRepository.AddAsync(new ProgrammingLanguageTech
            {
                Name = request.Name,
                ProgrammingLanguageId = Guid.Parse(request.ProgrammingLanguageId),
                Level = request.Level,
                LanguageTechImage = request.LanguageTechImage != null ? Encoding.UTF8.GetBytes(request.LanguageTechImage) : null
            });

            if (addedEntity.ResponseStatus != ResponseStatus.Success)
                return new CommonResponse<bool>
                {
                    Data = false,
                    ResponseStatus = addedEntity.ResponseStatus,
                    Message = "Eklenmek üzere olan veride eklenirken bir sorun oluştu."
                };


            if (string.IsNullOrEmpty(request.ProgrammingLanguageId))
                return new CommonResponse<bool>
                {
                    Data = false,
                    Message = "Programming Language Id degeri olmadan veri eklenemez. Lutfen kontrol ediniz.",
                    ResponseStatus = ResponseStatus.Info
                };


            var saveResult = await _programmingLanguageTechWriteRepository.SaveAsync();

            if (saveResult == 0)
            {
                return new CommonResponse<bool>
                {
                    Data = false,
                    ResponseStatus = ResponseStatus.Fail,
                    Message = "Database'e eklenirken bir sorun oluştu."
                };
            }


            return new CommonResponse<bool>
            {
                Data = true,
                Message = "Başarılı",
                ResponseStatus = ResponseStatus.Success
            };
        }
    }


    public class CreateProgrammingLangTechRequest : IRequest<CommonResponse<bool>>
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public string ProgrammingLanguageId { get; set; }
        public string? LanguageTechImage { get; set; }
    }
}
