using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.GameObserver
{
    public abstract class Subject
    {
        private List<Observer> observerList;

        public Subject()
        {
            observerList = new List<Observer>();
        }

        public void Attach(Observer observer)
        {
            this.observerList.Add(observer);
        }

        public void Detach(Observer observer)
        {
            this.observerList.Remove(observer);
        }

        public void Notify(MapObjectStub mapObject)
        {
            foreach (Observer observer in observerList)
            {
                observer.Update(mapObject);
            }
        }
        public int Count()
        {
            return this.observerList.Count;
        }
    }
}