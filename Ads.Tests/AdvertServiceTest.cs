
using Ads.Contracts.Dto;
using Ads.Contracts.Dto.Filters;
using AppServices.Services;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ads.Tests
{
    public class AdvertServiceTest
    {
        private Mock<IAdvertRepository> _repository;
        private AdvertService _service;

        public AdvertServiceTest()
        {
            AutoMapperConfig.Initialize();
            _repository = new Mock<IAdvertRepository>();
            _service = new AdvertService(_repository.Object);

            
            Func<Advert, Advert> func = (Advert advert) =>
            {
                return advert;
            };
            Task<Advert> advertTask = new Task<Advert>(() => func(GetAdvertsWithId().ToArray()[0]));
            advertTask.Start();

            _repository.Setup(x => x.GetAll()).Returns(GetAdvertsWithId());

            _repository.Setup(x => x.Get(1)).Returns(advertTask);

           // _repository.Setup(x => x.SaveOrUpdate(advert)).Returns(advertTask);
        }

        [Fact]
        public void GetAllAdvertsReturnAllAdverts()
        {
            var testAdverts = GetAdvertsWithId();
            
            var result = _service.GetAll();

            Assert.Equal(testAdverts.ToList().Count(), result.Count);
        }

        [Fact]
        public void GetAllAdvertToIndexReturnAllAdverts()
        {
            var testAdverts = GetAdvertsWithId();

            var result = _service.GetAll_ToIndex();

            Assert.Equal(testAdverts.ToList().Count(), result.Count);
        }

        [Fact]
        public async Task GetIdReturnAdvert()
        {
            var result = await _service.Get(1);

            Assert.Equal(1, result.Id);
        }

        [Fact]
        public void GetFilterCategoryIdReturnAdverts()
        {
            FilterDto filter = new FilterDto
            {
                CategoryId = 1
            };

            var result = _service.GetFiltred(filter);

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public void GetFilterCityIdReturnAdverts()
        {
            FilterDto filter = new FilterDto
            {
                CityId = 3
            };

            var result = _service.GetFiltred(filter);

            Assert.Single(result);
        }

        [Fact]
        public void GetFilterPaginathionReturnAdvertsOnPage()
        {
            FilterDto filter = new FilterDto
            {
                Pagination = new Contracts.Dto.Internal.Page<int>
                {
                    PageSize = 4,
                    PageNumber = 1
                }
            };
      

            var result = _service.GetFiltred(filter);

            Assert.Equal(4, result.Count());
        }

        [Fact]
        public void GetFilterSubstringReturnAdverts()
        {
            FilterDto filter = new FilterDto
            {
                Substring = "Samsung"
            };

            var result = _service.GetFiltred(filter);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetFilterPriceRangeReturnAdvertsOnPage()
        {
            FilterDto filter = new FilterDto
            {
                PriceRange = new Contracts.Dto.Internal.Range<decimal?>
                {
                    MinValue = 100,
                    MaxValue = 300
                }
            };


            var result = _service.GetFiltred(filter);

            Assert.Equal(3, result.Count());
        }

        [Fact]
        public void GetFilterRegionIdReturnAdverts()
        {
            FilterDto filter = new FilterDto
            {
                RegionId = 1
            };

            var result = _service.GetFiltred(filter);

            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetFilterWithAllParamsReturnAdverts()
        {
            FilterDto filter = new FilterDto
            {
                PriceRange = new Contracts.Dto.Internal.Range<decimal?>
                {
                    MinValue = 100,
                    MaxValue = 400
                },
                RegionId = 4,
                CategoryId = 1,
                CityId = 4,
                Substring = "Asus",
            };

            var result = _service.GetFiltred(filter);

            Assert.Single(result);
        }

        [Fact]
        public void GetAdvertIdReturnComments()
        {

        }
       
        /////Не работает
        //[Fact]
        //public async Task SaveOrUpdate_GetAdvertReturnAdvert()
        //{
        //    var result = await _service.SaveOrUpdate(advertDto);

        //    Assert.Equal(result.Id, advertDto.Id);
        //}
        // 
        private IQueryable<Advert> GetAdvertsWithId()
        {
            var adverts = Mapper.Map<Advert[]>(GetTestAdvertsDto());
            return adverts.AsQueryable();
        }

        public AdvertDto[] GetTestAdvertsDto()
        {
            return new[]
            {
                new AdvertDto
                {
                    Id = 1,
                    Name = "IPhone",
                    CategoryId = 1,
                    CityId = 1,
                    StatusId = 1,
                    TypeId = 1,
                    Price = 100,
                    City = new Ads.Contracts.Dto.City{ RegionId = 1 }

                },
                new AdvertDto
                {
                    Id = 2,
                    Name = "Samsung",
                    CategoryId = 1,
                    CityId = 2,
                    StatusId = 1,
                    TypeId = 1,
                    Price = 200,
                    City = new Ads.Contracts.Dto.City{ RegionId = 1 }
                },
                new AdvertDto
                {
                    Id = 3,
                    CategoryId = 1,
                    CityId = 3,
                    StatusId = 1,
                    TypeId = 1,
                    Price = 300,
                    City = new Ads.Contracts.Dto.City{ RegionId = 3 }
                },
                 new AdvertDto
                {
                    Id = 4,
                    Name = "Asus",
                    Description = "Samsung",
                    CategoryId = 1,
                    CityId = 4,
                    StatusId = 1,
                    TypeId = 2,
                    Price = 400,
                    City = new Ads.Contracts.Dto.City{ RegionId = 4 }
                }
            };
        }
    }
}
