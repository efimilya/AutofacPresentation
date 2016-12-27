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
            builder.RegisterType<SimpleHeaderViewModel>().As<IHeaderViewModel>().InstancePerDependency();
            builder.RegisterType<GoodSpeaker>().AsSelf();
            builder.RegisterType<BadSpeaker>().AsSelf();
            builder.RegisterType<HideSensitiveInfoFromHeader>().AsSelf();
            builder.RegisterType<LeftSensitiveInfoInHeader>().AsSelf();
            builder.RegisterType<HeaderTextProvider>().AsSelf();            

            builder.Register<BadChildWindowViewModelFactory>(
                context =>
                {
                    var parentContext = context.Persist();
                    return speaker => new ChildWindowViewModel(GetSpeaker(speaker, parentContext), 
                        new HeaderViewModel(new HeaderTextFormatter(GetFormatHeaderStrategy(speaker, parentContext)), parentContext.Resolve<HeaderTextProvider>()));
                });

            return builder.Build().Resolve<MainWindowViewModel>();
        }

        private static IFormatHeaderStrategy GetFormatHeaderStrategy(SpeakerType speakerType, IComponentContext context)
        {
            switch (speakerType)
            {
                case SpeakerType.Good:
                    return context.Resolve<HideSensitiveInfoFromHeader>();
                case SpeakerType.Bad:
                    return context.Resolve<LeftSensitiveInfoInHeader>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(speakerType), speakerType, null);
            }
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