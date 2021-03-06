﻿using LeagueSharp;
using LeagueSharp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hAram.Champions
{
    class amumu : Base
    {
        public amumu()
        {
            Game.PrintChat("hAram : " + Player.ChampionName + "Loaded.");
        }

        public override void Game_OnUpdate(EventArgs args)
        {
            base.Game_OnUpdate(args);

            CastSpell(Q, qData);

            if (W.Instance.ToggleState == 1 && Player.CountEnemiesInRange(W.Range) > 0)
                W.Cast();
            else if (W.Instance.ToggleState != 1 && Player.CountEnemiesInRange(W.Range) == 0)
                W.Cast();

            CastSpell(E, eData);

            if (R.CastIfWillHit(target, 2) || (status == "Fight" && Player.HealthPercentage() <= 30))
                CastSpell(R, rData);
        }
    }
}
