using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Assignment1
{
    [Serializable]
    public class Registrant
    {
        int registrationNumber = numberValue;
        string name;
        DateTime dateOfBirth;
        Address address;
        long phoneNumber;

        public static int numberValue = 1;
        Club club = new Club("not assigned");


        public Registrant()
        {
            numberValue++;
        }

        public Registrant(string name, DateTime dateOfBirth, Address address, long phoneNumber)
        {
            numberValue++;
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
        }

        public Registrant(int registrationNumber, string name, DateTime dateOfBirth, Address address, long phoneNumber)
        {
            this.registrationNumber = registrationNumber;
            Name = name;
            DateOfBirth = dateOfBirth;
            Address = address;
            PhoneNumber = phoneNumber;
        }
        public int RegistrationNumber
        {
            set
            {
                numberValue++;
                registrationNumber = value;
            }
            get
            {
                return registrationNumber;
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

        public DateTime DateOfBirth
        {
            set
            {
                dateOfBirth = value;
            }
            get
            {
                return dateOfBirth;
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
                phoneNumber = value;
                //string numberString = Convert.ToString(value);
                //int numberLength = numberString.Length;

                //if (numberLength == 10)
                //{
                //    phoneNumber = value;
                //}

                //else
                //{
                //   // Console.WriteLine("Invalid phone number. Please check.");
                //    phoneNumber = 0;
                //}
            }
            get
            {
                return phoneNumber;
            }

        }

        public Club Club
        {
            set
            {
                if (club.Name != "not assigned")
                {
                    throw new Exception(String.Format($"Swimmer already assigned to {club.Name} \n"));
                }
                else
                    club = value;
                club.AddSwimmer(new Registrant(registrationNumber, name, dateOfBirth, address, phoneNumber));
            }
            get
            {
                return club;
            }
        }

        public virtual void AddAsBestTime(PoolType course, EventDistance distance, Stroke stroke, TimeSpan time)
        {

        }

        public override string ToString()
        {
            string result = $"Registration Number: {registrationNumber}\nName: {name}\nDate of Birth: {dateOfBirth.Date.ToString("d")}\nAddress: {address.Street}, {address.City}, {address.Province}, {address.PostalCode}\nTelephone Number: {phoneNumber}\nClub: {club.Name}";
            return result;
        }
    }
}
