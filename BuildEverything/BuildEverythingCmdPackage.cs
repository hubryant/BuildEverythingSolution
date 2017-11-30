using BuildEverything.Common.Extension;
using BuildEverything.Common.Helper;
using BuildEverything.FormFiles;
using BuildEverything.Model;
using EnvDTE;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace BuildEverything
{
    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)] // Info on this package for Help/About
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(BuildEverythingCmdPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    public sealed class BuildEverythingCmdPackage : Package
    {
        /// <summary>
        /// BuildEverythingCmdPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "0d1b9419-9193-43ef-b38f-1cf80504ae86";
        public const int CommandId = 0x0100;
        public static readonly Guid CommandSet = new Guid("8fd676d0-6729-4d47-a40b-c36a187c89f5"); //new Guid("D309F791-903F-11D0-9EFC-00A0C911004F");
        /// <summary>
        /// Initializes a new instance of the <see cref="BuildEverythingCmd"/> class.
        /// </summary>
        public BuildEverythingCmdPackage()
        {
            // Inside this method you can place any initialization code that does not require
            // any Visual Studio service because at this point the package object is created but
            // not sited yet inside Visual Studio environment. The place to do all the other
            // initialization is the Initialize method.
        }

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        protected override void Initialize()
        {
            BuildEverythingCmd.Initialize(this);
            base.Initialize();

            var mcs = GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
            if (null != mcs)
            {
                var menuCommandId = new CommandID(CommandSet, CommandId);
                var menuItem = new OleMenuCommand(BuildEverythingEvent, menuCommandId);
                mcs.AddCommand(menuItem);
            }
        }

        #endregion

        #region 按钮事件
        /// <summary>
        /// 按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BuildEverythingEvent(object sender, EventArgs e)
        {
            var uiShell = (IVsUIShell)GetService(typeof(SVsUIShell));

            //获取选中项目信息
            var buildEverythingContent = new BuildEverythingContent { SelectedProject = GetSelectedProject() };
            if (buildEverythingContent.SelectedProject == null)
            {
                uiShell.ShowMessageBox("获取项目信息失败");
                return;
            }
            new BEMainForm(buildEverythingContent).ShowDialog();
        }

        /// <summary>
        /// 获取选中的项目所有信息
        /// </summary>
        /// <returns></returns>
        private SelectedProject GetSelectedProject()
        {
            SelectedProject projectInfo = null;
            try
            {
                var dte = (DTE)GetService(typeof(SDTE));
                //获取选中项目信息
                projectInfo = dte.GetSelectedProjectInfo();
            }
            catch (Exception)
            {
                OutputWindowHelper.OutPutMessage("未选择对应的项目，注意鼠标焦点");
            }
            return projectInfo;
        }

        /// <summary>
        /// 获取选中的项目所有信息
        /// </summary>
        /// <returns></returns>
        private SelectedProjectFolder GetSelectedProjectFolder()
        {
            var dte = (DTE)GetService(typeof(SDTE));
            //获取选中项目信息
            var projectFolderInfo = dte.GetSelectedProjectFolderInfo();
            return projectFolderInfo;
        }

        /// <summary>
        /// 获取物理表
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        private List<string> GetTables(string sqlstr)
        {
            var dbTable = new DbTable(sqlstr);

            return dbTable.QueryTablesName();
        }
    }
    #endregion

}
