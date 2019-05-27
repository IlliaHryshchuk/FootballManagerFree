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
    public sealed class Player : Person//, iCharacteristics
    {
        [Key]
        public int Id { get; set; }

        public double speed { get; set; }
        public double health { get; set; }
        public double skill { get; set; }
        public double power { get; set; }
        public double height { get; set; }
        public double weight { get; set; }
        public double scored { get; set; }
        public override string getName()
        {
            return this.name;
        }
        public override void setName(string name)
        {
            this.name = name;
        }
        public int? FootballTeamId { get; set; }
        public  FootballTeam FootballTeam { get; set; }

        //new public void writeinfo(Player player, ref StreamWriter writer)
        //{
        //    writer.WriteLine(player.Name + "\r\n" + player.speed + "\r\n" + player.health + "\r\n" + player.skill + "\r\n" + player.power + "\r\n" + player.height + "\r\n" + player.weight);
        //}

        public Player readInfo(Player player)
        {
            this.name = player.name;
            this.speed = player.speed;
            this.health =  player.health;
            this.skill =  player.skill;
            this.power = player.power;
            this.height = player.height;
            this.weight = player.weight;
            this.age = player.age;
            this.country = player.country;
            this.Id = player.Id;
            return this;
        }

        public Player() : base()
        {
            this.age = "empty";
            this.country = "empty";
            this.name = "empty";
            this.speed = 30;
            this.health = 20;
            this.skill = 10;
            this.power = 15;
            this.height = 30;
            this.weight = 30;
            this.scored = 0;
        }
    }
}
