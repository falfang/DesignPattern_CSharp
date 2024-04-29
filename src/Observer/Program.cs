using System;
using System.Collections.Generic;
using System.Threading;

namespace Observer
{
    /// <summary>
    /// The Subject owns some important state and notifies observers
    /// when the state changes.
    /// </summary>
    public class Subject : ISubject
    {
        public int State
        {
            get; set;
        } = -0;

        private List<IObserver> _observers = new List<IObserver>();


        /// <summary>
        /// The subscription management method
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer");
            this._observers.Add(observer);
        }

        /// <summary>
        /// The subscription management method
        /// </summary>
        /// <param name="observer"></param>
        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer");
        }


        /// <summary>
        /// Trigger an update in each subscriber
        /// </summary>
        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers ...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }


        public void SomeBusinessLogic()
        {
            Console.WriteLine("\nSubject: I'm doing something important");
            this.State = new Random().Next(0, 10);

            Thread.Sleep(15);

            Console.WriteLine("Subject: My state has just changed to: " + this.State);
            this.Notify();
        }
    }


    class ConcreteObserverA : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State < 3)
            {
                Console.WriteLine("ConcreteObserverA: Reacted to the event");
            }
        }
    }


    class ConcreteObserverB : IObserver
    {
        public void Update(ISubject subject)
        {
            if ((subject as Subject).State == 0 || (subject as Subject).State >= 2)
            {
                Console.WriteLine("ConcreteObserverB: Reacted to the event");
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // The client node
            var subject = new Subject();

            var observerA = new ConcreteObserverA();
            subject.Attach(observerA);

            var observerB = new ConcreteObserverB();
            subject.Attach(observerB);

            subject.SomeBusinessLogic();
            subject.SomeBusinessLogic();

            subject.Detach(observerB);

            subject.SomeBusinessLogic();

            Console.WriteLine("Press any key to exit ...");
            Console.ReadKey();
        }
    }


    /** Output
            Subject: Attached an observer
            Subject: Attached an observer

            Subject: I'm doing something important
            Subject: My state has just changed to: 1
            Subject: Notifying observers ...
            ConcreteObserverA: Reacted to the event

            Subject: I'm doing something important
            Subject: My state has just changed to: 3
            Subject: Notifying observers ...
            ConcreteObserverB: Reacted to the event
            Subject: Detached an observer

            Subject: I'm doing something important
            Subject: My state has just changed to: 0
            Subject: Notifying observers ...
            ConcreteObserverA: Reacted to the event
            Press any key to exit ...
    */
}
