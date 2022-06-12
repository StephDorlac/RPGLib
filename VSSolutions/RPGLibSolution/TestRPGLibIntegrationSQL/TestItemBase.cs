using log4net;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RPGLibBusinessCore.Context.Infra.SQLImpl;
using RPGLibEntityCore.Entities;
using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TestRPGLibIntegrationSQL
{
    [TestClass]
    public class TestItemBase
    {
        private static readonly SQLConfiguration _configuration = new SQLConfiguration();
        private ILog log = LogManager.GetLogger(typeof(TestItemTypeBase));

        internal static ItemTypeBase itemTypeTest;

        [ClassInitialize()]
        public static void ClassInit(TestContext context)
        {
            itemTypeTest = new ItemTypeBase();
            itemTypeTest.Name = "ItemTypeToRemove";
            itemTypeTest.Id = Guid.NewGuid();
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                SqlCommand command = new SqlCommand("INSERT INTO ITEM_TYPE(Id,Name) VALUES (@Id,@Name)", conn);
                command.Parameters.Add("@Id", System.Data.SqlDbType.UniqueIdentifier).Value = itemTypeTest.Id;
                command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar, 50).Value = itemTypeTest.Name;
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        [TestMethod]
        public async Task Ajoute_et_Supprime_un_ItemBase_avec_son_ITtempTypeBase()
        {

            ItemBaseImplementation impl = new ItemBaseImplementation(_configuration, log);

            //Add Item
            ItemBase itemToTest = new ItemBase() { Id = Guid.NewGuid(), Name = "ItemBaseToAdd", Weigth = 1.0f, ItemTypeId = itemTypeTest.Id };
            var expectedAdded = await impl.AddAsync(itemToTest);

            Assert.IsNotNull(expectedAdded);
            Assert.IsTrue(expectedAdded.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            //Remove ItemBase
            var expectedRemoved = await impl.DeleteAsync(itemToTest);
            Assert.IsNotNull(expectedRemoved);
            Assert.IsTrue(expectedRemoved.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

        }

        [TestMethod]
        public async Task Ajoute_un_ItemBase_avec_un_ItemTypeBase_inconnu()
        {
            ItemBaseImplementation impl = new ItemBaseImplementation(_configuration, log);

            ItemBase itemToTest = new ItemBase() { Id = Guid.NewGuid(), Name = "ItemBaseToAdd", Weigth = 1.0f, ItemTypeId = Guid.NewGuid() };
            var expectedAdded = await impl.AddAsync(itemToTest);

            Assert.IsNotNull(expectedAdded);
            Assert.IsTrue(expectedAdded.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Failure);
        }

        [TestMethod]
        public async Task Ajoute_un_ItemBase_avec_un_poids_trop_eleve()
        {
            ItemBaseImplementation impl = new ItemBaseImplementation(_configuration, log);

            //Add Item
            ItemBase itemToTest = new ItemBase() { Id = Guid.NewGuid(), Name = "ItemBaseToAdd", Weigth = float.MaxValue + 1, ItemTypeId = Guid.NewGuid() };
            var expectedAdded = await impl.AddAsync(itemToTest);

            Assert.IsNotNull(expectedAdded);
            Assert.IsTrue(expectedAdded.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Failure);

        }

        [TestMethod]
        public async Task Ajoute_un_ItemBase_et_retour_son_entite()
        {
            ItemBaseImplementation impl = new ItemBaseImplementation(_configuration, log);

            //Add Item
            ItemBase itemToTest = new ItemBase() { Id = Guid.NewGuid(), Name = "ItemBaseToAdd", Weigth = 1.0f, ItemTypeId = itemTypeTest.Id };
            var expectedAdded = await impl.AddAsync(itemToTest);

            Assert.IsNotNull(expectedAdded);
            Assert.IsTrue(expectedAdded.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            //Read Item
            var expectedRead = await impl.GetByIdAsync(itemToTest.Id);
            Assert.IsNotNull(expectedRead);
            Assert.IsTrue(expectedRead.Id == itemToTest.Id);
        }

        [TestMethod]
        public async Task Ajoute_des_ItemBase_et_retour_une_liste()
        {
            ItemBaseImplementation impl = new ItemBaseImplementation(_configuration, log);

            //Add Item
            ItemBase itemToTest1 = new ItemBase() { Id = Guid.NewGuid(), Name = "ItemBaseToAdd1", Weigth = 1.0f, ItemTypeId = itemTypeTest.Id };
            var expectedAdded1 = await impl.AddAsync(itemToTest1);
            ItemBase itemToTest2 = new ItemBase() { Id = Guid.NewGuid(), Name = "ItemBaseToAdd2", Weigth = 1.0f, ItemTypeId = itemTypeTest.Id };
            var expectedAdded2 = await impl.AddAsync(itemToTest2);
            ItemBase itemToTest3 = new ItemBase() { Id = Guid.NewGuid(), Name = "ItemBaseToAdd3", Weigth = 1.0f, ItemTypeId = itemTypeTest.Id };
            var expectedAdded3 = await impl.AddAsync(itemToTest3);

            Assert.IsNotNull(expectedAdded1);
            Assert.IsNotNull(expectedAdded2);
            Assert.IsNotNull(expectedAdded3);
            Assert.IsTrue(expectedAdded1.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            Assert.IsTrue(expectedAdded2.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
            Assert.IsTrue(expectedAdded3.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);
                        

            //List
            var expectedList = await impl.GetAllAsync();
            Assert.IsNotNull(expectedList);
            Assert.IsTrue(expectedList.Count>0);

        }

        [TestMethod]
        public async Task Ajoute_un_ItemBase_et_modifie_ses_proprietes()
        {
            ItemBaseImplementation impl = new ItemBaseImplementation(_configuration, log);

            //Add Item
            ItemBase itemToTest = new ItemBase() { Id = Guid.NewGuid(), Name = "ItemBaseToAdd", Weigth = 1.0f, ItemTypeId = itemTypeTest.Id };
            var expectedAdded = await impl.AddAsync(itemToTest);

            Assert.IsNotNull(expectedAdded);
            Assert.IsTrue(expectedAdded.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            //Update
            itemToTest.Name = "UpdatedName";
            itemToTest.Weigth = 2.0f;
            var expectedUpdate = await impl.UpdateAsync(itemToTest);
            Assert.IsNotNull(expectedUpdate);
            Assert.IsTrue(expectedUpdate.ResultStatus == RPGLibBusinessCore.Common.CommonResult.ResultStatusAction.Success);

            //read and compare
            var expectedRead = await impl.GetByIdAsync(itemToTest.Id);
            Assert.IsNotNull(expectedRead);
            Assert.IsTrue(String.Compare(expectedRead.Name, itemToTest.Name, true) == 0);
            Assert.IsTrue(expectedRead.Weigth == itemToTest.Weigth);
        }

        [ClassCleanupAttribute()]
        public static void Cleanup()
        {
            using (SqlConnection conn = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
            {
                SqlCommand command = new SqlCommand("delete from ITEM_BASE;delete from ITEM_TYPE", conn);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }


    }
}
