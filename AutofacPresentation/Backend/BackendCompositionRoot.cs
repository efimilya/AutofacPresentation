using System;
using Autofac;
using AutofacPresentation.Frontend;

namespace AutofacPresentation.Backend
{
    public static class BackendCompositionRoot
    {
        private static IContainer _container;

        public static IService CreateService(int customerId, int programId, string operationName)
        {
            if (_container == null)
            {
                _container = CreateContainer();
            }
            
            var serviceFactory = _container.Resolve<Func<CalculateContext, IService>>();
            var context = new CalculateContext(customerId, programId, operationName);
            return serviceFactory(context);
        }

        private static IContainer CreateContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<GlobalServiceData>().SingleInstance();
            builder.Register<Func<CalculateContext, IService>>(c =>
            {
                var parentContext = c.Persist();
                return calculateContext => parentContext.RegisterWithChildScope(
                    childBuilder => RegisterCalculateSerivce(childBuilder, calculateContext),
                    childScope => childScope.Resolve<IService>());
            });
            return builder.Build();
        }

        private static void RegisterCalculateSerivce(ContainerBuilder builder, CalculateContext context)
        {
            builder.RegisterType<Service>().As<IService>();
            builder.RegisterType<CustomerRepository>().AsSelf();
            builder.RegisterType<OperationRepository>().AsSelf();
            builder.RegisterType<ProgramRepository>().AsSelf();
            builder.RegisterType<FirstStepAggregator>().AsSelf();
            builder.RegisterType<SecondStepAggregator>().AsSelf();
            builder.RegisterType<CustomerHandler>().AsSelf();
            builder.RegisterType<OperationHandler>().AsSelf();
            builder.RegisterType<ProgramHandler>().AsSelf();
            builder.RegisterType<CalculateDataLoader>().AsSelf();
            builder.Register(c => context);
            builder.Register(c => c.Resolve<CalculateDataLoader>().Load());
        }
    }
}