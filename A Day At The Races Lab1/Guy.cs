using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_At_The_Races_Lab1
{
    public class Guy
    {
        public string Name;
        public Bet MyBet =null;
        public int Cash;

        public RadioButton MyRadioButton = null;
        public Label MyLabel =null;

        public void UpdateLabels()
        {
            
            MyLabel.Text = MyBet.GetDescription();
            MyRadioButton.Text = Name + " has " + Cash + " bucks";
        }

        public void ClearBet()
        {
            MyBet.Amount = 0;
        }

        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            if (BetAmount <= Cash)
            {
                MyBet.Amount = BetAmount;
                MyBet.Dog = DogToWin;
                return true;
            }
            return false;
        }

        public void Collect(int Winner)
        {
            Cash += MyBet.PayOut(Winner);
        }
    }
}
