using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class DVD : Disk
    {
        protected string producer;
        protected string filmCompany;
        protected int minutesCount;

        public DVD(string producer, string company, int minutes, string name, string genre) : base(name, genre)
        {
            this.producer = producer;
            filmCompany = company;
            minutesCount = minutes;
        }

        public override int DiskSize => (minutesCount / 64) * 2;

        public override void Burn(params string[] values)
        {
            producer = values[0];
            filmCompany = values[1];
            minutesCount = int.Parse(values[2]);
            Name = values[3];
            genre = values[4];
            burnCount++;
        }

        public override string ToString()
        {
            return $"DVD \"{Name}\", genre: {genre}, producer: {producer}, company: {filmCompany}, minutes: {minutesCount}, burns: {burnCount}";
        }
    }
}
