﻿using ProjectRPG.Monsters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Game
{
    public class Game
    {
        public void StartGame()
        {
            Fight fight = new Fight();
            Player player = new Player();
            Spider spider = new Spider("pajak", 1, 500, 50, 30, "Trucizna zadala");
            player.ChooseHero();
            Console.Clear();
            fight.StartFight(player, spider);
        }
    }
}
