using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Coach : Registrant
    {
        string credentials;
        List<Swimmer> swimmers = new List<Swimmer>();

        new static int numberValue = 6;
        public Coach()
        { }

        public Coach(string name, DateTime dateOfBirth, Address address, long phoneNumber) : base(name, dateOfBirth, address, phoneNumber)
        {
            RegistrationNumber = numberValue;
            numberValue++;
        }

        public string Credentials
        {
            set
            {
                credentials = value;
            }
            get
            {
                return credentials;
            }
        }

        public void AddSwimmer(Swimmer swimmer)
        {
            if (Club.Name == "not assigned")
            {
                throw new Exception(String.Format("Coach is not assigned to a club"));
            }
            if (swimmer.Club.Name != Club.Name)
            {
                throw new Exception(String.Format("Swimmer and Coach not in the same club"));
            }
            swimmers.Add(swimmer);
        }

        public override string ToString()
        {
            return base.ToString() + $"\nCredentials: {Credentials}\nSwimmers: {Swimmers()}";
        }

        public string Swimmers()
        {
            string result = "";
            for (int i = 0; i < swimmers.Count; i++)
            {
                result = result + $"\n             {swimmers[i].Name}";
            }
            return result;
        }
    }
}
