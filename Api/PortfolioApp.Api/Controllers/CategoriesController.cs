﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PortfolioApp.Application.Features.Queries.Category.GetAllCategory;

namespace PortfolioApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Admin")]
        public async Task<List<GetAllCategoryQueryResponse>> Get([FromQuery] GetAllCategoryQueryRequest getAllFlexQueryRequest)
        {
            List<GetAllCategoryQueryResponse> response = await _mediator.Send(getAllFlexQueryRequest);
            return response;
        }

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

        //[HttpPost]
        //[Authorize(AuthenticationSchemes = "Admin")]
        //public async Task<IActionResult> Post([FromBody] CreateArticleCommandRequest createArticleCommandRequest)
        //{
        //    CommonResponse<bool> response = await _mediator.Send(createArticleCommandRequest);
        //    return Ok(response);
        //}

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
