using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace taller2
{
    public class Program
    {
        

        List<carta> listCards = new List<carta>();
        List<Deck> listDeck = new List<Deck>();
        List<Player> listPlayers = new List<Player>();
        List<Character> listCharacters = new List<Character>();
        List<Equip> listEquips = new List<Equip>();
        List<SuppSkill> listSupport = new List<SuppSkill>();
        static void Main(string[] args)     {}

        public Character generateCardCharacter(string name, string rarity, int costPoints, int attackPoints, int resistPoints, Equip equip, string affinity)
        {
            Character cardCharacter = new Character(attackPoints, resistPoints, equip,  affinity, name, rarity, costPoints, type: "Character");

            return cardCharacter;
        }

        public Equip generateCardEquip(string name, string rarity, int costPoints, string targetAttribute, int effectPoints, string affinity)
        {
            Equip cardEquip = new Equip(targetAttribute, effectPoints, affinity, name, rarity, costPoints, type: "Equip");

            return cardEquip;
        }

        public SuppSkill generateCardSupport(String name, string rarity, int costPoints, string effectType, int effectPoints)
        {
            SuppSkill cardSupport = new SuppSkill(effectType, effectPoints, name, rarity, costPoints, type: "Support Skill");
            return cardSupport;
        }


        public string addCardToDeck(carta card, int costPoint)
        {

            if (listDeck.Count == 0)
            {
                costPointOfDeck(costPoint);

            }


            if (listDeck[0].CostPoints > card.CostPoint || listDeck[0].CostPoints == card.CostPoint)

            {
                int countCharacter = 0;
                int countEquip = 0;
                int countSupport = 0;

                for (int i = 0; i < listCards.Count; i++)
                {
                    if (listCards[i].Type.CompareTo("Character") == 0)
                    {

                        countCharacter++;
                        if (countCharacter == 5)
                        {
                            return "La baraja no puede tener mas de 5 cartas Character";
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (listCards[i].Type.CompareTo("Equip") == 0)
                    {
                        countEquip++;
                        if (countEquip == 10)
                        {
                            return "La baraja no puede tener mas 10 cartas Equip";
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else if (listCards[i].Type.CompareTo("Support Skill") == 0)
                    {
                        countSupport++;
                        if (countSupport == 5)
                        {
                            return "La baraja no puede tener mas de 5 cartas Support Skill";
                        }
                        else
                        {
                            continue;
                        }
                    }
                }

                listCards.Add(card);
                listDeck[0].CostPoints = listDeck[0].CostPoints - card.CostPoint;
                return "carta introducida a la baraja";
               
            }

            else
            {
                return "La cantidad de costPoint de tu baraja es inferior a los costPoints de la carta que intentas añadir";
            }

            return "Error, no cumple ninguna condición";

        }

        public void addCardCharacter(Character card)
        {
            listCharacters.Add(card);

        }
        public void addCardEquip(Equip card)
        {
            listEquips.Add(card);

        }
        public void addCardSupport(SuppSkill card)
        {
            listSupport.Add(card);

        }

        public void deleteList()
        {
            for (int i = 0; i < listCards.Count; i++)
            {
                listCards.RemoveAt(i);
            }
        }

        public int sizeOfDeck()
        {
            return listCards.Count;
        }

        public void costPointOfDeck(int costPoint)
        {
            Deck deck = new Deck(costPoint);
            listDeck.Add(deck);
            return;
        }

        public int confrontCharacters(Character attackCard, Character defenseCard)
        {
            if (attackCard.AttackPoints == defenseCard.ResistPoints)
            {
                if (attackCard.ResistPoints == defenseCard.AttackPoints)
                {
                    if (attackCard.Affinity.CompareTo("Knight") == 0 && defenseCard.Affinity.CompareTo("Mage") == 0
                        || attackCard.Affinity.CompareTo("Mage") == 0 && defenseCard.Affinity.CompareTo("Undead") == 0
                        || attackCard.Affinity.CompareTo("Undead") == 0 && defenseCard.Affinity.CompareTo("Knight") == 0)
                    {
                        attackCard.AttackPoints = attackCard.AttackPoints + 1;
                        defenseCard.ResistPoints = defenseCard.ResistPoints - 1;
                        return 0;

                    }
                    else if (attackCard.Affinity.CompareTo("Knight") == 0 && defenseCard.Affinity.CompareTo("Undead") == 0
                            || attackCard.Affinity.CompareTo("Undead") == 0 && defenseCard.Affinity.CompareTo("Mage") == 0
                            || attackCard.Affinity.CompareTo("Mage") == 0 && defenseCard.Affinity.CompareTo("Knight") == 0)
                    {
                        defenseCard.AttackPoints = defenseCard.AttackPoints + 1;
                        attackCard.ResistPoints = attackCard.ResistPoints - 1;
                        return 0;
                    }
                }
                else
                {

                    return -1;
                }
            }
            else if (attackCard.AttackPoints < defenseCard.ResistPoints)
            {
                int result = defenseCard.ResistPoints - attackCard.AttackPoints;
                defenseCard.ResistPoints = result;
                return defenseCard.ResistPoints;
            }
            else
            {

                return -1;
            }
            return 1;



        }

        public bool deleteCharacter(string nameOfPlayer, string nameOfCharacter)
        {
            for (int i = 0; i < listPlayers.Count; i++)
            {
                if (listPlayers[i].Name == nameOfPlayer)
                {
                    for (int x = 0; x < listPlayers[i].getCardsCharacter().Count; x++)
                    {
                        if (listPlayers[i].getCardsCharacter()[x].Name == nameOfCharacter)
                        {
                            listPlayers[i].getCardsCharacter().RemoveAt(x);
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        public void sendListCharactertToPlayer(Player player)
        {

            for (int i = 0; i < listCharacters.Count; i++)
            {
                player.createDeckCharacter(listCharacters[i]);
            }
        }

        public void deleteListCharacters()
        {
            for (int i = 0; i < listCharacters.Count; i++)
            {
                listCharacters.RemoveAt(i);
            }
        }

        public void sendListEquiptToPlayer(Player player)
        {

            for (int i = 0; i < listEquips.Count; i++)
            {
                player.createDeckEquip(listEquips[i]);
            }
        }

        public void deleteListEquip()
        {
            for (int i = 0; i < listEquips.Count; i++)
            {
                listEquips.RemoveAt(i);
            }
        }

        public bool deletePlayer(string nameOfPlayer)
        {
            for (int i = 0; i < listPlayers.Count; i++)
            {
                if (listPlayers[i].Name == nameOfPlayer)
                {
                    listPlayers.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public void sendListSupportToPlayer(Player player)
        {

            for (int i = 0; i < listSupport.Count; i++)
            {
                player.createDeckSupport(listSupport[i]);
            }
        }

        public void deleteListSupport()
        {
            for (int i = 0; i < listSupport.Count; i++)
            {
                listSupport.RemoveAt(i);
            }
        }

        public Player createPlayer(string name)
        {
            Player player = new Player(name);
            return player;
        }

        public void savePlayer(Player player)
        {
            listPlayers.Add(player);
        }

        public List<Player> getPlayerList()
        {
            return listPlayers;
        }

        public bool useCardSupport(Player player1, Player player2, int index)
        {
            string effect = player1.getCardsSupport()[index].EffectType;

            if (effect == "DestroyEquip")
            {
                if (deleteCardEquip(player2.getCardsEquip()))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else if (effect == "ReduceAP")
            {
                player2.getCardsCharacter()[0].AttackPoints = player2.getCardsCharacter()[0]
                    .AttackPoints - player1.getCardsSupport()[index].EffectPoints;

                return true;
            }
            else if (effect == "ReduceRP")
            {
                player2.getCardsCharacter()[0].ResistPoints = player2.getCardsCharacter()[0]
                    .ResistPoints - player1.getCardsSupport()[index].EffectPoints;

                if (player2.getCardsCharacter()[0].ResistPoints == 0)
                {
                    deleteCharacter(player2.Name, player2.getCardsCharacter()[0].Name);

                }
                return true;
            }
            else if (effect == "ReduceALL")
            {
                player2.getCardsCharacter()[0].AttackPoints = player2.getCardsCharacter()[0]
                    .AttackPoints - player1.getCardsSupport()[index].EffectPoints;
                player2.getCardsCharacter()[0].ResistPoints = player2.getCardsCharacter()[0]
                    .ResistPoints - player1.getCardsSupport()[index].EffectPoints;
                return true;
            }
            else if (effect == "RestoreRP")
            {
                player1.getCardsCharacter()[index].ResistPoints = player1.getCardsCharacter()[index]
                    .ResistPoints + player1.getCardsSupport()[index].EffectPoints;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool deleteCardEquip(List<Equip> list)
        {
            if (list.Count == 0)
            {
                return true;
            }
            else if (list.Count > 0)
            {
                list.RemoveAt(0);
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<Player> getPlayers()
        {
            return listPlayers;

        }


        // BONUS               

        public string[] cardRaffle()
        {
            var rand = new Random();
            int type = rand.Next(0, 100);
            string rarity = "";
            string typeName = "";
            double rarityAux = rand.NextDouble(); 
            rarityAux = Math.Round(rarityAux, 3); 
            rarityAux = rarityAux * 100;

            if (type <= 20) 
            {
                typeName = "Character";
                if (rarityAux <= 2.5) 
                {
                    rarity = "Ultra Rare";


                }
                else if (rarityAux > 2.5 && rarityAux < 15)
                {
                    rarity = "Super Rare";


                }
                else if (rarityAux >= 15 && rarityAux < 40)
                {
                    rarity = "Rare";


                }
                else if (rarityAux >= 40)
                {
                    rarity = "Common";


                }
            }
            else if (type > 20 && type < 50) 
            {
                typeName = "Equip";
                if (rarityAux <= 1.67)
                {
                    rarity = "Ultra Rare";


                }
                else if (rarityAux > 1.67 && rarityAux < 10)
                {
                    rarity = "Super Rare";


                }
                else if (rarityAux >= 10 && rarityAux < 33.33)
                {
                    rarity = "Rare";


                }
                else if (rarityAux >= 33.33)
                {
                    rarity = "Common";

                }
            }
            else if (type >= 50)
            {
                typeName = "Support Skill";

                if (rarityAux <= 1)
                {
                    rarity = "Ultra Rare";


                }
                else if (rarityAux > 1 && rarityAux < 6)
                {
                    rarity = "Super Rare";


                }
                else if (rarityAux >= 6 && rarityAux < 26)
                {
                    rarity = "Rare";


                }
                else if (rarityAux >= 26)
                {
                    rarity = "Common";

                }
            }
            string[] array = new string[] { rarity, typeName };
            return array;
        }
    }
}
