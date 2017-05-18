using System.Windows;
using Autofac;
using Autofac.Features.ResolveAnything;
using Classroom.View;
using Common.Helper;
using MeetingSdk;
using Service;

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

            builder.RegisterModule(new MeetingSdkModule());
            builder.RegisterModule(new ServiceModule());

            IContainer container = builder.Build();
            DependencyResolver.SetContainer(container);
        }
    }
}
