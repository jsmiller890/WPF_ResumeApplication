using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ResumeApplication.ForbiddenIsland
{
    class Player
    {
        private string job;
        private int location;

        public Player(string job, int location)
        {
            this.job = job;
            this.location = location;
        }
        public string getJob()
        {
            return job;
        }
        public int getLocation()
        {
            return location;
        }
        public void MoveTo(int newLocation)
        {
            location = newLocation;
        }
    }
}
