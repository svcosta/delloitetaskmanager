using Delloite.TaskManager.Data.Contracts.Respositories;
using Delloite.TaskManager.Data.Repositories;
using Delloite.TaskManager.Services;
using Delloite.TaskManager.Services.Contracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Test.Services
{
    [TestClass]
    public sealed class UsuarioServiceTest
    {
        IUserService _userService;     

        [TestInitialize]
        public void SetUp()
        {
            //Create Task repository
            IUserRepository repUser = new UserRepository();

            //SOLID  = Indepence Injection
            this._userService = new UserService(repUser);            
        }

        [TestMethod]
        public void TestingUserServiceGetAccessToken()
        {
            try
            {
                // scenario 1: get user
                var token = this._userService.GetUser("test2", "pwd123");  

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);

            }
        }     
    }
}
