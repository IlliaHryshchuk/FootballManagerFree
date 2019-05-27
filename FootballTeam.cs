using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FootballManagerFree
{
    public class FootballTeam : iPlay
    {
        [Key]
        public int Id { get; set; }

        public Player this[int index]
        {
            get
            {
                return player[index];
            }
            set
            {
                player[index] = value;
            }
        }


        private string nameOfTeam;
        public string NameOfTeam
        {
            get { return nameOfTeam; }
            set { nameOfTeam = value; }
        }
        private string logoNum;
        public string LogoNum
        {
            get { return logoNum; }
            set { logoNum = value; }
        }
        private double rating;
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        public string Country { get; set; }
        public double Money { get; set; }
        public int Wins { get; set; }
        public int PlayedGames { get; set; }
        public Player[] player;
        public Coach coach;
        public ICollection<Player> Players { get; set; }
        //public Coach Coach { get; set; }

        public FootballTeam()
        {
            //Coach = new Coach();
            Players = new List<Player>();
            player = new Player[3];
            for (int i = 0; i < 3; i++)
                player[i] = new Player();
            coach = new Coach();
            this.Money = 100;
            this.rating = 5;
            this.Wins = 0;
            this.PlayedGames = 0;
            this.nameOfTeam = "empty";
            this.logoNum = "2";
            this.Country = "empty";
        }

        public void writeInfo(FootballTeam fteam)
        {
            using (TournamentContext db = new TournamentContext())
            {
                db.Fteams.Add(fteam);
                //db.Players.Add(fteam.player[0]);
               // db.Players.Add(fteam.player[1]);
              //  db.Players.Add(fteam.player[2]);
                //

                db.Players.AddRange(new List<Player> {fteam.player[0], fteam.player[1], fteam.player[2]});
                //
                db.Coaches.Add(fteam.coach);
                db.SaveChanges();
            }
        }

        public int readAllTeams(ref FootballTeam[] fteam)
        {
            
            using (TournamentContext db = new TournamentContext())
            {
                for (int l = 0; l < 40; l++)
                    fteam[l] = new FootballTeam();
                int i = 0;
                Coach[] coachList = db.Coaches.ToArray();


                foreach (FootballTeam ftm in db.Fteams.Include(t => t.Players))
                {
                    fteam[i].nameOfTeam = ftm.nameOfTeam;
                    fteam[i].logoNum = ftm.logoNum;
                    fteam[i].rating = ftm.rating;
                    fteam[i].Country = ftm.Country;
                    fteam[i].Money = ftm.Money;
                    fteam[i].Wins = ftm.Wins;
                    fteam[i].PlayedGames = ftm.PlayedGames;
                    fteam[i].Id = ftm.Id;
                    foreach (Player pl in ftm.Players)
                    {
                        fteam[i].Players.Add(pl);
                    }
                    fteam[i].coach = new Coach();
                    fteam[i].coach = fteam[i].coach.readInfo(coachList[i]);
                    i++;
                }
                return i;






                //var teams = db.Fteams; 
                //Player[] playerList = db.Players.ToArray();
                //Coach[] coachList = db.Coaches.ToArray();
                //int i = 0;
                //int k = 0;
                //if (teams.Any(o => o.Id != null))
                //{
                //    foreach (FootballTeam ftm in teams)
                //    {
                //        fteam[i].nameOfTeam = ftm.nameOfTeam;
                //        fteam[i].logoNum = ftm.logoNum;
                //        fteam[i].rating = ftm.rating;
                //        fteam[i].Country = ftm.Country;
                //        fteam[i].Money = ftm.Money;
                //        fteam[i].Wins = ftm.Wins;
                //        fteam[i].PlayedGames = ftm.PlayedGames;
                //        fteam[i].Id = ftm.Id;

                //        //j = 0;//test
                //        //foreach (Player pl in db.Players.Include(p => p.Fteam))//test
                //        //{
                //        //    fteam[i].player[j] = new Player();
                //        //    fteam[i].player[j] = fteam[i].player[j].readInfo(pl); //test
                //        //    j++;
                //        //}
                //        for (int j = 0; j < 3; j++)
                //        {
                //            fteam[i].player[j] = new Player();
                //            fteam[i].player[j] = fteam[i].player[j].readInfo(playerList[k]);
                //            k++;
                //        }
                //        fteam[i].coach = new Coach();
                //        fteam[i].coach = fteam[i].coach.readInfo(coachList[i]);
                //        i++;
                //    }
                //}
            }
        }

        public FootballTeam playGame(FootballTeam fteam1, FootballTeam fteam2)
        {
            using (TournamentContext db = new TournamentContext())
            {
                var teams = db.Fteams.Where(c => c.Id == fteam1.Id).FirstOrDefault();
                var players = db.Players;           //придумати шось
                Player[] playerList = db.Players.ToArray();
                Coach[] coachList = db.Coaches.ToArray();
                var coaches = db.Coaches;           //придумати шось
                var rnd = new Random();
                int randomCoof1 = rnd.Next(0, 100);
                int randomCoof2 = rnd.Next(0, 100);
                double randCoof;

                
                //int b = 5;
                //b = fteam1.Id;
                //FootballTeam ftest = new FootballTeam();
                //ftest.Money = 400;
                //ftest = db.Fteams.First();
                //ftest.Money += 11;
                //List<FootballTeam>teamlist = db.Fteams.ToList();
                //string name = teamlist.Where(c => c.Id == fteam1.Id).FirstOrDefault().nameOfTeam;

                //ftest = teamlist.Where(c => c.Id == fteam1.Id).First();
                //ftest.Money = 11;

                
                if (randomCoof1 * fteam1.rating > randomCoof2 * fteam2.rating) //if 1 wins
                {
                    teams.PlayedGames += 1;//1 team
                    teams.rating += 2;
                    fteam1.rating += 2;
                    teams.Wins += 1;
                    teams.Money += 100;
                    for (int i = fteam1.Id*3 - 3; i < fteam1.Id * 3; i++)
                    {

                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].speed += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].health += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].skill += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].power += randCoof * (teams.coach.Experience + 1);
                    }
                    randCoof = Convert.ToDouble(rnd.Next(-1, 4) / 100.0);
                    coachList[fteam1.Id-1].Experience += randCoof;
                    //TO FIX
                    fteam1.Players.Clear();
                    for (int j = 0; j < 3; j++)
                    {
                        fteam1.Players.Add(fteam1.player[j]);
                    }
                        //end of fix
                    db.SaveChanges();
                    


                    teams = db.Fteams.Where(c => c.Id == fteam2.Id).FirstOrDefault();//2 team
                    teams.PlayedGames += 1;
                    teams.rating += 1;
                    fteam2.rating += 3;
                    teams.Money += 30;
                    for (int i = fteam1.Id * 3 - 3; i < fteam1.Id * 3; i++)
                    {

                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].speed += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].health += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].skill += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].power += randCoof * (teams.coach.Experience + 1);
                    }
                    randCoof = Convert.ToDouble(rnd.Next(-8, 25) / 1000.0);
                    coachList[fteam1.Id-1].Experience += randCoof;
                    //TO FIX
                    fteam2.Players.Clear();
                    for (int j = 0; j < 3; j++)
                    {
                        fteam2.Players.Add(fteam2.player[j]);
                    }
                    //end of fix
                    db.SaveChanges();
                    return fteam1;
                }
                else//if 2 wins
                {
                    teams.PlayedGames += 1;//1 team
                    fteam1.rating += 1;
                    teams.rating += 1;
                    teams.Money += 30;
                    for (int i = fteam1.Id * 3 -3; i < fteam1.Id * 3; i++)
                    {

                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].speed += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].health += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].skill += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].power += randCoof * (teams.coach.Experience + 1);
                    }
                    randCoof = Convert.ToDouble(rnd.Next(-8, 25) / 1000.0);
                    coachList[fteam1.Id-1].Experience += randCoof;
                    //TO FIX
                    fteam1.Players.Clear();
                    for (int j = 0; j < 3; j++)
                    {
                        fteam1.Players.Add(fteam1.player[j]);
                    }
                    //end of fix
                    db.SaveChanges();


                    teams = db.Fteams.Where(c => c.Id == fteam2.Id).FirstOrDefault();//2 team
                    teams.PlayedGames += 1;
                    teams.rating += 2;
                    fteam2.rating += 2;
                    teams.Wins += 1;
                    teams.Money += 100;
                    for (int i = fteam1.Id * 3 - 3; i < fteam1.Id * 3; i++)
                    {

                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].speed += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].health += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].skill += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].power += randCoof * (teams.coach.Experience + 1);
                    }
                    randCoof = Convert.ToDouble(rnd.Next(-1, 4) / 100.0);
                    coachList[fteam1.Id-1].Experience += randCoof;
                    //TO FIX
                    fteam2.Players.Clear();
                    for (int j = 0; j < 3; j++)
                    {
                        fteam2.Players.Add(fteam2.player[j]);
                    }
                    //end of fix
                    db.SaveChanges();
                    return fteam2;
                }
            }
        }
    }
}


//old_code
/*
 * using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace FootballManagerFree
{
    public class FootballTeam : iPlay
    {
        [Key]
        public int Id { get; set; }

        public Player this[int index]
        {
            get
            {
                return player[index];
            }
            set
            {
                player[index] = value;
            }
        }


        private string nameOfTeam;
        public string NameOfTeam
        {
            get { return nameOfTeam; }
            set { nameOfTeam = value; }
        }
        private string logoNum;
        public string LogoNum
        {
            get { return logoNum; }
            set { logoNum = value; }
        }
        private double rating;
        public double Rating
        {
            get { return rating; }
            set { rating = value; }
        }
        public string Country { get; set; }
        public double Money { get; set; }
        public int Wins { get; set; }
        public int PlayedGames { get; set; }
        public Player[] player;
        public Coach coach;
        //public ICollection<Player> Players { get; set; }

        public FootballTeam()
        {
            player = new Player[3];
            for (int i = 0; i < 3; i++)
                player[i] = new Player();
            coach = new Coach();
            this.Money = 100;
            this.rating = 5;
            this.Wins = 0;
            this.PlayedGames = 0;
            this.nameOfTeam = "empty";
            this.logoNum = "2";
            this.Country = "empty";
        }

        public void writeInfo(FootballTeam fteam)
        {
            using (TournamentContext db = new TournamentContext())
            {
                db.Fteams.Add(fteam);
                db.Players.Add(fteam.player[0]);
                db.Players.Add(fteam.player[1]);
                db.Players.Add(fteam.player[2]);
                //
                //db.Players.AddRange(new List<Player> {fteam.player[0], fteam.player[1], fteam.player[2]});
                //
                db.Coaches.Add(fteam.coach);
                db.SaveChanges();
            }
        }

        public int readAllTeams(ref FootballTeam[] fteam)
        {
            
            using (TournamentContext db = new TournamentContext())
            {
                for (int l = 0; l < 40; l++)
                    fteam[l] = new FootballTeam();
                var teams = db.Fteams; 
                Player[] playerList = db.Players.ToArray();
                Coach[] coachList = db.Coaches.ToArray();
                int i = 0;
                int k = 0;
                if (teams.Any(o => o.Id != null))
                {
                    foreach (FootballTeam ftm in teams)
                    {
                        fteam[i].nameOfTeam = ftm.nameOfTeam;
                        fteam[i].logoNum = ftm.logoNum;
                        fteam[i].rating = ftm.rating;
                        fteam[i].Country = ftm.Country;
                        fteam[i].Money = ftm.Money;
                        fteam[i].Wins = ftm.Wins;
                        fteam[i].PlayedGames = ftm.PlayedGames;
                        fteam[i].Id = ftm.Id;

                        //j = 0;//test
                        //foreach (Player pl in db.Players.Include(p => p.Fteam))//test
                        //{
                        //    fteam[i].player[j] = new Player();
                        //    fteam[i].player[j] = fteam[i].player[j].readInfo(pl); //test
                        //    j++;
                        //}
                        for (int j = 0; j < 3; j++)
                        {
                            fteam[i].player[j] = new Player();
                            fteam[i].player[j] = fteam[i].player[j].readInfo(playerList[k]);
                            k++;
                        }
                        fteam[i].coach = new Coach();
                        fteam[i].coach = fteam[i].coach.readInfo(coachList[i]);
                        i++;
                    }
                }
                return i;
            }
        }

        public FootballTeam playGame(FootballTeam fteam1, FootballTeam fteam2)
        {
            using (TournamentContext db = new TournamentContext())
            {
                var teams = db.Fteams.Where(c => c.Id == fteam1.Id).FirstOrDefault();
                var players = db.Players;           //придумати шось
                Player[] playerList = db.Players.ToArray();
                Coach[] coachList = db.Coaches.ToArray();
                var coaches = db.Coaches;           //придумати шось
                var rnd = new Random();
                int randomCoof1 = rnd.Next(0, 100);
                int randomCoof2 = rnd.Next(0, 100);
                double randCoof;

                
                //int b = 5;
                //b = fteam1.Id;
                //FootballTeam ftest = new FootballTeam();
                //ftest.Money = 400;
                //ftest = db.Fteams.First();
                //ftest.Money += 11;
                //List<FootballTeam>teamlist = db.Fteams.ToList();
                //string name = teamlist.Where(c => c.Id == fteam1.Id).FirstOrDefault().nameOfTeam;

                //ftest = teamlist.Where(c => c.Id == fteam1.Id).First();
                //ftest.Money = 11;

                
                if (randomCoof1 * fteam1.rating > randomCoof2 * fteam2.rating) //if 1 wins
                {
                    teams.PlayedGames += 1;//1 team
                    teams.rating += 2;
                    fteam1.rating += 2;
                    teams.Wins += 1;
                    teams.Money += 100;
                    for (int i = fteam1.Id*3 - 3; i < fteam1.Id * 3; i++)
                    {

                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].speed += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].health += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].skill += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].power += randCoof * (teams.coach.Experience + 1);
                    }
                    randCoof = Convert.ToDouble(rnd.Next(-1, 4) / 100.0);
                    coachList[fteam1.Id-1].Experience += randCoof;
                    db.SaveChanges();
                    


                    teams = db.Fteams.Where(c => c.Id == fteam2.Id).FirstOrDefault();//2 team
                    teams.PlayedGames += 1;
                    teams.rating += 1;
                    fteam2.rating += 3;
                    teams.Money += 30;
                    for (int i = fteam1.Id * 3 - 3; i < fteam1.Id * 3; i++)
                    {

                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].speed += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].health += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].skill += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].power += randCoof * (teams.coach.Experience + 1);
                    }
                    randCoof = Convert.ToDouble(rnd.Next(-8, 25) / 1000.0);
                    coachList[fteam1.Id-1].Experience += randCoof;
                    db.SaveChanges();
                    return fteam1;
                }
                else//if 2 wins
                {
                    teams.PlayedGames += 1;//1 team
                    fteam1.rating += 1;
                    teams.rating += 1;
                    teams.Money += 30;
                    for (int i = fteam1.Id * 3 -3; i < fteam1.Id * 3; i++)
                    {

                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].speed += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].health += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].skill += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-6, 13) / 100.0);
                        playerList[i].power += randCoof * (teams.coach.Experience + 1);
                    }
                    randCoof = Convert.ToDouble(rnd.Next(-8, 25) / 1000.0);
                    coachList[fteam1.Id-1].Experience += randCoof;
                    db.SaveChanges();


                    teams = db.Fteams.Where(c => c.Id == fteam2.Id).FirstOrDefault();//2 team
                    teams.PlayedGames += 1;
                    teams.rating += 2;
                    fteam2.rating += 2;
                    teams.Wins += 1;
                    teams.Money += 100;
                    for (int i = fteam1.Id * 3 - 3; i < fteam1.Id * 3; i++)
                    {

                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].speed += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].health += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].skill += randCoof * (teams.coach.Experience + 1);
                        randCoof = Convert.ToDouble(rnd.Next(-4, 20) / 10.0);
                        playerList[i].power += randCoof * (teams.coach.Experience + 1);
                    }
                    randCoof = Convert.ToDouble(rnd.Next(-1, 4) / 100.0);
                    coachList[fteam1.Id-1].Experience += randCoof;
                    db.SaveChanges();
                    return fteam2;
                }
            }
        }
    }
}

 */
