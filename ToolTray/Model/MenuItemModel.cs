using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolTray.Model
{
    public class MenuItemModel
    {
        public MenuItemModel(string text, string cmd)
        {
            Text = text;
            Command = cmd;
        }

        public MenuItemModel(string text)
        {
            Text = text;
        }

        /// <summary>
        /// 显示文本
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// CMD 命令
        /// </summary>
        public string Command { get; set; }

        /// <summary>
        /// 子菜单
        /// </summary>
        public List<MenuItemModel> Chidren { get; set; }
    }
}
