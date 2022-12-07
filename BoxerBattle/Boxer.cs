using System;
using System.Collections.Generic;
using System.Text;

namespace BoxerBattle
{
    class Boxer
    {
        private string Name;    // 名称
        private int HP;         // 血量 
        private int Attack;     // 攻击
        private int Defence;    // 防御
        private int Charge;     // 蓄力

        public Boxer(string name, int hp, int attack, int defence, int charge)
        {
            Name = name;
            HP = hp;
            Attack = attack;
            Defence = defence;
            Charge = charge;
        }

        public Boxer(string name, int hp, int attack, int defence)
        {
            Name = name;
            HP = hp;
            Attack = attack;
            Defence = defence;
        }

        public string GetName()
        {
            return Name;
        }

        public int GetHP()
        {
            return HP;
        }

        public void SetHP(int hp)
        {
            HP = hp;
        }

        public int GetAttack()
        {
            return Attack;
        }

        public int GetDefence()
        {
            return Defence;
        }

        public int GetCharge()
        {
            return Charge;
        }

        public void SetCharge(int charge)
        {
            Charge = charge;
        }


        public void BeDamaged(int damage)
        {
            HP -= damage;
            if (HP < 0)
            {
                HP = 0;
            }
        }

        public bool IsDead()
        {
            return HP <= 0;
        }

        public override string ToString()
        {
            return $"角色：{Name} HP：{HP} 攻击力：{Attack} 防御力：{Defence}";
        }
    }
}
