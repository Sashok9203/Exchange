using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    internal class Exchange
    {
        private readonly int maxUp, maxDown, ticksMinEvent, ticksMaxEvent;
        private int currentTicksMin, currentTicksMax;
        private Random random;

        public int CurrentPrice { get; private set; }
        public event Action<int> MaximumEvent;
        public event Action<int> MinimumEvent;

        public Exchange(int maxUp, int maxDown, int ticksMinEvent,int ticksMaxEvent, int currentPrice )
        {
            this.maxUp = maxUp;
            this.maxDown = maxDown;
            this.ticksMaxEvent = ticksMaxEvent;
            this.ticksMinEvent = ticksMinEvent;
            CurrentPrice = currentPrice;
            currentTicksMin = 0;
            currentTicksMax = 0;
            random = new Random();
        }

        public void Tick()
        {
            int tmpPrice = random.Next(maxDown,maxUp + 1);
            CurrentPrice += tmpPrice;
            if (tmpPrice > 0)
            {
                currentTicksMax++;
                if (currentTicksMin == ticksMinEvent)
                   MinimumEvent.Invoke(CurrentPrice);
                currentTicksMin = 0;
            }
            else if (tmpPrice < 0)
            {
                currentTicksMin++;
                if (currentTicksMax == ticksMaxEvent)
                     MaximumEvent.Invoke(CurrentPrice);
                currentTicksMax = 0;
            }
            Thread.Sleep(500);
        }
    }
}
