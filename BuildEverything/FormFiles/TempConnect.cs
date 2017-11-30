using BuildEverything.Common.EnumFolder;
using BuildEverything.Common.Extension;
using BuildEverything.Common.Helper;
using BuildEverything.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BuildEverything.FormFiles
{
    public partial class TempConnect : Form
    {
        string DBLink = string.Empty;
        public TempConnect(string dbLinkXmlPath)
        {
            InitializeComponent();
            DBLink = dbLinkXmlPath;
            this.cbx_DBType.SelectedIndex = 1;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            DBInfo info = new DBInfo()
            {
                Uid = txt_Uid.Text.Trim(),
                DBName = txt_DBName.Text.Trim(),
                Server = txt_Server.Text.Trim(),
                Port = txt_Port.Text.Trim(),
                Pwd = txt_PWD.Text.Trim(),
                Type = (DBEnum)cbx_DBType.SelectedIndex + 1
            };
            var connect = GetDBLink.GetTableList(info);
            if (string.IsNullOrEmpty(connect) == false)
            {
                MessageBox.Show($"非有效数据库连接，明细：{connect}");
                return;
            }
            var result = XMLNodeHelper.NodeAdd(DBLink, info);
            if (string.IsNullOrEmpty(result) == false)
            {
                MessageBox.Show($"添加出现错误，明细：{result}");
            }
            else
            {
                this.Close();
            }
        }
    }
}
