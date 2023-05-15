﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Heroes;

namespace ProjectRPG.Monsters
{
    public abstract class Monster
    {

        #region FieldsAndProperties
        public delegate double AttackDelegate(Hero<Weapon, Armor> hero);
        public event AttackDelegate OnNormalHit;
        public event AttackDelegate OnSpecialHit;
        public string Name { get; set; }
        public double Level { get; set; }
        public double MaxHP { get; set; }
        public double CurrentHP { get; set; }
        public double Attack { get; set; }
        public double Defence { get; set; }
        public string SpecialAttackDesc;

        #endregion

        #region Constructors
        public Monster(string name, double level, double maxHP, double attack, double defence)
        {
            Name = name;
            MaxHP = maxHP * level;
            CurrentHP = maxHP;
            Attack = attack * level;
            Defence = (defence * level) * 0.5;

            OnNormalHit += NormalHitHero;
        }
        #endregion

        #region Methods
        public double NormalAttack(Hero<Weapon, Armor> hero)
        {
            return OnNormalHit.Invoke(hero);
        }
        public double SpecialAttack(Hero<Weapon, Armor> hero)
        {
            return OnSpecialHit.Invoke(hero);
        }

        public double NormalHitHero(Hero<Weapon, Armor> hero)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (hero.Defence * 0.01))));
            hero.CurrentHP -= DamageDealt;
            if (hero.CurrentHP < 0)
            {
                hero.CurrentHP = 0; 
            }

            return DamageDealt;
        }
        public abstract double SpecialHitHero(Hero<Weapon, Armor> hero);
        #endregion
    }
}
