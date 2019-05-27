using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using MaterialSkin;
using MaterialSkin.Controls;

namespace FootballManagerFree
{
    public class Tournament
    {
        [Key]
        public int Id { get; set; }

        private string place;
        public string Place
        {
            get { return place; }
            set { place = value; }
        }
        private string numOfPic;
        public string NumOfPic
        {
            get { return numOfPic; }
            set { numOfPic = value; }
        }
        private string nameOfTournament;
        public string NameOfTournament
        {
            get { return nameOfTournament; }
            set { nameOfTournament = value; }
        }
        private string date;
        public string Date
        {
            get { return date; }
            set { date = value; }
        }
        private string winner;
        public string Winner
        {
            get { return winner; }
            set { winner = value; }
        }
        public FootballTeam[] fteam;

        static public MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;

        public Tournament(int numberOfTeams)
        {
            fteam = new FootballTeam[numberOfTeams];
            this.NameOfTournament = "empty";
            this.NumOfPic = "1";
            this.Place = "empty";
            this.Date = "empty";
        }

        public Tournament()
        {
            fteam = new FootballTeam[40];
            this.NameOfTournament = "empty";
            this.NumOfPic = "1";
            this.Place = "empty";
            this.Date = "empty";
            this.winner = "empty";
        }

        public void writeInfoAboutTournament(Tournament tournament)
        {
            using (TournamentContext db = new TournamentContext())
            {
                    db.Tours.Add(tournament);
                    db.SaveChanges();
            }
        }
        
        public Tournament readInfoAboutTournament(Tournament tournament)
        {
            using (TournamentContext db = new TournamentContext())
            {
                var trs = db.Tours.ToList();
                if (trs.Any(o => o.Id != null))
                {
                    tournament = trs.Last();
                }
                else
                {
                    tournament.NameOfTournament = "empty";
                    tournament.NumOfPic = "1";
                    tournament.Place = "empty";
                    tournament.Date = "empty";
                }
            }
            return tournament;
        }

        public void cheersForWinner(FootballTeam fteam)
        {
            using (TournamentContext db = new TournamentContext())
            {
                var rnd = new Random();
                double randCoof;
                var team = db.Fteams.Where(c => c.Id == fteam.Id).FirstOrDefault();
                Player[] playerList = db.Players.ToArray();
                Coach[] coachList = db.Coaches.ToArray();
                team.Rating += 2;
                team.Money += 100;
                for (int i = fteam.Id * 3 - 3; i < fteam.Id * 3; i++)
                {

                    randCoof = Convert.ToDouble(rnd.Next(-5, 30) / 10.0);
                    playerList[i].speed += randCoof * (team.coach.Experience + 1);
                    randCoof = Convert.ToDouble(rnd.Next(-5, 30) / 10.0);
                    playerList[i].health += randCoof * (team.coach.Experience + 1);
                    randCoof = Convert.ToDouble(rnd.Next(-5, 30) / 10.0);
                    playerList[i].skill += randCoof * (team.coach.Experience + 1);
                    randCoof = Convert.ToDouble(rnd.Next(-5, 30) / 10.0);
                    playerList[i].power += randCoof * (team.coach.Experience + 1);
                }
                randCoof = Convert.ToDouble(rnd.Next(-1, 4) / 100.0);
                coachList[fteam.Id-1].Experience += randCoof;
                var tour = db.Tours.Where(t => t.Id == db.Tours.Max(j => j.Id)).FirstOrDefault();
                tour.winner = fteam.NameOfTeam;
                db.SaveChanges();
            }
        }

    }


    //public class SkinInfo
    //{
    //    //наши данные
    //    int zminna;
    //    static public MaterialSkin.MaterialSkinManager skinManager = MaterialSkin.MaterialSkinManager.Instance;
    //}
}
