using Ads.CoreService.Contracts.Dto;
using AppServices.Services;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Func<Comment, Comment> func = (Comment comment) =>
            {
                return comment;
            };
            Task<Comment> commentTask = new Task<Comment>(() => func(MapCommentDtoToComment().ToArray()[0]));
            commentTask.Start();

            _commentRepository.Setup(x => x.GetAll()).Returns(MapCommentDtoToComment());
            _commentRepository.Setup(x => x.GetAsync(1)).Returns(commentTask);
        }

        [Fact]
        public void GetAllReturnAllComments()
        {
            var result = _commentService.GetAll();

            Assert.Equal(6, result.Count());
        }

        [Fact]
        public async Task GetIdReturnComment()
        {
            var result = await _commentService.GetAsync(1);

            Assert.Equal(1, result.Id);
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
                    Id = 1,
                    AdvertId = 1,
                    Body = "Круто!"
                },
                new CommentDto
                {   
                    Id = 2,
                    AdvertId = 1,
                    Body = "Работает!"
                },
                new CommentDto
                {
                    Id = 3,
                    AdvertId = 1,
                    Body = "Если не работает - за работает!"
                },
                new CommentDto
                {
                    Id = 4,
                    AdvertId = 2,
                    Body = "А тут ид = 2!"
                },
                new CommentDto
                {
                    Id = 5,
                    AdvertId = 2,
                    Body = "И тут 2!"
                },
                new CommentDto
                {
                    Id = 6,
                    AdvertId = 3,
                    Body = "А тут 3!"
                }
            };
        }
    }
}
