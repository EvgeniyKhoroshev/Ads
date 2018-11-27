using System.Threading.Tasks;
using Ads.CoreService.AppServices.ServiceInterfaces;
using Ads.CoreService.Contracts.Dto;
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
        // <inheritdoc />
        public async Task<bool> SetRatingToPostAsync(RatingDto ratingDto)
        {
            var rating = AutoMapper.Mapper.Map<PostRating>(ratingDto);
            return await _ratingRepository.SetRatingToPostAsync(rating);
        }
    }
}
