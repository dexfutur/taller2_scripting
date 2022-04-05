using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class Character : Card
    {
        private int attackPoints;
        private int resistPoints;
        private Equip equip;
        private string affinity;
        private string type = "Character";

        public Character(int attackPoints, int resistPoints, Equip equip, string affinity, string name, string rarity, int costPoint, string type) : base(name, rarity, costPoint, type)
        {
            this.attackPoints = attackPoints;
            this.resistPoints = resistPoints;
            this.equip = equip;
            this.affinity = affinity;
        }

        public int AttackPoints { get => attackPoints; set => attackPoints = value; }
        public int ResistPoints { get => resistPoints; set => resistPoints = value; }
        public string Affinity { get => affinity; set => affinity = value; }
        internal Equip Equip { get => equip; set => equip = value; }
    }
}
