using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public interface IClubsRepository
    {
        void Add(Club club);
        Club GetByRegNum(int clubNumber);
        void Load(string fileName, string delimiter);
        void Save(string fileName);
        int Number { get; }

        void Save(string v1, string v2);
    }
}
