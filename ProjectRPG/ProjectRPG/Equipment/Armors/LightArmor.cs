﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Equipment.Armors
{
    public class LightArmor : Armor
    {
        public LightArmor(string name, string rarity, string description, double defence, double dodgeRate, double additionalBonus) : base(name, rarity, description, defence, dodgeRate, additionalBonus)
        {
            AdditionalBonus = additionalBonus;
        }

        public override void PrintInfo()
        {
            base.PrintInfo();
            Console.WriteLine($" INT BONUS  :  {AdditionalBonus}                        ");
            Console.WriteLine("======================================================================================");
            Console.WriteLine();
        }

    }
}
