using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TSApi.Controllers;
using DataModel;
using TSApi;
using TSTest.Mock;
using DataAdapter;
using Unity;
using System.Collections.Generic;

namespace TSTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateIssue()
        {
            // Mock local storage
            var mockLocalStorage = new MockLocalStorage();
            mockLocalStorage.CreateNewIssueImpl = ((x) =>
            {
                return MockLocalStorage.mockIssue1.Id;
            });

            var uc = TestHelper.GetTestcontainer();
            uc.RegisterInstance<IStorage>(mockLocalStorage); 

            var tsc = new TSController();
            var retval = tsc.CreateIssue(MockLocalStorage.mockNewIssue1);
            Assert.IsTrue(retval == MockLocalStorage.mockIssue1.Id);
        }

        [TestMethod]
        public void GetIssue()
        {
            // Mock local storage
            var mockLocalStorage = new MockLocalStorage();
            mockLocalStorage.GetIssuesImpl = (() =>
            {
                return new List<Issue>() {
                        MockLocalStorage.mockIssue1,
                        MockLocalStorage.mockIssue2,
                        MockLocalStorage.mockIssue3
                    };
            });

            var uc = TestHelper.GetTestcontainer();
            uc.RegisterInstance<IStorage>(mockLocalStorage);

            var tsc = new TSController();
            var retval = tsc.GetIssues();
            Assert.IsTrue(retval.Count == 3);
            Assert.IsTrue(retval[0].Id == MockLocalStorage.mockIssue1.Id);
            Assert.IsTrue(retval[1].Id == MockLocalStorage.mockIssue2.Id);
            Assert.IsTrue(retval[2].Id == MockLocalStorage.mockIssue3.Id);
        }

        [TestMethod]
        public void SearchIssueById()
        {
            // Mock local storage
            var mockLocalStorage = new MockLocalStorage();
            mockLocalStorage.SearchIssueByIdImpl = ((x) =>
            {
                return MockLocalStorage.mockIssue1;
            });

            var uc = TestHelper.GetTestcontainer();
            uc.RegisterInstance<IStorage>(mockLocalStorage);

            var tsc = new TSController();
            var retval = tsc.SearchIssueById(MockLocalStorage.mockIssue1.Id);
            Assert.IsTrue(retval.Id == MockLocalStorage.mockIssue1.Id);
        }
    }
}
