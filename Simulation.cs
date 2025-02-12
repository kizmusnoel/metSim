using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Meteorology_Sim
{
    
    internal class Simulation
    {
        Random rnd = new Random();
        public DateTime Time { get; private set; } = DateTime.MinValue;

        public List<Tile> Tiles { get; private set; } = new List<Tile>();

        public int Size { get;}

        public Simulation(int size)
        {
            Size = size;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Tiles.Add(new Tile());
                }
            }
        }

        public void RandomizeTiles()
        {
            for (int i = 0; i < Tiles.Count; i++)
            {
                Tiles[i].State = "";
            }
        }
    }
}
