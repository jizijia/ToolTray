using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TBS.Core.Common;
using ToolTray.Model;

namespace ToolTray.Service
{
    public class MenuItemService
    {
        private string _filepath = "";

        public MenuItemService()
        {
            _filepath = $"{System.AppDomain.CurrentDomain.BaseDirectory}\\menes.config";
        }

        public List<MenuItemModel> GetMenuItems(List<MenuItemModel> list)
        {
            return (List<MenuItemModel>)SerializationHelper.Load<List<MenuItemModel>>(_filepath);
        }

        public void SaveMenuItems(List<MenuItemModel> list)
        {
            SerializationHelper.Save(list, _filepath);
        }

    }
}
