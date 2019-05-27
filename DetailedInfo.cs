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
    public partial class DetailedInfo : MaterialSkin.Controls.MaterialForm
    {
        public FootballTeam Fteam { get; set; }
        public DetailedInfo()
        {
            InitializeComponent();
            Tournament.skinManager.AddFormToManage(this);
        }
        private void DetailedInfo_Load(object sender, EventArgs e)
        {
            label1.Text = Fteam.NameOfTeam;
            pictureBox4.Load(@"../../logos/" + Fteam.LogoNum + ".jpg");
            materialLabel2.Text = Fteam.Country;
            materialLabel8.Text = Convert.ToString(Fteam.Rating);
            materialLabel3.Text = Convert.ToString(Fteam.Money);
            materialLabel9.Text = Convert.ToString(Fteam.PlayedGames) + "/" + Convert.ToString(Fteam.Wins);
            materialLabel13.Text = Fteam.coach.Name;
            materialLabel12.Text = Convert.ToString(Fteam.coach.Experience);
            materialLabel23.Text = Fteam.Players.ElementAt(0).Name;
            materialLabel24.Text = Fteam.Players.ElementAt(1).Name;
            materialLabel25.Text = Fteam.Players.ElementAt(2).Name;
            materialLabel26.Text = Fteam.Players.ElementAt(0).Age;
            materialLabel27.Text = Fteam.Players.ElementAt(1).Age;
            materialLabel28.Text = Fteam.Players.ElementAt(2).Age;
            materialLabel29.Text = Fteam.Players.ElementAt(0).Country;
            materialLabel30.Text = Fteam.Players.ElementAt(1).Country;
            materialLabel31.Text = Fteam.Players.ElementAt(2).Country;
            materialLabel32.Text = Convert.ToString(Fteam.Players.ElementAt(0).speed);
            materialLabel33.Text = Convert.ToString(Fteam.Players.ElementAt(1).speed);
            materialLabel34.Text = Convert.ToString(Fteam.Players.ElementAt(2).speed);
            materialLabel35.Text = Convert.ToString(Fteam.Players.ElementAt(0).health);
            materialLabel36.Text = Convert.ToString(Fteam.Players.ElementAt(1).health);
            materialLabel37.Text = Convert.ToString(Fteam.Players.ElementAt(2).health);
            materialLabel38.Text = Convert.ToString(Fteam.Players.ElementAt(0).skill);
            materialLabel39.Text = Convert.ToString(Fteam.Players.ElementAt(1).skill);
            materialLabel40.Text = Convert.ToString(Fteam.Players.ElementAt(2).skill);
            materialLabel41.Text = Convert.ToString(Fteam.Players.ElementAt(0).power);
            materialLabel43.Text = Convert.ToString(Fteam.Players.ElementAt(1).power);
            materialLabel42.Text = Convert.ToString(Fteam.Players.ElementAt(2).power);
        }
    }
}
