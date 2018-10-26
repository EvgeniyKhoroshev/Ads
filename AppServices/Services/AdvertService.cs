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
        /// <summary>
        /// Удаляет объявление по указанному идентификатору // 
        /// Delete advert from database
        /// </summary>
        /// <param name="id"> Идентификатор объявления </param>
        public override void Delete(int id)
        {
            try
            {
                _advertRepository.Delete(id);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("При удалении объявления №{id} возникла ошибка. "
                    + ex.Message);
            }
        }
        /// <summary>
        /// Возвращает список существующих объявлений // 
        /// Returns all existing adverts
        /// </summary>
        /// <returns>Возвращает список объявлений / 
        /// Getting the adverts list</returns>
        public override IList<AdvertDto> GetAll()
        {
            IQueryable<Advert> adv = _advertRepository.GetAll();
            if (adv == null)
                return null;
            AdvertDto[] result;
            result = Mapper.Map<AdvertDto[]>(adv.ToArray());
            return result;
        }
        /// <summary>
        /// Возвращает список существующих объявлений с данными для вывода на главную страницу // 
        /// Returns all existing adverts with a data for index page output
        /// </summary>
        /// <returns>Возвращает список объявлений с данными для вывода на главную страницу / 
        /// Getting the adverts list with a data for index page output</returns>
        public IList<AdvertDto> GetAll_ToIndex()
        {
            IQueryable<Advert> adv = _advertRepository.GetAll()
            .Include(t => t.Category)
            .Include(q => q.City)
            .Include(q => q.Status)
            //.Include(q => q.Comments)
            .Include(q => q.Type);
            if (adv == null)
                return null;
            AdvertDto[] result;
            result = Mapper.Map<AdvertDto[]>(adv.ToArray());
            return result;
        }
        /// <summary>
        /// Возвращает список существующих объявлений не включая дочерние // 
        /// Returns all adverts excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает список объявлений / 
        /// Getting the adverts list</returns>
        public override async Task<AdvertDto> SaveOrUpdate(AdvertDto entity)
        {

            var sm = await _advertRepository.SaveOrUpdate(Mapper.Map<Advert>(entity));
            return Mapper.Map<AdvertDto>(sm);
        }
        /// <summary>
        /// Возвращает список существующих объявлений не включая дочерние // 
        /// Returns all adverts excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает список объявлений / 
        /// Getting the adverts list</returns>
        public override async Task<AdvertDto> Get(int id)
        {
            Advert adv = await _advertRepository.Get(id);
                //.GetAll().FirstOrDefaultAsync(t => t.Id == id);
            if (adv == null)
                throw new ArgumentOutOfRangeException("Id", adv, "Не существует объявления с полученным Id.");

            return Mapper.Map<AdvertDto>(adv);
        }
        /// <summary>
        /// Возвращает массив объявлений, отфильтрованных по условиям, указанным в <paramref name="filter"/>.
        /// </summary>
        /// <param name="filter">Фильтр объявлений.</param>
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
                query = query.Include(x => x.City)
                    .Where(x => x.City.RegionId == filter.RegionId);

            if (filter.CityId.HasValue)
                query = query.Where(x => x.CityId == filter.CityId);

            if (filter.CategoryId.HasValue)
                if (filter.CategoryId.Value > 0)
                    query = query.Where(x => x.CategoryId == filter.CategoryId);

            if (!string.IsNullOrEmpty(filter.Substring))
                query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Substring}%") ||
                                    EF.Functions.Like(x.Description, $"%{filter.Substring}%"));

            query = query.Skip(filter.Pagination.PageSize * (filter.Pagination.PageNumber - 1))
                .Take(filter.Pagination.PageSize);
            try
            {
                var entities = query
                    .Include(t => t.Category)
                    .Include(q => q.City)
                    .Include(q => q.Status)
                    .Include(q => q.Comments)
                    .Include(q => q.Type)
                    .Include(q => q.City.Region).ToArray();
                return Mapper.Map<AdvertDto[]>(entities);
            }
            catch (SqlException ex)
            {
                throw new NullReferenceException($"Не существует записей с заданными параметрами фильтра. " +
                    ex.Message);
            }
        }
        /// <summary>
        /// Функция для получения списка комментариев объявления с заданным Id //
        /// The function to get a comments from advert by the given advert Id
        /// </summary>
        /// <param name="advertId">Идентификатор объявления //
        /// Advert Id</param>
        /// <returns>Список комментариев, принадлежащих объявлению с заданным Id//
        /// List of a comments from advert with a given Id</returns>
        public IList<CommentDto> GetAdvertComments(int advertId)
        {
            try
            {
                var buf = _advertRepository.GetAll()
                    .Include(s => s.Comments)
                    .Where(d => d.Id == advertId);
                Advert b = buf.FirstOrDefault();
                return Mapper.Map<List<CommentDto>>(b.Comments.ToList());
            }
            catch (Exception ex)
            {
                throw new Exception("При попытке получить комментарии объявления №" +
                    advertId + " произошла ошибка. " + ex.Message);
            }
        }
    }
}

