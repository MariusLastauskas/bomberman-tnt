using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameServer.Models.Memento
{
    public class Oiginator
    {
        public int Timer { get; set; }

        public Oiginator(int timer)
        {
            this.Timer = timer;
        }
        public void SetMemento(Memento memento)
        {
            this.Timer = memento.Timer;
        }
        public Memento CreateMemento()
        {
            return new Memento(this.Timer);
        }
        public void startTimer()
        {
            TimerTick();
        }
        public async void TimerTick()
        {
            await Task.Delay(1000);
            Timer = Timer - 1;
            if(Timer <= 0)
            {
                return;
            }
            TimerTick();
        }
    }
}
