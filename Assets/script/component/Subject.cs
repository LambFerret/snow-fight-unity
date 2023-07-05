using System.Collections.Generic;
using UnityEngine;

namespace script.component
{
    public abstract class Subject : MonoBehaviour
    {
        private readonly List<IObserver> _observers = new();

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        protected void NotifyObservers()
        {
            _observers.ForEach(observer => observer.OnNotify());
        }
    }
}