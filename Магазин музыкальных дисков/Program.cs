using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Store store = new Store("My music store", "Chelyabinsk, Lenin av., 12");
            Audio temp1 = new Audio("Nirvana", "DGC Records", 20, "Nevermind", "Rock");
            Audio temp2 = new Audio("Linkin Park", "WB Records", 12, "Meteora", "Alternative");
            Audio temp3 = new Audio("Queen", "Rocksfield", 15, "News of the world", "Rock");
            store += temp1;
            store += temp2;
            store += temp3;
            DVD temp4 = new DVD("George Lucas", "Lucasfilm", 121, "Star Wars 4: New Hope", "Fantastic");
            DVD temp5 = new DVD("David Yates", "Warner Bros. pictures", 138, "Harry Potter and the Order of the Phoenix", "Fantasy");
            store += temp4;
            store += temp5;
            Console.WriteLine(store);//ToString она сама сделает
            temp3.Burn("Metallica", "Elektra", "12", "Metallica", "Metal");
            store.Audios.ForEach(x => Console.WriteLine($"{x.Name} -> {x.DiskSize}"));
            store.Dvds.ForEach(x => Console.WriteLine($"{x.Name} -> {x.DiskSize}"));
        }
    }
}
