using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    public enum EventDistance { _50 = 50, _100 = 100, _200 = 200, _400 = 400, _800 = 800, _1500 = 1500 };
    public enum Stroke { Butterfly, Backstroke, Breaststroke, Freestyle, Indvidual_Medley };

    public class Event
    {
        EventDistance distance;
        Stroke stroke;

        public List<Registrant> swimmers = new List<Registrant>();
        // int indexer = 0;
        public List<Swim> swims = new List<Swim>();

        public Event() { }
        public Event(EventDistance distance, Stroke stroke)
        {
            Distance = distance;
            Stroke = stroke;
        }
        public EventDistance Distance
        {
            set
            {
                distance = value;
            }
            get
            {
                return distance;
            }
        }

        public Stroke Stroke
        {
            set
            {
                stroke = value;
            }
            get
            {
                return stroke;
            }
        }


        public void AddSwimmer(Registrant swimmer)
        {
            for (int i = 0; i < swimmers.Count && swimmers[i] != null; i++)
            {
                if (swimmers[i].Name == swimmer.Name || swimmers[i].RegistrationNumber == swimmer.RegistrationNumber)
                {
                    throw (new Exception(String.Format($"Swimmer {swimmer.Name}, {swimmer.RegistrationNumber} has already entered")));
                }
            }

            swimmers.Add(swimmer);
            swims.Add(new Swim());
            //indexer++;
        }

        public void EnterSwimmersTime(Registrant swimmer, string time)
        {
            int index = swimmers.IndexOf(swimmer);
            
            time = "0:" + time;
            try
            {
                swims[index].TimeSwam = TimeSpan.Parse(time);

            }
            catch (Exception)
            {
                Console.WriteLine("Swimmer has not entered the event\n");  
            }
            swimmer.AddAsBestTime(PoolType.SCM, Distance, stroke, TimeSpan.Parse(time));
        }

        public void Seed(int noOfLanes)
        {
            int heat = 1;
            int lane = 1;
            for (int i = 0; i < swimmers.Count; i++)
            {
                if (swimmers[i] == null)
                {
                    break;
                }
                heat = i / noOfLanes + 1;
                swims[i].Heat = heat;

                if (lane > noOfLanes)
                {
                    lane = 1;
                }

                swims[i].Lane = lane;
                lane++;
            }
        }
        public override string ToString()
        {
            string result = $"\n          {(int)distance} - {stroke}\n          Swimmers:\n {Swimmers()}";
            return result;
        }

        public string Swimmers()
        {
            string result = "";
            for (int i = 0; i < swimmers.Count; i++)
            {
                if (swimmers[i] == null)
                {
                    break;
                }
                else
                    result = result + $"          {swimmers[i].Name}\n                    {swims[i].ToString()}\n";

            }
            return result;
        }
    }
}
