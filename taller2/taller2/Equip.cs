using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class Equip : Card
    {
        private string targetAttribute;
        private int effectPoints;
        private string affinity;

        public Equip(string targetAttribute, int effectPoints, string affinity, string name, string rarity, int costPoint, string type) : base(name, rarity, costPoint, type)
        {
            this.targetAttribute = targetAttribute;
            this.effectPoints = effectPoints;
            this.affinity = affinity;
        }

        public string TargetAttibrute { get => targetAttribute; set => targetAttribute = value; }
        public int EffectPoints { get => effectPoints; set => effectPoints = value; }
        public string Affinity { get => affinity; set => affinity = value; }
    }
}
