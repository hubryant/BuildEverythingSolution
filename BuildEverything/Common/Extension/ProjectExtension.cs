using BuildEverything.Model;
using EnvDTE;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BuildEverything.Common.Extension
{
    public static class ProjectExtension
    {
        /// <summary>
        /// 获取选中项目的信息
        /// </summary>
        /// <param name="dte"></param>
        /// <returns></returns>
        public static SelectedProject GetSelectedProjectInfo(this DTE dte)
        {
            var selectedItems = dte.SelectedItems;
            var projectName = (from SelectedItem item in selectedItems select item.Name).ToList();
            if (!selectedItems.MultiSelect && selectedItems.Count == 1)
            {
                var selectProject = selectedItems.Item(projectName.First());
                var projectFileList = (from ProjectItem projectItem in selectProject.Project.ProjectItems
                                       select projectItem.Name).ToList();
                return new SelectedProject(selectProject.Project.FullName, selectProject.Project, projectFileList);
            }

            return null;
        }

        /// <summary>
        /// 获取选中文件夹的信息
        /// </summary>
        /// <param name="dte"></param>
        /// <returns></returns>
        public static SelectedProjectFolder GetSelectedProjectFolderInfo(this DTE dte)
        {
            var selectedItems = dte.SelectedItems;
            var projectName = (from SelectedItem item in selectedItems select item.Name).ToList();
            if (!selectedItems.MultiSelect && selectedItems.Count == 1)
            {
                var selectProject = selectedItems.Item(projectName.First());
                var projectFileList = (from ProjectItem projectItem in selectProject.ProjectItem.ProjectItems
                                       where projectItem.Name.EndsWith(".cs")
                                       select Path.GetFileNameWithoutExtension(projectItem.Name)).ToList();
                return new SelectedProjectFolder(selectProject.ProjectItem.FileNames[0], selectProject.Project, selectProject.ProjectItem, projectFileList);
            }

            return null;
        }

        /// <summary>
        /// 添加项目项
        /// </summary>
        /// <param name="projectDte"></param>
        /// <param name="files"></param>
        public static void AddFilesToProject(this Project projectDte, List<string> files)
        {
            if (files.Any())
            {
                foreach (string file in files)
                {
                    projectDte.ProjectItems.AddFromFile(file);
                }
                projectDte.Save();
            }
        }

        /// <summary>
        /// 添加项目项
        /// </summary>
        /// <param name="projectDte"></param>
        /// <param name="files"></param>
        public static void AddFilesToProjectFolder(this ProjectItem projectItemDte, List<string> files)
        {
            if (files.Any())
            {
                foreach (string file in files)
                {
                    projectItemDte.ProjectItems.AddFromFile(file);
                }
                projectItemDte.Save();
            }
        }

        /// <summary>
        /// 排除项目项
        /// </summary>
        /// <param name="projectDte"></param>
        /// <param name="files"></param>
        public static void RemoveFilesFromProject(this Project projectDte, List<string> files)
        {
            foreach (string file in files)
            {
                projectDte.ProjectItems.Item(Path.GetFileName(file)).Remove();
            }

            if (files.Any())
                projectDte.Save();
        }

        /// <summary>
        /// 警告提示框
        /// </summary>
        /// <param name="uiShell"></param>
        /// <param name="msg"></param>
        public static void ShowMessageBox(this IVsUIShell uiShell, string msg)
        {
            var clsid = Guid.Empty;
            int result;
            ErrorHandler.ThrowOnFailure(uiShell.ShowMessageBox(
                       0,
                       ref clsid,
                       "提示",
                       msg,
                       string.Empty,
                       0,
                       OLEMSGBUTTON.OLEMSGBUTTON_OK,
                       OLEMSGDEFBUTTON.OLEMSGDEFBUTTON_FIRST,
                       OLEMSGICON.OLEMSGICON_INFO,
                       0,
                       out result));
        }
    }
}
