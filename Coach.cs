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
    public class Coach : Person
    {
        [Key]
        public int Id { get; set; }

        private double experience;
        public double Experience
        {
            get { return experience; }
            set { experience = value; }
        }
        public override string getName()
        {
            return this.name;
        }
        public override void setName(string name)
        {
            this.name = name;
        }
        public int? FteamId { get; set; }
        public FootballTeam FootballTeam { get; set; }

        //new public void writeInfo(Coach coach, ref StreamWriter writer)
        //{
        //   // writer.WriteLine(coach.Name + "\r\n" + coach.Age + "\r\n" + coach.country + "\r\n" + coach.Experience);
        //    writer.WriteLine(coach.Name + "\r\n" + coach.Experience);
        //}
        new public Coach readInfo(Coach coach)
        {
            this.name = coach.name;
            this.age = coach.Age;
            this.country = coach.Country;
            this.experience = coach.Experience;
            this.Id = coach.Id;
            return this;
        }
        public Coach() : base()
        {
            this.experience = 0.05;
            this.age = "empty";
            this.country = "empty";
            this.name = "empty";
        }
    }
}
