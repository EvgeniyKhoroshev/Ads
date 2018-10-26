using Ads.Contracts.Dto;
using AppServices.Services;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Ads.Tests
{
    public class CommentsServiceTest
    {
        private Mock<ICommentsRepository> _commentRepository;
        private CommentsService _commentService;

        public CommentsServiceTest()
        {
            AutoMapperConfig.Initialize();
            _commentRepository = new Mock<ICommentsRepository>();
            _commentService = new CommentsService(_commentRepository.Object);

            _commentRepository.Setup(x => x.GetAll()).Returns(MapCommentDtoToComment());
        }

        [Fact]
        public void GetAllReturnAllComments()
        {
            var result = _commentService.GetAll();

            Assert.Equal(6, result.Count());
        }

        private IQueryable<Comment> MapCommentDtoToComment()
        {
            var comments = Mapper.Map<Comment[]>(GetTestCommentDtos());
            return comments.AsQueryable();
        }

        private CommentDto[] GetTestCommentDtos()
        {
            return new[]
            {
                new CommentDto
                {
                    AdvertId = 1,
                    Body = "Круто!"
                },
                new CommentDto
                {
                    AdvertId = 1,
                    Body = "Работает!"
                },
                new CommentDto
                {
                    AdvertId = 1,
                    Body = "Если не работает - за работает!"
                },
                new CommentDto
                {
                    AdvertId = 2,
                    Body = "А тут ид = 2!"
                },
                new CommentDto
                {
                    AdvertId = 2,
                    Body = "И тут 2!"
                },
                new CommentDto
                {
                    AdvertId = 3,
                    Body = "А тут 3!"
                }
            };
        }
    }
}
