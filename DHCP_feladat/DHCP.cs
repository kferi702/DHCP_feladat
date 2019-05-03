namespace DHCP_feladat
{
    public class DHCP
    {
        private string mac;
        private string ip;

        public DHCP(string line)
        {
            string[] t = line.Split(";");
            this.mac = t[0];
            this.ip = t[1];
        }
        public void setMAC(string mac)
        {
            this.mac = mac;
        }
        public void setIp(string ip)
        {
            this.ip = ip;
        }
        public string getMAC()
        {
            return mac;
        }
        public string getIP()
        {
            return ip;
        }
    }
}