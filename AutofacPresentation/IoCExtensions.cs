using System;
using Autofac;

namespace AutofacPresentation
{
    public static class IoCExtensions
    {
        public static T RegisterWithChildScope<T>(this IComponentContext parentContext,
            Action<ContainerBuilder> childBuilderRegistration,
            Func<ILifetimeScope, T> factory)
        {
            var scope = parentContext.Resolve<ILifetimeScope>().BeginLifetimeScope(childBuilderRegistration);
            return factory(scope);
        }

        public static IComponentContext Persist(this IComponentContext context)
        {
            return context.Resolve<IComponentContext>();
        }
    }
}