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

        [TestMethod]
        public void Enregistre_liste_et_supprime_des_ItemType()
        {
            ItemTypeBaseImplementation impl = new ItemTypeBaseImplementation(_configuration);

            ItemTypeBase itemTypeOne = new ItemTypeBase() { Id = Guid.NewGuid(), Name = "ItemTypeToAdd 1" };
            ItemTypeBase itemTypeTwo = new ItemTypeBase() { Id = Guid.NewGuid(), Name = "ItemTypeToAdd 2" };
            ItemTypeBase itemTypeThree = new ItemTypeBase() { Id = Guid.NewGuid(), Name = "ItemTypeToAdd 3" };

            //Add
            var expectedAddedOne = impl.AddAsync(itemTypeOne);
            Assert.IsTrue(expectedAddedOne.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            var expectedAddedTwo = impl.AddAsync(itemTypeTwo);
            Assert.IsTrue(expectedAddedTwo.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            var expectedAddedThree = impl.AddAsync(itemTypeThree);
            Assert.IsTrue(expectedAddedThree.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            //List
            var expectedList = impl.GetAllAsync();
            Assert.IsNotNull(expectedList);
            Assert.IsTrue(expectedList.Result.Count == 3);

            //Remove
            var expectedRemovedOne = impl.DeleteAsync(itemTypeOne);
            Assert.IsTrue(expectedRemovedOne.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            var expectedRemovedTwo = impl.DeleteAsync(itemTypeTwo);
            Assert.IsTrue(expectedRemovedTwo.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            var expectedRemovedThree = impl.DeleteAsync(itemTypeThree);
            Assert.IsTrue(expectedRemovedThree.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
        }

        [TestMethod]
        public void Enregistre_retourne_et_supprime_un_ItemTypBase()
        {
            ItemTypeBaseImplementation impl = new ItemTypeBaseImplementation(_configuration);

            ItemTypeBase itemTypeOne = new ItemTypeBase() { Id = Guid.NewGuid(), Name = "ItemTypeToAdd 1" };

            //Add
            var expectedAddedOne = impl.AddAsync(itemTypeOne);
            Assert.IsTrue(expectedAddedOne.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            //Get
            var expectedRead = impl.GetByIdAsync(itemTypeOne.Id);
            Assert.IsTrue(expectedRead.Result.Id == itemTypeOne.Id);

            //Remove
            var expectedRemovedOne = impl.DeleteAsync(itemTypeOne);
            Assert.IsTrue(expectedRemovedOne.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
        }

    }
}
