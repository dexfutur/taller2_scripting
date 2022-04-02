using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    class Character : carta
    {
        private int ap;
        private int rp;
        
        private Equip equip;
        private int affinity;

        public int Ap { get => ap; private set => ap = value; }
        public int Rp { get => rp; private set => rp = value; }
        public int Affinity { get => affinity; private set => affinity = value; }
        internal Equip Equip { get => equip; private set => equip = value; }
    }
}
