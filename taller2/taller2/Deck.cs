using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class Deck
    {
        int costPoints;

        public Deck(int costPoints)
        {

            this.costPoints = costPoints;

        }

        public int CostPoints { get => costPoints; set => costPoints = value; }
    }
}
