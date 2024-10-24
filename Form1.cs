using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PathToVictory
{
    public partial class Form1 : Form
    {
        int[] diceValue = { 1, 6 };
        int[] diceDelay = { 1, 1 };
        int[] diceCountDown = { 1, 1 };
        bool[] diceLocked = { true, true };
        bool betweenGames = true;
        decimal bankroll = 1000M;

        int bet_Path = 0;
        int bet_Stop = 0;
        int bet_end01 = 0;
        int bet_end02 = 0;
        int bet_end03 = 0;
        int bet_end04 = 0;
        int bet_end05 = 0;
        int bet_end06 = 0;
        int bet_end07 = 0;
        int bet_end08 = 0;
        int bet_end09 = 0;
        int bet_end10 = 0;
        int bet_end11 = 0;
        int bet_end12 = 0;
        int bet_end13 = 0;
        int bet_end14 = 0;
        int bet_doub1 = 0;
        int bet_doub2 = 0;
        int bet_doub3 = 0;
        int bet_doub4 = 0;
        int bet_doub5 = 0;
        int bet_doub6 = 0;

        int betPrev_Path = 0;
        int betPrev_Stop = 0;
        int betPrev_end01 = 0;
        int betPrev_end02 = 0;
        int betPrev_end03 = 0;
        int betPrev_end04 = 0;
        int betPrev_end05 = 0;
        int betPrev_end06 = 0;
        int betPrev_end07 = 0;
        int betPrev_end08 = 0;
        int betPrev_end09 = 0;
        int betPrev_end10 = 0;
        int betPrev_end11 = 0;
        int betPrev_end12 = 0;
        int betPrev_end13 = 0;
        int betPrev_end14 = 0;
        int betPrev_doub1 = 0;
        int betPrev_doub2 = 0;
        int betPrev_doub3 = 0;
        int betPrev_doub4 = 0;
        int betPrev_doub5 = 0;
        int betPrev_doub6 = 0;

        int currentSpace = 0;

        Random rand = new Random();

        public enum bets
        {
            n_a,
            path,
            stop,
            end01,
            end02,
            end03,
            end04,
            end05,
            end06,
            end07,
            end08,
            end09,
            end10,
            end11,
            end12,
            end13,
            end14,
            doub1,
            doub2,
            doub3,
            doub4,
            doub5,
            doub6,
        }

        bets currentBet = bets.n_a;


        public Form1()
        {
            InitializeComponent();

        }

        private void buttonRoll_Click(object sender, EventArgs e)
        {
            buttonRoll.Enabled = false;
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            
            if (betweenGames)
            {
                currentSpace = 0;
                betweenGames = false;

                betPrev_Path = bet_Path;
                betPrev_Stop = bet_Stop;
                betPrev_end01 = bet_end01;
                betPrev_end02 = bet_end02;
                betPrev_end03 = bet_end03;
                betPrev_end04 = bet_end04;
                betPrev_end05 = bet_end05;
                betPrev_end06 = bet_end06;
                betPrev_end07 = bet_end07;
                betPrev_end08 = bet_end08;
                betPrev_end09 = bet_end09;
                betPrev_end10 = bet_end10;
                betPrev_end11 = bet_end11;
                betPrev_end12 = bet_end12;
                betPrev_end13 = bet_end13;
                betPrev_end14 = bet_end14;
                betPrev_doub1 = bet_doub1;
                betPrev_doub2 = bet_doub2;
                betPrev_doub3 = bet_doub3;
                betPrev_doub4 = bet_doub4;
                betPrev_doub5 = bet_doub5;
                betPrev_doub6 = bet_doub6;
            }

            diceDelay[0] = rand.Next(2, 16);
            diceDelay[1] = rand.Next(2, 16);
            diceCountDown[0] = diceDelay[0];
            diceCountDown[1] = diceDelay[1];
            diceLocked[0] = false;
            diceLocked[1] = false;

            diceValue[0] = rand.Next(1, 7);
            diceValue[1] = rand.Next(1, 7);

            updateDice(diceValue[0], pictureBox0);
            updateDice(diceValue[1], pictureBox1);

            textBoxStatus.Text = "Rolling...";

            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            diceCountDown[0]--;
            diceCountDown[1]--;

            if (diceCountDown[0] < 1)
            {
                if (diceDelay[0] > 30)
                {
                    diceLocked[0] = true;
                    diceDelay[0] = 999;
                }
                else
                {
                    diceDelay[0] += rand.Next(1, 11);
                    diceCountDown[0] = diceDelay[0];
                    diceValue[0] = rand.Next(1, 7);
                    updateDice(diceValue[0], pictureBox0);
                }
            }

            if (diceCountDown[1] < 1)
            {
                if (diceDelay[1] > 30)
                {
                    diceLocked[1] = true;
                    diceDelay[1] = 999;
                }
                else
                {
                    diceDelay[1] += rand.Next(1, 11);
                    diceCountDown[1] = diceDelay[1];
                    diceValue[1] = rand.Next(1, 7);
                    updateDice(diceValue[1], pictureBox1);
                }
            }

            if (diceLocked[0] && diceLocked[1])
            {
                timer1.Enabled = false;
                postRoll();
            }
        }

        private void postRoll()
        {
            int rollResult = diceValue[0] - diceValue[1];
            if (rollResult < 0)
                rollResult *= -1;
            
            if (rollResult == 0)
            {
                textBoxStatus.Text = "Roll " + diceValue[0] + " - " + diceValue[1] + " : Doubles";

                UpdatePath(true);
                postGame();
            }
            else
            {
                textBoxStatus.Text = "Roll " + diceValue[0] + " - " + diceValue[1] + " : value = " + rollResult;
                currentSpace += rollResult;

                if (currentSpace > 9)
                {
                    UpdatePath(true);
                    postGame();
                }
                else
                {
                    UpdatePath(false);
                    openRollBets();
                }
            }



            buttonRoll.Enabled = true;
        }

        private void postGame()
        {
            if (bet_Path > 0)
            {
                if (currentSpace == 14)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Path bet wins " + (bet_Path * 4) + ". ";
                    bankroll += bet_Path * 5;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_Path = 0;
                    textBoxPathPassBet.Visible = false;
                }
                else if (currentSpace == 13)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Path bet wins " + (bet_Path * 3) + ". ";
                    bankroll += bet_Path * 4;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_Path = 0;
                    textBoxPathPassBet.Visible = false;
                }
                else if (currentSpace > 9)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Path bet wins " + (bet_Path * 1) + ". ";
                    bankroll += bet_Path * 2;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_Path = 0;
                    textBoxPathPassBet.Visible = false;
                }
                else
                {
                    bet_Path = 0;
                    textBoxPathPassBet.Visible = false;
                }
            }

            if (bet_Stop > 0)
            {
                if (currentSpace == 0)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Doubles bet pushes. ";
                    bankroll += bet_Stop;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_Stop = 0;
                    textBoxPathStopBet.Visible = false;
                }
                else if (currentSpace < 10)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Doubles bet wins " + (bet_Stop * 1) + ". ";
                    bankroll += bet_Stop * 2;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_Stop = 0;
                    textBoxPathStopBet.Visible = false;
                }
                else
                {
                    bet_Stop = 0;
                    textBoxPathStopBet.Visible = false;
                }
            }

            if (bet_end01 > 0)
            {
                if (currentSpace == 1)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 1 bet wins " + (bet_end01 * 20) + ". ";
                    bankroll += bet_end01 * 21;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end01 = 0;
                    textBoxEnd01.Visible = false;
                }
                else
                {
                    bet_end01 = 0;
                    textBoxEnd01.Visible = false;
                }
            }

            if (bet_end02 > 0)
            {
                if (currentSpace == 2)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 2 bet wins " + (bet_end02 * 18) + ". ";
                    bankroll += bet_end02 * 19;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end02 = 0;
                    textBoxEnd02.Visible = false;
                }
                else
                {
                    bet_end02 = 0;
                    textBoxEnd02.Visible = false;
                }
            }

            if (bet_end03 > 0)
            {
                if (currentSpace == 3)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 3 bet wins " + (bet_end03 * 17.5) + ". ";
                    bankroll += bet_end03 * 18.5M;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end03 = 0;
                    textBoxEnd03.Visible = false;
                }
                else
                {
                    bet_end03 = 0;
                    textBoxEnd03.Visible = false;
                }
            }

            if (bet_end04 > 0)
            {
                if (currentSpace == 4)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 4 bet wins " + (bet_end04 * 17.5) + ". ";
                    bankroll += bet_end04 * 18.5M;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end04 = 0;
                    textBoxEnd04.Visible = false;
                }
                else
                {
                    bet_end04 = 0;
                    textBoxEnd04.Visible = false;
                }
            }

            if (bet_end05 > 0)
            {
                if (currentSpace == 5)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 5 bet wins " + (bet_end05 * 19) + ". ";
                    bankroll += bet_end05 * 20;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end05 = 0;
                    textBoxEnd05.Visible = false;
                }
                else
                {
                    bet_end05 = 0;
                    textBoxEnd05.Visible = false;
                }
            }

            if (bet_end06 > 0)
            {
                if (currentSpace == 6)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 6 bet wins " + (bet_end06 * 22) + ". ";
                    bankroll += bet_end06 * 23;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end06 = 0;
                    textBoxEnd06.Visible = false;
                }
                else
                {
                    bet_end06 = 0;
                    textBoxEnd06.Visible = false;
                }
            }

            if (bet_end07 > 0)
            {
                if (currentSpace == 7)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 7 bet wins " + (bet_end07 * 23) + ". ";
                    bankroll += bet_end07 * 24;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end07 = 0;
                    textBoxEnd07.Visible = false;
                }
                else
                {
                    bet_end07 = 0;
                    textBoxEnd07.Visible = false;
                }
            }

            if (bet_end08 > 0)
            {
                if (currentSpace == 8)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 8 bet wins " + (bet_end08 * 25) + ". ";
                    bankroll += bet_end08 * 26;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end08 = 0;
                    textBoxEnd08.Visible = false;
                }
                else
                {
                    bet_end08 = 0;
                    textBoxEnd08.Visible = false;
                }
            }

            if (bet_end09 > 0)
            {
                if (currentSpace == 9)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 9 bet wins " + (bet_end09 * 27.5) + ". ";
                    bankroll += bet_end09 * 28.5M;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end09 = 0;
                    textBoxEnd09.Visible = false;
                }
                else
                {
                    bet_end09 = 0;
                    textBoxEnd09.Visible = false;
                }
            }

            if (bet_end10 > 0)
            {
                if (currentSpace == 10)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 10 bet wins " + (bet_end10 * 4) + ". ";
                    bankroll += bet_end10 * 5;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end10 = 0;
                    textBoxEnd10.Visible = false;
                }
                else
                {
                    bet_end10 = 0;
                    textBoxEnd10.Visible = false;
                }
            }

            if (bet_end11 > 0)
            {
                if (currentSpace == 11)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 11 bet wins " + (bet_end11 * 6.5) + ". ";
                    bankroll += bet_end11 * 7.5M;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end11 = 0;
                    textBoxEnd11.Visible = false;
                }
                else
                {
                    bet_end11 = 0;
                    textBoxEnd11.Visible = false;
                }
            }

            if (bet_end12 > 0)
            {
                if (currentSpace == 12)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 12 bet wins " + (bet_end12 * 12) + ". ";
                    bankroll += bet_end12 * 13;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end12 = 0;
                    textBoxEnd12.Visible = false;
                }
                else
                {
                    bet_end12 = 0;
                    textBoxEnd12.Visible = false;
                }
            }

            if (bet_end13 > 0)
            {
                if (currentSpace == 13)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 13 bet wins " + (bet_end13 * 25) + ". ";
                    bankroll += bet_end13 * 26;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end13 = 0;
                    textBoxEnd13.Visible = false;
                }
                else
                {
                    bet_end13 = 0;
                    textBoxEnd13.Visible = false;
                }
            }

            if (bet_end14 > 0)
            {
                if (currentSpace == 14)
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "End on 14 bet wins " + (bet_end14 * 80) + ". ";
                    bankroll += bet_end14 * 81;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_end14 = 0;
                    textBoxEnd14.Visible = false;
                }
                else
                {
                    bet_end14 = 0;
                    textBoxEnd14.Visible = false;
                }
            }

            if (bet_doub1 > 0)
            {
                if ((diceValue[0] == 1) && (diceValue[1] == 1))
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Double 1s bet wins " + (bet_doub1 * 9) + ". ";
                    bankroll += bet_doub1 * 10;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_doub1 = 0;
                    textBoxDouble1.Visible = false;
                }
                else
                {
                    bet_doub1 = 0;
                    textBoxDouble1.Visible = false;
                }
            }

            if (bet_doub2 > 0)
            {
                if ((diceValue[0] == 2) && (diceValue[1] == 2))
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Double 2s bet wins " + (bet_doub2 * 9) + ". ";
                    bankroll += bet_doub2 * 10;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_doub2 = 0;
                    textBoxDouble2.Visible = false;
                }
                else
                {
                    bet_doub2 = 0;
                    textBoxDouble2.Visible = false;
                }
            }

            if (bet_doub3 > 0)
            {
                if ((diceValue[0] == 3) && (diceValue[1] == 3))
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Double 3s bet wins " + (bet_doub3 * 9) + ". ";
                    bankroll += bet_doub3 * 10;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_doub3 = 0;
                    textBoxDouble3.Visible = false;
                }
                else
                {
                    bet_doub3 = 0;
                    textBoxDouble3.Visible = false;
                }
            }

            if (bet_doub4 > 0)
            {
                if ((diceValue[0] == 4) && (diceValue[1] == 4))
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Double 4s bet wins " + (bet_doub4 * 9) + ". ";
                    bankroll += bet_doub4 * 10;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_doub4 = 0;
                    textBoxDouble4.Visible = false;
                }
                else
                {
                    bet_doub4 = 0;
                    textBoxDouble4.Visible = false;
                }
            }

            if (bet_doub5 > 0)
            {
                if ((diceValue[0] == 5) && (diceValue[1] == 5))
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Double 5s bet wins " + (bet_doub5 * 9) + ". ";
                    bankroll += bet_doub5 * 10;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_doub5 = 0;
                    textBoxDouble5.Visible = false;
                }
                else
                {
                    bet_doub5 = 0;
                    textBoxDouble5.Visible = false;
                }
            }

            if (bet_doub6 > 0)
            {
                if ((diceValue[0] == 6) && (diceValue[1] == 6))
                {
                    textBoxStatus.Text += Environment.NewLine;
                    textBoxStatus.Text += "Double 6s bet wins " + (bet_doub6 * 9) + ". ";
                    bankroll += bet_doub6 * 10;
                    toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
                    bet_doub6 = 0;
                    textBoxDouble6.Visible = false;
                }
                else
                {
                    bet_doub6 = 0;
                    textBoxDouble6.Visible = false;
                }
            }

            if (bankroll < 10)
            {
                MessageBox.Show("Looks like you are out of money.  How about I loan you another 1000?", "Need money?");
                bankroll += 1000;
                toolStripStatusBankroll.Text = "Bankroll: " + bankroll;
            }

            betweenGames = true;
            openGameBets();
        }

        private void preGame()
        {


        }

        private void updateDice(int value, PictureBox box)
        {
            if (value == 1) box.Image = Properties.Resources.Dice_1;
            if (value == 2) box.Image = Properties.Resources.Dice_2;
            if (value == 3) box.Image = Properties.Resources.Dice_3;
            if (value == 4) box.Image = Properties.Resources.Dice_4;
            if (value == 5) box.Image = Properties.Resources.Dice_5;
            if (value == 6) box.Image = Properties.Resources.Dice_6;

        }

        private void buttonPathPass_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxPathPassBet.BackColor = Color.Yellow;

            textBoxStatus.Text = "Path bet: At least 10 spaces will be moved before rolling doubles. " + Environment.NewLine + "Pays 4-1 at space 14, 3-1 at space 13, 1-1 for spaces 10-12. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.path;
        }

        private void buttonPathStop_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxPathStopBet.BackColor = Color.Yellow;

            textBoxStatus.Text = "Doubles bet: Doubles will be rolled before 10 spaces are moved. " + Environment.NewLine + "Pushes if the first roll is doubles, 1-1 if doubles are rolled after. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.stop;
        }

        private void buttonBetEnter_Click(object sender, EventArgs e)
        {
            numericUpDownBet.Visible = false;
            buttonBetEnter.Visible = false;
            buttonBetCancel.Visible = false;

            bankroll -= numericUpDownBet.Value;

            switch (currentBet)
            {
                case bets.n_a:
                    break;
                case bets.path:
                    bankroll += bet_Path;
                    bet_Path = (int)numericUpDownBet.Value;
                    textBoxPathPassBet.Text = "Path Bet: " + bet_Path;
                    textBoxPathPassBet.BackColor = Color.LightGray;
                    textBoxPathPassBet.Visible = false;
                    if (bet_Path > 0)
                        textBoxPathPassBet.Visible = true;
                    break;
                case bets.stop:
                    bankroll += bet_Stop;
                    bet_Stop = (int)numericUpDownBet.Value;
                    textBoxPathStopBet.Text = "Doubles Bet: " + bet_Stop;
                    textBoxPathStopBet.BackColor = Color.LightGray;
                    textBoxPathStopBet.Visible = false;
                    if (bet_Stop > 0)
                        textBoxPathStopBet.Visible = true;
                    break;
                case bets.end01:
                    bankroll += bet_end01;
                    bet_end01 = (int)numericUpDownBet.Value;
                    textBoxEnd01.Text = "Bet: " + bet_end01;
                    textBoxEnd01.BackColor = Color.LightGray;
                    textBoxEnd01.Visible = false;
                    if (bet_end01 > 0)
                        textBoxEnd01.Visible = true;
                    break;
                case bets.end02:
                    bankroll += bet_end02;
                    bet_end02 = (int)numericUpDownBet.Value;
                    textBoxEnd02.Text = "Bet: " + bet_end02;
                    textBoxEnd02.BackColor = Color.LightGray;
                    textBoxEnd02.Visible = false;
                    if (bet_end02 > 0)
                        textBoxEnd02.Visible = true;
                    break;
                case bets.end03:
                    bankroll += bet_end03;
                    bet_end03 = (int)numericUpDownBet.Value;
                    textBoxEnd03.Text = "Bet: " + bet_end03;
                    textBoxEnd03.BackColor = Color.LightGray;
                    textBoxEnd03.Visible = false;
                    if (bet_end03 > 0)
                        textBoxEnd03.Visible = true;
                    break;
                case bets.end04:
                    bankroll += bet_end04;
                    bet_end04 = (int)numericUpDownBet.Value;
                    textBoxEnd04.Text = "Bet: " + bet_end04;
                    textBoxEnd04.BackColor = Color.LightGray;
                    textBoxEnd04.Visible = false;
                    if (bet_end04 > 0)
                        textBoxEnd04.Visible = true;
                    break;
                case bets.end05:
                    bankroll += bet_end05;
                    bet_end05 = (int)numericUpDownBet.Value;
                    textBoxEnd05.Text = "Bet: " + bet_end05;
                    textBoxEnd05.BackColor = Color.LightGray;
                    textBoxEnd05.Visible = false;
                    if (bet_end05 > 0)
                        textBoxEnd05.Visible = true;
                    break;
                case bets.end06:
                    bankroll += bet_end06;
                    bet_end06 = (int)numericUpDownBet.Value;
                    textBoxEnd06.Text = "Bet: " + bet_end06;
                    textBoxEnd06.BackColor = Color.LightGray;
                    textBoxEnd06.Visible = false;
                    if (bet_end06 > 0)
                        textBoxEnd06.Visible = true;
                    break;
                case bets.end07:
                    bankroll += bet_end07;
                    bet_end07 = (int)numericUpDownBet.Value;
                    textBoxEnd07.Text = "Bet: " + bet_end07;
                    textBoxEnd07.BackColor = Color.LightGray;
                    textBoxEnd07.Visible = false;
                    if (bet_end07 > 0)
                        textBoxEnd07.Visible = true;
                    break;
                case bets.end08:
                    bankroll += bet_end08;
                    bet_end08 = (int)numericUpDownBet.Value;
                    textBoxEnd08.Text = "Bet: " + bet_end08;
                    textBoxEnd08.BackColor = Color.LightGray;
                    textBoxEnd08.Visible = false;
                    if (bet_end08 > 0)
                        textBoxEnd08.Visible = true;
                    break;
                case bets.end09:
                    bankroll += bet_end09;
                    bet_end09 = (int)numericUpDownBet.Value;
                    textBoxEnd09.Text = "Bet: " + bet_end09;
                    textBoxEnd09.BackColor = Color.LightGray;
                    textBoxEnd09.Visible = false;
                    if (bet_end09 > 0)
                        textBoxEnd09.Visible = true;
                    break;
                case bets.end10:
                    bankroll += bet_end10;
                    bet_end10 = (int)numericUpDownBet.Value;
                    textBoxEnd10.Text = "Bet: " + bet_end10;
                    textBoxEnd10.BackColor = Color.LightGray;
                    textBoxEnd10.Visible = false;
                    if (bet_end10 > 0)
                        textBoxEnd10.Visible = true;
                    break;
                case bets.end11:
                    bankroll += bet_end11;
                    bet_end11 = (int)numericUpDownBet.Value;
                    textBoxEnd11.Text = "Bet: " + bet_end11;
                    textBoxEnd11.BackColor = Color.LightGray;
                    textBoxEnd11.Visible = false;
                    if (bet_end11 > 0)
                        textBoxEnd11.Visible = true;
                    break;
                case bets.end12:
                    bankroll += bet_end12;
                    bet_end12 = (int)numericUpDownBet.Value;
                    textBoxEnd12.Text = "Bet: " + bet_end12;
                    textBoxEnd12.BackColor = Color.LightGray;
                    textBoxEnd12.Visible = false;
                    if (bet_end12 > 0)
                        textBoxEnd12.Visible = true;
                    break;
                case bets.end13:
                    bankroll += bet_end13;
                    bet_end13 = (int)numericUpDownBet.Value;
                    textBoxEnd13.Text = "Bet: " + bet_end13;
                    textBoxEnd13.BackColor = Color.LightGray;
                    textBoxEnd13.Visible = false;
                    if (bet_end13 > 0)
                        textBoxEnd13.Visible = true;
                    break;
                case bets.end14:
                    bankroll += bet_end14;
                    bet_end14 = (int)numericUpDownBet.Value;
                    textBoxEnd14.Text = "Bet: " + bet_end14;
                    textBoxEnd14.BackColor = Color.LightGray;
                    textBoxEnd14.Visible = false;
                    if (bet_end14 > 0)
                        textBoxEnd14.Visible = true;
                    break;
                case bets.doub1:
                    bankroll += bet_doub1;
                    bet_doub1 = (int)numericUpDownBet.Value;
                    textBoxDouble1.Text = "1-1 Bet: " + bet_doub1;
                    textBoxDouble1.BackColor = Color.LightGray;
                    textBoxDouble1.Visible = false;
                    if (bet_doub1 > 0)
                        textBoxDouble1.Visible = true;
                    break;
                case bets.doub2:
                    bankroll += bet_doub2;
                    bet_doub2 = (int)numericUpDownBet.Value;
                    textBoxDouble2.Text = "2-2 Bet: " + bet_doub2;
                    textBoxDouble2.BackColor = Color.LightGray;
                    textBoxDouble2.Visible = false;
                    if (bet_doub2 > 0)
                        textBoxDouble2.Visible = true;
                    break;
                case bets.doub3:
                    bankroll += bet_doub3;
                    bet_doub3 = (int)numericUpDownBet.Value;
                    textBoxDouble3.Text = "3-3 Bet: " + bet_doub3;
                    textBoxDouble3.BackColor = Color.LightGray;
                    textBoxDouble3.Visible = false;
                    if (bet_doub3 > 0)
                        textBoxDouble3.Visible = true;
                    break;
                case bets.doub4:
                    bankroll += bet_doub4;
                    bet_doub4 = (int)numericUpDownBet.Value;
                    textBoxDouble4.Text = "4-4 Bet: " + bet_doub4;
                    textBoxDouble4.BackColor = Color.LightGray;
                    textBoxDouble4.Visible = false;
                    if (bet_doub4 > 0)
                        textBoxDouble4.Visible = true;
                    break;
                case bets.doub5:
                    bankroll += bet_doub5;
                    bet_doub5 = (int)numericUpDownBet.Value;
                    textBoxDouble5.Text = "5-5 Bet: " + bet_doub5;
                    textBoxDouble5.BackColor = Color.LightGray;
                    textBoxDouble5.Visible = false;
                    if (bet_doub5 > 0)
                        textBoxDouble5.Visible = true;
                    break;
                case bets.doub6:
                    bankroll += bet_doub6;
                    bet_doub6 = (int)numericUpDownBet.Value;
                    textBoxDouble6.Text = "6-6 Bet: " + bet_doub6;
                    textBoxDouble6.BackColor = Color.LightGray;
                    textBoxDouble6.Visible = false;
                    if (bet_doub6 > 0)
                        textBoxDouble6.Visible = true;
                    break;
                default:
                    break;
            }

            toolStripStatusBankroll.Text = "Bankroll: " + bankroll;

            textBoxStatus.Text = "";

            if (betweenGames)
                openGameBets();
            else
                openRollBets();

        }

        private void buttonBetCancel_Click(object sender, EventArgs e)
        {
            numericUpDownBet.Visible = false;
            buttonBetEnter.Visible = false;
            buttonBetCancel.Visible = false;

            textBoxStatus.Text = "";

            textBoxPathPassBet.BackColor = Color.LightGray;
            textBoxPathStopBet.BackColor = Color.LightGray;
            textBoxEnd01.BackColor = Color.LightGray;
            textBoxEnd02.BackColor = Color.LightGray;
            textBoxEnd03.BackColor = Color.LightGray;
            textBoxEnd04.BackColor = Color.LightGray;
            textBoxEnd05.BackColor = Color.LightGray;
            textBoxEnd06.BackColor = Color.LightGray;
            textBoxEnd07.BackColor = Color.LightGray;
            textBoxEnd08.BackColor = Color.LightGray;
            textBoxEnd09.BackColor = Color.LightGray;
            textBoxEnd10.BackColor = Color.LightGray;
            textBoxEnd11.BackColor = Color.LightGray;
            textBoxEnd12.BackColor = Color.LightGray;
            textBoxEnd13.BackColor = Color.LightGray;
            textBoxEnd14.BackColor = Color.LightGray;
            textBoxDouble1.BackColor = Color.LightGray;
            textBoxDouble2.BackColor = Color.LightGray;
            textBoxDouble3.BackColor = Color.LightGray;
            textBoxDouble4.BackColor = Color.LightGray;
            textBoxDouble5.BackColor = Color.LightGray;
            textBoxDouble6.BackColor = Color.LightGray;

            if (betweenGames)
                openGameBets();
            else
                openRollBets();
        }

        private void openGameBets()
        {
            buttonRepeatBets.Visible = true;
            buttonPathPass.Visible = true;
            buttonPathStop.Visible = true;
            buttonEnd01.Visible = true;
            buttonEnd02.Visible = true;
            buttonEnd03.Visible = true;
            buttonEnd04.Visible = true;
            buttonEnd05.Visible = true;
            buttonEnd06.Visible = true;
            buttonEnd07.Visible = true;
            buttonEnd08.Visible = true;
            buttonEnd09.Visible = true;
            buttonEnd10.Visible = true;
            buttonEnd11.Visible = true;
            buttonEnd12.Visible = true;
            buttonEnd13.Visible = true;
            buttonEnd14.Visible = true;
            buttonDouble1.Visible = true;
            buttonDouble2.Visible = true;
            buttonDouble3.Visible = true;
            buttonDouble4.Visible = true;
            buttonDouble5.Visible = true;
            buttonDouble6.Visible = true;

            if (textBoxStatus.Text.Length > 0)
                textBoxStatus.Text += Environment.NewLine;
            textBoxStatus.Text += "Enter your bets; " + Environment.NewLine + "then press Roll to start the game";

            buttonRoll.Enabled = true;
        }

        private void openRollBets()
        {
            if (textBoxStatus.Text.Length > 0)
                textBoxStatus.Text += Environment.NewLine;
            textBoxStatus.Text += "Currently on space " + currentSpace + ". " + Environment.NewLine + "Press Roll to start next roll.";

            textBoxPathPassBet.BackColor = Color.LightGray;
            textBoxPathStopBet.BackColor = Color.LightGray;
            textBoxEnd01.BackColor = Color.LightGray;
            textBoxEnd02.BackColor = Color.LightGray;
            textBoxEnd03.BackColor = Color.LightGray;
            textBoxEnd04.BackColor = Color.LightGray;
            textBoxEnd05.BackColor = Color.LightGray;
            textBoxEnd06.BackColor = Color.LightGray;
            textBoxEnd07.BackColor = Color.LightGray;
            textBoxEnd08.BackColor = Color.LightGray;
            textBoxEnd09.BackColor = Color.LightGray;
            textBoxEnd10.BackColor = Color.LightGray;
            textBoxEnd11.BackColor = Color.LightGray;
            textBoxEnd12.BackColor = Color.LightGray;
            textBoxEnd13.BackColor = Color.LightGray;
            textBoxEnd14.BackColor = Color.LightGray;
            textBoxDouble1.BackColor = Color.LightGray;
            textBoxDouble2.BackColor = Color.LightGray;
            textBoxDouble3.BackColor = Color.LightGray;
            textBoxDouble4.BackColor = Color.LightGray;
            textBoxDouble5.BackColor = Color.LightGray;
            textBoxDouble6.BackColor = Color.LightGray;

            buttonRoll.Enabled = true;
        }

        private void UpdatePath(bool endgame = false)
        {
            if (currentSpace > 0)
            {
                textBox00.BackColor = Color.DarkBlue;
            }
            if (currentSpace == 0)
            {
                if (endgame)
                {
                    textBox00.BackColor = Color.Red;
                }
                else
                {
                    textBox00.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 1)
            {
                textBox01.BackColor = Color.White;
            }
            if (currentSpace > 1)
            {
                textBox01.BackColor = Color.DarkBlue;
                bet_end01 = 0;
                textBoxEnd01.Visible = false;
            }
            if (currentSpace == 1)
            {
                if (endgame)
                {
                    textBox01.BackColor = Color.Red;
                }
                else
                {
                    textBox01.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 2)
            {
                textBox02.BackColor = Color.White;
            }
            if (currentSpace > 2)
            {
                textBox02.BackColor = Color.DarkBlue;
                bet_end02 = 0;
                textBoxEnd02.Visible = false;
            }
            if (currentSpace == 2)
            {
                if (endgame)
                {
                    textBox02.BackColor = Color.Red;
                }
                else
                {
                    textBox02.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 3)
            {
                textBox03.BackColor = Color.White;
            }
            if (currentSpace > 3)
            {
                textBox03.BackColor = Color.DarkBlue;
                bet_end03 = 0;
                textBoxEnd03.Visible = false;
            }
            if (currentSpace == 3)
            {
                if (endgame)
                {
                    textBox03.BackColor = Color.Red;
                }
                else
                {
                    textBox03.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 4)
            {
                textBox04.BackColor = Color.White;
            }
            if (currentSpace > 4)
            {
                textBox04.BackColor = Color.DarkBlue;
                bet_end04 = 0;
                textBoxEnd04.Visible = false;
            }
            if (currentSpace == 4)
            {
                if (endgame)
                {
                    textBox04.BackColor = Color.Red;
                }
                else
                {
                    textBox04.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 5)
            {
                textBox05.BackColor = Color.White;
            }
            if (currentSpace > 5)
            {
                textBox05.BackColor = Color.DarkBlue;
                bet_end05 = 0;
                textBoxEnd05.Visible = false;
            }
            if (currentSpace == 5)
            {
                if (endgame)
                {
                    textBox05.BackColor = Color.Red;
                }
                else
                {
                    textBox05.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 6)
            {
                textBox06.BackColor = Color.White;
            }
            if (currentSpace > 6)
            {
                textBox06.BackColor = Color.DarkBlue;
                bet_end06 = 0;
                textBoxEnd06.Visible = false;
            }
            if (currentSpace == 6)
            {
                if (endgame)
                {
                    textBox06.BackColor = Color.Red;
                }
                else
                {
                    textBox06.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 7)
            {
                textBox07.BackColor = Color.White;
            }
            if (currentSpace > 7)
            {
                textBox07.BackColor = Color.DarkBlue;
                bet_end07 = 0;
                textBoxEnd07.Visible = false;
            }
            if (currentSpace == 7)
            {
                if (endgame)
                {
                    textBox07.BackColor = Color.Red;
                }
                else
                {
                    textBox07.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 8)
            {
                textBox08.BackColor = Color.White;
            }
            if (currentSpace > 8)
            {
                textBox08.BackColor = Color.DarkBlue;
                bet_end08 = 0;
                textBoxEnd08.Visible = false;
            }
            if (currentSpace == 8)
            {
                if (endgame)
                {
                    textBox08.BackColor = Color.Red;
                }
                else
                {
                    textBox08.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 9)
            {
                textBox09.BackColor = Color.White;
            }
            if (currentSpace > 9)
            {
                textBox09.BackColor = Color.DarkBlue;
                bet_end09 = 0;
                textBoxEnd09.Visible = false;
            }
            if (currentSpace == 9)
            {
                if (endgame)
                {
                    textBox09.BackColor = Color.Red;
                }
                else
                {
                    textBox09.BackColor = Color.Yellow;
                }
            }

            if (currentSpace < 10)
            {
                textBox10.BackColor = Color.White;
            }
            if (currentSpace > 10)
            {
                textBox10.BackColor = Color.DarkBlue;
                bet_end10 = 0;
                textBoxEnd10.Visible = false;
            }
            if (currentSpace == 10)
            {
                textBox10.BackColor = Color.Red;
            }

            if (currentSpace < 11)
            {
                textBox11.BackColor = Color.White;
            }
            if (currentSpace > 11)
            {
                textBox11.BackColor = Color.DarkBlue;
                bet_end11 = 0;
                textBoxEnd11.Visible = false;
            }
            if (currentSpace == 11)
            {
                textBox11.BackColor = Color.Red;
            }

            if (currentSpace < 12)
            {
                textBox12.BackColor = Color.White;
            }
            if (currentSpace > 12)
            {
                textBox12.BackColor = Color.DarkBlue;
                bet_end12 = 0;
                textBoxEnd12.Visible = false;
            }
            if (currentSpace == 12)
            {
                textBox12.BackColor = Color.Red;
            }

            if (currentSpace < 13)
            {
                textBox13.BackColor = Color.White;
            }
            if (currentSpace > 13)
            {
                textBox13.BackColor = Color.DarkBlue;
                bet_end13 = 0;
                textBoxEnd13.Visible = false;
            }
            if (currentSpace == 13)
            {
                textBox13.BackColor = Color.Red;
            }

            if (currentSpace < 14)
            {
                textBox14.BackColor = Color.White;
            }
            if (currentSpace > 14)
            {
                textBox14.BackColor = Color.DarkBlue;
                bet_end14 = 0;
                textBoxEnd14.Visible = false;
            }
            if (currentSpace == 14)
            {
                textBox14.BackColor = Color.Red;
            }

        }

        private void buttonEnd01_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd01.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 1 bet: Doubles will be rolled after moving exactly 1 space. " + Environment.NewLine + "Pays 20-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end01;
        }

        private void buttonEnd02_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd02.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 2 bet: Doubles will be rolled after moving exactly 2 spaces. " + Environment.NewLine + "Pays 18-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end02;
        }

        private void buttonEnd03_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd03.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 3 bet: Doubles will be rolled after moving exactly 3 spaces. " + Environment.NewLine + "Pays 17.5-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end03;
        }

        private void buttonEnd04_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd04.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 4 bet: Doubles will be rolled after moving exactly 4 spaces. " + Environment.NewLine + "Pays 17.5-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end04;
        }

        private void buttonEnd05_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd05.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 5 bet: Doubles will be rolled after moving exactly 5 spaces. " + Environment.NewLine + "Pays 19-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end05;
        }

        private void buttonEnd06_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd06.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 6 bet: Doubles will be rolled after moving exactly 6 spaces. " + Environment.NewLine + "Pays 22-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end06;
        }

        private void buttonEnd07_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd07.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 7 bet: Doubles will be rolled after moving exactly 7 spaces. " + Environment.NewLine + "Pays 23-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end07;
        }

        private void buttonEnd08_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd08.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 8 bet: Doubles will be rolled after moving exactly 8 spaces. " + Environment.NewLine + "Pays 25-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end08;
        }

        private void buttonEnd09_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd09.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 9 bet: Doubles will be rolled after moving exactly 9 spaces. " + Environment.NewLine + "Pays 27.5-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end09;
        }

        private void buttonEnd10_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd10.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 10 bet: Exactly 10 spaces will be moved. " + Environment.NewLine + "Pays 4-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end10;
        }

        private void buttonEnd11_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd11.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 11 bet: Exactly 11 spaces will be moved. " + Environment.NewLine + "Pays 6.5-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end11;
        }

        private void buttonEnd12_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd12.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 12 bet: Exactly 12 spaces will be moved. " + Environment.NewLine + "Pays 12-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end12;
        }

        private void buttonEnd13_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd13.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 13 bet: Exactly 13 spaces will be moved. " + Environment.NewLine + "Pays 25-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end13;
        }

        private void buttonEnd14_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxEnd14.BackColor = Color.Yellow;

            textBoxStatus.Text = "End on 14 bet: Exactly 14 spaces will be moved. " + Environment.NewLine + "Pays 80-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.end14;
        }

        private void buttonRepeatBets_Click(object sender, EventArgs e)
        {
            int totalprev = 0;
            totalprev += betPrev_Path;
            totalprev += betPrev_Stop;
            totalprev += betPrev_end01;
            totalprev += betPrev_end02;
            totalprev += betPrev_end03;
            totalprev += betPrev_end04;
            totalprev += betPrev_end05;
            totalprev += betPrev_end06;
            totalprev += betPrev_end07;
            totalprev += betPrev_end08;
            totalprev += betPrev_end09;
            totalprev += betPrev_end10;
            totalprev += betPrev_end11;
            totalprev += betPrev_end12;
            totalprev += betPrev_end13;
            totalprev += betPrev_end14;
            totalprev += betPrev_doub1;
            totalprev += betPrev_doub2;
            totalprev += betPrev_doub3;
            totalprev += betPrev_doub4;
            totalprev += betPrev_doub5;
            totalprev += betPrev_doub6;

            if (bankroll >= totalprev)
            {
                bankroll += bet_Path;
                bankroll += bet_Stop;
                bankroll += bet_end01;
                bankroll += bet_end02;
                bankroll += bet_end03;
                bankroll += bet_end04;
                bankroll += bet_end05;
                bankroll += bet_end06;
                bankroll += bet_end07;
                bankroll += bet_end08;
                bankroll += bet_end09;
                bankroll += bet_end10;
                bankroll += bet_end11;
                bankroll += bet_end12;
                bankroll += bet_end13;
                bankroll += bet_end14;
                bankroll += bet_doub1;
                bankroll += bet_doub2;
                bankroll += bet_doub3;
                bankroll += bet_doub4;
                bankroll += bet_doub5;
                bankroll += bet_doub6;

                bet_Path = betPrev_Path;
                bet_Stop = betPrev_Stop;
                bet_end01 = betPrev_end01;
                bet_end02 = betPrev_end02;
                bet_end03 = betPrev_end03;
                bet_end04 = betPrev_end04;
                bet_end05 = betPrev_end05;
                bet_end06 = betPrev_end06;
                bet_end07 = betPrev_end07;
                bet_end08 = betPrev_end08;
                bet_end09 = betPrev_end09;
                bet_end10 = betPrev_end10;
                bet_end11 = betPrev_end11;
                bet_end12 = betPrev_end12;
                bet_end13 = betPrev_end13;
                bet_end14 = betPrev_end14;
                bet_doub1 = betPrev_doub1;
                bet_doub2 = betPrev_doub2;
                bet_doub3 = betPrev_doub3;
                bet_doub4 = betPrev_doub4;
                bet_doub5 = betPrev_doub5;
                bet_doub6 = betPrev_doub6;

                bankroll -= bet_Path;
                bankroll -= bet_Stop;
                bankroll -= bet_end01;
                bankroll -= bet_end02;
                bankroll -= bet_end03;
                bankroll -= bet_end04;
                bankroll -= bet_end05;
                bankroll -= bet_end06;
                bankroll -= bet_end07;
                bankroll -= bet_end08;
                bankroll -= bet_end09;
                bankroll -= bet_end10;
                bankroll -= bet_end11;
                bankroll -= bet_end12;
                bankroll -= bet_end13;
                bankroll -= bet_end14;
                bankroll -= bet_doub1;
                bankroll -= bet_doub2;
                bankroll -= bet_doub3;
                bankroll -= bet_doub4;
                bankroll -= bet_doub5;
                bankroll -= bet_doub6;

                toolStripStatusBankroll.Text = "Bankroll: " + bankroll;

                textBoxPathPassBet.Text = "Path Bet: " + bet_Path;
                textBoxPathPassBet.Visible = false;
                if (bet_Path > 0)
                    textBoxPathPassBet.Visible = true;
                textBoxPathStopBet.Text = "Doubles Bet: " + bet_Stop;
                textBoxPathStopBet.Visible = false;
                if (bet_Stop > 0)
                    textBoxPathStopBet.Visible = true;
                textBoxEnd01.Text = "Bet: " + bet_end01;
                textBoxEnd01.Visible = false;
                if (bet_end01 > 0)
                    textBoxEnd01.Visible = true;
                textBoxEnd02.Text = "Bet: " + bet_end02;
                textBoxEnd02.Visible = false;
                if (bet_end02 > 0)
                    textBoxEnd02.Visible = true;
                textBoxEnd03.Text = "Bet: " + bet_end03;
                textBoxEnd03.Visible = false;
                if (bet_end03 > 0)
                    textBoxEnd03.Visible = true;
                textBoxEnd04.Text = "Bet: " + bet_end04;
                textBoxEnd04.Visible = false;
                if (bet_end04 > 0)
                    textBoxEnd04.Visible = true;
                textBoxEnd05.Text = "Bet: " + bet_end05;
                textBoxEnd05.Visible = false;
                if (bet_end05 > 0)
                    textBoxEnd05.Visible = true;
                textBoxEnd06.Text = "Bet: " + bet_end06;
                textBoxEnd06.Visible = false;
                if (bet_end06 > 0)
                    textBoxEnd06.Visible = true;
                textBoxEnd07.Text = "Bet: " + bet_end07;
                textBoxEnd07.Visible = false;
                if (bet_end07 > 0)
                    textBoxEnd07.Visible = true;
                textBoxEnd08.Text = "Bet: " + bet_end08;
                textBoxEnd08.Visible = false;
                if (bet_end08 > 0)
                    textBoxEnd08.Visible = true;
                textBoxEnd09.Text = "Bet: " + bet_end09;
                textBoxEnd09.Visible = false;
                if (bet_end09 > 0)
                    textBoxEnd09.Visible = true;
                textBoxEnd10.Text = "Bet: " + bet_end10;
                textBoxEnd10.Visible = false;
                if (bet_end10 > 0)
                    textBoxEnd10.Visible = true;
                textBoxEnd11.Text = "Bet: " + bet_end11;
                textBoxEnd11.Visible = false;
                if (bet_end11 > 0)
                    textBoxEnd11.Visible = true;
                textBoxEnd12.Text = "Bet: " + bet_end12;
                textBoxEnd12.Visible = false;
                if (bet_end12 > 0)
                    textBoxEnd12.Visible = true;
                textBoxEnd13.Text = "Bet: " + bet_end13;
                textBoxEnd13.Visible = false;
                if (bet_end13 > 0)
                    textBoxEnd13.Visible = true;
                textBoxEnd14.Text = "Bet: " + bet_end14;
                textBoxEnd14.Visible = false;
                if (bet_end14 > 0)
                    textBoxEnd14.Visible = true;
                textBoxDouble1.Text = "1-1 Bet: " + bet_doub1;
                textBoxDouble1.Visible = false;
                if (bet_doub1 > 0)
                    textBoxDouble1.Visible = true;
                textBoxDouble2.Text = "2-2 Bet: " + bet_doub2;
                textBoxDouble2.Visible = false;
                if (bet_doub2 > 0)
                    textBoxDouble2.Visible = true;
                textBoxDouble3.Text = "3-3 Bet: " + bet_doub3;
                textBoxDouble3.Visible = false;
                if (bet_doub3 > 0)
                    textBoxDouble3.Visible = true;
                textBoxDouble4.Text = "4-4 Bet: " + bet_doub4;
                textBoxDouble4.Visible = false;
                if (bet_doub4 > 0)
                    textBoxDouble4.Visible = true;
                textBoxDouble5.Text = "5-5 Bet: " + bet_doub5;
                textBoxDouble5.Visible = false;
                if (bet_doub5 > 0)
                    textBoxDouble5.Visible = true;
                textBoxDouble6.Text = "6-6 Bet: " + bet_doub6;
                textBoxDouble6.Visible = false;
                if (bet_doub6 > 0)
                    textBoxDouble6.Visible = true;
            }
        }

        private void buttonDouble1_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxDouble1.BackColor = Color.Yellow;

            textBoxStatus.Text = "Double 1 bet: Double 1s will be rolled this game. " + Environment.NewLine + "Pays 9-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.doub1;
        }

        private void buttonDouble2_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxDouble2.BackColor = Color.Yellow;

            textBoxStatus.Text = "Double 2 bet: Double 2s will be rolled this game. " + Environment.NewLine + "Pays 9-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.doub2;
        }

        private void buttonDouble3_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxDouble3.BackColor = Color.Yellow;

            textBoxStatus.Text = "Double 3 bet: Double 3s will be rolled this game. " + Environment.NewLine + "Pays 9-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.doub3;
        }

        private void buttonDouble4_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxDouble4.BackColor = Color.Yellow;

            textBoxStatus.Text = "Double 4 bet: Double 4s will be rolled this game. " + Environment.NewLine + "Pays 9-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.doub4;
        }

        private void buttonDouble5_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxDouble5.BackColor = Color.Yellow;

            textBoxStatus.Text = "Double 5 bet: Double 5s will be rolled this game. " + Environment.NewLine + "Pays 9-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.doub5;
        }

        private void buttonDouble6_Click(object sender, EventArgs e)
        {
            buttonRepeatBets.Visible = false;
            buttonPathPass.Visible = false;
            buttonPathStop.Visible = false;
            buttonEnd01.Visible = false;
            buttonEnd02.Visible = false;
            buttonEnd03.Visible = false;
            buttonEnd04.Visible = false;
            buttonEnd05.Visible = false;
            buttonEnd06.Visible = false;
            buttonEnd07.Visible = false;
            buttonEnd08.Visible = false;
            buttonEnd09.Visible = false;
            buttonEnd10.Visible = false;
            buttonEnd11.Visible = false;
            buttonEnd12.Visible = false;
            buttonEnd13.Visible = false;
            buttonEnd14.Visible = false;
            buttonDouble1.Visible = false;
            buttonDouble2.Visible = false;
            buttonDouble3.Visible = false;
            buttonDouble4.Visible = false;
            buttonDouble5.Visible = false;
            buttonDouble6.Visible = false;
            buttonRoll.Enabled = false;

            numericUpDownBet.Maximum = bankroll;
            numericUpDownBet.Visible = true;
            buttonBetEnter.Visible = true;
            buttonBetCancel.Visible = true;

            textBoxDouble6.BackColor = Color.Yellow;

            textBoxStatus.Text = "Double 6 bet: Double 6s will be rolled this game. " + Environment.NewLine + "Pays 9-1. " + Environment.NewLine + "Enter your bet and press Bet It";

            currentBet = bets.doub6;
        }

    }
}
