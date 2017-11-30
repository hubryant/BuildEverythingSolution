using BuildEverything.Common.EnumFolder;
using BuildEverything.Common.Extension;
using BuildEverything.Common.Helper;
using BuildEverything.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace BuildEverything.FormFiles
{
    public partial class BEMainForm : Form
    {
        string tag = "True";//Tag标签
        TreeNode CurrentNode = null;
        BuildEverythingContent BEContent = null;
        DBInfoModel DBInfo = null;
        TextBox txtSqls = new TextBox()
        {
            Location = new System.Drawing.Point(0, 0),
            Multiline = true,
            Name = "txtSqls",
            Size = new System.Drawing.Size(559, 411),
            TabIndex = 0
        };
        TabPage tPage_SQL = new TabPage()
        {
            Name = "tPage_SQL",
            TabIndex = 0,
            Text = "复合查询",
        };
        public BEMainForm(BuildEverythingContent beContent)
        {
            InitializeComponent();
            BEContent = beContent;
            InitFiles();
            DBInfo = new GetDBLink().GetBDList(BEContent.SelectedProject.ABEPath);
            BindData();
            OutPutMsg($"资源配置地址:{BEContent.SelectedProject.RootPath}");
            OutPutMsg("数据已加载完成...");
        }

        /// <summary>
        /// 初始化文件信息
        /// </summary>
        private void InitFiles()
        {
            if (Directory.Exists(Path.Combine(BEContent.SelectedProject.ABEPath, "Config")) == false)
            {
                DirectoryHelper.CopyDir(Path.Combine(BEContent.SelectedProject.RootPath, "Config"), Path.Combine(BEContent.SelectedProject.ABEPath, "Config"));
            }
            if (Directory.Exists(Path.Combine(BEContent.SelectedProject.ABEPath, "Templates")) == false)
            {
                DirectoryHelper.CopyDir(Path.Combine(BEContent.SelectedProject.RootPath, "Templates"), Path.Combine(BEContent.SelectedProject.ABEPath, "Templates"));
            }
        }

        /// <summary>
        /// 数据绑定
        /// </summary>
        /// <param name="model"></param>
        /// <param name="tview"></param>
        private void BindData(bool needNew = false)
        {
            this.Text = "实体生成工具";
            if (needNew)
            {
                DBInfo.DBInfoList = new GetDBLink().GetBDList(BEContent.SelectedProject.ABEPath).DBInfoList;
            }

            if (DBInfo == null || DBInfo.DBInfoList == null || DBInfo.DBInfoList.Count == 0)
            {
                return;
            }
            tv_DBList.Nodes.Clear();
            DBInfo.DBInfoList.OrderBy(o => o.DBName).Distinct();
            foreach (DBInfo info in DBInfo.DBInfoList)
            {
                TreeNode node = new TreeNode();
                if (info.Type == Common.EnumFolder.DBEnum.MySQL)
                {
                    node.ImageKey = "dbM.png";
                    node.SelectedImageKey = "dbM.png";
                }
                else
                {
                    node.ImageKey = "dbS.png";
                    node.SelectedImageKey = "dbS.png";
                }

                node.Name = info.DBName;
                node.Text = info.DBName;
                foreach (var table in info.TableStruList.Select(s => s.TableName).Distinct())
                {
                    TreeNode subNode = new TreeNode()
                    {
                        Name = table,
                        Text = table,
                        ImageKey = "tableo.png",
                        SelectedImageKey = "tableo.png",
                    };
                    node.Nodes.Add(subNode);
                }
                tv_DBList.Nodes.Add(node);
            }
            cbx_Folder.DataSource = BEContent.SelectedProject.FolderNames;
        }

        #region CheckBox操作
        private void tv_DBList_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                TreeNode node = e.Node;
                if (node.Tag == null)
                    node.Tag = tag;//附加结点信息
                else
                    node.Tag = null;

                CheckAllChildNodes(e.Node, e.Node.Checked);

                //选中父节点 
                bool bol = true;
                if (e.Node.Parent != null)
                {
                    for (int i = 0; i < e.Node.Parent.Nodes.Count; i++)
                    {
                        if (!e.Node.Parent.Nodes[i].Checked)
                            bol = false;
                    }
                    e.Node.Parent.Checked = bol;

                    //记得如果父节点被选中或取消，记得设置它的tag哦
                    if (bol)
                    {
                        e.Node.Parent.Tag = tag;
                    }
                    else
                    {
                        e.Node.Parent.Tag = null;
                    }
                }
            }
        }

        private void CheckAllChildNodes(TreeNode treeNode, bool nodeChecked)
        {
            foreach (TreeNode node in treeNode.Nodes)
            {
                node.Checked = nodeChecked;
                node.Tag = tag;////记得在这里为选中的项目设置tag属性
                if (node.Nodes.Count > 0)
                {
                    this.CheckAllChildNodes(node, nodeChecked);
                }
            }
        }

        #endregion


        /// <summary>
        /// 数据执行操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Build_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> csFileList = new List<string>();
                var template = string.Empty;
                List<TreeNode> tNodeList = new List<TreeNode>();
                if (tabControl1.SelectedTab != null && tabControl1.SelectedTab.Name == "tPage_SQL")
                {
                    var sql = txtSqls.Text.Trim();
                    var link = DBInfo.DBInfoList.Where(w => w.DBName == tv_DBList.SelectedNode.Name).FirstOrDefault();
                    if (link == null)
                    {
                        OutPutMsg($"鼠标焦点不在库节点上，请重置焦点");
                    }
                    DataColumnCollection colums = null;
                    if (link.Type == DBEnum.SqlServer)
                    {
                        colums = SqlHelper.ExecuteDataTable(link?.DBLink, sql).Columns;
                    }
                    else
                    {
                        colums = MySqlHelper.ExecuteDataTable(link?.DBLink, sql).Columns;
                    }
                    List<DBStructure> infos = new List<DBStructure>();
                    template = File.ReadAllText(Path.Combine(BEContent.SelectedProject.ABEPath, "Templates", "ComboEntity.txt"));
                    for (int i = 0; i < colums.Count; i++)
                    {
                        DBStructure stru = new DBStructure();
                        stru.ColName = colums[i].ColumnName;
                        stru.ColType = colums[i].DataType.MapCsharpType();
                        infos.Add(stru);
                    }
                    var csFile = GetCSFile(tv_DBList.SelectedNode.Name, "NameReplace", template, infos, sql);
                    csFileList.Add(csFile);
                }
                else
                {
                    template = File.ReadAllText(Path.Combine(BEContent.SelectedProject.ABEPath, "Templates", "Entity.txt"));
                    foreach (TreeNode tnode in this.tv_DBList.Nodes)
                    {
                        foreach (TreeNode node in tnode.Nodes)
                        {
                            if (node.Checked)
                            {
                                tNodeList.Add(node);
                                var csFile = GetCSFile(node.Parent.Name, node.Name, template);
                                csFileList.Add(csFile);
                            }
                        }
                    }
                }
                BEContent.SelectedProject.ProjectDte.AddFilesToProject(csFileList);
                tNodeList.ForEach(f => f.Checked = false);
                txtSqls.Clear();
                OutPutMsg($"数据执行操作成功，共生成{csFileList.Count}文件");
            }
            catch (Exception ex)
            {
                OutputWindowHelper.OutPutMessage($"数据执行操作出现异常 \r\n 信息：{ex.Message} \r\n 堆栈：{ex.StackTrace}");
                OutPutMsg($"数据执行操作出现异常 \r\n 信息：{ex.Message}");
            }
        }

        /// <summary>
        /// 获取CS文件
        /// </summary>
        /// <param name="parentName"></param>
        /// <param name="subName"></param>
        /// <param name="template"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private string GetCSFile(string parentName, string subName, string template, List<DBStructure> dbStru = null, string sql = "", string entity = "Entity")
        {
            var csFile = string.Empty;
            try
            {
                List<DBStructure> strinfo = dbStru;
                if (dbStru == null || dbStru.Count == 0)
                {
                    List<DBStructure> infos = DBInfo.DBInfoList.Where(w => w.DBName == parentName).Select(s => s.TableStruList).FirstOrDefault();
                    strinfo = infos == null ? null : infos.Where(w => w.TableName == subName).ToList();
                    if (strinfo == null && strinfo.Count() > 0)
                    {
                        return csFile;
                    }
                    strinfo.ForEach(f => f.ColDesc = Regex.Replace(f.ColDesc, @"[\r\n]+", ";"));
                }
                Dictionary<string, object> dicInfo = new Dictionary<string, object>();
                dicInfo.Add("Entity", strinfo);
                dicInfo.Add("NameSpace", BEContent.SelectedProject.ProjectName + (cbx_Folder.Text == "根文件" ? "" : $".{cbx_Folder.Text}"));
                dicInfo.Add("DBName", parentName);
                dicInfo.Add("TableName", subName);
                if (string.IsNullOrEmpty(sql) == false)
                {
                    dicInfo.Add("SQL", sql);
                }
                var result = NVelocityHelper.ProcessTemplate(BEContent.SelectedProject.ProjectDirectoryName, template, dicInfo);
                csFile = FilesHelper.Write(Path.Combine(BEContent.SelectedProject.ProjectDirectoryName, cbx_Folder.Text == "根文件" ? "" : cbx_Folder.Text), subName + "Entity", result);
            }
            catch (Exception ex)
            {
                OutputWindowHelper.OutPutMessage($"获取CS文件出现异常 \r\n 信息：{ex.Message} \r\n 堆栈：{ex.StackTrace}");
                OutPutMsg($"获取CS文件出现异常 \r\n 信息：{ex.Message}");
            }
            return csFile;
        }

        /// <summary>
        /// 页面输出信息
        /// </summary>
        /// <param name="message"></param>
        /// <param name="isClear"></param>
        private void OutPutMsg(string message, bool isClear = false)
        {
            if (string.IsNullOrEmpty(txt_Msg.Text) == false)
            {
                txt_Msg.Text += "\r\n";
            }
            txt_Msg.Text += message;
        }

        private void 复合查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tPage_SQL.Controls.Contains(this.txtSqls) == false)
            {
                tPage_SQL.Controls.Add(this.txtSqls);
                tabControl1.Controls.Add(tPage_SQL);
            }
            tPage_SQL.Text = tv_DBList.SelectedNode.Name + "  ";
            tabControl1.SelectedIndex = tabControl1.Controls.IndexOf(tPage_SQL);
        }

        private void DelDB_Click(object sender, EventArgs e)
        {
            if (CurrentNode != null)
            {
                var result = XMLNodeHelper.NodeRemove(Path.Combine(BEContent.SelectedProject.ABEPath, "Config", "DBLinkInfo.xml"), CurrentNode.Name);

                if (string.IsNullOrEmpty(result))
                {
                    BindData(true);
                    MessageBox.Show("操作成功");
                }
                else
                {
                    MessageBox.Show(result);
                }

            }
        }

        private void 新增库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = new TempConnect(Path.Combine(BEContent.SelectedProject.ABEPath, "Config", "DBLinkInfo.xml")).ShowDialog();
            BindData(true);
        }

        private void 新增SQL实体ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage page = new TabPage();
            TextBox txt = new TextBox();
            txt.Multiline = true;
            txt.Dock = DockStyle.Fill;
            page.Controls.Add(txt);
            tabControl1.Controls.Add(page);
        }

        private void tv_DBList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node.Parent == null) //判断选中节点是否有父节点
                {
                    return;
                }
                bool hasControl = false;
                foreach (Control ctrol in tabControl1.Controls)
                {
                    if (ctrol.Name == e.Node.Name)
                    {
                        tabControl1.SelectedIndex = tabControl1.Controls.IndexOf(ctrol);
                        hasControl = true;
                    }
                }
                if (hasControl == false)
                {
                    TabPage tabpage = new TabPage(e.Node.Name + "  ");
                    tabpage.Name = e.Node.Name;
                    tabpage.AutoScroll = true;
                    var data = DBInfo.DBInfoList.Where(w => w.DBName == e.Node.Parent.Name).FirstOrDefault();
                    var list = data.TableStruList.Where(w => w.TableName == e.Node.Name).ToList();
                    DataGridView dgv = new DataGridView()
                    {
                        Dock = DockStyle.Fill,
                        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                        DataSource = list.Select(s => new CHNDesc
                        {
                            列名 = s.ColName,
                            类型 = s.ColType,
                            长度 = s.ColLen.ToString(),
                            自增 = s.ColIsinc,
                            主键 = s.ColIsPri,
                            允许空 = s.ColisNull,
                            默认值 = s.DefaultValue,
                            描述 = s.ColDesc
                        }).ToList()
                    };
                    tabpage.Controls.Add(dgv);
                    this.tabControl1.Controls.Add(tabpage);
                    tabControl1.SelectedTab = tabpage;
                }
            }
            catch (Exception ex)
            {
                OutputWindowHelper.OutPutMessage($"查看数据结构出现异常 \r\n 信息：{ex.Message} \r\n 堆栈：{ex.StackTrace}");
                OutPutMsg($"查看数据结构出现异常 \r\n 信息：{ex.Message}");
            }
        }

        private void tv_DBList_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                CurrentNode = tv_DBList.GetNodeAt(ClickPoint);
                if (CurrentNode != null)
                {
                    tv_DBList.SelectedNode = CurrentNode;//选中这个节点
                    if (CurrentNode.Level == 0)
                    {
                        contextMenuStrip1.Show(tv_DBList, ClickPoint);
                    }
                }
                else
                {
                    contextMenuStrip2.Show(tv_DBList, ClickPoint);
                }
            }
        }
    }
}
