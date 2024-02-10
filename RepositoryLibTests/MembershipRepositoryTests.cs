using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLib.Tests
{
    [TestClass()]
    public class MembershipRepositoryTests
    {
        IMembershipRepository memrepo = new MembershipRepository();
        [TestMethod()]
        public void ChangePasswordTest()
        {
            Assert.AreEqual(true, memrepo.ChangePassword("user1@example.com", "u1", "u1newpassword"));
        }

        [TestMethod()]
        public void CreateUserTest()
        {
            Assert.AreEqual(true, memrepo.CreateUser("user1", "u1", "9876543210", "user1@example.com", 2));
        }
    }
}

