using Ads.CoreService.Contracts.Dto;
using Ads.CoreService.Contracts.Dto.Filters;
using Ads.Shared.Contracts;
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

namespace Ads.CoreService.AppServices.Services
{
    public class AdvertService : Base.BaseService<AdvertDto, int>, IAdvertService
    {
        readonly IAdvertRepository _advertRepository;
        readonly IImageRepository _imageRepository;
        public AdvertService(IAdvertRepository advertRepository,
                             IImageRepository imageRepository)
        {
            _imageRepository = imageRepository;
            _advertRepository = advertRepository;
        }
        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public override IList<AdvertDto> GetAll()
        {
            IQueryable<Advert> adv = _advertRepository.GetAll();
            if (adv == null)
                return null;
            AdvertDto[] result = Mapper.Map<AdvertDto[]>(adv.ToArray());
            return result;
        }

        /// <inheritdoc/>
        public IList<AdvertDto> GetAdvertsByUserId(int userId)
        {
            IQueryable<Advert> adv = _advertRepository.GetAll()
                .Where(u => u.UserId == userId);

            if (adv == null)
                throw new ArgumentOutOfRangeException($"У пользователя с Id = {userId} нет объявлений");

            AdvertDto[] result = Mapper.Map<AdvertDto[]>(adv.ToArray());
            return result;
        }

        /// <inheritdoc/>
        public IList<AdvertDto> GetAll_ToIndex()
        {
            IQueryable<Advert> adv = _advertRepository.GetAll()
            .Include(t => t.Category)
            .Include(q => q.City)
            .Include(q => q.Status)
            .Include(q => q.Type);
            if (adv == null)
                return null;
            AdvertDto[] result = Mapper.Map<AdvertDto[]>(adv.ToArray());
            return result;
        }
        /// <inheritdoc/>
        public override async Task<AdvertDto> SaveOrUpdateAsync(AdvertDto entity)
        {
            if (entity.Images.Count()>0)
                await _imageRepository.DeleteAdvertImages(entity.Id);
            var advert = await _advertRepository.SaveOrUpdateAsync(Mapper.Map<Advert>(entity));
            return Mapper.Map<AdvertDto>(advert);
        }
        /// <inheritdoc/>
        public override async Task<AdvertDto> GetAsync(int id)
        {
            Advert adv = await _advertRepository.GetAsync(id);
            if (adv == null)
                throw new ArgumentOutOfRangeException("Id", adv, "Не существует объявления с полученным Id.");

            return Mapper.Map<AdvertDto>(adv);
        }
        /// <inheritdoc/>
        /// На время, пока фото загружаются вместе с Advert[]
        //public override async Task<AdvertDto> GetAsync(int id)
        //{
        //    Advert adv = await _advertRepository.GetAll()
        //        .Include(t => t.Images)
        //        .FirstOrDefaultAsync(t => t.Id == id);
        //    if (adv == null)
        //        throw new ArgumentOutOfRangeException("Id", adv, "Не существует объявления с полученным Id.");

        //    return Mapper.Map<AdvertDto>(adv);
        //}
        /// <inheritdoc/>
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
                if (filter.CategoryId.Value > 0)
                    query = query.Where(x => x.CategoryId == filter.CategoryId
                                             || x.Category.ParentCategoryId == filter.CategoryId);

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
                    .Include(q => q.Images)
                    .Include(q => q.Type).ToArray();
                return Mapper.Map<AdvertDto[]>(entities);
            }
            catch (SqlException ex)
            {
                throw new NullReferenceException($"Не существует записей с заданными параметрами фильтра. " +
                    ex.Message);
            }
        }
        /// <inheritdoc/>
        public PagedCollection<AdvertDto> GetFilteredAsync(AdvertFilterDto filter)
        {
            var query = _advertRepository.GetAll();
            if (filter.PriceRange.From.HasValue)
                query = query.Where(x => x.Price >= filter.PriceRange.From);
            if (filter.PriceRange.To.HasValue)
                query = query.Where(x => x.Price <= filter.PriceRange.To);
            if (filter.RegionId.HasValue)
                query = query.Where(x => x.City.RegionId == filter.RegionId);
            if (filter.CityId.HasValue)
                query = query.Where(x => x.CityId == filter.CityId);

            if (filter.CategoryId.HasValue)
                if (filter.CategoryId.Value > 0)
                    query = query.Where(x => x.CategoryId == filter.CategoryId
                                        || x.Category.ParentCategoryId == filter.CategoryId);

            if (filter.onlyName == true)
            {
                if (!string.IsNullOrEmpty(filter.Substring))
                    query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Substring}%"));
            }
            else
            {
                if (!string.IsNullOrEmpty(filter.Substring))
                    query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Substring}%") ||
                                        EF.Functions.Like(x.Description, $"%{filter.Substring}%"));
            }

            if (filter.onlyPhoto == true)
                query = query.Where(x => x.Images.Count() != 0);

            var count = query.Count();
            query = query.Skip(filter.PageSize * (filter.PageNumber - 1))
                .Take(filter.PageSize);
            try
            {
                var entities = query
                    .Include(t => t.Category)
                    .Include(q => q.City)
                    .Include(q => q.Status)
                    .Include(q => q.Type)
                    .ToArray();
                var pages = count % filter.PageSize > 0 ? (count / filter.PageSize) + 1 : (count / filter.PageSize);

                return new PagedCollection<AdvertDto>(
                    Mapper.Map<AdvertDto[]>(entities),
                    filter.PageNumber,
                    filter.PageSize,
                    totalPages: pages);
            }
            catch (SqlException ex)
            {
                throw new NullReferenceException($"Не существует записей с заданными параметрами фильтра. " +
                    ex.Message);
            }
        }

        /// <inheritdoc />
        public PagedCollection<AdvertDto> GetLastAddedAdverts()
        {
            int count = _advertRepository.GetAll().Count();
            if (count >= 9)
                count = 9;
            var query = _advertRepository.GetAll()
                .OrderByDescending(a => a.Created)
                .Take(count);
            var entities = query
                    .Include(t => t.Category)
                    .Include(q => q.City)
                    .Include(q => q.Status)
                    .Include(q => q.Type)
                    .ToArray();

            return new PagedCollection<AdvertDto>(
                    Mapper.Map<AdvertDto[]>(entities), 1, 1, 1);
        }

        /// <inheritdoc/>
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
        /// <inheritdoc />
        public async Task<ImageDto[]> GetAdvertImages(int advertId)
        {
            var images = await _imageRepository.GetAdvertImages(advertId);
            if (images.Length == 0)
                return null;
            return Mapper.Map<ImageDto[]>(images);
        }
    }
}

