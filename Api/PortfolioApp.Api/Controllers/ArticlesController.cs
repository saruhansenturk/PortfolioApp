using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Features.Commands;
using PortfolioApp.Application.Features.Queries.Article.GetArticleById;
using PortfolioApp.Application.Features.Queries.Article.GetArticleNameandId;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Config;

namespace PortfolioApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ITokenOptions _tokenOptions;
        public ArticlesController(IMediator mediator, ITokenOptions tokenOptions)
        {
            _mediator = mediator;
            _tokenOptions = tokenOptions;
        }

        //[HttpGet]
        //public async Task<GetAllFlexQueryResponse> Get(
        //    [FromQuery] GetAllFlexQueryRequest getAllFlexQueryRequest)
        //{
        //    GetAllFlexQueryResponse response = await _mediator.Send(getAllFlexQueryRequest);
        //    return response;
        //}

        //[HttpPost("[action]")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //public async Task<List<GetAllProgrammingLanguageNameAndIdResponse>> GetProgrammingLangItems(GetAllProgrammingLanguageNameAndIdRequest getAllProgrammingLanguageNameAndIdRequest)
        //{
        //    List<GetAllProgrammingLanguageNameAndIdResponse> response = await _mediator.Send(getAllProgrammingLanguageNameAndIdRequest);
        //    return response;
        //}

        //[HttpGet("{Id}")]
        //public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLangRequest getByIdProgrammingLangRequest)
        //{
        //    GetByIdProgrammingLangResponse response = await _mediator.Send(getByIdProgrammingLangRequest);
        //    return Ok(response);
        //}

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateArticleCommandRequest createArticleCommandRequest)
        {
            CommonResponse<bool> response = await _mediator.Send(createArticleCommandRequest);
            return Ok(response);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> GetArticleNameId([FromBody] GetArticleNameandIdQueryRequest getArticleNameandIdQueryRequest)
        {
            List<GetArticleNameandIdQueryResponse> response = await _mediator.Send(getArticleNameandIdQueryRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetArticleById([FromQuery] GetArticleByIdQueryRequest getArticleByIdQueryRequest)
        {
            CommonResponse<GetArticleByIdQueryResponse> response = await _mediator.Send(getArticleByIdQueryRequest);
            return Ok(response);
        }

        //[HttpGet("{FlexEnum}")]
        //public async Task<IActionResult> GetWhere([FromRoute] GetWhereFlexQueryRequest getWhereFlexQueryRequest)
        //{
        //    CommonResponse<GetWhereFlexQueryResponse> response = await _mediator.Send(getWhereFlexQueryRequest);
        //    return Ok(response);
        //}

        //[HttpPost("[action]")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //public async Task<IActionResult> Update([FromBody] UpdateProgrammingLangRequest updateProgrammingLangRequest)
        //{
        //    CommonResponse<bool> response = await _mediator.Send(updateProgrammingLangRequest);
        //    return Ok(response);
        //}

        //[HttpPost("{Id}")]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //public async Task<IActionResult> Delete([FromRoute] DeleteProgrammingLangRequest deleteProgrammingLangRequest)
        //{
        //    CommonResponse<bool> response = await _mediator.Send(deleteProgrammingLangRequest);
        //    return Ok(response);
        //}
    }
}
