using System;

namespace BoxerBattle
{
    class Program
    {
       

        static void Main(string[] args)
        {
            Boxer boxer1 = new Boxer("Tom", 100, 19, 5, 0);
            Boxer boxer2 = new Boxer("Jerry", 80, 15, 3);

            int count = 1;
            int reviveChance = 1;
            int damage;
            Random random = new Random();

            while (!boxer1.IsDead() && !boxer2.IsDead())
            {
                Console.WriteLine($"--------turn{count}--------");
                //boxer1攻击boxer2
                //boxer1主动技能消耗100技力,，每次攻击增加20技力，技能发动时造成2倍伤害
                if (boxer1.GetCharge() == 100)
                {
                    Console.WriteLine($"{boxer1.GetName()}发动了重击！");
                    boxer1.SetCharge(0);
                    damage = 2 * boxer1.GetAttack() - boxer2.GetDefence();
                }
                else
                {
                    damage = boxer1.GetAttack() - boxer2.GetDefence();
                    boxer1.SetCharge(boxer1.GetCharge() + 20);
                    Console.WriteLine($"{boxer1.GetName()}攻击了{boxer2.GetName()}");
                }

                //boxer2被动技能——闪避
                int num = random.Next(1, 100);
                if (num <= 20)
                {
                    Console.WriteLine($"{boxer2.GetName()}发动了技能闪避，闪避了伤害！");
                }
                else
                {
                    boxer2.BeDamaged(damage);
                    Console.WriteLine($"{boxer2.GetName()}受到了{damage}点伤害");
                }

                Console.WriteLine(boxer2);


                if (!boxer2.IsDead())
                {
                    //boxer2攻击boxer1
                    damage = boxer2.GetAttack() - boxer1.GetDefence();
                    boxer1.BeDamaged(damage);
                    Console.WriteLine($"{boxer2.GetName()}攻击了{boxer1.GetName()}");
                    Console.WriteLine($"{boxer1.GetName()}受到了{damage}点伤害");
                    //boxer1被动技能——毅力（战败后复活一次并恢复10点生命值）
                    if (boxer1.GetHP() == 0 && reviveChance > 0)
                    {
                        Console.WriteLine($"{boxer1.GetName()}发动了技能战续，恢复了10点生命值！");
                        boxer1.SetHP(10);
                        reviveChance--;
                    }

                    Console.WriteLine(boxer1);
                }

                count++;
            }

            if (boxer1.IsDead())
            {
                Console.WriteLine($"-------{boxer2.GetName()}胜利-------");
            }
            else
            {
                Console.WriteLine($"-------{boxer1.GetName()}胜利-------");
            }
        }
    }
}
