using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{

    public class Swimmer : Registrant
    {
        private List<TimeSpan> bestTime = new List<TimeSpan>();
        private List<string> events = new List<string>();
        private Coach coach;

        public Swimmer()
        { }
        public Swimmer(string name, DateTime dateOfBirth, Address address, long phoneNumber) : base(name, dateOfBirth, address, phoneNumber)
        { }

        public Swimmer(int regNum, string name, DateTime dateOfBirth, Address address, long phoneNumber) : base(regNum, name, dateOfBirth, address, phoneNumber)
        { }

        public Coach Coach
        {
            set
            {
                if (value.Club.Name == "not assigned")
                {
                    throw new Exception(String.Format("Coach is not assigned to the club"));
                }

                coach = value;
                value.AddSwimmer(new Swimmer { RegistrationNumber = RegistrationNumber, Name = Name, DateOfBirth = DateOfBirth, Address = Address, PhoneNumber = PhoneNumber, Club = Club });

            }
            get
            {
                return coach;
            }

        }

        public TimeSpan GetBestTime(PoolType course, Stroke stroke, EventDistance distance)
        {
            Event e = new Event(distance, stroke);

            int index = events.IndexOf(e.ToString());

            return bestTime[index];
        }

        public override void AddAsBestTime(PoolType course, EventDistance distance, Stroke stroke, TimeSpan time)
        {
            //int index = bestTime.Count;
            Event e = new Event(distance, stroke);
            int index = events.IndexOf(e.ToString());

            if (index == -1)
            {
                events.Add(e.ToString());
                bestTime.Add(time);
            }
            else
            {
                if (bestTime[index] > time)
                {
                    bestTime[index] = time;
                }
            }

        }
        public override string ToString()
        {
            if (Coach == null)
            {
                return base.ToString() + $"\nCoach: not assigned";
            }
            else
                return base.ToString() + $"\nCoach: {Coach.Name}";
        }



    }
}
