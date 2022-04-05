using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class Card
    {
        private string name;
        private string rarity;
        private int costPoint;
        private string type;

        public Card(string name, string rarity, int costPoint, string type)
        {
            this.name = name;
            this.rarity = rarity;
            this.costPoint = costPoint;
            this.type = type;
        }

        public string Name { get => name; set => name = value; }
        public string Rarity { get => rarity; set => rarity = value; }
        public int CostPoint { get => costPoint; set => costPoint = value; }

        public string Type { get => type; set => type = value; }
    }
}
