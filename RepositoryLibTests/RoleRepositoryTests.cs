using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace RepositoryLib.Testsr
{
    [TestClass()]
    public class RoleRepositoryTests
    {
        IRoleRepository rolerepo = new RoleRepository();
        [TestMethod()]
        public void CreateRoleTest()
        {
            Assert.AreEqual(true, rolerepo.CreateRole("manager"));
        }

        [TestMethod()]
        public void DeleteRoleTest()
        {
            Assert.AreEqual(true, rolerepo.DeleteRole("1"));
        }

        [TestMethod()]
        public void IsUserInRoleTest()
        {
            Assert.AreEqual(true, rolerepo.IsUserInRole("u", "manager"));
        }
    }
}