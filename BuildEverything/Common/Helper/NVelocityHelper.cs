using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using System.Collections.Generic;
using System.IO;

namespace BuildEverything.Common.Helper
{
    public static class NVelocityHelper
    {
        /// <summary>
        /// 初始化模板引擎
        /// </summary>
        public static string ProcessTemplate(string path, string template, Dictionary<string, object> dicStru)
        {
            var templateEngine = new VelocityEngine();
            templateEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
            templateEngine.SetProperty(RuntimeConstants.INPUT_ENCODING, "utf-8");
            templateEngine.SetProperty(RuntimeConstants.OUTPUT_ENCODING, "utf-8");
            //路径
            templateEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, Path.Combine(path, "Templates"));

            var context = new VelocityContext();
            foreach (var dbs in dicStru)
            {
                context.Put(dbs.Key, dbs.Value);
            }
            templateEngine.Init();
            var writer = new StringWriter();
            templateEngine.Evaluate(context, writer, "mystring", template);

            return writer.GetStringBuilder().ToString();
        }

    }
}
