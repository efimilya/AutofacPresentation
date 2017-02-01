using Autofac;

namespace AutofacPresentation.Backend
{
    public static class BadBackendCompositionRoot
    {
        public static IService CreateService()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Service>().As<IService>();
            builder.RegisterType<CustomerRepository>().AsSelf();
            builder.RegisterType<OperationRepository>().AsSelf();
            builder.RegisterType<ProgramRepository>().AsSelf();
            builder.RegisterType<FirstStepAggregator>().AsSelf();
            builder.RegisterType<SecondStepAggregator>().AsSelf();
            builder.RegisterType<CustomerHandler>().AsSelf();
            builder.RegisterType<OperationHandler>().AsSelf();
            builder.RegisterType<ProgramHandler>().AsSelf();
            builder.RegisterType<GlobalServiceData>().SingleInstance();

            return _service ?? (_service = builder.Build().Resolve<IService>());
        }

        private static IService _service;
    }
}