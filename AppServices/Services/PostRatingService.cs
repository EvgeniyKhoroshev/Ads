using System.Threading.Tasks;
using Ads.CoreService.AppServices.ServiceInterfaces;
using Ads.CoreService.Contracts.Dto;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;

namespace Ads.CoreService.AppServices.Services
{
    public class PostRatingService : IPostRatingService
    {
        protected readonly IPostRatingRepository _ratingRepository;
        public PostRatingService(IPostRatingRepository ratingRepository)
        {
            _ratingRepository = ratingRepository;
        }
        /// <inheritdoc />
        public async Task<RatingDto[]> GetCurrentUserRatesAsync(int userId, int advertId)
        {
            var rateList = await _ratingRepository.GetUserRatesAsync(userId, advertId);
            return Mapper.Map<RatingDto[]>(rateList);
        }
        /// <inheritdoc />
        public async Task<int> GetPostRatingAsync(int postId)
        {
            return await _ratingRepository.GetPostRatingAsync(postId);
        }
        /// <inheritdoc />
        public async Task<bool> SetRatingToPostAsync(RatingDto ratingDto)
        {
            var rating = AutoMapper.Mapper.Map<PostRating>(ratingDto);
            return await _ratingRepository.SetRatingToPostAsync(rating);
        }
    }
}
