using AutoMapper;
using HomeMgmt.Contexts;
using HomeMgmt.DTOs.GeneralDTOs;
using HomeMgmt.DTOs.UserDTOs.UserAccountDTOs;
using HomeMgmt.Models.UserModels;
using HomeMgmt.Services.AuthServices;
using HomeMgmt.Services.UserAccountService;
using HomeMgmt.Services.UserRoleServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HomeMgmtTest.ServiceTests
{
    public class UserAccountServiceTests
    {
        [Fact]
        public void ReadUserAccountById_WhenUserAccountIdExists_ShouldReturnUserAccount()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite(connection)
                .Options;

            // MOCK DATA FOR TESTING
            using (var context = new DataContext(options))
            {
                context.Database.EnsureCreated();
                
                byte[] passwordSalt;
                byte[] passwordHash;


                using (var hmac = new HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("12345678"));
                }

                context.UserAccounts.AddRange(
                    new UserAccount()
                    {
                        Id = "d80f0b50-f48c-48e1-b495-21d8c4e168d8",
                        FirstName = "John",
                        MiddleName = "B",
                        LastName = "Doe",
                        Username = "bytr",
                        PasswordSalt = passwordSalt,
                        PasswordHash = passwordHash
                    },
                    new UserAccount()
                    {
                        Id = "d80f0b50-f48c-48e1-b495-21d8c4e168d9",
                        FirstName = "Jane",
                        MiddleName = "B",
                        LastName = "Doe",
                        Username = "wlfy",
                        PasswordSalt = passwordSalt,
                        PasswordHash = passwordHash
                    });

                context.SaveChanges();
            }

            using (var context = new DataContext(options))
            {
                context.Database.EnsureCreated();

                var serviceProvider = new ServiceCollection()
                    .AddScoped<DataContext>(_ => context)
                    .AddScoped<IMapper>(_ => Mock.Of<IMapper>())
                    .AddScoped<IAuthService>(_ => Mock.Of<IAuthService>())
                    .BuildServiceProvider();
                
                var userAccountService = ActivatorUtilities.CreateInstance<UserAccountService>(serviceProvider);


                var userAccount1 = userAccountService.ReadUserAccountById(id: "d80f0b50-f48c-48e1-b495-21d8c4e168d8");

                Assert.NotNull(userAccount1.Result);
                Assert.Equal("John", userAccount1.Result.FirstName);
                Assert.Equal("B", userAccount1.Result.MiddleName);
                Assert.Equal("Doe", userAccount1.Result.LastName);
                Assert.Equal("bytr", userAccount1.Result.Username);

                var userAccount2 = userAccountService.ReadUserAccountById(id: "d80f0b50-f48c-48e1-b495-21d8c4e168d9");

                Assert.NotNull(userAccount2.Result);
                Assert.Equal("Jane", userAccount2.Result.FirstName);
                Assert.Equal("B", userAccount2.Result.MiddleName);
                Assert.Equal("Doe", userAccount2.Result.LastName);
                Assert.Equal("wlfy", userAccount2.Result.Username);

            }
        }

        [Fact]
        public void ReadUserAccountById_WhenUserAccountIdDoesNotExist_ShouldReturnError()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();

            var options = new DbContextOptionsBuilder<DataContext>()
                .UseSqlite(connection)
                .Options;

            // MOCK DATA FOR TESTING
            using (var context = new DataContext(options))
            {
                context.Database.EnsureCreated();

                byte[] passwordSalt;
                byte[] passwordHash;


                using (var hmac = new HMACSHA512())
                {
                    passwordSalt = hmac.Key;
                    passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("12345678"));
                }

                context.UserAccounts.AddRange(
                    new UserAccount()
                    {
                        Id = "d80f0b50-f48c-48e1-b495-21d8c4e168d8",
                        FirstName = "John",
                        MiddleName = "B",
                        LastName = "Doe",
                        Username = "bytr",
                        PasswordSalt = passwordSalt,
                        PasswordHash = passwordHash
                    });

                context.SaveChanges();
            }

            using (var context = new DataContext(options))
            {
                context.Database.EnsureCreated();

                var serviceProvider = new ServiceCollection()
                    .AddScoped<DataContext>(_ => context)
                    .AddScoped<IMapper>(_ => Mock.Of<IMapper>())
                    .AddScoped<IAuthService>(_ => Mock.Of<IAuthService>())
                    .BuildServiceProvider();

                var userAccountService = ActivatorUtilities.CreateInstance<UserAccountService>(serviceProvider);

                var exception = Assert.ThrowsAsync<KeyNotFoundException>(() => userAccountService.ReadUserAccountById(id: "d80f0b50-f48c-48e1-b495-21d8c4e168d9"));

                Assert.Equal("User Account Not Found.", exception.Result.Message);
            }
        }

        //[Fact]
        //public void ReadUserAccounts_ShouldReturnUserAccounts()
        //{
        //    var connection = new SqliteConnection("DataSource=:memory:");
        //    connection.Open();

        //    var options = new DbContextOptionsBuilder<DataContext>()
        //        .UseSqlite(connection)
        //        .Options;

        //    // MOCK DATA FOR TESTING
        //    using (var context = new DataContext(options))
        //    {
        //        context.Database.EnsureCreated();

        //        byte[] passwordSalt;
        //        byte[] passwordHash;


        //        using (var hmac = new HMACSHA512())
        //        {
        //            passwordSalt = hmac.Key;
        //            passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("12345678"));
        //        }

        //        context.UserAccounts.AddRange(
        //            new UserAccount()
        //            {
        //                Id = "d80f0b50-f48c-48e1-b495-21d8c4e168d8",
        //                FirstName = "John",
        //                MiddleName = "B",
        //                LastName = "Doe",
        //                Username = "bytr",
        //                PasswordSalt = passwordSalt,
        //                PasswordHash = passwordHash
        //            },
        //            new UserAccount()
        //            {
        //                Id = "d80f0b50-f48c-48e1-b495-21d8c4e168d9",
        //                FirstName = "Jane",
        //                MiddleName = "B",
        //                LastName = "Doe",
        //                Username = "wlfy",
        //                PasswordSalt = passwordSalt,
        //                PasswordHash = passwordHash
        //            });

        //        context.SaveChanges();
        //    }

        //    using (var context = new DataContext(options))
        //    {
        //        context.Database.EnsureCreated();

        //        var serviceProvider = new ServiceCollection()
        //            .AddScoped<DataContext>(_ => context)
        //            .AddScoped<IMapper>(_ => Mock.Of<IMapper>())
        //            .AddScoped<IAuthService>(_ => Mock.Of<IAuthService>())
        //            .BuildServiceProvider();

        //        var userAccountService = ActivatorUtilities.CreateInstance<UserAccountService>(serviceProvider);

        //        var userAccounts = userAccountService.ReadUserAccounts(queryDTO: new QueryDTO() { PageNumber = 1} , filterDTO: new FilterUserAccountDTO());

        //        Assert.Equal(1, userAccounts.Result.Pages);
        //        Assert.Equal(2, userAccounts.Result.TotalData);
        //    }
        //}
    }
}
