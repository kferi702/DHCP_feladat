namespace DHCP_feladat
{
    public class Test
    {
        private string command;
        private string address;

        public Test(string line)
        {
            string[] t = line.Split(";");
            this.command = t[0];
            this.address = t[1];
        }
        public void setCommand(string command)
        {
            this.command = command;
        }
        public void setAddress(string address)
        {
            this.address = address;
        }
        public string getCommand()
        {
            return command;
        }
        public string getAddress()
        {
            return address;
        }
    }
}