using System;

namespace BuildEverything.Common.Extension
{
    public static class ConverUnity
    {
        /// <summary>
        /// 转换成C#类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string MapCsharpType(this Type type)
        {
            var csharpType = string.Empty;

            switch (type.Name.ToLower())
            {
                case "boolean": csharpType = "bool"; break;
                case "byte": csharpType = "byte"; break;
                case "byte[]": csharpType = "byte[]"; break;
                case "datetime": csharpType = "DateTime"; break;
                case "decimal": csharpType = "decimal"; break;
                case "double": csharpType = "double"; break;
                case "guid": csharpType = "Guid"; break;
                case "int32": csharpType = "int"; break;
                case "int64": csharpType = "long"; break;
                case "string": csharpType = "string"; break;

                default: csharpType = "object"; break;
            }

            return csharpType;
        }
    }
}
