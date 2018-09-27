using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment1
{
    public class SwimmersManager : ISwimmersRepository
    {
        private ClubsManager clbMngr;

        public SwimmersManager(ClubsManager clbMngr)
        {
            this.clbMngr = clbMngr;
        }

        Registrant[] swimmers = new Registrant[100];
        int numberOfSwimmers = 0;
        //static int i = 0;

        public SwimmersManager() { }

        public SwimmersManager(Registrant[] swimmers)
        {
            Swimmers = swimmers;
        }

        public Registrant[] Swimmers
        {
            set
            {
                swimmers = value;
                numberOfSwimmers++;
            }
            get
            {
                return swimmers;
            }
        }

        public int Number
        {
            //set
            //{
            //    numberOfClubs++;
            //}
            get
            {
                return numberOfSwimmers;
            }
        }

        public void Add(Registrant swimmer)
        {
            for (int i = 0; i < Swimmers.Length; i++)
            {

                if (swimmers[i] == null)
                {
                    swimmers[i] = swimmer;

                    numberOfSwimmers++;
                    break;
                }

                if (swimmers[i].RegistrationNumber == swimmer.RegistrationNumber)
                {
                    throw new Exception(String.Format($"Invalid swimmer record. Club with the registration number already exists:\n {swimmer.RegistrationNumber}, {swimmer.Name}, {swimmer.Address.Street}, {swimmer.Address.City}, {swimmer.Address.Province}, {swimmer.Address.PostalCode} {swimmer.PhoneNumber}\n "));
                    // break;
                }
                if (swimmer.RegistrationNumber == 0 || swimmer.PhoneNumber == 1234567890 || swimmer.Name == "No" || swimmer.DateOfBirth == new DateTime(1999, 9, 9))
                {
                    throw new Exception(String.Format(""));// String.Format($"Invalid club record Club number is not valid:\n {club.ClubNumber}, {club.Name}, {club.Address.Street}, {club.Address.City}, {club.Address.Province}, {club.Address.PostalCode} {club.PhoneNumber} \n"));
                }

            }
        }

        public Club GetByRegNum(int registrationNumber)
        {
            Club requiredClub;
            for (int i = 0; i < clbMngr.Clubs.Length; i++)
            {
                if (clbMngr.Clubs[i] == null)
                {
                    break;
                }
                if (clbMngr.Clubs[i].ClubNumber == registrationNumber)
                {
                    requiredClub = clbMngr.Clubs[i];
                    return requiredClub;
                }
            }
            return null;

        }

        public void Load(string fileName, string delimiter)
        {
            char delim = Convert.ToChar(delimiter);

            FileStream inFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(inFile);
            string recordIn;
            string[] fields;

            recordIn = reader.ReadLine();
            while (recordIn != null)
            {

                fields = recordIn.Split(delim);
                Registrant c1 = new Registrant();
                Registrant.numberValue = 0;
                try
                {
                    if (fields[0] == "")
                    {
                        throw new Exception();//String.Format($"Invalid swimmer record. Invalid Swimmer Name:\n {fields[0]}, {fields[1]}, {fields[2]}, {fields[3]}, {fields[4]}, {fields[5]}, {fields[6]}"));
                    }

                    c1.RegistrationNumber = Convert.ToInt32(fields[0]);
                }
                catch (Exception)
                {
                    c1.RegistrationNumber = 0;
                    Console.WriteLine($"Invalid swimmer record.Invalid Registration Number:\n { fields[0]}, { fields[1]}, { fields[2]}, { fields[3]}, { fields[4]}, { fields[5]}, { fields[6]}, {fields[7]}, {fields[8]}");
                }


                try
                {
                    if (fields[1] == "")
                    {
                        c1.Name = "No";
                        throw new Exception(String.Format($"Invalid swimmer record.Invalid Swimmer Name:\n { fields[0] }, { fields[1]}, { fields[2]}, { fields[3]}, { fields[4]}, { fields[5]}, { fields[6]}, {fields[7]}, {fields[8]}"));
                    }
                    c1.Name = fields[1];

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    c1.DateOfBirth = Convert.ToDateTime(fields[2]);

                }
                catch (Exception)
                {
                    c1.DateOfBirth = new DateTime(1999, 9, 9);
                    Console.WriteLine($"Invalid swimmer record. BirthDate is Invalid:\n {fields[0]}, {fields[1]}, {fields[2]}, {fields[3]}, {fields[4]}, {fields[5]}, {fields[6]}, {fields[7]}, {fields[8]}");
                }

                c1.Address = new Address { Street = fields[3], City = fields[4], Province = fields[5], PostalCode = fields[6] };

                try
                {
                    c1.PhoneNumber = Convert.ToInt64(fields[7]);
                    if (fields[7] == "")
                    {
                        throw new Exception(String.Format($"No value  entered. It is a mandatory field."));
                    }
                }
                catch (System.FormatException)
                {
                    c1.PhoneNumber = 1234567890;
                    Console.WriteLine($"Invalid club record. Phone number wrong format:\n  {fields[0]}, {fields[1]}, {fields[2]}, {fields[3]}, {fields[4]}, {fields[5]}, {fields[6]}, {fields[7]}, {fields[8]} ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                try
                {
                    c1.Club = GetByRegNum(Convert.ToInt32(fields[8]));
                }
                catch (Exception)
                {
                    Club c = new Club("not assigned");
                    c1.Club = c;
                    Console.Write("");
                }

                recordIn = reader.ReadLine();
                try
                {
                    Add(c1);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            reader.Close();
            inFile.Close();
        }

        public void Save(string fileName)
        {
            Registrant c1 = new Registrant();
            FileStream outFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter bFormatter = new BinaryFormatter();

            // c1.ClubNumber = Convert.ToInt32(Console.ReadLine());

            int i = 0;
            while (swimmers[i] != null)
            {
                c1 = swimmers[i];
                bFormatter.Serialize(outFile, c1);
                i++;
            }
            outFile.Close();



        }

        public void Load(string fileName)
        {
            FileStream inFile = null;
            BinaryFormatter bFormatter = new BinaryFormatter();
            Registrant c1 = new Registrant();
            try
            {
                inFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);


                while (inFile.Position < inFile.Length)
                {
                    c1 = (Registrant)bFormatter.Deserialize(inFile);
                    Add(c1);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                inFile.Close();
            }

        }

        public void Save(string fileName, string delimiter)
        { }
    }
}