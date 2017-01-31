using System;
using System.Collections.Generic;
using Autofac;

namespace AutofacPresentation
{
    public static class GoodCompositionRoot
    {
        public static MainWindowViewModel CreateMainWindowViewModel()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<ShowChildWindowCommand>().AsSelf();
            builder.RegisterType<MainHeaderViewModel>().As<IHeaderViewModel>();

            builder.Register<ChildWindowViewModelFactory>(context =>
            {
                var parentContext = context.Persist();
                return speakerType => parentContext.RegisterWithChildScope(childBuilder => RegisterChildWindowViewModel(childBuilder, speakerType), childScope => childScope.Resolve<ChildWindowViewModel>());
            });

            return builder.Build().Resolve<MainWindowViewModel>();
        }

        private static readonly Dictionary<SpeakerType, Type> SpeakerRegistrationMap = new Dictionary<SpeakerType, Type>
        {
            {SpeakerType.Bad, typeof(BadSpeaker)}, {SpeakerType.Good, typeof(GoodSpeaker)}
        };

        private static readonly Dictionary<SpeakerType, Type> FormatStrategyRegistrationMap = new Dictionary<SpeakerType, Type>
        {
            {SpeakerType.Bad, typeof(LeftSensitiveInfoInHeader)}, {SpeakerType.Good, typeof(HideSensitiveInfoFromHeader)}
        };

        private static void RegisterChildWindowViewModel(this ContainerBuilder builder, SpeakerType speakerType)
        {
            builder.RegisterType(SpeakerRegistrationMap[speakerType]).As<ISpeaker>();
            builder.RegisterType(FormatStrategyRegistrationMap[speakerType]).As<IFormatHeaderStrategy>();
            builder.RegisterType<ChildWindowViewModel>().AsSelf();
            builder.RegisterType<HeaderTextFormatter>().AsSelf();
            builder.RegisterType<ChildHeaderViewModel>().As<IHeaderViewModel>();
            builder.RegisterType<HeaderTextProvider>().AsSelf();
        }
    }
}