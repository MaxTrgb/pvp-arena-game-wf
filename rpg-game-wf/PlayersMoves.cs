using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace C_CLASS25._11._2
{
    static class PlayersMoves
    {
        private static int skillCounterPOne = 0;
        private static int skillCounterPTwo = 0;
        public static int playerOneMove(ConsoleKeyInfo move1, int damage, string currentPlayer, Hero Player1, Hero Player2)
        {

            switch (move1.KeyChar)
            {

                case '1':
                    damage = Player1.CalculateDamage(Player2.AttackPower, Hero.AttackType.Physical, Player1.CriticalChance, Player1.Name, move1);
                    damage = Player2.Defend(damage);

                    PrintManger.printPlOneDamage(currentPlayer, damage);

                    skillCheckOne();
                    return damage;

                case '2':
                    Player1.StartDefending();

                    PrintManger.printPlDefending(currentPlayer);

                    skillCheckOne();
                    return damage;

                case '3':
                    Player1.Heal();

                    PrintManger.printPlHealed(currentPlayer);

                    skillCheckOne();
                    return damage;

                case '4':
                    if (skillCounterPOne == 0)
                    {
                        damage = Player1.CalculateDamage(Player2.AttackPower, Hero.AttackType.Physical, Player1.CriticalChance, Player1.Name, move1);
                        damage = Player1.Skill(damage);
                        damage = Player2.Defend(damage);

                        PrintManger.printPlOneDamage(currentPlayer, damage);
                         
                        skillCounterPOne = 4;
                        skillCheckOne();

                        return damage;
                    }
                    else
                    {
                        PrintManger.printSkillCdOne(skillCounterPOne);
                        skillCheckOne();
                        return damage;
                    }
            }
            return damage;
        }
        public static int playerTwoMove(ConsoleKeyInfo move2, int damage2, string currentPlayer, Hero Player1, Hero Player2)
        {
            switch (move2.KeyChar)
            {
                case '1':
                    damage2 = Player2.CalculateDamage(Player1.AttackPower, Hero.AttackType.Physical, Player2.CriticalChance, Player2.Name, move2);
                    damage2 = Player1.Defend(damage2);

                    PrintManger.printPlTwoDamage(currentPlayer, damage2);

                    skillCheckTwo();

                    return damage2;

                case '2':
                    Player2.StartDefending();

                    PrintManger.printPlDefending(currentPlayer);

                    skillCheckTwo();

                    return damage2;

                case '3':
                    Player2.Heal();

                    PrintManger.printPlHealed(currentPlayer);

                    skillCheckTwo();

                    return damage2;

                case '4':
                    if (skillCounterPTwo == 0)
                    {
                        damage2 = Player2.CalculateDamage(Player1.AttackPower, Hero.AttackType.Physical, Player2.CriticalChance, Player2.Name, move2);
                        damage2 = Player2.Skill(damage2);
                        damage2 = Player1.Defend(damage2);

                        PrintManger.printPlTwoDamage(currentPlayer, damage2);

                        skillCounterPTwo = 4;

                        skillCheckTwo();
                        return damage2;
                    }
                    else
                    {
                        PrintManger.printSkillCdTwo(skillCounterPTwo);
                        skillCheckTwo();
                        return damage2;
                    }
            }
            return damage2;
        }

        private static void skillCheckOne()
        {
            if (skillCounterPOne > 0)
            {
                skillCounterPOne--;
            }
        }
        private static void skillCheckTwo()
        {
            if (skillCounterPTwo > 0)
            {
                skillCounterPTwo--;
            }
        }
    }
}