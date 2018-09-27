using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    [Serializable]
    public struct Address
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }

        public Address(string Street, string City, string Province, string PostalCode)
        {
            this.Street = Street;
            this.City = City;
            this.Province = Province;
            this.PostalCode = PostalCode;
        }


    }
    [Serializable]
    public class Club
    {
        int clubNumber = clubNumberValue;
        string name;
        Address address;
        long phoneNumber = 0;
        public static int clubNumberValue = 4;
        Coach coach;


        static List<string> clubNames = new List<string>();
        static int clubNamesLength = clubNames.Count + 1;
        // static int i = 0;
        public Registrant[] clubMembers = new Registrant[20];
        int count = 0;

        public Club()
        {
            clubNumberValue++;
        }
        public Club(string name)
        {
            Name = name;
        }
        public Club(int clubNumber, string name, Address address, long phoneNumber)
        {
            ClubNumber = clubNumber;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;

        }

        public Club(string name, Address address, long phoneNumber)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public int ClubNumber
        {
            set
            {
                clubNumber = value;
                clubNumberValue++;

            }
            get
            {
                return clubNumber;
            }

        }

        public string Name
        {
            set
            {
                name = value;
                clubNames.Add(name);
                // i++;
                // Array.Resize<string>(ref clubNames, clubNamesLength);
                // clubNamesLength++;
            }
            get
            {
                return name;
            }

        }

        public Address Address
        {
            set
            {
                address = value;
            }
            get
            {
                return address;
            }

        }

        public long PhoneNumber
        {
            set
            {
                string numberString = Convert.ToString(value);
                int numberLength = numberString.Length;

                if (numberLength == 10)
                {
                    phoneNumber = value;
                }

                else
                {
                    //Console.WriteLine("Invalid phone number. Please check.");
                    phoneNumber = 0;
                }
            }
            get
            {
                return phoneNumber;
            }

        }

        public Coach Coach
        {
            set
            {
                coach = value;
            }
            get
            {
                return coach;
            }
        }

        public void AddCoach(Coach coach)
        {
            Coach = coach;
            coach.Club = new Club(this.ClubNumber, this.Name, this.Address, this.PhoneNumber);
        }


        public override string ToString()
        {
            Coach c1 = new Coach();
            if (Coach == null)
                c1.Name = "";
            else
                c1.Name = coach.Name;

            string result = $"Name: {name}\nAddress: {address.Street}, {address.City}, {address.Province}, {address.PostalCode}\nTelephone Number: {phoneNumber}\nRegistration Number: {clubNumber}\nSwimmmers:\n {ClubMembers()}\nCoaches: {c1.Name}\n";
            return result;
        }


        public void AddSwimmer(Registrant swimmer)
        {
            if (swimmer.Club.name != "not assigned")
            {
                throw (new Exception(String.Format($"Swimmer already assigned to {swimmer.Club.Name} Club;")));
            }
            else
            {
                swimmer.Club.name = name;
                clubMembers[count] = swimmer;
                count++;
            }
        }

        public string ClubMembers()
        {
            string result = "";
            for (int i = 0; i < clubMembers.Length; i++)
            {
                if (clubMembers[i] == null)
                {
                    break;
                }
                else
                    result = result + $"          {clubMembers[i].Name}\n";

            }
            return result;
        }
    }
}
