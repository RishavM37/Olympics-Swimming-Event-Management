using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Swim
    {
        TimeSpan timeSwam = new TimeSpan(0, 0, 0);
        int heat = 0;
        int lane = 0;

        public Swim() { }
        public Swim(TimeSpan timeSwan, int heat, int lane)
        {
            TimeSwam = TimeSwam;
            Heat = Heat;
            Lane = Lane;
        }
        public TimeSpan TimeSwam
        {
            set
            {
                timeSwam = value;
            }
            get
            {
                return timeSwam;
            }
        }

        public int Heat
        {
            set
            {
                heat = value;
            }
            get
            {
                return heat;
            }
        }

        public int Lane
        {
            set
            {
                lane = value;
            }
            get
            {
                return lane;
            }
        }

        public override string ToString()
        {
            string result = $"H{heat}L{lane} Time: {timeSwam.ToString(@"mm\:ss\.ff")}";
            if (timeSwam == new TimeSpan(0, 0, 0))
            {
                 result = $"H{heat}L{lane} Time: no time";
            }
            if (heat == 0 && lane == 0 && timeSwam == new TimeSpan(0, 0, 0))
            {
                result = "not seeded/no swim";
            }
            return result;

        }
    }
}
