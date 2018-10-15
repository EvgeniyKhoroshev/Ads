using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using AppServices.ServiceInterfaces;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace AppServices.Services
{
    public class AdvertService : Base.BaseService<AdvertDto, int>, IAdvertService
    {
        readonly IAdvertRepository _advertRepository;
        public AdvertService(IAdvertRepository advertRepository)
        {
            _advertRepository = advertRepository;
        }
        public override void Delete(int id)
        {
            _advertRepository.Delete(id);
        }
        public override IList<AdvertDto> GetAll()
        {
            IQueryable<Advert> adv = _advertRepository.GetAll();
            if (adv == null)
                return null;
            AdvertDto[] result;
            result = Mapper.Map<AdvertDto[]>(adv.ToArray());
            return result;
        }
        public IList<CommentDto> GetAdvertComments(int advertId)
        {
            IQueryable<Advert> adv = _advertRepository.GetAll()
                .Include(t => t.Comments);
            if (advertId == 0)
                throw new ArgumentException("Error during query for comments of a advert with id = " + advertId);
            else
            {
                adv.Select(a => a.Id == advertId);
                CommentDto[] result = Mapper.Map<CommentDto[]>(adv.Select(t => t.Comments).ToArray());
                return result;
            }
        }
        public override async Task<int> SaveOrUpdate(AdvertDto entity)
        {
            return await _advertRepository.SaveOrUpdate(Mapper.Map<Advert>(entity));
             
        }
        /// <summary>
        /// Возвращает список существующих объявлений не включая дочерние // 
        /// Returns all adverts excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает список объявлений / 
        /// Getting the adverts list</returns>
        public override async Task<AdvertDto> Get(int id)
        {

            var adv = _advertRepository
                .GetAll()
                .Where(t => t.Id == id);
            if (adv == null)
                return null;
            return Mapper.Map<AdvertDto>(await adv.FirstOrDefaultAsync());
        }
        /// <summary>
        /// Возвращает список существующих объявлений включая дочерние // 
        /// Returns all adverts including subsidiaries
        /// </summary>
        /// <returns>Возвращает список существующих объявлений включая дочерние / 
        /// Returns all adverts including subsidiaries</returns>
        //public override async Task<AdvertDto> GetWithIncludes(int id)
        //{
        //    var adv = _advertRepository
        //        .GetAll()
        //        .Include(t => t.Comments)
        //        .Select(t => t.Id == id);
        //    if (adv == null)
        //        return null;
        //    return Mapper.Map<AdvertDto>(await adv.FirstOrDefaultAsync());
        //}

        public AdvertDto[] GetFiltred(FilterDto filter)
        {
            var query = _advertRepository.GetAll();

            if (filter.PriceRange != null)
            {
                if (filter.PriceRange.MinValue.HasValue)
                    query = query.Where(x => x.Price >= filter.PriceRange.MinValue);
                if (filter.PriceRange.MaxValue.HasValue)
                    query = query.Where(x => x.Price <= filter.PriceRange.MaxValue);
            }

            if (filter.RegionId.HasValue)
                query = query.Where(x => x.City.RegionId == filter.RegionId);

            if (filter.CityId.HasValue)
                query = query.Where(x => x.CityId == filter.CityId);

            if (filter.CategoryId.HasValue)
                query = query.Where(x => x.CategoryId == filter.CategoryId);

            if (!string.IsNullOrEmpty(filter.Substring))
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Substring}%") ||
                                    EF.Functions.Like(x.Description, $"%{filter.Substring}%"));

            query = query.Skip(filter.Pagination.PageSize * (filter.Pagination.PageNumber - 1))
                .Take(filter.Pagination.PageSize);
            try
            {
                var entities = query.ToArray();
                return Mapper.Map<AdvertDto[]>(entities);
            }
            catch (SqlException)
            {
                throw new NullReferenceException($"Не существует записей с заданными параметрами фильтра.");
            }

        }
    }
}

