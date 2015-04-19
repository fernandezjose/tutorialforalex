using System.Linq;
using Castle.Components.DictionaryAdapter.Xml;
using FluentNHibernate.Automapping;
using NHibernate.Loader;
using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Extensions.Factory;

namespace CommandPatternAlejandro
{
    public static class RegisterNinject
    {
        public static StandardKernel RegisterClasses()
        {
            var container = new StandardKernel();

            container.Bind<ICommandHandlerFactory>().ToFactory(() => new CommandHandlerFactoryInstaceProvider());
            //container.Bind(typeof (ICommandHandler<>)).To(typeof (LoggerCommandHandlerDecorator<>)).WhenInjectedInto(typeof(TransactionCommandHandlerDecorator<>));
            container.Bind(typeof(ICommandHandler<>)).To(typeof(TransactionCommandHandlerDecorator<>));
            container.Bind(typeof(ICommandHandler<>))
                .To(typeof(NHibernateCommandHandlerDecorator<>))
                .WhenInjectedInto(typeof(TransactionCommandHandlerDecorator<>));
            container.Bind(typeof(ICommandHandler<>))
                .To(typeof(ContainerCommandHandlerDecorator<>))
                .WhenInjectedInto(typeof(NHibernateCommandHandlerDecorator<>));
            container.Bind<IGate>().To<StandardGate>();
            container.Bind<CommandDispatcher>().ToSelf();

            var assembly = typeof(Program).Assembly;

            foreach (var commandHandler in from f in assembly.GetTypes()
                where f.IsClass
                from i in f.GetInterfaces()
                where
                    i.IsGenericType &&
                    i.GetGenericTypeDefinition() == typeof(ICommandHandler<>)
                let genericArgument = i.GetGenericArguments()[0]
                where !genericArgument.ContainsGenericParameters
                select new { Impl = f, Key = genericArgument.FullName }
                )
            {
                container.Bind<ICommandHandler>().To(commandHandler.Impl).Named(commandHandler.Key);
            }

            container.Bind<IUnitOfWork>().To<UnitOfWork>().InThreadScope();
            container.Bind(
                x => x.FromAssemblyContaining<Program>()
                    .SelectAllClasses()
                    .InheritedFrom(typeof (IRepository<>))
                    .BindAllInterfaces()
                );

            return container;
        }
    }
}