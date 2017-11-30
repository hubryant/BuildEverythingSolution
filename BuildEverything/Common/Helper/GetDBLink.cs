using BuildEverything.Common.EnumFolder;
using BuildEverything.Model;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Xml;

namespace BuildEverything.Common.Helper
{
    public class GetDBLink
    {
        public DBInfoModel GetBDList(string path)
        {
            DBInfoModel model = new DBInfoModel();
            XmlDocument xmlDoc = new XmlDocument();
            //xmlDoc.Load(Path.Combine(Environment.CurrentDirectory, "AppData", "DBLinkInfo.xml"));
            xmlDoc.Load(Path.Combine(path, "Config", "DBLinkInfo.xml"));
            XmlNodeList xnList = xmlDoc.SelectNodes("DBInfoList/DBInfo");
            if (xnList != null && xnList.Count > 0)
            {
                foreach (XmlNode node in xnList)
                {
                    DBInfo info = new DBInfo()
                    {
                        DBName = node["DBName"].InnerText,
                        Port = node["Port"].InnerText,
                        Pwd = node["Pwd"].InnerText,
                        Server = node["Server"].InnerText,
                        Type = (DBEnum)Enum.Parse(typeof(DBEnum), node["Type"].InnerText),
                        Uid = node["Uid"].InnerText
                    };
                    GetTableList(info);
                    model.DBInfoList.Add(info);
                }
            }
            return model;
        }

        public static void GetConnectLink(DBInfo info)
        {
            switch (info.Type)
            {
                case DBEnum.SqlServer:
                    info.DBLink = $"Data Source={info.Server},{info.Port};Initial Catalog={info.DBName};Persist Security Info=True;User ID={info.Uid};Password={info.Pwd}";
                    break;
                case DBEnum.MySQL:
                    info.DBLink = $"Server={info.Server};Port={info.Port};Database={info.DBName};Uid={info.Uid};Pwd={info.Pwd}";
                    break;
                default:
                    break;
            }
        }

        public static string GetTableList(DBInfo info)
        {
            string result = "";
            try
            {
                GetConnectLink(info);
                DataTable table = new DataTable();
                if (info.Type == DBEnum.SqlServer)
                {
                    #region SQLServer表结构
                    var GetTableSql = @"SELECT  obj.name AS TableName ,
col.name AS ColName ,  
        ISNULL(ep.[value], '') AS ColDesc ,  
        t.name AS ColType ,  
        convert(int,col.length) AS ColLen ,   
        CASE WHEN COLUMNPROPERTY(col.id, col.name, 'IsIdentity') = 1 THEN '√'  
             ELSE ''  
        END AS ColIsinc ,  
        CASE WHEN EXISTS ( SELECT   1  
                           FROM     dbo.sysindexes si  
                                    INNER JOIN dbo.sysindexkeys sik ON si.id = sik.id  
                                                              AND si.indid = sik.indid  
                                    INNER JOIN dbo.syscolumns sc ON sc.id = sik.id  
                                                              AND sc.colid = sik.colid  
                                    INNER JOIN dbo.sysobjects so ON so.name = si.name  
                                                              AND so.xtype = 'PK'  
                           WHERE    sc.id = col.id  
                                    AND sc.colid = col.colid ) THEN '√'  
             ELSE ''  
        END AS ColIsPri ,  
        CASE WHEN col.isnullable = 1 THEN '√'  
             ELSE ''  
        END AS ColisNull ,  
        ISNULL(comm.text, '') AS DefaultValue  
FROM    dbo.syscolumns col  
        LEFT  JOIN dbo.systypes t ON col.xtype = t.xusertype  
        inner JOIN dbo.sysobjects obj ON col.id = obj.id  
                                         AND obj.xtype = 'U'  
                                         AND obj.status >= 0  
        LEFT  JOIN dbo.syscomments comm ON col.cdefault = comm.id  
        LEFT  JOIN sys.extended_properties ep ON col.id = ep.major_id  
                                                      AND col.colid = ep.minor_id  
                                                      AND ep.name = 'MS_Description'  
        LEFT  JOIN sys.extended_properties epTwo ON obj.id = epTwo.major_id  
                                                         AND epTwo.minor_id = 0  
                                                         AND epTwo.name = 'MS_Description'  
ORDER BY obj.name,col.colorder ; ";
                    #endregion
                    table = new SqlHelper(info.DBLink).ExecuteDataTable(GetTableSql);
                }
                else if (info.Type == DBEnum.MySQL)
                {
                    #region SQLServer表结构
                    var GetTableSql = $@"select table_name as TableName,column_name as ColName,column_comment as ColDesc,data_type as ColType ,convert(character_maximum_length,int) as ColLen,
                                        case EXTRA when 'auto_increment' then '√' else '' end as ColIsinc,
                                        case COLUMN_KEY when 'PRI' then '√' else '' end as ColIsPri ,is_nullable as ColisNull,COLUMN_DEFAULT as DefaultValue
                                        from information_schema.columns where table_schema ='{info.DBName}' 
                                        order by table_name ,ORDINAL_POSITION";
                    #endregion
                    table = MySqlHelper.ExecuteDataTable(info.DBLink, GetTableSql);
                }
                if (table != null && table.Rows.Count > 0)
                {
                    info.TableStruList = ModelConvertHelper<DBStructure>.ConvertToModel(table).ToList();
                }
            }
            catch (Exception ex)
            {
                result = $"获取数据库表出现异常,明细:{ex.Message}";
                OutputWindowHelper.OutPutMessage($"获取数据库表出现异常 \r\n 信息：{ex.Message} \r\n 堆栈：{ex.StackTrace}");
            }
            return result;
        }
    }
}
