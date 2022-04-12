using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_ResumeApplication.ForbiddenIsland
{
    class Tile
    {
        private string name;
        private string status;
        private int location;

        public Tile(string name)
        {
            this.name = name;
            status = "Dry";
        }

        public string getName()
        {
            return name;
        }

        public string getStatus()
        {
            return status;
        }

        public void setStatus(string status)
        {
            this.status = status;
        }

        public int getLocation()
        {
            return location;
        }

        public void setLocation(int location)
        {
            this.location = location;
        }

        public void FloodTile()
        {
            status = "Flooded";
        }
        public void RemoveTile()
        {
            status = "Removed";
        }
        public void ShoreUpTile()
        {
            status = "Dry";
        }
    }
}
