using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A_Day_At_The_Races_Lab1
{
    public class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor = new Guy();

        public string GetDescription()
        {
            string betDescription = "";
            if (Amount == 0)
                betDescription = Bettor.Name + " hasn't placed a bet.";
            else
                betDescription = Bettor.Name + " bets " + Amount + " on dog # " + Dog;
            return betDescription;
        }

        public int PayOut(int Winner)
        {
            if (Dog == Winner)
                return Amount;
            return -Amount;
            
        }
    }
}
