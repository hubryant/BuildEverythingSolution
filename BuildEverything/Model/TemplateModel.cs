﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildEverything.Model
{
    /// <summary>
    /// 模版实体
    /// </summary>
    public class TemplateModel
    {
        public TemplateModel(string tableName, List<TableColumn> columns, string projectName)
        {
            TableName = tableName;
            Columns = columns;
            ProjectName = projectName;
        }
        public string TableName { get; private set; }

        public List<TableColumn> Columns { get; private set; }

        public string ProjectName { get; private set; }
    }
}
