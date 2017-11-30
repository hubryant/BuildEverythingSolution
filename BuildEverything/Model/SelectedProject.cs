using EnvDTE;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace BuildEverything.Model
{
    public class SelectedProject
    {
        private readonly string _projectPath;
        private readonly Project _projectDte;
        private readonly List<string> _folderNames;

        public SelectedProject(string projectPath, Project projectDte, List<string> folderNames)
        {
            _projectPath = projectPath;
            _projectDte = projectDte;
            _folderNames = new List<string>() { { "根文件" } };
            _folderNames.AddRange(folderNames);
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

        public string RootPath
        {
            get
            {
                string path = this.GetType().Assembly.Location;
                path = path.Replace(@"\BuildEverything.dll", "");
                return path;
            }
        }

        public string ABEPath
        {
            get
            {
                string path = this.GetType().Assembly.Location;
                Match ma = Regex.Match(path, "(.*Extensions).*", RegexOptions.IgnoreCase);
                if (ma.Success)
                {
                    path = ma.Groups[1].ToString();
                }
                return path;
            }
        }

        public List<string> FolderNames
        {
            get
            {
                return _folderNames.Where(w => w.Contains(".") == false && w.Contains("Properties") == false).ToList();
            }
        }
    }
}
