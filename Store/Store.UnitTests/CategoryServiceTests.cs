using AutoMapper;
using FluentAssertions;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.Extensions.Msal;
using Moq;
using Store.Entities;
using Store.Models;
using Store.Repositories;
using Store.Services.CategoryService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.UnitTests
{
    public class CategoryServiceTests
    {
        private readonly Mock<ICategoryRepository> mockRepository;
        private readonly Mock<IMapper> mockMapper;
        private CategoryService sut;

        public CategoryServiceTests()
        {
            mockRepository = new Mock<ICategoryRepository>();
            mockMapper = new Mock<IMapper>();
            sut = new CategoryService(mockRepository.Object , mockMapper.Object );
        }


        [Fact]

        public void Add_WhenDublicateCategoryName_ShouldRetrunNull()
        {
            //arange

            mockRepository.Setup(x => x.IsDuplicateCategoryName(It.IsAny<string>())).Returns(true);
            //act
            var result = sut.Add(CategoryModelData);

            //assert
            result.Should().BeNull();

        }
        [Fact]
        public void Add_WhenUniqueCategoryName_ShouldReturnCategoryModel()
        {
            var category = new Category { Categoryid = 1 };
            var addedCategory = new Category();
            var expected = new CategoryModel();

            mockRepository.Setup(x => x.IsDuplicateCategoryName(It.IsAny<string>())).Returns(false);
            mockMapper.Setup(m => m.Map<Category>(It.IsAny<CategoryModel>())).Returns(category);
            mockRepository.Setup(m => m.Add(It.IsAny<Category>())).Returns(addedCategory);
            mockMapper.Setup(m => m.Map<CategoryModel>(addedCategory)).Returns(expected);

            var result = sut.Add(CategoryModelData);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(expected);
        }





        private CategoryModel CategoryModelData => new CategoryModel
        {
            Categoryid = 1,
            CategoryName = "Test",
            Description = "Test nu stiu ma rog descriere",
        };
    }
}
