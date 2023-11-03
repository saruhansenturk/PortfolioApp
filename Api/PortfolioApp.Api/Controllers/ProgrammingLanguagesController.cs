using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Features.Commands.ProgrammingLang.CreateProgrammingLang;
using PortfolioApp.Application.Features.Commands.ProgrammingLang.DeleteProgrammingLang;
using PortfolioApp.Application.Features.Commands.ProgrammingLang.UpdateProgrammingLang;
using PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetAllProgrammingLanguage;
using PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetAllProgrammingLanguageNameAndId;
using PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetAllProgrammingLanguageUi;
using PortfolioApp.Application.Features.Queries.ProgramingLanguage.GetByIdProgrammingLanguage;
using PortfolioApp.Application.Response;

namespace PortfolioApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgrammingLanguagesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetAllProgrammingLangQueryResponse> Get(
            [FromQuery] GetAllProgrammingLangQueryRequest getAllProgrammingLangQueryRequest)
        {
            GetAllProgrammingLangQueryResponse response = await _mediator.Send(getAllProgrammingLangQueryRequest);
            return response;
        }

        [HttpGet("[action]")]
        public async Task<GetAllProgrammingLangUiQueryResponse> GetProgrammingUi(
            [FromQuery] GetAllProgrammingLangUiQueryRequest getAllProgrammingLangQueryRequest)
        {
            GetAllProgrammingLangUiQueryResponse response = await _mediator.Send(getAllProgrammingLangQueryRequest);
            return response;
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<List<GetAllProgrammingLanguageNameAndIdResponse>> GetProgrammingLangItems(GetAllProgrammingLanguageNameAndIdRequest getAllProgrammingLanguageNameAndIdRequest)
        {
            List<GetAllProgrammingLanguageNameAndIdResponse> response = await _mediator.Send(getAllProgrammingLanguageNameAndIdRequest);
            return response;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLangRequest getByIdProgrammingLangRequest)
        {
            GetByIdProgrammingLangResponse response = await _mediator.Send(getByIdProgrammingLangRequest);
            return Ok(response);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateProgrammingLangCommandRequest createProgrammingLangCommandHandler)
        {
            CommonResponse<bool> response = await _mediator.Send(createProgrammingLangCommandHandler);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLangRequest updateProgrammingLangRequest)
        {
            CommonResponse<bool> response = await _mediator.Send(updateProgrammingLangRequest);
            return Ok(response);
        }

        [HttpPost("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLangRequest deleteProgrammingLangRequest)
        {
            CommonResponse<bool> response = await _mediator.Send(deleteProgrammingLangRequest);
            return Ok(response);
        }
    }
}
