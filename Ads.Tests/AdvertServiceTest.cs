
using Ads.Contracts.Dto;
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

            Advert advert = new Advert
            {
                Name = "Samsung",
                StatusId = 1,
                TypeId = 1,
                CategoryId = 1,
                CityId = 1,
                Price = 1000
            };
            Func<Advert, Advert> func = (Advert advertF) =>
            {
                return advertF;
            };
            Task<Advert> advertTask = new Task<Advert>(() => func(advert));
            advertTask.Start();

            _repository.Setup(x => x.GetAll()).Returns(GetTestAdverts());

            _repository.Setup(x => x.Get(1)).Returns(advertTask);

            _repository.Setup(x => x.SaveOrUpdate(advert)).Returns(advertTask);
        }

        [Fact]
        public void GetAllAdvertsReturnAllAdverts()
        {
            var testAdverts = GetTestAdverts();
            
            var result = _service.GetAll();

            Assert.Equal(testAdverts.ToList().Count(), result.Count);
        }

        [Fact]
        public async Task GetIdReturnAdvert()
        {
            var result = await _service.Get(1);

            Assert.Equal(advertDto.Id, result.Id);
        }

        [Fact]
        public async Task SaveOrUpdate_GetAdvertReturnAdvert()
        {
            var result = await _service.SaveOrUpdate(advertDto);

            Assert.Equal(result.Id, advertDto.Id);
        }

        [Fact]
        public void GetAllAdvertToIndexReturnAllAdverts()
        {
            var testAdverts = GetTestAdverts();

            var result = _service.GetAll_ToIndex();

            Assert.Equal(testAdverts.ToList().Count(), result.Count);
        }

        private IQueryable<Advert> GetTestAdverts()
        {
            var adverts = new List<Advert>{
                new Advert
                {
                    Name = "IPhone",
                    CategoryId = 1,
                    CityId = 1,
                    StatusId = 1,
                    TypeId = 1
                },
                new Advert
                {
                    Name = "Samsung",
                    CategoryId = 1,
                    CityId = 1,
                    StatusId = 1,
                    TypeId = 1
                },
                new Advert
                {
                    Name = "Sony",
                    CategoryId = 1,
                    CityId = 1,
                    StatusId = 1,
                    TypeId = 1
                }
            };

            IQueryable<Advert> result = adverts.AsQueryable();

            return result;
        }


        public AdvertDto[] GetTestAdvertsDto()
        {
            return new[]
            {
                new AdvertDto
                {
                    Name = "IPhone",
                    Status =  new Ads.Contracts.Dto.Status{ Id = 1 },
                    Type = new Ads.Contracts.Dto.AdvertType{ Id = 1 },
                    Category = new Ads.Contracts.Dto.Category{ Id = 1 },
                    City = new Ads.Contracts.Dto.City{Id = 1}
                },
                new AdvertDto
                {
                    Name = "Samsung",
                    Status =  new Ads.Contracts.Dto.Status{ Id = 1 },
                    Type = new Ads.Contracts.Dto.AdvertType{ Id = 1 },
                    Category = new Ads.Contracts.Dto.Category{ Id = 1 },
                    City = new Ads.Contracts.Dto.City{Id = 1}
                },
                new AdvertDto
                {
                    Status =  new Ads.Contracts.Dto.Status{ Id = 1 },
                    Type = new Ads.Contracts.Dto.AdvertType{ Id = 1 },
                    Category = new Ads.Contracts.Dto.Category{ Id = 1 },
                    City = new Ads.Contracts.Dto.City{Id = 1}
                }
            };
        }

        AdvertDto advertDto = new AdvertDto
        {
            Name = "Samsung",
            Status = new Ads.Contracts.Dto.Status { Id = 1 },
            Type = new Ads.Contracts.Dto.AdvertType { Id = 1 },
            Category = new Ads.Contracts.Dto.Category { Id = 1 },
            City = new Ads.Contracts.Dto.City { Id = 1 },
            Price = 1000
        };
    }
}
