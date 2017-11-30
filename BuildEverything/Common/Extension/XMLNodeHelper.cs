using BuildEverything.Common.Helper;
using BuildEverything.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BuildEverything.Common.Extension
{
    public static class XMLNodeHelper
    {
        public static bool NeedAuth = true;
        public static string NodeRemove(string path, string nodeName)
        {
            string flag = string.Empty;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                XmlNodeList xnList = xmlDoc.SelectNodes("DBInfoList/DBInfo");
                if (xnList != null && xnList.Count > 0)
                {
                    foreach (XmlNode node in xnList)
                    {
                        if (node["DBName"].InnerText == nodeName)
                        {
                            node.ParentNode.RemoveChild(node);
                            break;
                        }
                    }
                }
                xmlDoc.Save(path);
            }
            catch (Exception ex)
            {
                flag = $"删除数据库连接出现异常 \r\n 信息：{ex.Message}";
                OutputWindowHelper.OutPutMessage($"删除数据库连接出现异常 \r\n 信息：{ex.Message} \r\n 堆栈：{ex.StackTrace}");
            }
            if (flag.Contains("访问被拒绝") && NeedAuth)
            {
                FilesHelper.AddSecurityControll2File(path);
                flag = NodeRemove(path, nodeName);
            }
            return flag;
        }

        public static string NodeAdd(string path, DBInfo info)
        {
            string flag = string.Empty;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(path);
                XmlNode xnList = xmlDoc.SelectSingleNode("DBInfoList");
                XmlElement xeRoot = xmlDoc.CreateElement("DBInfo");
                foreach (PropertyInfo p in info.GetType().GetProperties())
                {
                    if ("TableStruList,DBLink".Contains(p.Name))
                    {
                        continue;
                    }
                    XmlElement xe = xmlDoc.CreateElement(p.Name);
                    xe.InnerText = p.GetValue(info).ToString();
                    xeRoot.AppendChild(xe);
                }
                xnList.AppendChild(xeRoot);
                xmlDoc.Save(path);
            }
            catch (Exception ex)
            {
                flag = $"新增数据库连接出现异常 \r\n 信息：{ex.Message}";
                OutputWindowHelper.OutPutMessage($"添加数据库连接出现异常 \r\n 信息：{ex.Message} \r\n 堆栈：{ex.StackTrace}");
            }
            if (flag.Contains("访问被拒绝") && NeedAuth)
            {
                FilesHelper.AddSecurityControll2File(path);
                flag = NodeAdd(path, info);
            }
            return flag;
        }
    }
}
