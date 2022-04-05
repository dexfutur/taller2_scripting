using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class SupportSkill : Card
    {

        private string effectType;
        private int effectPoints;

        public SupportSkill(string effectType, int effectPoints, string name, string rarity, int costPoint, string type) : base(name, rarity, costPoint, type)
        {
            this.effectType = effectType;
            this.effectPoints = effectPoints;
        }

        public string EffectType { get => effectType; set => effectType = value; }
        public int EffectPoints { get => effectPoints; set => effectPoints = value; }
    }
}
