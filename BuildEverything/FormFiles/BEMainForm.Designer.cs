namespace BuildEverything.FormFiles
{
    partial class BEMainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BEMainForm));
            this.tv_DBList = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            //this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabControl1 = new MyTabControl();
            this.txt_Msg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbx_Folder = new System.Windows.Forms.ComboBox();
            this.btn_Build = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.复合查询ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelDB = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.新增库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增SQL实体ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.contextMenuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_DBList
            // 
            this.tv_DBList.CheckBoxes = true;
            this.tv_DBList.ImageIndex = 0;
            this.tv_DBList.ImageList = this.imageList1;
            this.tv_DBList.Location = new System.Drawing.Point(7, 3);
            this.tv_DBList.Name = "tv_DBList";
            this.tv_DBList.SelectedImageIndex = 0;
            this.tv_DBList.Size = new System.Drawing.Size(233, 433);
            this.tv_DBList.TabIndex = 7;
            this.tv_DBList.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tv_DBList_AfterCheck);
            this.tv_DBList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tv_DBList_AfterSelect);
            this.tv_DBList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.tv_DBList_MouseUp);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "AutoBuildCommandPackage.ico");
            this.imageList1.Images.SetKeyName(1, "dbM.png");
            this.imageList1.Images.SetKeyName(2, "dbS.png");
            this.imageList1.Images.SetKeyName(3, "microsoftsql-server.png");
            this.imageList1.Images.SetKeyName(4, "MySql.jpg");
            this.imageList1.Images.SetKeyName(5, "MySQL.png");
            this.imageList1.Images.SetKeyName(6, "Package.ico");
            this.imageList1.Images.SetKeyName(7, "SQL.ico");
            this.imageList1.Images.SetKeyName(8, "tableo.png");
            this.imageList1.Images.SetKeyName(9, "title.ico");
            this.imageList1.Images.SetKeyName(10, "icon.png");
            // 
            // tabControl1
            // 
            this.tabControl1.Location = new System.Drawing.Point(246, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(567, 433);
            this.tabControl1.TabIndex = 8;
            // 
            // txt_Msg
            // 
            this.txt_Msg.Location = new System.Drawing.Point(826, 55);
            this.txt_Msg.Multiline = true;
            this.txt_Msg.Name = "txt_Msg";
            this.txt_Msg.Size = new System.Drawing.Size(227, 322);
            this.txt_Msg.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(821, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "选择文件夹：";
            // 
            // cbx_Folder
            // 
            this.cbx_Folder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Folder.FormattingEnabled = true;
            this.cbx_Folder.Location = new System.Drawing.Point(904, 15);
            this.cbx_Folder.Name = "cbx_Folder";
            this.cbx_Folder.Size = new System.Drawing.Size(149, 20);
            this.cbx_Folder.TabIndex = 10;
            // 
            // btn_Build
            // 
            this.btn_Build.Location = new System.Drawing.Point(948, 395);
            this.btn_Build.Name = "btn_Build";
            this.btn_Build.Size = new System.Drawing.Size(105, 41);
            this.btn_Build.TabIndex = 9;
            this.btn_Build.Text = "生成";
            this.btn_Build.UseVisualStyleBackColor = true;
            this.btn_Build.Click += new System.EventHandler(this.btn_Build_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复合查询ToolStripMenuItem,
            this.DelDB});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // 复合查询ToolStripMenuItem
            // 
            this.复合查询ToolStripMenuItem.Name = "复合查询ToolStripMenuItem";
            this.复合查询ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.复合查询ToolStripMenuItem.Text = "复合查询";
            this.复合查询ToolStripMenuItem.Click += new System.EventHandler(this.复合查询ToolStripMenuItem_Click);
            // 
            // DelDB
            // 
            this.DelDB.Name = "DelDB";
            this.DelDB.Size = new System.Drawing.Size(124, 22);
            this.DelDB.Text = "删除该库";
            this.DelDB.Click += new System.EventHandler(this.DelDB_Click);
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增库ToolStripMenuItem,
            this.新增SQL实体ToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(148, 48);
            // 
            // 新增库ToolStripMenuItem
            // 
            this.新增库ToolStripMenuItem.Name = "新增库ToolStripMenuItem";
            this.新增库ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.新增库ToolStripMenuItem.Text = "新增库";
            this.新增库ToolStripMenuItem.Click += new System.EventHandler(this.新增库ToolStripMenuItem_Click);
            // 
            // 新增SQL实体ToolStripMenuItem
            // 
            this.新增SQL实体ToolStripMenuItem.Name = "新增SQL实体ToolStripMenuItem";
            this.新增SQL实体ToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.新增SQL实体ToolStripMenuItem.Text = "新增SQL实体";
            this.新增SQL实体ToolStripMenuItem.Click += new System.EventHandler(this.新增SQL实体ToolStripMenuItem_Click);
            // 
            // BEMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1072, 475);
            this.Controls.Add(this.tv_DBList);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txt_Msg);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbx_Folder);
            this.Controls.Add(this.btn_Build);
            this.Name = "BEMainForm";
            this.Text = "BEMainForm";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TreeView tv_DBList;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txt_Msg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbx_Folder;
        private System.Windows.Forms.Button btn_Build;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 复合查询ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelDB;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem 新增库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增SQL实体ToolStripMenuItem;
    }
}