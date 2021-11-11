using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Store
    {
        string storeName;
        string address;
        List<Audio> audios;
        List<DVD> dvds;

        public List<DVD> Dvds { get => dvds; set => dvds = value; }//Создаю свойства, чтобы можно было потом выывести список дисков (по последней части задания)
        public List<Audio> Audios { get => audios; set => audios = value; }

        public Store(string name, string address)
        {
            storeName = name;
            this.address = address;
            audios = new List<Audio>();
            dvds = new List<DVD>();
        }

        public static Store operator +(Store left, Audio right)
        {
            left.Audios.Add(right);
            return left;
        }

        public static Store operator -(Store left, Audio right)
        {
            left.Audios.Remove(right);
            return left;
        }

        public static Store operator +(Store left, DVD right)
        {
            left.Dvds.Add(right);
            return left;
        }

        public static Store operator -(Store left, DVD right)
        {
            left.Dvds.Remove(right);
            return left;
        }

        public override string ToString()
        {
            string output = $"Store \"{storeName}\", {address}\nAudio list:\n";
            foreach (Audio audio in Audios)
            {
                output += audio + "\n";
            }
            output += "DVD list:";
            foreach (DVD dvd in Dvds)
            {
                output += dvd + "\n";
            }
            return output.Trim('\n');//Чтобы лишний enter убрать.
        }
    }
}
