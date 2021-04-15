using System;
using CRM.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestClient
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var db = new CRM_Model()) 
            {
                string titleTest = "test";
                string lastNameTest = "test";
                string firstNameTest = "test";
                string patronymicTest = "test";
                string phoneTest = "test";
                string addressCompanyTest = "test";
                string photoTest = "";
                string expected = "Запись добавлена!";
                string actual = db.AddClient(titleTest, lastNameTest, firstNameTest, patronymicTest, phoneTest, addressCompanyTest, photoTest);
                Assert.AreEqual(expected,actual);
            }
        }
    }
}
