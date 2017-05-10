using System.Windows;
using Common.Message;

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
