using System;
using System.Linq;
using System.Reflection;
using DellTddBanking2.Events;

namespace DellTddBanking2.Bus
{
    public class Bus
    {
        public void Send<T>(T command) where T : ICommand
        {
            var handler = Assembly.GetAssembly(typeof(Bus)).GetTypes().FirstOrDefault(t =>
            {
                return !t.IsInterface && t.GetInterfaces().Any(iface => iface.IsGenericType && iface == typeof(IHandleMessages<T>));
            });

            if (handler != null) ((IHandleMessages<T>)Activator.CreateInstance(handler)).Handle(command);

        }

        public void Publish<T>(T tEvent) where T : IEvent
        {
            var handlers = Assembly.GetAssembly(typeof(Bus)).GetTypes().Where(t =>
            {
                return !t.IsInterface && t.GetInterfaces().Any(iface => iface.IsGenericType && iface == typeof(IHandleMessages<T>));
            });

            foreach (var handler in handlers)
            {
                ((IHandleMessages<T>)Activator.CreateInstance(handler)).Handle(tEvent);
            }
        }
    }
}