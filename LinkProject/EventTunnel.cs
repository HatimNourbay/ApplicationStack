using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkProject
{
    public interface IEventReceiver
    {
        void Receive<T>(T arg) where T : EventArgs;
    }

    public class SomeUniqueEvent : EventArgs
    {
        public bool Clicked { get; set; }

        public SomeUniqueEvent(bool clicked)
        {
            Clicked = clicked;
        }
    }

    public static class EventTunnel
    {
        private static readonly List<IEventReceiver> _receivers = new List<IEventReceiver>();
        public static void Publish<T>(T arg) where T : EventArgs
        {
            foreach (var receiver in _receivers)
            {
                receiver.Receive(arg);
            }
        }

        public static void Subscribe(IEventReceiver subscriber)
        {
            _receivers.Add(subscriber);
        }
    }
}
