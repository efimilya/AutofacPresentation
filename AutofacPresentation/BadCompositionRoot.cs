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
            builder.RegisterType<ShowChildWindowCommand>().AsSelf();
            builder.RegisterType<HeaderViewModel>().AsSelf().InstancePerDependency();
            builder.RegisterType<HelloSpeaker>().AsSelf();
            builder.RegisterType<ByeSpeaker>().AsSelf();

            builder.Register<ChildWindowViewModelFactory>(
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
                    return context.Resolve<HelloSpeaker>();
                case SpeakerType.Bad:
                    return context.Resolve<ByeSpeaker>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(speakerType), speakerType, null);
            }
        }
    }
}