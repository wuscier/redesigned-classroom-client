using System;
using Autofac;

namespace MeetingSdk
{
    public class MeetingSdkModule:Module
    {

        public MeetingSdkModule()
        {
            Console.WriteLine("construct MeetingSdkModule");
        }

        protected override void Load(ContainerBuilder builder)
        {
            Console.WriteLine("Register ServiceModule Components");
        }
    }
}
