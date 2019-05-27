using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerFree
{
    interface iCharacteristics
    {
         int speed { get; set; }
         int health { get; set; }
         int skill { get; set; }
         int power { get; set; }
         int height { get; set; }
         int weight { get; set; }
    }
}
