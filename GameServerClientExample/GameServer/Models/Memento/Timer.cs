using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Memento
{
    public class Timer
    {
        private Oiginator orig = new Oiginator(150);
        private Memento memento = new Memento(150);
        private CareTaker taker = new CareTaker();
        private bool notStarted = true;

        public int GetTime()
        {
            return orig.Timer;
        }

        public void StartTimer()
        {
            orig.startTimer();
        }
        public void ResetTimer()
        {
            orig = new Oiginator(150); ;
        }
        public void MemetnoTimer()
        {
            taker.memento = orig.CreateMemento();
        }
        public void ResetMementoTimer()
        {
            orig.SetMemento(taker.memento);
        }
    }
}
