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
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {

        bool changeMode = false;
        bool pcBox2OnTop = true;
        bool goRight = true;
        //MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;

        string numOfPic = "1";
        FootballTeam[] fteam = new FootballTeam[40];
        int size = 0;
        delegate void enablerForPics(bool var);
        Tournament tournament = new Tournament();


      

        public Form1()
        {
            InitializeComponent();

            Tournament.skinManager = MaterialSkin.MaterialSkinManager.Instance;
            Tournament.skinManager.AddFormToManage(this);
            Tournament.skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
            Tournament.skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green900, MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Green600, MaterialSkin.Accent.DeepOrange700, MaterialSkin.TextShade.BLACK);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            materialFlatButton10.Enabled = false;// NE ZABUD` UDALUTU
            tournament = tournament.readInfoAboutTournament(tournament);
            materialLabel5.Text = tournament.NameOfTournament;
            numOfPic = tournament.NumOfPic;
            pictureBox2.Load(@"../../pictures/" + numOfPic + ".jpg");
            label27.Text = tournament.Place;
            materialLabel6.Text = tournament.Date;
            for (int i = 0; i < 40; i++)
                fteam[i] = new FootballTeam();
        }

        private void materialDivider1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }

        private void materialTabSelector2_Click(object sender, EventArgs e)
        {

        }
        string[] fields = new string[] { "Металіст, Харків", "Альянц арена, Мюнхен", "Зігнал-Ідуна-Парк, Дортмунд", "Лужніки, Москва", "Олімпійський, Лондон", "НСК олімпійський, Київ", "Донбас арена, Донецьк", "Газпром арена, Санкт Петербург", "Coca-cola fun mode" };
        // >>
        private void materialFlatButton7_Click(object sender, EventArgs e)
        {
            enablerForPics enabler = delegate (bool var) //anon
            {
                materialFlatButton7.Enabled = var;
                materialFlatButton8.Enabled = var;
                materialFlatButton4.Enabled = var;
            };
            enabler(false);
            numOfPic = numOfPic + 1;
            if (numOfPic == "1111111111") numOfPic = "1";
            label27.Text = fields[numOfPic.Length - 1];
            if (pcBox2OnTop == true)
            {
                pictureBox4.Load(@"../../pictures/" + numOfPic + ".jpg");
                pcBox2OnTop = false;
                timer4.Start();
            }
            else
            {
                pictureBox2.Load(@"../../pictures/" + numOfPic + ".jpg");
                pcBox2OnTop = true;
                timer3.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (goRight == true) //left is right here ;)
            {
                pictureBox4.Left -= 10;
                if (pictureBox4.Left <= -40)
                {
                    pictureBox4.BringToFront();
                    goRight = false;
                }
            }
            else if (goRight == false)
            {
                pictureBox4.Left += 10;
                if (pictureBox4.Left >= 130)
                {
                    goRight = true;
                    materialFlatButton7.Enabled = true;
                    materialFlatButton8.Enabled = true;
                    materialFlatButton4.Enabled = true;
                    timer1.Stop();
                }
            }
            //if(pcBox2OnTop == true)
            //{
            //    if (goRight == true)
            //    {
            //        materialFlatButton7.Enabled = false;
            //        materialFlatButton8.Enabled = false;
            //        pictureBox4.Left += 10;
            //        if (pictureBox4.Left >= 340)
            //        {
            //            pictureBox4.BringToFront();
            //            goRight = false;
            //        }
            //    }
            //    else if (goRight == false)
            //    {
            //        pictureBox4.Left -= 10;
            //        if (pictureBox4.Left <= 140)
            //        {
            //            materialFlatButton7.Enabled = true;
            //            materialFlatButton8.Enabled = true;
            //            //pictureBox4.Image = Properties.Resources._1;
            //            pictureBox2.Load(@"../../pictures/" + numOfPic + ".jpg");
            //            pcBox2OnTop = false;
            //            goRight = true;
            //            timer1.Stop();
            //        }
            //    }
            //}
            //else if(pcBox2OnTop == false)
            //{
            //    if (goRight == true)
            //    {
            //        materialFlatButton8.Enabled = false;
            //        materialFlatButton7.Enabled = false;
            //        pictureBox2.Left += 10;
            //        if (pictureBox2.Left >= 340)
            //        {
            //            pictureBox2.BringToFront();
            //            goRight = false;
            //        }
            //    }
            //    else if (goRight == false)
            //    {
            //        pictureBox2.Left -= 10;
            //        if (pictureBox2.Left <= 140)
            //        {
            //            materialFlatButton8.Enabled = true;
            //            materialFlatButton7.Enabled = true;
            //            pictureBox4.Load(@"../../pictures/" + numOfPic + ".jpg");
            //            pcBox2OnTop = true;
            //            goRight = true;
            //            timer1.Stop();
            //        }
            //    }
            //}
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (goRight == true) //left is right here ;)
            {
                pictureBox2.Left -= 10;
                if (pictureBox2.Left <= -40)
                {
                    pictureBox2.BringToFront();
                    goRight = false;
                }
            }
            else if (goRight == false)
            {
                pictureBox2.Left += 10;
                if (pictureBox2.Left >= 130)
                {
                    goRight = true;
                    materialFlatButton7.Enabled = true;
                    materialFlatButton8.Enabled = true;
                    materialFlatButton4.Enabled = true;
                    timer2.Stop();
                }
            }
            //if (pcBox2OnTop == true)
            //{
            //    if (goRight == true) //left is right here ;)
            //    {
            //        materialFlatButton7.Enabled = false;
            //        materialFlatButton8.Enabled = false;
            //        pictureBox4.Left -= 10;
            //        if (pictureBox4.Left <= -40)
            //        {
            //            pictureBox4.BringToFront();
            //            goRight = false;
            //        }
            //    }
            //    else if (goRight == false)
            //    {
            //        pictureBox4.Left += 10;
            //        if (pictureBox4.Left >= 130)
            //        {
            //            materialFlatButton7.Enabled = true;
            //            materialFlatButton8.Enabled = true;
            //            pictureBox2.Load(@"../../pictures/" + numOfPic + ".jpg");
            //            pcBox2OnTop = false;
            //            goRight = true;
            //            timer2.Stop();
            //        }
            //    }
            //}
            //else if (pcBox2OnTop == false)
            //{
            //    if (goRight == true)
            //    {
            //        materialFlatButton8.Enabled = false;
            //        materialFlatButton7.Enabled = false;
            //        pictureBox2.Left -= 10;
            //        if (pictureBox2.Left <= -40)
            //        {
            //            pictureBox2.BringToFront();
            //            goRight = false;
            //        }
            //    }
            //    else if (goRight == false)
            //    {
            //        pictureBox2.Left += 10;
            //        if (pictureBox2.Left >= 130)
            //        {
            //            materialFlatButton8.Enabled = true;
            //            materialFlatButton7.Enabled = true;
            //            pictureBox4.Load(@"../../pictures/" + numOfPic + ".jpg");
            //            pcBox2OnTop = true;
            //            goRight = true;
            //            timer2.Stop();
            //        }
            //    }
            //}
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
        //info pro turnir
        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Black;
            pictureBox12.BackColor = Color.Black;
            pictureBox10.BackColor = Color.Black;
            pictureBox3.BackColor = Color.DarkGreen;
            pictureBox50.BackColor = Color.Black;
            panel5.Visible = false;
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
        }
        //spisok komand
        private void materialFlatButton2_Click(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Black;
            pictureBox12.BackColor = Color.DarkGreen;
            pictureBox10.BackColor = Color.Black;
            pictureBox3.BackColor = Color.Black;
            pictureBox50.BackColor = Color.Black;
            panel5.Visible = false;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel2.Visible = true;

            comboBox1.Items.Clear();
            size = fteam[0].readAllTeams(ref fteam);


            //TO FIX
            int j = 0;
            for (int i = 0; i < size; i++)
            {
                for (j = 0; j < 3; j++)
                    fteam[i].player[j] = fteam[i].Players.ElementAt(j);
                
            }
            //end FIX

            for (int i = 0; i < size; i++)
                comboBox1.Items.Add(fteam[i].NameOfTeam);
            //comboBox1.SelectedIndex = 0;
            pictureBox20.Load(@"../../logos/empty.jpg");
            materialLabel12.Text = "empty";
            materialLabel13.Text = "empty";
            materialLabel14.Text = "empty";
            materialLabel15.Text = "empty";
            materialLabel16.Text = "empty";
            if (comboBox1.SelectedIndex == -1) materialFlatButton10.Enabled = false;
            else materialFlatButton10.Enabled = true;
        }
        //stvorutu comandu
        private void materialFlatButton3_Click(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Black;
            pictureBox12.BackColor = Color.Black;
            pictureBox10.BackColor = Color.Black;
            pictureBox3.BackColor = Color.Black;
            panel1.Visible = false;
        }
        //tablica
        private void materialFlatButton5_Click(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.DarkGreen;
            pictureBox12.BackColor = Color.Black;
            pictureBox10.BackColor = Color.Black;
            pictureBox3.BackColor = Color.Black;
            pictureBox50.BackColor = Color.Black;
            panel5.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel3.Visible = true;

            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox7.Items.Clear();
            comboBox8.Items.Clear();
            comboBox9.Items.Clear();

            size = fteam[0].readAllTeams(ref fteam);

            for (int i = 0; i < size; i++)
            {
                comboBox2.Items.Add(fteam[i].NameOfTeam);
                comboBox3.Items.Add(fteam[i].NameOfTeam);
                comboBox4.Items.Add(fteam[i].NameOfTeam);
                comboBox5.Items.Add(fteam[i].NameOfTeam);
                comboBox6.Items.Add(fteam[i].NameOfTeam);
                comboBox7.Items.Add(fteam[i].NameOfTeam);
                comboBox8.Items.Add(fteam[i].NameOfTeam);
                comboBox9.Items.Add(fteam[i].NameOfTeam);
            }
            pictureBox11.Load(@"../../logos/empty.jpg");
            pictureBox21.Load(@"../../logos/empty.jpg");
            pictureBox22.Load(@"../../logos/empty.jpg");
            pictureBox23.Load(@"../../logos/empty.jpg");
            pictureBox24.Load(@"../../logos/empty.jpg");
            pictureBox25.Load(@"../../logos/empty.jpg");
            pictureBox26.Load(@"../../logos/empty.jpg");
            pictureBox27.Load(@"../../logos/empty.jpg");
        }
        //nalashtuvannia
        private void materialFlatButton6_Click(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Black;
            pictureBox12.BackColor = Color.Black;
            pictureBox10.BackColor = Color.DarkGreen;
            pictureBox3.BackColor = Color.Black;
            pictureBox50.BackColor = Color.Black;
            panel5.Visible = false;
            panel1.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;
        }
        //zminutu on info pro turnir
        private void materialFlatButton4_Click(object sender, EventArgs e)
        {
                changeMode = true;
                pictureBox9.BackColor = Color.DarkGreen;
                pictureBox16.BackColor = Color.DarkGreen;
                pictureBox17.BackColor = Color.DarkGreen;
                materialFlatButton3.Visible = true;
                pictureBox9.Width = 83;
                materialSingleLineTextField1.Visible = true;
                materialSingleLineTextField2.Visible = true;
                materialFlatButton7.Visible = true;
                materialFlatButton8.Visible = true;
                materialSingleLineTextField1.Text = materialLabel5.Text;
                materialSingleLineTextField2.Text = materialLabel6.Text;
        }
        //date of tournament
        private void materialSingleLineTextField2_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField2.Text = "";
        }
        //name of tournament
        private void materialSingleLineTextField1_Click(object sender, EventArgs e)
        {
            materialSingleLineTextField1.Text = "";
        }
        //<<
        private void materialFlatButton8_Click(object sender, EventArgs e)
        {

            numOfPic = numOfPic.Substring(0, numOfPic.Length-1);
            if (numOfPic == "") numOfPic = "111111111";
            label27.Text = fields[numOfPic.Length - 1];
            materialFlatButton7.Enabled = false;
            materialFlatButton8.Enabled = false;
            materialFlatButton4.Enabled = false;
            if (pcBox2OnTop == true)
            {
                pictureBox4.Load(@"../../pictures/" + numOfPic + ".jpg");
                pcBox2OnTop = false;
                timer1.Start();
            }
            else
            {
                pictureBox2.Load(@"../../pictures/" + numOfPic + ".jpg");
                pcBox2OnTop = true;
                timer2.Start();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void materialLabel9_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox24_Click(object sender, EventArgs e)
        {

        }

        //spisok komand.spisok komand
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox20.Load(@"../../logos/" + fteam[comboBox1.SelectedIndex].LogoNum + ".jpg");
            materialLabel12.Text = fteam[comboBox1.SelectedIndex].Country;
            materialLabel13.Text = Convert.ToString(fteam[comboBox1.SelectedIndex].Rating);

           // foreach (Player player in fteam[comboBox1.SelectedIndex].Players)
             //   materialLabel14.Text = player.Name;  //dorobutu

            materialLabel14.Text = fteam[comboBox1.SelectedIndex].Players.ElementAt(0).Name;
            materialLabel15.Text = fteam[comboBox1.SelectedIndex].Players.ElementAt(1).Name;
            materialLabel16.Text = fteam[comboBox1.SelectedIndex].Players.ElementAt(2).Name;
            // materialLabel14.Text = fteam[comboBox1.SelectedIndex].player[0].Name;
            // materialLabel15.Text = fteam[comboBox1.SelectedIndex].player[1].Name;
            // materialLabel16.Text = fteam[comboBox1.SelectedIndex].player[2].Name;

            if (comboBox1.SelectedIndex == -1) materialFlatButton10.Enabled = false;
            else materialFlatButton10.Enabled = true;
        }
        //add team
        private void materialFlatButton9_Click(object sender, EventArgs e)
        {
            AddTeamMenu atm = new AddTeamMenu();
            //atm.Load += (senderAtm, eAtm) =>
            //{
            //    atm.SkinManager skn = this.skinManager;
            //   // atm.textBox1.Text = SlaveForm.textBox2.Text;
            //};
            //MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
            //skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            atm.ShowDialog();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox28.SendToBack();
            pictureBox11.Load(@"../../logos/" + fteam[comboBox2.SelectedIndex].LogoNum + ".jpg");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox29.SendToBack();
            pictureBox21.Load(@"../../logos/" + fteam[comboBox3.SelectedIndex].LogoNum + ".jpg");
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox32.SendToBack();
            pictureBox22.Load(@"../../logos/" + fteam[comboBox4.SelectedIndex].LogoNum + ".jpg");
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox33.SendToBack();
            pictureBox23.Load(@"../../logos/" + fteam[comboBox5.SelectedIndex].LogoNum + ".jpg");
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox35.SendToBack();
            pictureBox24.Load(@"../../logos/" + fteam[comboBox6.SelectedIndex].LogoNum + ".jpg");
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox30.SendToBack();
            pictureBox25.Load(@"../../logos/" + fteam[comboBox7.SelectedIndex].LogoNum + ".jpg");

        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox34.SendToBack();
            pictureBox26.Load(@"../../logos/" + fteam[comboBox8.SelectedIndex].LogoNum + ".jpg");
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox31.SendToBack();
            pictureBox27.Load(@"../../logos/" + fteam[comboBox9.SelectedIndex].LogoNum + ".jpg");
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Tournament.skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Tournament.skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tournament.skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Green900, MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Green600, MaterialSkin.Accent.DeepOrange700, MaterialSkin.TextShade.BLACK);
            pictureBox10.BackColor = Color.Green;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tournament.skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.LightBlue300, MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Green600, MaterialSkin.Accent.DeepOrange700, MaterialSkin.TextShade.BLACK);
            pictureBox10.BackColor = Color.AliceBlue;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Tournament.skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Red700, MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Green600, MaterialSkin.Accent.DeepOrange700, MaterialSkin.TextShade.BLACK);
            pictureBox10.BackColor = Color.Red;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Tournament.skinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Yellow700, MaterialSkin.Primary.Grey800, MaterialSkin.Primary.Green600, MaterialSkin.Accent.DeepOrange700, MaterialSkin.TextShade.BLACK);
            pictureBox10.BackColor = Color.Yellow;
        }
        //return from tablo
        private void pictureBox47_Click(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Black;
            pictureBox12.BackColor = Color.DarkGreen;
            pictureBox10.BackColor = Color.Black;
            pictureBox3.BackColor = Color.Black;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel2.Visible = true;
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            if (goRight == true)
            {
                pictureBox2.Left += 10;
                if (pictureBox2.Left >= 340)
                {
                    pictureBox2.BringToFront();
                    goRight = false;
                }
            }
            else if (goRight == false)
            {
                pictureBox2.Left -= 10;
                if (pictureBox2.Left <= 140)
                {
                    goRight = true;
                    materialFlatButton7.Enabled = true;
                    materialFlatButton8.Enabled = true;
                    materialFlatButton4.Enabled = true;
                    timer3.Stop();
                }
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            if (goRight == true)
            {
                pictureBox4.Left += 10;
                if (pictureBox4.Left >= 340)
                {
                    pictureBox4.BringToFront();
                    goRight = false;
                }
            }
            else if (goRight == false)
            {
                pictureBox4.Left -= 10;
                if (pictureBox4.Left <= 140)
                {
                    goRight = true;
                    materialFlatButton7.Enabled = true;
                    materialFlatButton8.Enabled = true;
                    materialFlatButton4.Enabled = true;
                    timer4.Stop();
                }
            }
        }

        //zberegtu
        private void materialFlatButton3_Click_1(object sender, EventArgs e)
        {
            if (materialSingleLineTextField1.Text == "" || materialSingleLineTextField2.Text == "")
            {

                MessageBox.Show("Заповніть поля!");
            }
            else
            {
                //Tournament tournament = new Tournament();
                tournament.NameOfTournament = materialSingleLineTextField1.Text;
                tournament.NumOfPic = numOfPic;
                tournament.Place = label27.Text;
                tournament.Date = materialSingleLineTextField2.Text;
                if (materialSingleLineTextField1.Text != materialLabel5.Text || materialSingleLineTextField2.Text != materialLabel6.Text || numOfPic != tournament.NumOfPic)
                {
                    tournament.writeInfoAboutTournament(tournament);
                }
                changeMode = false;
                pictureBox9.BackColor = Color.Black;
                pictureBox16.BackColor = Color.FromArgb(33, 33, 33);
                pictureBox17.BackColor = Color.FromArgb(33, 33, 33);
                pictureBox9.Width = 78;
                materialSingleLineTextField1.Visible = false;
                materialSingleLineTextField2.Visible = false;
                materialFlatButton7.Visible = false;
                materialFlatButton8.Visible = false;
                materialFlatButton3.Visible = false;
                materialLabel5.Text = materialSingleLineTextField1.Text;
                materialLabel6.Text = materialSingleLineTextField2.Text;
            }
        }

        //random tour
        private void pictureBox44_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            int randomCoof1 = rnd.Next(0, 100);

            Random rand = new Random(((int)DateTime.Now.Ticks));
            int rndnum = 0, j = 0;
            int[] mas = new int[8];
            for (int i = 0; i < 8; i++)
                mas[i] = 41;
            while (mas[7] == 41)
            {
                rndnum = rand.Next(0, size);
                if (mas.Contains(rndnum))
                {
                    continue;
                }
                else
                {
                    mas[j] = rndnum;
                    j++;
                }
            }

            comboBox2.SelectedIndex = mas[0];
            comboBox3.SelectedIndex = mas[1];
            comboBox4.SelectedIndex = mas[2];
            comboBox5.SelectedIndex = mas[3];
            comboBox6.SelectedIndex = mas[4];
            comboBox7.SelectedIndex = mas[5];
            comboBox8.SelectedIndex = mas[6];
            comboBox9.SelectedIndex = mas[7];
        }

        private void pictureBox46_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1 || comboBox3.SelectedIndex == -1 || comboBox4.SelectedIndex == -1 || comboBox5.SelectedIndex == -1 || comboBox6.SelectedIndex == -1 || comboBox7.SelectedIndex == -1 || comboBox8.SelectedIndex == -1 || comboBox9.SelectedIndex == -1)
            {
                MessageBox.Show("Заповніть групи повністю!");
            }
            else
            {
                MessageBox.Show("Команди зареєстровані успішно! Очікуйте початок турніру!");
                FootballTeam[] teamsWinners = new FootballTeam[7];
                for (int i = 0; i < 7; i++)
                    teamsWinners[i] = new FootballTeam();
                //A
                teamsWinners[0] = teamsWinners[0].playGame(fteam[comboBox2.SelectedIndex], fteam[comboBox3.SelectedIndex]);
                pictureBox38.Load(@"../../logos/" + teamsWinners[0].LogoNum + ".jpg");
                teamsWinners[1] = teamsWinners[1].playGame(fteam[comboBox4.SelectedIndex], fteam[comboBox5.SelectedIndex]);
                pictureBox39.Load(@"../../logos/" + teamsWinners[1].LogoNum + ".jpg");
                teamsWinners[2] = teamsWinners[2].playGame(teamsWinners[0], teamsWinners[1]);
                pictureBox42.Load(@"../../logos/" + teamsWinners[2].LogoNum + ".jpg");
                //B
                teamsWinners[3] = teamsWinners[3].playGame(fteam[comboBox6.SelectedIndex], fteam[comboBox7.SelectedIndex]);
                pictureBox40.Load(@"../../logos/" + teamsWinners[3].LogoNum + ".jpg");
                teamsWinners[4] = teamsWinners[4].playGame(fteam[comboBox8.SelectedIndex], fteam[comboBox9.SelectedIndex]);
                pictureBox41.Load(@"../../logos/" + teamsWinners[4].LogoNum + ".jpg");
                teamsWinners[5] = teamsWinners[5].playGame(teamsWinners[3], teamsWinners[4]);
                pictureBox43.Load(@"../../logos/" + teamsWinners[5].LogoNum + ".jpg");
                //FINAL
                teamsWinners[6] = teamsWinners[6].playGame(teamsWinners[2], teamsWinners[5]);
                pictureBox48.Load(@"../../logos/" + teamsWinners[6].LogoNum + ".jpg");
                tournament.cheersForWinner(teamsWinners[6]);
                MessageBox.Show("Команда " + teamsWinners[6].NameOfTeam + " виграла турнір!");
                pictureBox46.Enabled = false;
            }
        }

        //detalno
        private void materialFlatButton10_Click(object sender, EventArgs e)
        {
            DetailedInfo detinfo = new DetailedInfo();
            detinfo.Fteam = fteam[comboBox1.SelectedIndex];
            detinfo.ShowDialog();
        }

        private void pictureBox48_Click(object sender, EventArgs e)
        {

        }
        //statistica
        List<FootballTeam> teams = new List<FootballTeam>();
        private void materialFlatButton11_Click(object sender, EventArgs e)
        {
            pictureBox13.BackColor = Color.Black;
            pictureBox12.BackColor = Color.Black;
            pictureBox10.BackColor = Color.Black;
            pictureBox3.BackColor = Color.Black;
            pictureBox50.BackColor = Color.DarkGreen;
            panel5.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            
            size = fteam[0].readAllTeams(ref fteam);
            teams.Clear();
            for (int i = 0; i < size; i++)
            {
                teams.Add(fteam[i]);
            }
            comboBox10.SelectedIndex = 0;
        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (TournamentContext db = new TournamentContext())
            {


                dataGridView1.Rows.Clear(); //teams+players+features
                dataGridView1.Columns.Clear();
                dataGridView1.ReadOnly = true;

                dataGridView1.Columns.Add("гравець", "гравець");
                dataGridView1.Columns.Add("команда", "команда");
                dataGridView1.Columns.Add("сила", "сила");
                dataGridView1.Columns.Add("швидкість", "швидкість");
                dataGridView1.Columns.Add("гра", "гра");
                dataGridView1.Columns.Add("здоров'я", "здоров'я");
                for (int i = 0; i < size; i++)
                {
                    dataGridView1.Rows.Add(fteam[i].Players.ElementAt(0).Name, fteam[i].NameOfTeam, fteam[i].Players.ElementAt(0).power, fteam[i].Players.ElementAt(0).speed, fteam[i].Players.ElementAt(0).skill, fteam[i].Players.ElementAt(0).health);
                    dataGridView1.Rows.Add(fteam[i].Players.ElementAt(1).Name, fteam[i].NameOfTeam, fteam[i].Players.ElementAt(1).power, fteam[i].Players.ElementAt(1).speed, fteam[i].Players.ElementAt(1).skill, fteam[i].Players.ElementAt(1).health);
                    dataGridView1.Rows.Add(fteam[i].Players.ElementAt(2).Name, fteam[i].NameOfTeam, fteam[i].Players.ElementAt(2).power, fteam[i].Players.ElementAt(2).speed, fteam[i].Players.ElementAt(2).skill, fteam[i].Players.ElementAt(2).health);

                }

                switch (comboBox10.SelectedIndex)
                {
                    case 0://teams+players+features
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();


                        dataGridView1.Columns.Add("команда", "команда");
                        dataGridView1.Columns.Add("гравець", "гравець");
                        dataGridView1.Columns.Add("сила", "сила");
                        dataGridView1.Columns.Add("швидкість", "швидкість");
                        dataGridView1.Columns.Add("гра", "гра");
                        dataGridView1.Columns.Add("здоров'я", "здоров'я");
                        for (int i = 0; i < size; i++)
                        {
                            dataGridView1.Rows.Add(fteam[i].NameOfTeam, fteam[i].Players.ElementAt(0).Name, fteam[i].Players.ElementAt(0).power, fteam[i].Players.ElementAt(0).speed, fteam[i].Players.ElementAt(0).skill, fteam[i].Players.ElementAt(0).health);
                            dataGridView1.Rows.Add(fteam[i].NameOfTeam, fteam[i].Players.ElementAt(1).Name, fteam[i].Players.ElementAt(1).power, fteam[i].Players.ElementAt(1).speed, fteam[i].Players.ElementAt(1).skill, fteam[i].Players.ElementAt(1).health);
                            dataGridView1.Rows.Add(fteam[i].NameOfTeam, fteam[i].Players.ElementAt(2).Name, fteam[i].Players.ElementAt(2).power, fteam[i].Players.ElementAt(2).speed, fteam[i].Players.ElementAt(2).skill, fteam[i].Players.ElementAt(2).health);

                        }
                        break;
                    case 1://win/lost > 50%
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();

                        dataGridView1.Columns.Add("команда", "команда");
                        dataGridView1.Columns.Add("вінрейт", "ігор/перемог");
                        dataGridView1.Columns.Add("рейтинг", "рейтинг");
                        dataGridView1.Columns.Add("гроші", "гроші");


                        var rez = db.Fteams.Where(p => p.Wins > p.PlayedGames / 2).Union(db.Fteams.Where(p => p.PlayedGames < 2 * p.Wins)).OrderByDescending(t => t.Rating);
                        int rw__ = 0;
                        foreach (var r in rez)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[rw__].Cells[0].Value = r.NameOfTeam;
                            dataGridView1.Rows[rw__].Cells[1].Value = r.Wins + "/" + r.PlayedGames;
                            dataGridView1.Rows[rw__].Cells[2].Value = r.Rating;
                            dataGridView1.Rows[rw__].Cells[3].Value = r.Money;
                            rw__++;
                        }


                        //dataGridView1.Height = dataGridView1.Rows[0].Height * rw__;

                        break;
                    case 2://country
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();

                        dataGridView1.Columns.Add("країна", "країна");
                        dataGridView1.Columns.Add("команда", "команда");
                        dataGridView1.Columns.Add("вінрейт", "перемог/ігор");
                        dataGridView1.Columns.Add("рейтинг", "рейтинг");
                        dataGridView1.Columns.Add("гроші", "гроші");

                        var from1country = from team in teams
                                            group team by team.Country;
                        from1country.OrderBy(t => t);
                        int rw = 0;
                        foreach (IGrouping<string, FootballTeam> teams in from1country)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[rw].Cells[0].Value = teams.Key;
                            foreach (var t in teams)
                            {
                                dataGridView1.Rows[rw].Cells[1].Value = t.NameOfTeam;
                                dataGridView1.Rows[rw].Cells[2].Value = t.Wins + "/" + t.PlayedGames;
                                dataGridView1.Rows[rw].Cells[3].Value = t.Rating;
                                dataGridView1.Rows[rw].Cells[4].Value = t.Money;
                            }
                            rw++;
                        }
                        break;
                    case 3://gravci v 1 country
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();

                        dataGridView1.Columns.Add("країна", "країна");
                        dataGridView1.Columns.Add("команда", "команда");
                        dataGridView1.Columns.Add("гравець", "гравець");

                        List<Player> players = db.Players.ToList();
                        var result = from pl in players
                                     join t in teams on pl.Country equals t.Country
                                     select new { NameOfTeam = t.NameOfTeam, NameOfPlayer = pl.Name, Country = pl.Country };

                        int rw_ = 0;
                        foreach (var item in result)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[rw_].Cells[0].Value = item.Country;
                            dataGridView1.Rows[rw_].Cells[1].Value = item.NameOfTeam;
                            dataGridView1.Rows[rw_].Cells[2].Value = item.NameOfPlayer;
                            rw_++;
                        }
                        break;

                    case 4://best rating
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();

                        var toprating = teams.Where(t => t.Rating == teams.Max(d => d.Rating));

                        dataGridView1.Columns.Add("команда", "команда");
                        dataGridView1.Columns.Add("країна", "країна");
                        dataGridView1.Columns.Add("вінрейт", "ігор/перемог");
                        dataGridView1.Columns.Add("рейтинг", "рейтинг");

                        foreach(FootballTeam t in toprating)
                            dataGridView1.Rows.Add(t.NameOfTeam, t.Country, t.Wins + "/" + t.PlayedGames, t.Rating);
                        break;
                    case 5://odnakova number of games
                        dataGridView1.Rows.Clear();
                        dataGridView1.Columns.Clear();

                        dataGridView1.Columns.Add("турнір", "турнір");
                        dataGridView1.Columns.Add("дата", "дата");
                        dataGridView1.Columns.Add("місце", "місце");
                        dataGridView1.Columns.Add("переможець", "переможець");


                        var tr = db.Tours.ToList();
                        int allgames = db.Fteams.ToList().Sum(n => n.PlayedGames);
                        int row = 0;
                        foreach (var t in tr)
                        {
                            dataGridView1.Rows.Add();
                            dataGridView1.Rows[row].Cells[0].Value = t.NameOfTournament;
                            dataGridView1.Rows[row].Cells[1].Value = t.Date;
                            dataGridView1.Rows[row].Cells[2].Value = t.Place;
                            dataGridView1.Rows[row].Cells[3].Value = t.Winner;
                            row++;
                        }
                        dataGridView1.Rows.Add();
                        dataGridView1.Rows.Add("Всього ігор:", allgames);
                        break;
                }
            }
        }
    }
}













//FAN MODE :D 
/*
  private void timer2_Tick(object sender, EventArgs e)
        {
            if (pcBox2OnTop == true)
            {
                if (goRight == true) //left is right here ;)
                {
                    materialFlatButton7.Enabled = false;
                    materialFlatButton8.Enabled = false;
                    pictureBox4.Left -= 10;
                    pictureBox16.BackColor = Color.Green;
                    pictureBox17.BackColor = Color.AliceBlue;
                    MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
                    skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
                    panel1.BackColor = Color.Red;
                    if (pictureBox4.Left <= -40)
                    {
                        pictureBox4.BringToFront();
                        goRight = false;
                        skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
                        pictureBox16.BackColor = Color.Gray;
                        pictureBox17.BackColor = Color.LightPink;
                        panel1.BackColor = Color.Green;
                    }
                }
                else if (goRight == false)
                {
                    pictureBox16.BackColor = Color.RosyBrown;
                    pictureBox17.BackColor = Color.Aqua;
                    panel1.BackColor = Color.Blue;
                    MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
                    //skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
                    pictureBox4.Left += 10;
                    if (pictureBox4.Left >= 130)
                    {
                        materialFlatButton7.Enabled = true;
                        materialFlatButton8.Enabled = true;
                        //  pictureBox4.Image = pictureBox2.Image;
                        pcBox2OnTop = false;
                        goRight = true;
                        timer1.Stop();
                        skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
                        pictureBox16.BackColor = Color.Crimson;
                        pictureBox17.BackColor = Color.DarkTurquoise;
                        panel1.BackColor = Color.Yellow;
                    }
                }
            }
            else if (pcBox2OnTop == false)
            {
                if (goRight == true)
                {
                    materialFlatButton8.Enabled = false;
                    materialFlatButton7.Enabled = false;
                    pictureBox2.Left -= 10;
                    MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
                    skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
                    panel1.BackColor = Color.Black;
                    pictureBox16.BackColor = Color.AntiqueWhite;
                    pictureBox17.BackColor = Color.Chocolate;
                    if (pictureBox2.Left <= -40)
                    {
                        pictureBox2.BringToFront();
                        goRight = false;
                        skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
                        panel1.BackColor = Color.White;
                        pictureBox16.BackColor = Color.LightGoldenrodYellow;
                        pictureBox17.BackColor = Color.DarkRed;
                    }
                }
                else if (goRight == false)
                {
                    pictureBox2.Left += 10;
                    MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
                    skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
                    panel1.BackColor = Color.Brown;
                    pictureBox16.BackColor = Color.IndianRed;
                    pictureBox17.BackColor = Color.Khaki;
                    if (pictureBox2.Left >= 130)
                    {
                        materialFlatButton8.Enabled = true;
                        materialFlatButton7.Enabled = true;
                        //pictureBox2.Image = pictureBox4.Image;
                        pcBox2OnTop = true;
                        goRight = true;
                        panel1.BackColor = Color.Pink;
                        pictureBox16.BackColor = Color.Yellow;
                        pictureBox17.BackColor = Color.Azure;
                        timer1.Stop();
                        skinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.DARK;
                    }
                }
            }
        }*/
