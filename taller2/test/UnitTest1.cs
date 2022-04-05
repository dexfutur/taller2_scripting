using taller2;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        /*Se crea la carta tipo Character correctamente*/
        [Test]
        public void Test1()
        {
            MyApp.Program main = new MyApp.Program();

            taller2.Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 3, targetAttribute: "Ap",
                effectPoints: 6, affinity: "k");



            taller2.Character card = main.generateCardCharacter(name: "a", rarity: "Rare", costPoints: 5,
                attackPoints: 3, resistPoints: 5, equip, affinity: "Knight");

            Assert.AreEqual("Character", card.Type);
        }


        /*Se crea la carta tipo Equip correctamente */
        [Test]
        public void Test2()
        {
            MyApp.Program main = new MyApp.Program();

            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 3, targetAttribute: "Ap",
                effectPoints: 6, affinity: "k");

            Assert.AreEqual("Equip", equip.Type);
        }

        /* Se crea la carta tipo Support correctamente */
        [Test]
        public void Test3()
        {
            MyApp.Program main = new MyApp.Program();

            taller2.SupportSkill support = main.generateCardSupport(name: "a", rarity: "C", costPoints: 4,
                effectType: "ReduceAP", effectPoints: 0);

            Assert.AreEqual("Support Skill", support.Type);
        }


        /* La carta si se agrega a la baraja */
        [Test]
        public void Test4()
        {

            MyApp.Program main = new MyApp.Program();

            taller2.Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 3, targetAttribute: "Ap",
                effectPoints: 6, affinity: "k");

            main.addCardToDeck(equip, costPoint: 100);

            string name = "a";
            string rarity = "rare";
            int costPoint = 5;
            int attackPoints = 3;
            int resistPoints = 5;
            string affinity = "K";

            taller2.Character card = main.generateCardCharacter(name, rarity, costPoint, attackPoints, resistPoints, equip, affinity);
            string response = main.addCardToDeck(card, costPoint: 100);
            Assert.AreEqual("carta introducida a la baraja", response);



        }

        /* la cantidad de cartas Character debe ser hasta 5 */
        [Test]
        public void Test5()
        {
            string response = "";
            MyApp.Program main = new MyApp.Program();
            for (int i = 0; i < 6; i++)
            {

                taller2.Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 3, targetAttribute: "Ap",
              effectPoints: 6, affinity: "k");

                main.addCardToDeck(equip, costPoint: 100);

                taller2.Character card = main.generateCardCharacter(name: "a", rarity: "Rare", costPoints: 5,
                    attackPoints: 3, resistPoints: 5, equip, affinity: "Knight");

                response = main.addCardToDeck(card, costPoint: 100);
            }
            Assert.AreEqual("La baraja no puede tener mas de 5 cartas Character", response);
        }   

        /* la cantidad de cartas Equip debe ser hasta 10 */
        [Test]
        public void Test6()
        {
            string response = "";
            MyApp.Program main = new MyApp.Program();
            for (int i = 0; i < 11; i++)
            {

                taller2.Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 3, targetAttribute: "Ap",
              effectPoints: 6, affinity: "k");



                response = main.addCardToDeck(equip, costPoint: 100);
            }
            Assert.AreEqual("La baraja no puede tener mas 10 cartas Equip", response);
        }

        /* la cantidad de cartas Support Skill debe ser hasta 5*/
        [Test]
        public void Test7()
        {
            string response = "";
            MyApp.Program main = new MyApp.Program();
            for (int i = 0; i < 11; i++)
            {

                taller2.SupportSkill support = main.generateCardSupport(name: "a", rarity: "C", costPoints: 4,
                 effectType: "ReduceAP", effectPoints: 0);



                response = main.addCardToDeck(support, costPoint: 100);
            }
            Assert.AreEqual("La baraja no puede tener mas de 5 cartas Support Skill", response);
        }

        /*Se esta creando la baraja correctamente con la cantidad de datos especificado*/
        [Test]
        public void Test8()
        {

            MyApp.Program main = new MyApp.Program();
            for (int i = 0; i < 5; i++)
            {

                taller2.Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 3, targetAttribute: "Ap",
                             effectPoints: 6, affinity: "k");

                main.addCardToDeck(equip, costPoint: 100);

                taller2.Character card = main.generateCardCharacter(name: "a", rarity: "Rare", costPoints: 5,
                    attackPoints: 3, resistPoints: 5, equip, affinity: "Knight");

                main.addCardToDeck(card, costPoint: 100);
            }

            Assert.AreEqual(10, main.sizeOfDeck());
        }

        /*Se verifica que al ser mayor el cp de la carta al de la baraja no deje introducirla*/
        [Test]
        public void Test9()
        {

            MyApp.Program main = new MyApp.Program();



            taller2.Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 3, targetAttribute: "Ap",
                         effectPoints: 6, affinity: "k");

            main.addCardToDeck(equip, costPoint: 4);

            taller2.Character card = main.generateCardCharacter(name: "a", rarity: "Rare", costPoints: 5,
                    attackPoints: 3, resistPoints: 5, equip, affinity: "Knight");

            string response = main.addCardToDeck(card, costPoint: 4);


            Assert.AreEqual("La cantidad de costPoint de tu baraja es inferior a los costPoints de la carta que intentas añadir", response);
        }

        /* Cuando los puntos de ataque son menores que los puntos de resistencia */
        [Test]
        public void Test10()
        {

            MyApp.Program main = new MyApp.Program();

            Character attackCard;
            Character defenseCard;
            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 2, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "ReduceAP", effectPoints: 3);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 3, resistPoints: 5, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            List<Player> players = main.getPlayerList();

            attackCard = players[0].getCardsCharacter()[0];


            defenseCard = players[1].getCardsCharacter()[0];


            int response = main.confrontCharacters(attackCard, defenseCard);




            Assert.AreEqual(3, response);
        }


        /* Cuando los puntos de ataque son mayores que los puntos de resistencia */
        [Test]
        public void Test11()
        {

            MyApp.Program main = new MyApp.Program();

            Character attackCard;
            Character defenseCard;
            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 6, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "ReduceAP", effectPoints: 3);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 3, resistPoints: 5, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            List<Player> players = main.getPlayerList();

            attackCard = players[0].getCardsCharacter()[0];


            defenseCard = players[1].getCardsCharacter()[0];


            int response = main.confrontCharacters(attackCard, defenseCard);




            Assert.AreEqual(-1, response);
        }


        /* empate cuando tienen los mismos puntos de resistencia y de ataque 
         y el atacante tiene mejor afinidad*/
        [Test]
        public void Test12()
        {

            MyApp.Program main = new MyApp.Program();

            Character attackCard;
            Character defenseCard;
            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 2, resistPoints: 2, equip, affinity: "Knight");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "ReduceAP", effectPoints: 3);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 2, resistPoints: 2, equip, affinity: "Mage");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            List<Player> players = main.getPlayerList();

            attackCard = players[0].getCardsCharacter()[0];


            defenseCard = players[1].getCardsCharacter()[0];


            main.confrontCharacters(attackCard, defenseCard);

            int attackCardPointA = players[0].getCardsCharacter()[0].AttackPoints;

            int defenseCardPointR = players[1].getCardsCharacter()[0].ResistPoints;

            Assert.AreEqual(3, attackCardPointA);
            Assert.AreEqual(1, defenseCardPointR);


        }

        /*empate por que tienen los mismos puntos de resistencia y de ataque 
         y el defensor tiene mejor afinidad*/
        [Test]
        public void Test13()
        {

            MyApp.Program main = new MyApp.Program();

            Character attackCard;
            Character defenseCard;
            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 2, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "ReduceAP", effectPoints: 3);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 2, resistPoints: 2, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            List<Player> players = main.getPlayerList();

            attackCard = players[0].getCardsCharacter()[0];


            defenseCard = players[1].getCardsCharacter()[0];


            main.confrontCharacters(attackCard, defenseCard);

            int attackCardPointR = players[0].getCardsCharacter()[0].ResistPoints;

            int defenseCardPointA = players[1].getCardsCharacter()[0].AttackPoints;

            Assert.AreEqual(1, attackCardPointR);
            Assert.AreEqual(3, defenseCardPointA);


        }
        /* Cuando los RP del contrincante llegan a 0 la carta quedara destruida */
        [Test]
        public void Test14()
        {

            MyApp.Program main = new MyApp.Program();

            bool response = false;
            Character attackCard;
            Character defenseCard;
            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 5, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "ReduceAP", effectPoints: 3);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 2, resistPoints: 2, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            List<Player> players = main.getPlayerList();

            attackCard = players[0].getCardsCharacter()[0];


            defenseCard = players[1].getCardsCharacter()[0];


            int result = main.confrontCharacters(attackCard, defenseCard);

            if (result == -1)
            {
                response = main.deleteCharacter(player2.Name, defenseCard.Name);
            }



            Assert.AreEqual(true, response);


        }

        /* Cuando el contrincante se queda sin Characters, pierde la partida */
        [Test]
        public void Test15()
        {

            MyApp.Program main = new MyApp.Program();

            bool deletePlayer = false;
            bool response = false;
            Character attackCard;
            Character defenseCard;
            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 5, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "ReduceAP", effectPoints: 3);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 2, resistPoints: 2, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            List<Player> players = main.getPlayerList();

            attackCard = players[0].getCardsCharacter()[0];


            defenseCard = players[1].getCardsCharacter()[0];


            int result = main.confrontCharacters(attackCard, defenseCard);

            if (result == -1)
            {
                response = main.deleteCharacter(player2.Name, defenseCard.Name);
            }

            if (response)
            {
                if (player2.getCardsCharacter().Count == 0)
                {
                    deletePlayer = main.deletePlayer(player2.Name);
                }
            }

            Assert.AreEqual(true, deletePlayer);


        }

        /* Elimina una sola carta del tipo Support con una carta Support 
         de tipo "DestroyEquip" el contrincante queda sin cartas de tipo Equip*/
        [Test]
        public void Test16()
        {
            MyApp.Program main = new MyApp.Program();
            int cardsEquip = 0;


            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 5, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "DestroyEquip", effectPoints: 0);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 2, resistPoints: 2, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
              effectType: "ReduceRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            bool result = main.useCardSupport(player, player2, 0);

            if (result)
            {
                player = main.getPlayers()[1];
                cardsEquip = player.getCardsEquip().Count;
            }



            Assert.AreEqual(0, cardsEquip);
        }

        /* ReduceAP del coontrincante 1 punto*/
        [Test]
        public void Test17()
        {
            MyApp.Program main = new MyApp.Program();
            int valueAp = 0;


            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 5, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "ReduceAP", effectPoints: 1);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 2, resistPoints: 2, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
              effectType: "ReduceRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            bool result = main.useCardSupport(player, player2, 0);

            if (result)
            {
                player = main.getPlayers()[1];
                valueAp = player.getCardsCharacter()[0].AttackPoints;
            }



            Assert.AreEqual(1, valueAp);
        }
        /* ReduceRP del coontrincante 2 puntos*/
        [Test]
        public void Test18()
        {
            MyApp.Program main = new MyApp.Program();
            int valueRp = 0;


            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 5, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "ReduceRP", effectPoints: 2);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 2, resistPoints: 5, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
              effectType: "ReduceRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            bool result = main.useCardSupport(player, player2, 0);

            if (result)
            {
                player = main.getPlayers()[1];
                valueRp = player.getCardsCharacter()[0].ResistPoints;
            }



            Assert.AreEqual(3, valueRp);
        }
        /* ReduceRP y ReduceAP del coontrincante 2 puntos */
        [Test]
        public void Test19()
        {
            MyApp.Program main = new MyApp.Program();
            int valueRp = 0;
            int valueAp = 0;

            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 5, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "ReduceALL", effectPoints: 2);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 3, resistPoints: 5, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
              effectType: "ReduceRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            bool result = main.useCardSupport(player, player2, 0);

            if (result)
            {
                player = main.getPlayers()[1];
                valueRp = player.getCardsCharacter()[0].ResistPoints;
                valueAp = player.getCardsCharacter()[0].AttackPoints;
            }



            Assert.AreEqual(3, valueRp);
            Assert.AreEqual(1, valueAp);
        }

        /* RestoreRP porpio del coontrincante 5 puntos */
        [Test]
        public void Test20()
        {
            MyApp.Program main = new MyApp.Program();
            int valueRp = 0;


            Equip equip = main.generateCardEquip(name: "a", rarity: "UR", costPoints: 10, targetAttribute: "AP",
                         effectPoints: 6, affinity: "ALL");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            Character card = main.generateCardCharacter(name: "b", rarity: "R", costPoints: 3,
                attackPoints: 5, resistPoints: 2, equip, affinity: "Mage");

            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            SupportSkill support = main.generateCardSupport(name: "c", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 5);
            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player = main.createPlayer("jugador1");
            main.sendListCharactertToPlayer(player);
            main.sendListEquiptToPlayer(player);
            main.sendListSupportToPlayer(player);
            main.savePlayer(player);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            equip = main.generateCardEquip(name: "c", rarity: "R", costPoints: 5, targetAttribute: "RP",
                        effectPoints: 2, affinity: "Knight");

            if (main.addCardToDeck(equip, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardEquip(equip);
            }

            card = main.generateCardCharacter(name: "d", rarity: "Rare", costPoints: 5,
                   attackPoints: 3, resistPoints: 5, equip, affinity: "Knight");


            if (main.addCardToDeck(card, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardCharacter(card);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
                effectType: "RestoreRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            support = main.generateCardSupport(name: "e", rarity: "Common", costPoints: 1,
              effectType: "ReduceRP", effectPoints: 3);

            if (main.addCardToDeck(support, costPoint: 50).CompareTo("carta introducida a la baraja") == 0)
            {
                main.addCardSupport(support);
            }

            Player player2 = main.createPlayer("jugador2");
            main.sendListCharactertToPlayer(player2);
            main.sendListEquiptToPlayer(player2);
            main.sendListSupportToPlayer(player2);
            main.savePlayer(player2);
            main.deleteList();
            main.deleteListCharacters();
            main.deleteListEquip();
            main.deleteListSupport();

            bool result = main.useCardSupport(player, player2, 0);

            if (result)
            {
                player = main.getPlayers()[0];
                valueRp = player.getCardsCharacter()[0].ResistPoints;

            }



            Assert.AreEqual(7, valueRp);

        }

        /* Bonus */
        [Test]

        public void Test21()
        {
            MyApp.Program main = new MyApp.Program();
            string rarity = main.cardRaffle()[0];
            string type = main.cardRaffle()[1];

            if (type.CompareTo("Equip") == 0)
            {
                Equip equip = main.generateCardEquip(name: "a", rarity: rarity, costPoints: 3, targetAttribute: "Ap",
                effectPoints: 6, affinity: "k");
                Assert.AreEqual("Equip", equip.Type);
            }
            else if (type.CompareTo("Character") == 0)
            {
                taller2.Equip equip = main.generateCardEquip(name: "a", rarity: rarity, costPoints: 3, targetAttribute: "Ap",
                effectPoints: 6, affinity: "k");



                taller2.Character card = main.generateCardCharacter(name: "a", rarity: rarity, costPoints: 5,
                    attackPoints: 3, resistPoints: 5, equip, affinity: "Knight");

                Assert.AreEqual("Character", card.Type);

            }

            else
            {
                taller2.SupportSkill support = main.generateCardSupport(name: "a", rarity: rarity, costPoints: 4,
               effectType: "ReduceAP", effectPoints: 0);

                Assert.AreEqual("Support Skill", support.Type);
            }



        }
    }
}