﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_TD_Game
{
    public class EnemyAir : EnemyModel
    {
        public EnemyAir(PictureBox pb, Grid g, LevelBase l, int r, int health, int damage, float speed, Wave w) : base(pb, g, l, r, health, damage, speed, w)
        {
        }
    }
    public class EnemyVehicle : EnemyModel
    {
        public EnemyVehicle(PictureBox pb, Grid g, LevelBase l, int r, int health, int damage, float speed, Wave w) : base(pb, g, l, r, health, damage, speed, w)
        {
        }
    }
    public class EnemyGround : EnemyModel
    {
        public EnemyGround(PictureBox pb, Grid g, LevelBase l, int r, int health, int damage, float speed, Wave w) : base(pb, g, l, r, health, damage, speed, w)
        {
        }
    }

   
}
