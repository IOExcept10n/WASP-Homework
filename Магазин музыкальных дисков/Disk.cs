using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Disk : IStoreItem
    {
        private string name;
        protected string genre;
        protected int burnCount;

        public Disk(string name, string genre)
        {
            this.Name = name;
            this.genre = genre;
        }

        public virtual int DiskSize { get; }
        public double Price { get; set; }
        public string Name { get => name; set => name = value; }//Тоже создаю свойство, потому что оно используется в задаче.

        public virtual void Burn(params string[] values)
        {

        }

        public void DiscountPrice(int percent)
        {
            Price -= Price * (percent / 100.0);
        }
    }
}
