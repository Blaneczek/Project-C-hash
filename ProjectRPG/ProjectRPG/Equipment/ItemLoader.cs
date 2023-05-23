﻿using ProjectRPG.Equipment.Armors;
using ProjectRPG.Equipment.Weapons;
using System;
using System.Collections.Generic;
using System.IO;

namespace ProjectRPG
{
    public class ItemLoader
    {
        public List<Armor> Armors { get; private set; }
        public List<Weapon> Weapons { get; private set; }
        public List<Helmet> Helmets { get; private set; }
        public List<Necklace> Necklaces { get; private set; }
        public List<Boot> Boots { get; private set; }

        public ItemLoader()
        {
            Armors = new List<Armor>();
            Weapons = new List<Weapon>();
            Helmets = new List<Helmet>();
            Necklaces = new List<Necklace>();
            Boots = new List<Boot>();
        }

        public void LoadItemsFromFile(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                string[] values = line.Split(',');

                if (values.Length < 3)
                    continue;

                string itemType = values[0];

                switch (itemType)
                {
                    case "Armor":
                        if (values.Length >= 6)
                        {
                            string name = values[1];
                            string rarity = values[2];
                            string description = values[3];
                            double defence = double.Parse(values[4]);
                            double dodgeRate = double.Parse(values[5]);

                            Armor armor = new Armor(name, rarity, description, defence, dodgeRate);
                            Armors.Add(armor);
                        }
                        break;

                    case "Weapon":
                        if (values.Length >= 5)
                        {
                            string name = values[1];
                            string rarity = values[2];
                            string description = values[3];
                            double damage = double.Parse(values[4]);

                            Weapon weapon = new Weapon(name, rarity, description, damage);
                            Weapons.Add(weapon);
                        }
                        break;

                    case "Helmet":
                        if (values.Length >= 6)
                        {
                            string name = values[1];
                            string rarity = values[2];
                            string description = values[3];
                            double hpBonus = double.Parse(values[4]);
                            double strengthBonus = double.Parse(values[5]);

                            Helmet helmet = new Helmet(name, rarity, description, hpBonus, strengthBonus);
                            Helmets.Add(helmet);
                        }
                        break;

                    case "Necklace":
                        if (values.Length >= 6)
                        {
                            string name = values[1];
                            string rarity = values[2];
                            string description = values[3];
                            double manaBonus = double.Parse(values[4]);
                            double intelligenceBonus = double.Parse(values[5]);

                            Necklace necklace = new Necklace(name, rarity, description, manaBonus, intelligenceBonus);
                            Necklaces.Add(necklace);
                        }
                        break;

                    case "Boot":
                        if (values.Length >= 6)
                        {
                            string name = values[1];
                            string rarity = values[2];
                            string description = values[3];
                            double agilityBonus = double.Parse(values[4]);
                            double dodgeRateBonus = double.Parse(values[5]);

                            Boot boots = new Boot(name, rarity, description, agilityBonus, dodgeRateBonus);
                            Boots.Add(boots);
                        }
                        break;

                    default:
                        break;
                }
            }
        }

        public void PrintItems()
        {
            Console.WriteLine("Armors:");
            foreach (Armor armor in Armors)
            {
                Console.WriteLine($"Name: {armor.Name}, Rarity: {armor.Rarity}, Description: {armor.Description}, Defence: {armor.Defence}, Dodge Rate: {armor.DodgeRate}");
            }

            Console.WriteLine("\nWeapons:");
            foreach (Weapon weapon in Weapons)
            {
                Console.WriteLine($"Name: {weapon.Name}, Rarity: {weapon.Rarity}, Description: {weapon.Description}, Damage: {weapon.Damage}");
            }

            Console.WriteLine("\nHelmets:");
            foreach (Helmet helmet in Helmets)
            {
                Console.WriteLine($"Name: {helmet.Name}, Rarity: {helmet.Rarity}, Description: {helmet.Description}, HP Bonus: {helmet.HPBonus}, Strength Bonus: {helmet.StrengthBonus}");
            }

            Console.WriteLine("\nNecklaces:");
            foreach (Necklace necklace in Necklaces)
            {
                Console.WriteLine($"Name: {necklace.Name}, Rarity: {necklace.Rarity}, Description: {necklace.Description}, Mana Bonus: {necklace.MPBonus}, Intelligence Bonus: {necklace.IntelligenceBonus}");
            }

            Console.WriteLine("\nBoots:");
            foreach (Boot boot in Boots)
            {
                Console.WriteLine($"Name: {boot.Name}, Rarity: {boot.Rarity}, Description: {boot.Description}, Agility Bonus: {boot.AgilityBonus}, Dodge Rate Bonus: {boot.DodgeRateBonus}");
            }
        }
    }
}