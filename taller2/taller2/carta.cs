using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class carta
    {
        private int name;
        private int rarity;
        private int cp;

        public int Name { get => name; private set => name = value; }
        public int Rarity { get => rarity; private set => rarity = value; }
        public int Cp { get => cp; private set => cp = value; }
    }
}
