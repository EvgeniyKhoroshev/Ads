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
    public class AdvertServiceGetAllTests
    {

        private Mock<IAdvertRepository> _repository;
        private AdvertService _service;

        public AdvertServiceGetAllTests()
        {
            AutoMapperConfig.Initialize();
            _repository = new Mock<IAdvertRepository>();
            _service = new AdvertService(_repository.Object);

           _repository.Setup(x => x.GetAll()).Returns(GetTestAdverts());
        }

        //[Fact]
        //public async Task SaveOrUpdate()
        //{
        //    //Arrange

        //    var testAdverts = GetTestAdverts();
        //    AdvertDto testAdvertDto = new AdvertDto
        //    {
        //        Id = 1,
        //        Name = "IPhone",
        //        CategoryId = 1,
        //        CityId = 1,
        //        StatusId = 1,
        //        TypeId = 1
        //    };


        //    _repository.Setup(x => x.SaveOrUpdate(testAdverts.ToArray()[1])).Returns();

        //    //Act
        //    //_repository.Setup(r => r.SaveOrUpdate(It.Is<Advert>(x => x.Id == testAdvert.Id))).ReturnsAsync<Task<int>>(1);

        //    //var result = await _service.SaveOrUpdate(testAdvert);

        //    //Assert
        //   // Assert.Equal(testAdvert.Id, result);
        //}

        [Fact]
        public void GetAllAdvertsReturnAdverts()
        {
            var testAdverts = GetTestAdverts();

            //_repository.Setup(r => r.GetAll()).Returns(testAdverts);

            var result = _service.GetAll();


            Assert.Equal(testAdverts.ToList().Count(), result.Count);
        }

        //[Fact]
        //public void SaveOrUpdate()
        //{
        //    var testAdverts = GetTestAdverts();

        //    AdvertDto testAdvertDto = new AdvertDto
        //    {
        //        Id = 2,
        //        Name = "Samsung",
        //        CategoryId = 1,
        //        CityId = 1,
        //        StatusId = 1,
        //        TypeId = 1
        //    };

        //    _repository.Setup(r => r.GetAll()).Returns(testAdverts);

        //    _repository.Setup(r => r.SaveOrUpdate(It.IsAny<Domain.Entities.Advert>())).Returns((Task<int> task) => task);

        //    var result = _service.SaveOrUpdate(testAdvertDto);
        
        //    Assert.Equal(2, result.Id);

        //}
        private IQueryable<Domain.Entities.Advert> GetTestAdverts()
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

            IQueryable<Domain.Entities.Advert> result = adverts.AsQueryable();

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
