﻿using System;
using System.Collections.Generic;
using static Play;

namespace WumpusGame
{
    public class Game
    {
        private Warrior Warrior;
        private Room CurrentRoom;

        public Game(Room entrance, Warrior warrior)
        {
            this.CurrentRoom = entrance;
            this.Warrior = warrior;
        }

        public void start()
        {
            Result next = null;

            while (!(next is GameOver) && !(next is Victory))
            {
                Console.Clear();

                next = readChoiceFor(CurrentRoom);
            }
        }

        private Result readChoiceFor(Room currentRoom)
        {
            /*
            presentRoom(currentRoom);
            presentWeapon(Warrior);
            presentSign(currentRoom);
            presentTunnels(currentRoom);
            presentTrap(currentRoom);

            Play moveOrShoot = readMoveOrShoot();
            */

            Play moveOrShoot = draw();

            Room target = readWhereToMoveOrShoot(moveOrShoot);

            return doMoveOrShoot(target, moveOrShoot);
        }

        private Play draw()
        {
            presentTrap(CurrentRoom);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(@"     Room {0}                     Room {1}         Room {2}         Room {3}", CurrentRoom, CurrentRoom.FrontRoom, CurrentRoom.LeftRoom, CurrentRoom.RightRoom);
            Console.WriteLine(@"     ______            ?        ______         ______         ______");
            Console.WriteLine(@"    / you  \          O        /      \       /      \       /      \     ---\__O");
            Console.WriteLine(@"    | are  |        /|\        |     o|       |     o|       |     o|           |\    ({0} Arrows Left)", Warrior.Arrows);
            Console.WriteLine(@"   _| here |__      / \      __|      |__   __|      |__   __|      |__        / \ ");
            Console.WriteLine(@"                  [M]ove                                                     [S]hoot ");
            Console.WriteLine();

            Console.Write("   Move or Shoot? ");

            do
            {
                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "M":
                        return Move;
                    case "S":
                        return Shoot;
                    default:
                        showInvalidEntry("Invalid option!", "Move or Shoot? ");
                        break;
                }

            } while (true);
        }

        private Result doMoveOrShoot(Room target, Play moveOrShoot)
        {
            if (moveOrShoot == Move)
                return moveTo(target);
            else
                return shootTo(target);
        }

        private Result shootTo(Room target)
        {
            Result result = target.getShot();

            if (result is Victory)
                return result;

            return Warrior.spendArrow();
        }

        private Result moveTo(Room target)
        {
            CurrentRoom = target;
            return target.getIn();
        }

        private Room readWhereToMoveOrShoot(Play play)
        {
            Console.Write("   Which room? ");

            do
            {
                int roomNumber = 0;

                try
                {
                    roomNumber = Convert.ToInt16(Console.ReadLine());

                    if (roomNumber == CurrentRoom.FrontRoom.Number)
                        return CurrentRoom.FrontRoom;
                    else if (roomNumber == CurrentRoom.LeftRoom.Number)
                        return CurrentRoom.LeftRoom;
                    else if (roomNumber == CurrentRoom.RightRoom.Number)
                        return CurrentRoom.RightRoom;
                    else
                        throw new Exception();

                }
                catch (Exception)
                {
                    showInvalidEntry(String.Format("Dimwit! You can't get to there from here. There are tunnels to rooms {0}, {1}, and {2}.",
                        CurrentRoom.FrontRoom, CurrentRoom.LeftRoom, CurrentRoom.RightRoom), "Which room? ");
                }


            } while (true);
        }

        private void showInvalidEntry(string message, string label = "")
        {
            Console.WriteLine(message);
            Console.ReadKey();

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.WriteLine(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 2);
            Console.WriteLine(new String(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 3);
            Console.WriteLine(label + new String(' ', Console.WindowWidth - label.Length));
            Console.SetCursorPosition(label.Length + 3, Console.CursorTop - 2);
        }

        private void presentTrap(Room currentRoom)
        {
            currentRoom.FrontRoom.Trap.presentSign();
            currentRoom.LeftRoom.Trap.presentSign();
            currentRoom.RightRoom.Trap.presentSign();
        }

        private Play readMoveOrShoot()
        {

            Console.WriteLine(@"                          _______");
            Console.WriteLine(@"                   ?     /       \");
            Console.WriteLine(@"                  O      |       |    ---\__O");
            Console.WriteLine(@"        [M]ove  /|\      |       |          |\  [S]hoot");
            Console.WriteLine(@"                / \   ___|       |____     / \");

            //Console.WriteLine("[M]ove or [S]hoot?");

            do
            {
                string choice = Console.ReadLine();

                switch (choice.ToUpper())
                {
                    case "M":
                        return Move;
                    case "S":
                        return Shoot;
                    default:
                        showInvalidEntry("Invalid option!");
                        break;
                }

            } while (true);
        }

        private void presentTunnels(Room currentRoom)
        {
            Console.WriteLine("There are tunnels to rooms {0}, {1}, and {2}",
                currentRoom.FrontRoom, currentRoom.LeftRoom, currentRoom.RightRoom);
        }

        private void presentSign(Room currentRoom)
        {
            Console.WriteLine(currentRoom.Sign);
        }

        private void presentWeapon(Warrior warrior)
        {
            Console.WriteLine("You have {0} arrows left.", warrior.Arrows);
        }

        private void presentRoom(Room currentRoom)
        {
            Console.WriteLine("You are in room {0}.", currentRoom.Number);
        }
    }
}

