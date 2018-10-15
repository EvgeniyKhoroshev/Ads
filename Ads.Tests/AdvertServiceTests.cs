using Ads.Contracts.Dto;
using AppServices.Services;
using AutoMapper;
using Domain.Entities;
using Domain.RepositoryInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;

namespace Ads.Tests
{
    [TestFixture]
    public class AdvertServiceTests
    {

        private AdvertService _service;
        private Mock<IMapper> _mapper;
        private Mock<IAdvertRepository> _repository;

        [SetUp]
        public void Setup()
        {
            _mapper = new Mock<IMapper>();
            _repository = new Mock<IAdvertRepository>();
            _service = new AdvertService(_repository.Object);
        }

        [Test]
        public void GetAdvertByIdShouldReturnAdvertIfExists()
        {
            var testAdvert = new Advert
            {
                Name = "Объявление",
                Price = 1000,
                StatusId = 1,
                TypeId = 1,
                CityId = 1
            };

            _repository.Setup(r => r.GetWithIncludes(1)).ReturnsAsync(testAdvert);

            //_mapper.Setup(x => x.Map<AdvertDto>(testAdvert)).Returns(new AdvertDto
            //{
            //    Name = "Объявление",
            //    Price = 1000,
            //    StatusId = 1,
            //    TypeId = 1,
            //    CityId = 1
            //});

            var advert = _service.GetWithIncludes(1);

            NUnit.Framework.Assert.AreEqual(testAdvert, advert);
        }
    }
}
