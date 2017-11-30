using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildEverything.Model
{
    public class BuildEverythingContent
    {
        /// <summary>
        /// 选中项目
        /// </summary>
        public SelectedProject SelectedProject { get; set; }

        /// <summary>
        /// 选中文件夹
        /// </summary>
        public SelectedProjectFolder SelectedProjectFolder { get; set; }

        /// <summary>
        /// 表名
        /// </summary>
        public List<string> TablesName { get; set; }
    }
}
