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
    public class Person 
    {
        protected string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        protected string age;
        public string Age
        {
            get { return age; }
            set { age = value; }
        }
        protected string country;
        public string Country
        {
            get { return country; }
            set { country = value; }
        }
        public virtual string getName() {   return "0"; }
        public virtual void setName(string country){}

        public Person()
        {

        }
    }
}
