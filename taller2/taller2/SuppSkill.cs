using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    class SuppSkill : carta
    {

        private int et;
        private int ep;

        public int Et { get => et; private set => et = value; }
        public int Ep { get => ep; private set => ep = value; }
    }
}
