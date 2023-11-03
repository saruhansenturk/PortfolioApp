using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PortfolioApp.Application.Extensions;
using PortfolioApp.Application.Response;
using PortfolioApp.Domain.Entities;

namespace PortfolioApp.Application.Features.Commands
{
    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommandRequest, CommonResponse<bool>>
    {
        private readonly IArticleWriteRepository _articleWriteRepository;

        public CreateArticleCommandHandler(IArticleWriteRepository articleWriteRepository)
        {
            _articleWriteRepository = articleWriteRepository;
        }

        public async Task<CommonResponse<bool>> Handle(CreateArticleCommandRequest request, CancellationToken cancellationToken)
        {

            var addToEntity = await _articleWriteRepository.AddAsync(new Article
            {
                ArticleName = request.ArticleName,
                Author = request.Author,
                Body = request.Body,
                Conclusion = request.Conclusion,
                Image = request.Image != null ? Encoding.UTF8.GetBytes(request.Image) : null,
                Introduction = request.Introduction,
                LikeCount = 0,
                Title = request.Title,
                CategoryId = Guid.Parse("ad74af6e-a56a-4bdb-93b1-34bfbae4d1fa")
            });

            if (addToEntity.Data != null)
            {
                var saveChanges = await _articleWriteRepository.SaveAsync();
                if (saveChanges > 0)
                    return new CommonResponse<bool>
                    {
                        Data = true,
                        ResponseStatus = ResponseStatus.Success,
                        Message = "Article added to successfuly"
                    };
            }


            return new CommonResponse<bool>
            {
                Data = true,
                ResponseStatus = ResponseStatus.Fail,
                Message = "An error occured when add to Article"
            };
        }
    }

    public class CreateArticleCommandRequest : IRequest<CommonResponse<bool>>
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Introduction { get; set; }
        public string Body { get; set; }
        public string Conclusion { get; set; }
        public string ArticleName { get; set; }
        public string? Image { get; set; }
        public int LikeCount { get; set; }
        public string? CategoryId { get; set; }
    }

    //public class CreateArticleCommandResponse
    //{
    //}
}