namespace SystemDot.Web.WebApi.Ioc
{
    using System;
    using System.Collections.Generic;
    using System.Web.Http.Dependencies;
    using SystemDot.Ioc;

    internal class SystemDotDependencyResolver : IDependencyResolver
    {
        readonly IIocContainer container;

        public SystemDotDependencyResolver(IIocContainer container)
        {
            this.container = container;
        }

        public object GetService(Type serviceType)
        {
            return container.ComponentExists(serviceType) 
                ? container.Resolve(serviceType) 
                : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return container.ComponentExists(serviceType) 
                ? new List<object> {container.Resolve(serviceType)} 
                : new List<object>();
        }

        public IDependencyScope BeginScope()
        {
            return new SystemDotDependencyScope(container);
        }

        public void Dispose()
        {
        }

        class SystemDotDependencyScope : IDependencyScope
        {
            readonly IIocContainer container;

            public SystemDotDependencyScope(IIocContainer container)
            {
                this.container = container;
            }

            public void Dispose()
            {
            }

            public object GetService(Type serviceType)
            {
                return container.ComponentExists(serviceType)
                    ? container.Resolve(serviceType)
                    : null;
            }

            public IEnumerable<object> GetServices(Type serviceType)
            {
                return container.ComponentExists(serviceType) 
                    ? new List<object> { container.Resolve(serviceType) } 
                    : new List<object>();
            }
        }
    }
}