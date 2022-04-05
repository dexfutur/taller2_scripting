using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class Player
    {
        private string name;
        List<Character> character = new List<Character>();
        List<Equip> equip = new List<Equip>();
        List<SupportSkill> support = new List<SupportSkill>();

        public Player(string name)
        {
            this.name = name;
        }

        public string Name { get => name; set => name = value; }


        public void createDeckCharacter(Character card)
        {
            character.Add(card);

        }
        public void createDeckEquip(Equip card)
        {
            equip.Add(card);
        }
        public void createDeckSupport(SupportSkill card)
        {
            support.Add(card);
        }

        public List<Character> getCardsCharacter()
        {
            return character;
        }

        public List<Equip> getCardsEquip()
        {
            return equip;

        }

        public List<SupportSkill> getCardsSupport()
        {
            return support;
        }


    }
}
