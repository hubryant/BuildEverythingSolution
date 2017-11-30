using BuildEverything.Common.EnumFolder;
using System.Collections.Generic;

namespace BuildEverything.Model
{
    public class DBInfoModel
    {
        public List<DBInfo> DBInfoList { get; set; } = new List<DBInfo>();
    }

    public class DBInfo
    {
        public DBEnum Type { get; set; } = DBEnum.MySQL;
        public string Server { get; set; } = string.Empty;
        public string Port { get; set; } = string.Empty;
        public string DBName { get; set; } = string.Empty;
        public string Uid { get; set; } = string.Empty;
        public string Pwd { get; set; } = string.Empty;
        public List<DBStructure> TableStruList { get; set; } = new List<DBStructure>();
        public string DBLink { get; set; } = string.Empty;
    }
}
