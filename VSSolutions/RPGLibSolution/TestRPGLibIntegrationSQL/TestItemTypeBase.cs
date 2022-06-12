using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGLibBusinessCore.Context.Infra.SQLImpl;
using RPGLibEntityCore.Entities;
using System;
using System.Threading.Tasks;

[assembly: log4net.Config.XmlConfigurator(Watch = true)]

namespace TestRPGLibIntegrationSQL
{
    [TestClass]
    public class TestItemTypeBase
    {
        private readonly SQLConfiguration _configuration = new SQLConfiguration();
        private ILog log = LogManager.GetLogger(typeof(TestItemTypeBase));
   

        [TestMethod]
        public async Task Ajoute_et_Supprime_un_ItemType()
        {         
            ItemTypeBaseImplementation impl = new ItemTypeBaseImplementation(_configuration, log);

            ItemTypeBase itemTypeToTest = new ItemTypeBase() { Id = Guid.NewGuid(), Name="ItemTypeToAdd"};

            var expectedAdded = await impl.AddAsync(itemTypeToTest);

            Assert.IsNotNull(expectedAdded);
            Assert.IsTrue(expectedAdded.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            var expectedRemoved = impl.DeleteAsync(itemTypeToTest);
            Assert.IsNotNull(expectedRemoved);
            Assert.IsTrue(expectedRemoved.Result.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

        }

        [TestMethod]
        public async Task Enregistre_liste_et_supprime_des_ItemType()
        {
            ItemTypeBaseImplementation impl = new ItemTypeBaseImplementation(_configuration, log);

            ItemTypeBase itemTypeOne = new ItemTypeBase() { Id = Guid.NewGuid(), Name = "ItemTypeToAdd 1" };
            ItemTypeBase itemTypeTwo = new ItemTypeBase() { Id = Guid.NewGuid(), Name = "ItemTypeToAdd 2" };
            ItemTypeBase itemTypeThree = new ItemTypeBase() { Id = Guid.NewGuid(), Name = "ItemTypeToAdd 3" };

            //Add
            var expectedAddedOne = await impl.AddAsync(itemTypeOne);
            Assert.IsTrue(expectedAddedOne.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            var expectedAddedTwo = await impl.AddAsync(itemTypeTwo);
            Assert.IsTrue(expectedAddedTwo.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            var expectedAddedThree = await impl.AddAsync(itemTypeThree);
            Assert.IsTrue(expectedAddedThree.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            //List
            var expectedList = impl.GetAllAsync();
            Assert.IsNotNull(expectedList);
            Assert.IsTrue(expectedList.Result.Count == 3);

            //Remove
            var expectedRemovedOne = await impl.DeleteAsync(itemTypeOne);
            Assert.IsTrue(expectedRemovedOne.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            var expectedRemovedTwo = await impl.DeleteAsync(itemTypeTwo);
            Assert.IsTrue(expectedRemovedTwo.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            var expectedRemovedThree = await impl.DeleteAsync(itemTypeThree);
            Assert.IsTrue(expectedRemovedThree.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
        }

        [TestMethod]
        public async Task Enregistre_retourne_et_supprime_un_ItemTypBase()
        {
            ItemTypeBaseImplementation impl = new ItemTypeBaseImplementation(_configuration, log);

            ItemTypeBase itemTypeOne = new ItemTypeBase() { Id = Guid.NewGuid(), Name = "ItemTypeToAdd 1" };

            //Add
            var expectedAddedOne = await impl.AddAsync(itemTypeOne);
            Assert.IsTrue(expectedAddedOne.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            //Get
            var expectedRead = await impl.GetByIdAsync(itemTypeOne.Id);
            Assert.IsTrue(expectedRead.Id == itemTypeOne.Id);

            //Remove
            var expectedRemovedOne = await impl.DeleteAsync(itemTypeOne);
            Assert.IsTrue(expectedRemovedOne.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
        }

        [TestMethod]
        public async Task Ajoute_un_ItemType_et_modifie_ses_proprietes()
        {
            ItemTypeBaseImplementation impl = new ItemTypeBaseImplementation(_configuration, log);

            ItemTypeBase itemTypeOne = new ItemTypeBase() { Id = Guid.NewGuid(), Name = "ItemTypeToAdd 1" };

            //Add
            var expectedAddedOne = await impl.AddAsync(itemTypeOne);
            Assert.IsTrue(expectedAddedOne.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
                      

            //Update
            itemTypeOne.Name = "UpdatedName";           
            var expectedUpdate = await impl.UpdateAsync(itemTypeOne);
            Assert.IsNotNull(expectedUpdate);
            Assert.IsTrue(expectedUpdate.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            //read and compare            
            var expectedRead = await impl.GetByIdAsync(itemTypeOne.Id);
            Assert.IsTrue(String.Compare(expectedRead.Name, itemTypeOne.Name,true)==0);

            //Remove
            var expectedRemovedOne = await impl.DeleteAsync(itemTypeOne);
            Assert.IsTrue(expectedRemovedOne.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
        }

    }
}
