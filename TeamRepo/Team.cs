using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamRepo
{
    //POCO
    public class TeamContent
    {
        public string TeamName { get; set; }
        public int TeamNumber { get; set; }
        public int[] TeamMembers { get; set; }



        // zerod constructor
        public TeamContent()
        {
        }

        // populated constructor
        public TeamContent(int teamNumber, string teamName, int[] teamMembers)
        {
            TeamNumber = teamNumber;
            TeamName = teamName;
            TeamMembers = teamMembers;
        }

    }
}
