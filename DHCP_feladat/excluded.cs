using System;
using System.Collections.Generic;
using System.Text;

namespace DHCP_feladat
{
    class Excluded
    {
        private string ip;

        public Excluded(string ip)
        {
            this.ip = ip;
        }
        public void setIP(string ip)
        {
            this.ip = ip;
        }
        public string getIP()
        {
            return ip;
        }
    }


}
