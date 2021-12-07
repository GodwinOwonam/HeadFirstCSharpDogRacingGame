using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace A_Day_At_The_Races_Lab1
{
    public partial class Form1 : Form
    {
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Guy[] GuyArray = new Guy[3];
        Bet[] BetArray = new Bet[3];
        Random MyRandomizer = new Random();
        Guy CurrentBettor = new Guy();
        
        public Form1()
        {
            InitializeComponent();
            InitializeGuys();
            InitializeDogs();
            
        }

        private void InitializeDogs()
        {
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = pictureBox1,
                StartingPosition = pictureBox1.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox1.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox2.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox3.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = raceTrackPictureBox.Width - pictureBox4.Width,
                Randomizer = MyRandomizer
            };
        }

        private void InitializeGuys()
        {
            GuyArray[0] = new Guy()
            {
                Name = "Joe",
                Cash = 61,
                MyRadioButton = joeRadioButton,
                MyLabel = joeLabel,
                MyBet = new Bet() { Bettor = GuyArray[0]}
                
                
            };

            GuyArray[1] = new Guy()
            {
                Name = "Bob",
                Cash = 62,
                MyRadioButton = bobRadioButton,
                MyLabel = bobLabel,
                MyBet = new Bet { Bettor=GuyArray[1]}
            };

            GuyArray[2] = new Guy()
            {
                Name = "Al",
                Cash = 36,
                MyRadioButton = alRadioButton,
                MyLabel = alLabel,
                MyBet = new Bet() { Bettor = GuyArray[2]}
                
            };
        }

        private void placeBetButton_Click(object sender, EventArgs e)
        {
            PlaceBetNow();
        }

        private void PlaceBetNow()
        {
            if (joeRadioButton.Checked == false && bobRadioButton.Checked == false && alRadioButton.Checked == false)
                MessageBox.Show("Select a bettor first before placing a bet", "Dog Racing says");
            else
            {
                CurrentBettor.PlaceBet((int)numericUpDown1.Value, (int)numericUpDown2.Value);
                CurrentBettor.UpdateLabels();
            }
        }

        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked)
            {
                CurrentBettor = GuyArray[0];
                bettorNameLabel.Text = CurrentBettor.Name;
                
            }
                
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (bobRadioButton.Checked)
            {
                CurrentBettor = GuyArray[1];
                bettorNameLabel.Text = CurrentBettor.Name;
                
            }
                
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (alRadioButton.Checked)
            {
                CurrentBettor = GuyArray[2];
                bettorNameLabel.Text = CurrentBettor.Name;
                
            }
                
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeDogs();
            InitializeGuys();
            
            for(int i = 0; i<GuyArray.Length; i++)
            {
                GuyArray[i].UpdateLabels();
            }

            minimumBetLabel.Text = "Minimum Bet: "+System.Convert.ToString((int)numericUpDown1.Minimum)+ " bucks";
            timer1.Stop();

        }

        private void ResetBetButton_Click(object sender, EventArgs e)
        {
            if (joeRadioButton.Checked == false && bobRadioButton.Checked == false && alRadioButton.Checked == false)
                MessageBox.Show("Select a bettor first before resetting a bet", "Dog Racing says");
            else
            {
                CurrentBettor.ClearBet();
                CurrentBettor.UpdateLabels();
            }
        }

        private void startRaceButton_Click(object sender, EventArgs e)
        {
            for(int i =0; i<GreyhoundArray.Length; i++)
            {
                GreyhoundArray[i].TakeStartingPosition();
                groupBox1.Enabled = false;
                timer1.Start();
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i<GreyhoundArray.Length; i++)
            {
                if (GreyhoundArray[i].Run())
                {
                    int winningDog = i+1;
                    timer1.Stop();
                    MessageBox.Show($"Dog #{winningDog} won the race.", "Dog Racing says");
                    
                    for(int j =0; j<GuyArray.Length; j++)
                    {
                        if(GuyArray[j].MyBet.Amount != 0)
                        {
                            GuyArray[j].Collect(winningDog);
                            GuyArray[j].UpdateLabels();
                        }
                    }
                    groupBox1.Enabled = true;
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
