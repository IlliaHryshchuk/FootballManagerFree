using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;


namespace FootballManagerFree
{
    public partial class AddTeamMenu : MaterialSkin.Controls.MaterialForm
    {
        bool pcBox2OnTop = true;
        bool goRight = true;
        string numOfPic = "2";
        delegate void setNameOfPerson(string str);
        delegate string picNameSliderR(string str);
        delegate string picNameSliderL(string str);

        public AddTeamMenu()
        {
            InitializeComponent();
            Tournament.skinManager.AddFormToManage(this);
        }
        //save
        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text != "" && materialSingleLineTextField2.Text != "" && materialSingleLineTextField4.Text != "" && materialSingleLineTextField5.Text != "" && materialSingleLineTextField6.Text != "" && materialSingleLineTextField7.Text != "" && materialSingleLineTextField3.Text != "" &&  materialSingleLineTextField8.Text != "" &&  materialSingleLineTextField9.Text != "" &&  materialSingleLineTextField10.Text != "" && materialSingleLineTextField11.Text != "" && materialSingleLineTextField12.Text != "" && materialSingleLineTextField13.Text != "" && materialSingleLineTextField14.Text != "")
            {
                FootballTeam fteam = new FootballTeam();
                fteam.NameOfTeam = materialSingleLineTextField1.Text;
                fteam.LogoNum = numOfPic; 
                fteam.Country = materialSingleLineTextField2.Text;
                for (int j = 0; j < 3; j++)
                {
                    fteam.player[j] = new Player();
                }
                setNameOfPerson snop = new setNameOfPerson(fteam.player[0].setName); //delegate
                snop(materialSingleLineTextField4.Text);
                fteam.player[0].Age = materialSingleLineTextField3.Text;
                fteam.player[0].Country = materialSingleLineTextField8.Text;

                snop = new setNameOfPerson(fteam.player[1].setName);
                snop(materialSingleLineTextField5.Text);
                fteam.player[1].Age = materialSingleLineTextField9.Text;
                fteam.player[1].Country = materialSingleLineTextField10.Text;

                snop = new setNameOfPerson(fteam.player[2].setName);
                snop(materialSingleLineTextField6.Text);
                fteam.player[2].Age = materialSingleLineTextField11.Text;
                fteam.player[2].Country = materialSingleLineTextField12.Text;

                snop = new setNameOfPerson(fteam.coach.setName);
                snop(materialSingleLineTextField7.Text);
                fteam.coach.Age = materialSingleLineTextField13.Text;
                fteam.coach.Country = materialSingleLineTextField14.Text;

                fteam.player[0].FootballTeam = fteam;
                fteam.player[1].FootballTeam = fteam;
                fteam.player[2].FootballTeam = fteam;

                fteam.writeInfo(fteam);
                MessageBox.Show("Команда додана успішно!");
                materialSingleLineTextField1.Text = "";
                materialSingleLineTextField2.Text = "";
                materialSingleLineTextField4.Text = "";
                materialSingleLineTextField5.Text = "";
                materialSingleLineTextField6.Text = "";
                materialSingleLineTextField7.Text = "";
                materialSingleLineTextField3.Text = "";
                materialSingleLineTextField8.Text = "";
                materialSingleLineTextField9.Text = "";
                materialSingleLineTextField10.Text = "";
                materialSingleLineTextField11.Text = "";
                materialSingleLineTextField12.Text = "";
                materialSingleLineTextField13.Text = "";
                materialSingleLineTextField14.Text = "";
            }
            else
            {
                MessageBox.Show("Заповніть всі поля!");
            }
            Coach coach = new Coach();
        }

        private void materialSingleLineTextField3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != 8)
                e.Handled = true;
        }
        // >>
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            picNameSliderR slider = num => //lambda
            {
                num = num + 2;
                if (num == "22222222222")
                {
                    num = "2";
                }
                return num;
            };

            numOfPic = slider(numOfPic);
            materialFlatButton1.Enabled = false;
            materialFlatButton2.Enabled = false;
            materialFlatButton3.Enabled = false;
            if (pcBox2OnTop == true)
            {
                pictureBox4.Load(@"../../logos/" + numOfPic + ".jpg");
                pcBox2OnTop = false;
                timer4.Start();
            }
            else
            {
                pictureBox2.Load(@"../../logos/" + numOfPic + ".jpg");
                pcBox2OnTop = true;
                timer3.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goRight == true) //left is right here ;)
            {
                pictureBox2.Left -= 5;
                if (pictureBox2.Left <= 130)
                {
                    pictureBox2.BringToFront();
                    goRight = false;
                }
            }
            else if (goRight == false)
            {
                pictureBox2.Left += 5;
                if (pictureBox2.Left >= 190)
                {
                    goRight = true;
                    materialFlatButton1.Enabled = true;
                    materialFlatButton2.Enabled = true;
                    materialFlatButton3.Enabled = true;
                    timer1.Stop();
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {

                if (goRight == true) //left is right here ;)
                {
                    pictureBox4.Left -= 5;
                    if (pictureBox4.Left <= 130)
                    {
                        pictureBox4.BringToFront();
                        goRight = false;
                    }
                }
                else if (goRight == false)
                {
                    pictureBox4.Left += 5;
                    if (pictureBox4.Left >= 190)
                    {
                        goRight = true;
                    materialFlatButton1.Enabled = true;
                    materialFlatButton2.Enabled = true;
                    materialFlatButton3.Enabled = true;
                    timer2.Stop();
                    }
                }
        }
        //<<
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            picNameSliderL slider = num => //lambda
            {
                num = num.Substring(0, num.Length - 1);
                if (num == "")
                    num = "2222222222";
                return num;
            };

            numOfPic = slider(numOfPic);
            materialFlatButton1.Enabled = false;
            materialFlatButton2.Enabled = false;
            materialFlatButton3.Enabled = false;
            if (pcBox2OnTop == true)
            {
                pictureBox4.Load(@"../../logos/" + numOfPic + ".jpg");
                pcBox2OnTop = false;
                timer2.Start();
            }
            else
            {
                pictureBox2.Load(@"../../logos/" + numOfPic + ".jpg");
                pcBox2OnTop = true;
                timer1.Start();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
                if (goRight == true)
                {
                    pictureBox4.Left += 5;
                    if (pictureBox4.Left >= 230)
                    {
                        pictureBox4.BringToFront();
                        goRight = false;
                    }
                }
                else if (goRight == false)
                {
                    pictureBox4.Left -= 5;
                    if (pictureBox4.Left <= 190)
                    {
                        goRight = true;
                    materialFlatButton1.Enabled = true;
                    materialFlatButton2.Enabled = true;
                    materialFlatButton3.Enabled = true;
                    timer4.Stop();
                    }
                }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (goRight == true)
            {
                pictureBox2.Left += 5;
                if (pictureBox2.Left >= 230)
                {
                    pictureBox2.BringToFront();
                    goRight = false;
                }
            }
            else if (goRight == false)
            {
                pictureBox2.Left -= 5;
                if (pictureBox2.Left <= 190)
                {
                    goRight = true;
                    materialFlatButton1.Enabled = true;
                    materialFlatButton2.Enabled = true;
                    materialFlatButton3.Enabled = true;
                    timer3.Stop();
                }
            }
        }

        private void AddTeamMenu_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }
    }
    
}
