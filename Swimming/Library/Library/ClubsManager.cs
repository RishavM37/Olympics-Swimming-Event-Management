using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Assignment1
{
    [Serializable]
    public class ClubsManager : IClubsRepository
    {
        Club[] clubs = new Club[100];
        int numberOfClubs = 0;
        //static int i = 0;

        public ClubsManager() { }

        public ClubsManager(Club[] clubs)
        {
            Clubs = clubs;
        }

        public Club[] Clubs
        {
            set
            {
                clubs = value;
                numberOfClubs++;
            }
            get
            {
                return clubs;
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
                return numberOfClubs;
            }
        }

        public void Add(Club club)
        {
            for (int i = 0; i < clubs.Length; i++)
            {

                if (clubs[i] == null)
                {
                    clubs[i] = club;

                    numberOfClubs++;
                    break;
                }

                if (clubs[i].ClubNumber == club.ClubNumber)
                {
                    throw new Exception(String.Format($"Invalid club record. Club with the registration number already exists:\n {club.ClubNumber}, {club.Name}, {club.Address.Street}, {club.Address.City}, {club.Address.Province}, {club.Address.PostalCode} {club.PhoneNumber}\n "));
                    // break;
                }
                if (club.ClubNumber == 0 || club.PhoneNumber == 1234567890 || club.Name == "No")
                {
                    throw new Exception(String.Format(""));// String.Format($"Invalid club record Club number is not valid:\n {club.ClubNumber}, {club.Name}, {club.Address.Street}, {club.Address.City}, {club.Address.Province}, {club.Address.PostalCode} {club.PhoneNumber} \n"));
                }

            }
        }

        public Club GetByRegNum(int clubNumber)
        {
            Club requiredClub;
            for (int i = 0; i < clubs.Length; i++)
            {
                if (clubs[i] == null)
                {
                    break;
                }
                if (clubs[i].ClubNumber == clubNumber)
                {
                    requiredClub = clubs[i];
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
                Club c1 = new Club();
                Club.clubNumberValue = 3;
                try
                {
                    if (fields[0] == "")
                    {
                        throw new Exception(String.Format($"Invalid club record. Club with the registration number already exists:\n {fields[0]}, {fields[1]}, {fields[2]}, {fields[3]}, {fields[4]}, {fields[5]}, {fields[6]}"));
                    }
                    c1.ClubNumber = Convert.ToInt32(fields[0]);
                }
                catch (Exception ex)
                {
                    c1.ClubNumber = 0;
                    Console.WriteLine(ex.Message);
                }

                try
                {
                    if (fields[1] == "")
                    {
                        c1.Name = "No";
                        throw new Exception(String.Format("No value entered. It is a mandatory field"));
                    }
                    c1.Name = fields[1];

                }
                catch (Exception)
                {

                    throw;
                }
                c1.Address = new Address { Street = fields[2], City = fields[3], Province = fields[4], PostalCode = fields[5] };

                try
                {
                    c1.PhoneNumber = Convert.ToInt64(fields[6]);
                    if (fields[6] == "")
                    {
                        throw new Exception(String.Format($"No value  entered. It is a mandatory field."));
                    }
                }
                catch (System.FormatException)
                {
                    c1.PhoneNumber = 1234567890;
                    Console.WriteLine($"Invalid club record. Phone number wrong format:\n  {fields[0]}, {fields[1]}, {fields[2]}, {fields[3]}, {fields[4]}, {fields[5]}, {fields[6]} ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
            Club c1 = new Club();
            FileStream outFile = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryFormatter bFormatter = new BinaryFormatter();

            // c1.ClubNumber = Convert.ToInt32(Console.ReadLine());

            int i = 0;
            while (clubs[i] != null)
            {
                c1 = clubs[i];
                bFormatter.Serialize(outFile, c1);
                i++;
            }
            outFile.Close();



        }

        public void Load(string fileName)
        {
            FileStream inFile = null;
            BinaryFormatter bFormatter = new BinaryFormatter();
            Club c1 = new Club();
            try
            {
                inFile = new FileStream(fileName, FileMode.Open, FileAccess.Read);


                while (inFile.Position < inFile.Length)
                {
                    c1 = (Club)bFormatter.Deserialize(inFile);
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
