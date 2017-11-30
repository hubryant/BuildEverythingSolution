using EnvDTE;
using System.Collections.Generic;
using System.IO;

namespace BuildEverything.Model
{
    public class SelectedProjectFolder
    {
        private readonly string _projectPath;
        private readonly Project _projectDte;
        private readonly ProjectItem _projectItemDte;
        private readonly List<string> _folderName;

        public SelectedProjectFolder(string projectPath, Project projectDte, ProjectItem projectItemDte, List<string> folderName)
        {
            _projectPath = projectPath;
            _projectDte = projectDte;
            _projectItemDte = projectItemDte;
            _folderName = folderName;
        }
        public string ProjectPath
        {
            get { return _projectPath; }
        }

        public string ProjectName
        {
            get { return Path.GetFileNameWithoutExtension(ProjectPath); }
        }

        public string ProjectDirectoryName
        {
            get { return Path.GetDirectoryName(ProjectPath); }
        }

        public Project ProjectDte
        {
            get { return _projectDte; }
        }

        public ProjectItem ProjectItemDte
        {
            get { return _projectItemDte; }
        }

        public List<string> FolderName
        {
            get { return _folderName; }
        }
    }
}
