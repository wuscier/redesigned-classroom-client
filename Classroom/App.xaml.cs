using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Classroom
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;

            MessageQueueManager.Instance.AddInfo("INFO");



            //MessageQueueManager.Instance.AddWarning("WARNING");
            //MessageQueueManager.Instance.AddError("ERROR");

            //Thread.Sleep(4000);

            //MessageQueueManager.Instance.AddInfo("INFO");
            //MessageQueueManager.Instance.AddWarning("WARNING");
            //MessageQueueManager.Instance.AddError("ERROR");

        }
    }
}
