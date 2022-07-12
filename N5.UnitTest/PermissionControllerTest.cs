using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using N5.Api.Controllers;
using N5.Api.Model.Response;
using N5.Core.DTOs;
using N5.Core.Entities;
using N5.Core.Interfaces;
using N5.Core.Services;
using N5.Infrastructure.Data;
using N5.Infrastructure.Mappings;
using N5.Infrastructure.Repositories;
using N5.UnitTest.Mock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using Xunit.Extensions.Ordering;

namespace N5.UnitTest
{
    public class PermissionControllerTest
    {
        private readonly TestN5_DBContext n5_DBContext;
        private readonly UnitOfWork unitOfWork;
        private readonly PermissionService permissionService;
        private readonly AutoMapperProfile autoMapperProfile;
        private readonly IMapper mapper;
        public PermissionControllerTest()
        {
            n5_DBContext = new TestN5_DBContext();
            unitOfWork = new UnitOfWork(n5_DBContext);
            permissionService = new PermissionService(unitOfWork);
            autoMapperProfile = new AutoMapperProfile();
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(autoMapperProfile);
            });
            mapper = mockMapper.CreateMapper();
        }

        private List<PermissionEntity> GetTestPermission()
        {
            List<PermissionEntity> sessions = new();
            sessions.Add(new()
            {
                Date = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Sergio",
                LastName = "Ribera",
                IdTypePermission = 2
            });

            sessions.Add(new()
            {
                Date = new DateTime(2015, 7, 2),
                Id = 2,
                Name = "Alejandro",
                LastName = "Costa",
                IdTypePermission = 1
            });

            sessions.Add(new()
            {
                Date = new DateTime(2015, 6, 2),
                Id = 2,
                Name = "Vladimir",
                LastName = "Chacolla",
                IdTypePermission = 3
            });
            return sessions;
        }
        private async Task<PermissionEntity> GetAsyncTestPermission()
        {
            List<PermissionEntity> sessions = new();
            sessions.Add(new()
            {
                Date = new DateTime(2016, 7, 2),
                Id = 1,
                Name = "Sergio",
                LastName = "Ribera",
                IdTypePermission = 2
            });
            sessions.Add(new()
            {
                Date = new DateTime(2015, 7, 2),
                Id = 2,
                Name = "Alejandro",
                LastName = "Costa",
                IdTypePermission = 1
            });

            sessions.Add(new()
            {
                Date = new DateTime(2015, 6, 2),
                Id = 2,
                Name = "Vladimir",
                LastName = "Chacolla",
                IdTypePermission = 3
            });
            return sessions[0];
        }

        [Fact, Order(1)]
        public void Get()
        {
            var mockRepo = new Mock<IPermissionService>();
            mockRepo.Setup(repo => repo.Get())
                .Returns(GetTestPermission());
            //Arrange
            var controller = new PermissionController(mockRepo.Object, mapper);
            //Act
            var response = controller.Get();
            //Asserts
            Assert.NotNull(response);
            var objectResult = Assert.IsType<OkObjectResult>(response);
            var model = Assert.IsAssignableFrom<Response<IEnumerable<PermissionDto>>>(objectResult.Value);
            var modelCount = model.Data.Count();
            Assert.Equal(3, modelCount);
        }
        [Fact, Order(1)]
        public async Task GetById()
        {
            var mockRepo = new Mock<IPermissionService>();
            mockRepo.Setup(repo => repo.Get(1))
                .Returns(GetAsyncTestPermission());
            //Arrange
            var controller = new PermissionController(mockRepo.Object, mapper);
            //Act
            var response = await controller.Get(1);
            //Assertsa
            Assert.NotNull(response);
            var objectResult = Assert.IsType<OkObjectResult>(response);
            var model = Assert.IsAssignableFrom<Response<PermissionDto>>(objectResult.Value);
            Assert.Equal(1, model.Data.Id);
        }
        [Fact, Order(2)]
        public async Task Insert()
        {
            var mockRepo = new Mock<IPermissionService>();
            mockRepo.Setup(repo => repo.Get())
                .Returns(GetTestPermission());
            //Arrange
            var controller = new PermissionController(mockRepo.Object, mapper);
            var permission = new PermissionDto()
            {
                Name = "Sergio",
                LastName = "Ribera",
                IdTypePermission = 2
            };
            //Act
            var response = await controller.Post(permission);
            //Assert
            Assert.IsType<OkObjectResult>(response);
        }
        [Fact, Order(3)]
        public async Task Update()
        {
            //Arrange
            var permissionDto = new PermissionDto()
            {
                Name = "Vladimir",
                LastName = "Chacolla",
                IdTypePermission = 2
            };
            var controller = new PermissionController(permissionService, mapper);
            await controller.Post(permissionDto);
            //Act
            permissionDto.Id = 5;
            var response = await controller.Put(permissionDto);
            //Assert
            Assert.NotNull(response);
            Assert.IsType<BadRequestObjectResult>(response);
            permissionDto.Id = 1;
            response = await controller.Put(permissionDto);
            Assert.NotNull(response);
            var objectResult = Assert.IsType<OkObjectResult>(response);
            var model = Assert.IsAssignableFrom<Response<bool>>(objectResult.Value);
            Assert.True(model.Data);
        }
        [Fact, Order(4)]
        public async Task Delete()
        {
            var permission = new PermissionEntity ()
            {
                Name = "Alejandro",
                LastName = "Costa",
                IdTypePermission = 1
            };
            var mockRepo = new Mock<IPermissionService>();
            await mockRepo.Object.InsertPermissions(permission);
            //Arrange
            var controller = new PermissionController(mockRepo.Object, mapper);
            //Act
            var response = await controller.Delete(1);
            //Assert
            Assert.NotNull(response);
            Assert.DoesNotContain(permission, mockRepo.Object.Get());
        }
    }
}
