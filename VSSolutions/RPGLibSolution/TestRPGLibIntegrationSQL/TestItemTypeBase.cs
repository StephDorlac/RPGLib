using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGLibBusinessCore.Context.Infra.SQLImpl;
using RPGLibEntityCore.Entities;
using System;

namespace TestRPGLibIntegrationSQL
{
    [TestClass]
    public class TestItemTypeBase
    {
        private readonly SQLConfiguration _configuration = new SQLConfiguration();

        [TestMethod]
        public void Ajoute_et_Supprime_un_ItemType()
        {
            ItemTypeBaseImplementation impl = new ItemTypeBaseImplementation(_configuration);

            ItemTypeBase itemTypeToTest = new ItemTypeBase() { Id = Guid.NewGuid(), Name="ItemTypeToAdd"};

            var expectedAdded = impl.AddAsync(itemTypeToTest);

            Assert.IsNotNull(expectedAdded);
            Assert.IsTrue(expectedAdded.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            var expectedRemoved = impl.DeleteAsync(itemTypeToTest);
            Assert.IsNotNull(expectedRemoved);
            Assert.IsTrue(expectedRemoved.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
        }
    }
}
