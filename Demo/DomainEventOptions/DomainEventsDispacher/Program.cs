using System;
using Autofac;
using DomainEventsDispacher.Bases;
using DomainEventsDispacher.EventAggregator;
using DomainEventsDispacher.Events;
using DomainEventsDispacher.Listeners;

namespace DomainEventsDispacher
{
    class Program
    {
        static void Main(string[] args)
        {
            //StaticEventAggregator();

            //EventAggregatorWithContainer();

            //EventAgregatorReactive();

            LogEventAggregator();

            Console.ReadLine();
        }

        private static void EventAgregatorReactive()
        {
            var eventAgregator = new EventAggregatorReactive();
            using (eventAgregator.GetEvent<AvisadoEstas>().Subscribe(ActionAvisadoEstas()))
            using (eventAgregator.GetEvent<AvisadoEstas>().Subscribe(ev=>HazEsto(ev)))
            using (eventAgregator.GetEvent<AvisadoEstas>().Subscribe(ev => { new EventListener().Handle(ev); }))
            {
                eventAgregator.Raise(new AvisadoEstas("Daniel"));
            }

            eventAgregator.Raise(new AvisadoEstas("Mazzini"));
        }

        private static void EventAggregatorWithContainer()
        {
            var mainBuilder = new ContainerBuilder();

            mainBuilder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .AsClosedTypesOf(typeof(DomainEventHandler<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            mainBuilder.RegisterType<EventAggregatorContainer>().As<Bases.EventDispacher>();

            mainBuilder.RegisterType<EventAggregatorCaller>().As<IEventAggregatorCaller>().InstancePerLifetimeScope();

            mainBuilder.RegisterType<EventAggregatorContainer>().As<Bases.EventDispacher>().InstancePerLifetimeScope();

            IContainer container = mainBuilder.Build();


            IEventAggregatorCaller caller = container.Resolve<IEventAggregatorCaller>();

            EventDispacher dispacher = container.Resolve<EventDispacher>();

            dispacher.Raise(new AvisadoEstas("Daniel"));
            caller.Algo();
        }

        private static void StaticEventAggregator()
        {
            using (DomainEvents.Register(ActionAvisadoEstas()))
            using (DomainEvents.Register<AvisadoEstas>(HazEsto))
            {

                DomainEvents.Raise(new AvisadoEstas("Daniel"));
            }

            DomainEvents.Raise(new AvisadoEstas("Otra vez"));
        }

        private static void LogEventAggregator()
        {
            using (DomainEvents.Register<DomainEvent>(onLog))
            using (DomainEvents.Register<OtroEventoPaso>(OnOtroEventoPaso))
            using (DomainEvents.Register<AvisadoEstas>(ActionAvisadoEstas()))
            {
                DomainEvents.Raise(new AvisadoEstas("Daniel"));
                DomainEvents.Raise(new OtroEventoPaso());
            }

            DomainEvents.Raise(new AvisadoEstas("Otra vez"));
        }

        static void OnOtroEventoPaso(OtroEventoPaso avisadoEstas)
        {
            Console.WriteLine($"Evento capturado {avisadoEstas} en onAvisadoEstas");
        }

        static Action<AvisadoEstas> ActionAvisadoEstas()
        {
            return avisadoEstas => { Console.WriteLine($"Evento capturado {avisadoEstas} en onAvisadoEstas"); };
        }

        static void HazEsto(AvisadoEstas avisadoEstas)
        {
            Console.WriteLine($"Evento capturado {avisadoEstas} en HazEsto");
        }

        static void onLog(DomainEvent avisadoEstas)
        {
            Console.WriteLine($"LOG => {DateTime.UtcNow} Evento capturado {avisadoEstas.OccuredOn} - Type {avisadoEstas.GetType()}");
        }
    }
}
