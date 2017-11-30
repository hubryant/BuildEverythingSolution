using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System;

namespace BuildEverything.Common.Helper
{
    public static class OutputWindowHelper
    {
        #region OutputWindow
        /// <summary>
        /// 向Output Window 写入信息
        /// </summary>
        /// <param name="Message"></param>
        public static void OutPutMessage(string Message)
        {
            OutPutMessage(Message, false);
        }

        /// <summary>
        /// 向Output Window 写入信息
        /// </summary>
        /// <param name="message">Message</param>
        /// <param name="IsClear">IsClear</param>
        public static void OutPutMessage(string Message, bool IsClear)
        {
            IVsOutputWindow outWindow = Package.GetGlobalService(typeof(SVsOutputWindow)) as IVsOutputWindow;
            Guid guidOutPut = new Guid();

            outWindow.CreatePane(ref guidOutPut, "BuildEverything", 1, 0);
            IVsOutputWindowPane windowPane;
            outWindow.GetPane(ref guidOutPut, out windowPane);

            if (IsClear) windowPane.Clear();
            //激活窗体  ？有问题
            windowPane.Activate();
            windowPane.OutputString(Message + "\n");
        }

        #endregion
    }
}
