using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    class Equip : carta
    {
        private int TargetA;
        private int EP;
        private int affinity;

        public int TargetA1 { get => TargetA; set => TargetA = value; }
        public int EP1 { get => EP; set => EP = value; }
        public int Affinity { get => affinity; set => affinity = value; }
    }
}
