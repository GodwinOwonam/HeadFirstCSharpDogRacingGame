using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_At_The_Races_Lab1
{
    public class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLength;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random Randomizer;

        public bool Run()
        {
            Location = Randomizer.Next(1, 5);
            MyPictureBox.Left += Location;
            if(MyPictureBox.Left>=RacetrackLength-MyPictureBox.Width)
            {
                return true;
            }
            return false;
        }

        public void TakeStartingPosition()
        {
            Location = 0;
            MyPictureBox.Left = 0;
        }
    }
}
