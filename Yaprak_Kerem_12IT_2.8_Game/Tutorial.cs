using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yaprak_Kerem_12IT_2_8_Game
{
    public partial class Tutorial : LevelBase
    {
        public Tutorial(string map) : base(map)
        {
            this.Name += ": Tutorial";
        }
    }
}
