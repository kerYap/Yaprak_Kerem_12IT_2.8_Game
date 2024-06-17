﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_TD_Game.src
{
    public interface IPlayer
    {
        PictureBox pb { get; }
        void AttackTick(List<IEnemy> enemies);
    }
}