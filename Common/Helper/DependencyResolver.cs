using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace Common.Helper
{
    public class DependencyResolver
    {
        public static readonly DependencyResolver Current = new DependencyResolver();
        private static IContainer _innerContainer;

        public static void SetContainer(IContainer container)
        {
            if (_innerContainer == null)
            {
                _innerContainer = container;
            }
        }

        private DependencyResolver()
        {

        }

        public object GetService(Type type)
        {
            return _innerContainer.Resolve(type);
        }

        public T GetService<T>()
        {
            return _innerContainer.Resolve<T>();
        }

        public IContainer Container
        {
            get
            {
                if (_innerContainer == null)
                {
                    throw new NullReferenceException("未设置容器。");
                }

                return _innerContainer;
            }
        }
    }
}
