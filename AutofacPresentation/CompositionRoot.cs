using System;
using System.Collections.Generic;
using Autofac;

namespace AutofacPresentation
{
    public static class CompositionRoot
    {
        public static MainWindowViewModel CreateMainWindowViewModel()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<ShowChildWindowCommand>().AsSelf();

            builder.Register<ChildWindowViewModelFactory>(
                context =>
                {
                    var parentContext = context.Persist();
                    return speakerType =>
                        parentContext.RegisterWithChildScope(
                            childBuilder => RegisterChildWindowViewModel(childBuilder, speakerType),
                            childScope => childScope.Resolve<ChildWindowViewModel>());
                });

            return builder.Build().Resolve<MainWindowViewModel>();
        }

        private static readonly Dictionary<SpeakerType, Type> SpeakerTypeToTypeMap = new Dictionary<SpeakerType, Type>
        {
            { SpeakerType.Bad, typeof(BadSpeaker)},
            { SpeakerType.Good, typeof(GoodSpeaker)}
        };

        private static void RegisterChildWindowViewModel(this ContainerBuilder builder, SpeakerType speakerType)
        {
            builder.RegisterType(SpeakerTypeToTypeMap[speakerType]).As<ISpeaker>();
            builder.RegisterType<ChildWindowViewModel>().AsSelf();
        }
    }
}