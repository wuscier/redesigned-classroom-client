using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
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

            Dialog baseWindow = new Dialog("你好，suppeman！你好，supper man！你好，supper man！", "谢谢","不用了");

            baseWindow.ShowDialog();
        }
    }
}
