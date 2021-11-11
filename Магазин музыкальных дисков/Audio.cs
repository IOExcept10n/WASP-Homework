using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    public class Audio : Disk
    {
        protected string artist;
        protected string recordingStudio;
        protected int songsNumber;

        public Audio(string artist, string recordingStudio, int songsNumber, string name, string genre) : base(name, genre)
        {
            this.artist = artist;
            this.recordingStudio = recordingStudio;
            this.songsNumber = songsNumber;
        }

        public override int DiskSize { get => songsNumber * 8;  }

        public override void Burn(params string[] values)
        {   
            artist = values[0];
            recordingStudio = values[1];
            songsNumber = int.Parse(values[2]);
            Name = values[3];
            genre = values[4];
            burnCount++;
        }

        public override string ToString()
        {
            return $"Disk \"{Name}\", genre: {genre}, artist: {artist}, studio: {recordingStudio}, songs: {songsNumber}, burns: {burnCount}";
        }
    }
}
