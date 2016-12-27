using Autofac;

namespace AutofacPresentation
{
    public static class BadCompositionRoot
    {
        public static MainWindowViewModel CreateMainWindowViewModel()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<BadShowChildWindowCommand>().As<IShowChildWindowCommand>();
            builder.RegisterType<HeaderViewModel>().AsSelf().InstancePerDependency();

            builder.Register<BadChildWindowViewModelFactory>(
                context =>
                {
                    var parentContext = context.Persist();
                    return speaker => new ChildWindowViewModel(speaker, parentContext.Resolve<HeaderViewModel>());
                });

            return builder.Build().Resolve<MainWindowViewModel>();
        }
    }
}