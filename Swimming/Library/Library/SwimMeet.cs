using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public enum PoolType { SCM, SCY, LCM };
    public class SwimMeet
    {
        DateTime startDate;
        DateTime endDate;
        string name;
        PoolType poolType;
        readonly int noOfLanes = 8;

        public List<Event> events = new List<Event>();
        int i = 0;

        public SwimMeet(string name, DateTime startDate, DateTime endDate, PoolType poolType, int noOfLanes)
        {
            StartDate = startDate;
            EndDate = endDate;
            Name = name;
            PoolType = poolType;
            this.noOfLanes = noOfLanes;
        }
        public SwimMeet()
        { }
        public DateTime StartDate
        {
            set
            {
                startDate = value;
            }
            get
            {
                return startDate;
            }

        }
        public DateTime EndDate
        {
            set
            {
                endDate = value;
            }
            get
            {
                return endDate;
            }

        }
        public string Name
        {
            set
            {
                name = value;
            }
            get
            {
                return name;
            }

        }

        public PoolType PoolType
        {
            set
            {
                poolType = value;
            }
            get
            {
                return poolType;
            }
        }

        public int NoOfLanes
        {
            // set
            //{
            //    noOfLanes = NoOfLanes;
            //}
            get
            {
                return noOfLanes;
            }
        }

        public void AddEvent(Event addEvent)
        {
            events.Add(addEvent);
            i++;
        }

        public void Seed()
        {

            for (int i = 0; i < events.Count; i++)
            {
                if (events[i] == null)
                {
                    break;
                }
                events[i].Seed(noOfLanes);
            }

        }
        public override string ToString()
        {
            string result = $"Meet Name: {name}\nStart Date: {startDate.Date.ToString("d")}\nEnd Date: {endDate.Date.ToString("d")}\nPooltype: {poolType}\nNo. of Lanes: {NoOfLanes}\nEvents: {Events()}";
            return result;
        }

        public string Events()
        {

            string result = "";
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i] == null)
                {
                    break;
                }
                result = result + events[i].ToString();
            }
            return result;
        }

    }

}


