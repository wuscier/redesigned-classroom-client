using Autofac;
using Common.Contract;
using System;

namespace Service
{
    public class ServiceModule:Module
    {
        public ServiceModule()
        {
            Console.WriteLine("construct ServiceModule");
        }

        protected override void Load(ContainerBuilder builder)
        {
            Console.WriteLine("Register ServiceModule Components");

            builder.RegisterType<ClassroomBms>().As<IBms>().SingleInstance();
        }
    }
}
