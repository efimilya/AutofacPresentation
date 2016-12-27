using System;
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
            builder.RegisterType<GoodSpeaker>().AsSelf();
            builder.RegisterType<BadSpeaker>().AsSelf();

            builder.Register<BadChildWindowViewModelFactory>(
                context =>
                {
                    var parentContext = context.Persist();
                    return speaker => new ChildWindowViewModel(GetSpeaker(speaker, parentContext), parentContext.Resolve<HeaderViewModel>());
                });

            return builder.Build().Resolve<MainWindowViewModel>();
        }

        private static ISpeaker GetSpeaker(SpeakerType speakerType, IComponentContext context)
        {
            switch (speakerType)
            {
                case SpeakerType.Good:
                    return context.Resolve<GoodSpeaker>();
                case SpeakerType.Bad:
                    return context.Resolve<BadSpeaker>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(speakerType), speakerType, null);
            }
        }
    }
}