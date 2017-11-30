using System.IO;
using System.Security.AccessControl;
using System.Text;

namespace BuildEverything.Common.Helper
{
    public static class FilesHelper
    {
        public static string Write(string directory, string fileName, string content)
        {
            var path = Path.Combine(directory, fileName + ".cs");
            using (var fs = new FileStream(path, FileMode.Create, FileAccess.Write))
            {
                byte[] byteFile = Encoding.UTF8.GetBytes(content);
                fs.Write(byteFile, 0, byteFile.Length);
            }
            return path;
        }
        /// <summary>
        /// 为文件添加users，everyone用户组的完全控制权限
        /// </summary>
        /// <param name="filePath"></param>
        public static void AddSecurityControll2File(string filePath)
        {

            //获取文件信息
            FileInfo fileInfo = new FileInfo(filePath);
            //获得该文件的访问权限
            System.Security.AccessControl.FileSecurity fileSecurity = fileInfo.GetAccessControl();
            //添加ereryone用户组的访问权限规则 完全控制权限
            fileSecurity.AddAccessRule(new FileSystemAccessRule("Everyone", FileSystemRights.FullControl, AccessControlType.Allow));
            //添加Users用户组的访问权限规则 完全控制权限
            fileSecurity.AddAccessRule(new FileSystemAccessRule("Users", FileSystemRights.FullControl, AccessControlType.Allow));
            //设置访问权限
            fileInfo.SetAccessControl(fileSecurity);
        }

    }
}
