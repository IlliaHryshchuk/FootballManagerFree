using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagerFree
{
    interface iPlay
    {
        FootballTeam playGame(FootballTeam fteam1, FootballTeam fteam2);
        Player this[int index] { get; set; }
    }
}
