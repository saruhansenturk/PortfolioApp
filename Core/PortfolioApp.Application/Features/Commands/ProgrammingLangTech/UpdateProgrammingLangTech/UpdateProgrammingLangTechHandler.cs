using MediatR;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Features.Commands.ProgrammingLangTech.UpdateProgrammingLangTech
{
    public class UpdateProgrammingLangTechHandler : IRequestHandler<UpdateProgrammingLangTechRequest, CommonResponse<ProgrammingLanguageTech>>
    {
        private readonly IProgrammingLanguageTechWriteRepository _programmingLanguageTechWriteRepository;
        private readonly IProgrammingLanguageTechReadRepository _programmingLanguageTechReadRepository;


        public UpdateProgrammingLangTechHandler(IProgrammingLanguageTechWriteRepository programmingLanguageTechWriteRepository, IProgrammingLanguageTechReadRepository programmingLanguageTechReadRepository)
        {
            _programmingLanguageTechWriteRepository = programmingLanguageTechWriteRepository;
            _programmingLanguageTechReadRepository = programmingLanguageTechReadRepository;
        }

        public async Task<CommonResponse<ProgrammingLanguageTech>> Handle(UpdateProgrammingLangTechRequest request, CancellationToken cancellationToken)
        {
            ProgrammingLanguageTech updateToEntityLanguageTech = await _programmingLanguageTechReadRepository.GetByIdAsync(request.Id, false);

            if (updateToEntityLanguageTech == null)
            {
                return new CommonResponse<ProgrammingLanguageTech>
                {
                    Message = "Update edilecek veri bulunamadi",
                    ResponseStatus = ResponseStatus.NoData
                };
            }

            updateToEntityLanguageTech.Level = request.Level;
            updateToEntityLanguageTech.Name = request.Name;

            CommonResponse<ProgrammingLanguageTech> updatedEntity = _programmingLanguageTechWriteRepository.Update(updateToEntityLanguageTech);

            var saveResult = await _programmingLanguageTechWriteRepository.SaveAsync();

            return new CommonResponse<ProgrammingLanguageTech>
            {
                Data = updatedEntity.Data,
                Message = "Başarıyla güncellendi",
                ResponseStatus = ResponseStatus.Success
            };

        }
    }

    public class UpdateProgrammingLangTechRequest : IRequest<CommonResponse<ProgrammingLanguageTech>>
    {
        public string Id { get; set; }
        public int Level { get; set; }
        public string Name { get; set; }
    }

}
