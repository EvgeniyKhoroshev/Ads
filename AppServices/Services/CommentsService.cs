﻿using Ads.Contracts.Dto;
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
    public class CommentsService : Base.BaseService<CommentDto, int>, ICommentsService
    {
        readonly ICommentsRepository _commentRepository;
        public CommentsService(ICommentsRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }
        public override void Delete(int id)
        {
            _commentRepository.Delete(id);
        }
        public override IList<CommentDto> GetAll()
        {
            IQueryable<Comment> adv = _commentRepository.GetAll();
            if (adv == null)
                return null;
            CommentDto[] result;
            result = Mapper.Map<CommentDto[]>(adv.ToArray());
            return result;
        }
        public IList<CommentDto> GetAllAdvertComments(int advertId)
        {
            IQueryable<Comment> adv = _commentRepository.GetAll();
            if(advertId == 0)
                throw new ArgumentException("Invalid advert id = 0");
            else
            {
                adv.Select(a => a.AdvertId == advertId);
                CommentDto[] result = Mapper.Map<CommentDto[]>(adv.ToArrayAsync().Result);
                return result;
            }
        }
        public override async Task<CommentDto> SaveOrUpdate(CommentDto entity)
        {
            var sm = await _commentRepository.SaveOrUpdate(Mapper.Map<Comment>(entity));
            return Mapper.Map<CommentDto>(sm);

        }
        /// <summary>
        /// Возвращает список существующих объявлений не включая дочерние // 
        /// Returns all Comments excluding subsidiaries
        /// </summary>
        /// <returns>Возвращает список объявлений / 
        /// Getting the Comments list</returns>
        public override async Task<CommentDto> Get(int id)
        {

            var adv = _commentRepository
                .GetAll()
                .Select(t => t.Id == id);
            if (adv == null)
                return null;
            return Mapper.Map<CommentDto>(await adv.FirstOrDefaultAsync());
        }
        /// <summary>
        /// Возвращает список существующих объявлений включая дочерние // 
        /// Returns all Comments including subsidiaries
        /// </summary>
        /// <returns>Возвращает список существующих объявлений включая дочерние / 
        /// Returns all Comments including subsidiaries</returns>
        //public override async Task<CommentDto> GetWithIncludes(int id)
        //{
        //    var adv = _CommentRepository
        //        .GetAll()
        //        .Include(t => t.Comments)
        //        .Select(t => t.Id == id);
        //    if (adv == null)
        //        return null;
        //    return Mapper.Map<CommentDto>(await adv.FirstOrDefaultAsync());
        //}

        //public CommentDto[] GetFiltred(FilterDto filter)
        //{
        //    var query = _commentRepository.GetAll();

        //    if (filter.PriceRange != null)
        //    {
        //        if (filter.PriceRange.MinValue.HasValue)
        //            query = query.Where(x => x.Price >= filter.PriceRange.MinValue);
        //        if (filter.PriceRange.MaxValue.HasValue)
        //            query = query.Where(x => x.Price <= filter.PriceRange.MaxValue);
        //    }
        //    if (filter.RegionId.HasValue)
        //        query = query.Where(x => x.City.RegionId == filter.RegionId);

        //    if (filter.CityId.HasValue)
        //        query = query.Where(x => x.CityId == filter.CityId);

        //    if (filter.CategoryId.HasValue)
        //        query = query.Where(x => x.CategoryId == filter.CategoryId);

        //    if (!string.IsNullOrEmpty(filter.Substring))
        //        query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Substring}%") ||
        //                            EF.Functions.Like(x.Description, $"%{filter.Substring}%"));

        //    query = query.Skip(filter.Pagination.PageSize * (filter.Pagination.PageNumber - 1))
        //        .Take(filter.Pagination.PageSize);
        //    try
        //    {
        //        var entities = query.ToArray();
        //        return Mapper.Map<CommentDto[]>(entities);
        //    }
        //    catch (SqlException)
        //    {
        //        throw new NullReferenceException($"Не существует записей с заданными параметрами фильтра.");
        //    }
        //}
    }
}

