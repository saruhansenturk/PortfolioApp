using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Features.Commands.ProgrammingLangTech.CreateProgrammingLangTech;
using PortfolioApp.Application.Features.Commands.ProgrammingLangTech.DeleteProgrammingLangTech;
using PortfolioApp.Application.Features.Commands.ProgrammingLangTech.UpdateProgrammingLangTech;
using PortfolioApp.Application.Features.Queries.ProgrammingLanguageTech.GetAllProgrammingLangTechUi;
using PortfolioApp.Application.Features.Queries.ProgrammingLanguageTech.GetAllProgramminLanguageTech;
using PortfolioApp.Application.Features.Queries.ProgrammingLanguageTech.GetByIdProgramminLanguageTech;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLangTechsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProgrammingLangTechsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllProgrammingTechQueryRequest getAllProgrammingTechQueryRequest)
        {
            GetAllProgrammingTechQueryResponse response = await _mediator.Send(getAllProgrammingTechQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLangTechRequest getByIdProgrammingLangTechRequest)
        {
            GetByIdProgrammingLangTechResponse response = await _mediator.Send(getByIdProgrammingLangTechRequest);
            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<GetAllProgrammingLangTechUiQueryResponse> GetProgrammingTechUi(
            [FromQuery] GetAllProgrammingLangTechUiQueryRequest getAllProgrammingLangTechUiQueryRequest)
        {
            GetAllProgrammingLangTechUiQueryResponse response = await _mediator.Send(getAllProgrammingLangTechUiQueryRequest);
            return response;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateProgrammingLangTechRequest createProgrammingLangTechRequest)
        {
            CommonResponse<bool> response = await _mediator.Send(createProgrammingLangTechRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLangTechRequest updateProgrammingLangTechRequest)
        {
            CommonResponse<ProgrammingLanguageTech> response = await _mediator.Send(updateProgrammingLangTechRequest);
            return Ok(response);
        }

        [HttpPost("{Id}")]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLangTechRequest deleteProgrammingLangRequest)
        {
            CommonResponse<bool> response = await _mediator.Send(deleteProgrammingLangRequest);
            return Ok(response);
        }
    }
}
