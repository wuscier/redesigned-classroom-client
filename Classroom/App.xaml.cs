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
using Autofac.Features.ResolveAnything;
using Classroom.View;
using Common.Helper;
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

            LoginView loginView = DependencyResolver.Current.GetService<LoginView>();
            loginView.Show();
        }

        private void RegisterModuleComponents()
        {
            var builder = new ContainerBuilder();

            // Make sure any not specifically registered concrete type can resolve.
            builder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            var modulePath = Path.Combine(Environment.CurrentDirectory, "Modules");
            var assemblies = Directory.GetFiles(modulePath, "*.dll").Select(Assembly.LoadFile);

            builder.RegisterAssemblyModules(assemblies.ToArray());

            IContainer container = builder.Build();
            DependencyResolver.SetContainer(container);
        }
    }
}
