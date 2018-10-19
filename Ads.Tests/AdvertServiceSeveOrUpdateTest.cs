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
    public class AdvertServiceSeveOrUpdateTest
    {
        private Mock<IAdvertRepository> _repository;
        private AdvertService _service;

        public AdvertServiceSeveOrUpdateTest()
        {
            AutoMapperConfig.Initialize();
            _repository = new Mock<IAdvertRepository>();
            _service = new AdvertService(_repository.Object);

            Advert testAdvert = new Advert
            {
                Name = "IPhone",
                CategoryId = 1,
                CityId = 1,
                StatusId = 1,
                TypeId = 1
            };

            _repository.Setup(r => r.SaveOrUpdate(It.IsAny<Advert>())).
                Returns((Task<int> task) => task);
        }

        [Fact]
        public async Task SaveOrUpdate()
        {
            var testAdverts = GetTestAdverts();

            AdvertDto testAdvertDto = new AdvertDto
            {
                Id = 2,
                Name = "Samsung",
                CategoryId = 1,
                CityId = 1,
                StatusId = 1,
                TypeId = 1
            };

            //_repository.Setup(r => r.GetAll()).Returns(testAdverts);

            //_repository.Setup(r => r.SaveOrUpdate(testAdvert)).Returns((Task<int> task) => task);

            var result =  await _service.SaveOrUpdate(testAdvertDto);

            Assert.Equal(0, result);
        }

        private IQueryable<Advert> GetTestAdverts()
        {
            var adverts = new List<Domain.Entities.Advert>{
                new Domain.Entities.Advert
                {
                    Name = "IPhone",
                    CategoryId = 1,
                    CityId = 1,
                    StatusId = 1,
                    TypeId = 1
                },
                new Domain.Entities.Advert
                {
                    Name = "Samsung",
                    CategoryId = 1,
                    CityId = 1,
                    StatusId = 1,
                    TypeId = 1
                },
                new Domain.Entities.Advert
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

        private AdvertDto[] GetTestAdvertsDto()
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
                    TypeId = 1
                },
                new AdvertDto
                {
                    Id = 2,
                    Name = "Samsung",
                    CategoryId = 1,
                    CityId = 1,
                    StatusId = 1,
                    TypeId = 1
                },
                new AdvertDto
                {
                    Id = 3,
                    Name = "Sony",
                    CategoryId = 1,
                    CityId = 1,
                    StatusId = 1,
                    TypeId = 1
                }
            };
        }
    }
}
