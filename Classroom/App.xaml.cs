using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Windows;
using Autofac;
using Autofac.Core;
using Common.UiMessage;

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

            RegisterModuleComponents();
        }

        private void RegisterModuleComponents()
        {
            var builder = new ContainerBuilder();

            var modulePath = Path.Combine(Environment.CurrentDirectory, "Modules");

            var modules = Directory.GetFiles(modulePath, "*.dll").Select(Assembly.LoadFile).ToArray();

            builder.RegisterAssemblyModules(modules);
        }
    }
}
