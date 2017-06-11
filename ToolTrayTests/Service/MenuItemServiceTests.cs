using Microsoft.VisualStudio.TestTools.UnitTesting;
using ToolTray.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolTray.Model;

namespace ToolTray.Service.Tests
{
    [TestClass()]
    public class MenuItemServiceTests
    {
        [TestMethod()]
        public void GetMenuItemsTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void SaveMenuItemsTest()
        {
            List<MenuItemModel> list = new List<MenuItemModel>();
            list.Add(new MenuItemModel("Guid 生成器"));
            Assert.Fail();
        }
    }
}