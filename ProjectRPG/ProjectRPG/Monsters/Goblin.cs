﻿using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using ProjectRPG.Heroes;
using System;

namespace ProjectRPG.Monsters
{
    public class Goblin : Monster
    {
        public Goblin(string name, double level, double maxHP, double attack, double defence, string specialAttackDesc)
            : base(name, level, maxHP, attack, defence, specialAttackDesc)
        {
            OnSpecialHit += SpecialHitHero;
        }

        public override double SpecialHitHero(Hero<Weapon, Armor> hero)
        {
            double DamageDealt = Math.Round((Attack - (Attack * (hero.Defence * 0.01)) * 1.25) + (hero.MaxHP * 0.1)); // + 5% Maxymalnego HP bohatera jako bonus dmg

            if (hero.AbsoluteDefence)
            {
                DamageDealt = 0;
                return DamageDealt;
            }

            Random rnd = new Random();
            int losuj = rnd.Next(1, 101);
            if (losuj >= 1 && losuj <= hero.DodgeRate)
            {
                DamageDealt = 0;
                hero.Dodged = true;
                return DamageDealt;
            }
            else if (losuj > hero.DodgeRate)
            {
                hero.CurrentHP -= Math.Round(DamageDealt);
                if (hero.CurrentHP < 0)
                {
                    hero.CurrentHP = 0;
                }
            }
            return DamageDealt; 
        }
    }
}