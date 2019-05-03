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
        public DHCP(string Mac, string Ip)
        {
            this.mac = Mac;
            this.ip = Ip;
        }
        public void setMAC(string mac)
        {
            this.mac = mac;
        }
        public void setIp(string ip)
        {
            this.ip = ip;
        }
        public void setIP(string ip, int kiosztas)
        {
            this.ip = ip.Remove(ip.Length - 3)+kiosztas;
        }
        public string getMAC()
        {
            return mac;
        }
        public string getIP()
        {
            return ip;
        }
        public override string ToString()
        {
            return getMAC()+";"+getIP();
        }
    }
}