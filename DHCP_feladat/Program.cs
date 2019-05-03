using System;
using System.Collections.Generic;
using System.IO;

namespace DHCP_feladat
{
    class Program
    {
        //deklarálás hogy mindenhol elérhető legyen az osztályon beül
        public static List<Excluded> excluded = new List<Excluded>();
        public static List<Reserved> reserved = new List<Reserved>();
        public static List<DHCP> dhcp = new List<DHCP>();
        public static List<Test> test = new List<Test>();
        public static List<DHCP> dhcp_kesz = new List<DHCP>();


        public static void beolv_excluded()
        {
            try
            {
                //Fájl megnyitása
                FileStream file = new FileStream(@"excluded.csv", FileMode.Open);
                //Fájl olvasásra készítése
                StreamReader read = new StreamReader(file);
                //Ciklus amíg van olvasható sor
                while (!read.EndOfStream)
                {
                    //sor mentése
                    string line = read.ReadLine();
                    //sor hozzáadása a külön osztályhoz
                    excluded.Add(new Excluded(line));
                }
                //olvasás majd a fájl bezárása
                read.Close();
                file.Close();
                Console.WriteLine("excluded.csv...\tbeolvasása....Sikeresen megtörtént!");
            }
            catch (Exception e)
            {
                Console.WriteLine("excluded.csv...\tbeolvasása........HIBA a beolvasásnál!" + e);
            }
        }
        public static void beolv_reserved()
        {
            try
            {
                //Fájl megnyitása
                FileStream file = new FileStream(@"reserved.csv", FileMode.Open);
                //Fájl olvasásra készítése
                StreamReader read = new StreamReader(file);
                //Ciklus amíg van olvasható sor
                while (!read.EndOfStream)
                {
                    //sor mentése
                    string line = read.ReadLine();
                    //sor hozzáadása a külön osztályhoz
                    reserved.Add(new Reserved(line));
                }
                //olvasás majd a fájl bezárása
                read.Close();
                file.Close();
                Console.WriteLine("reserved.csv...\tbeolvasása.......Sikeresen megtörtént!");
            }
            catch (Exception e)
            {
                Console.WriteLine("reserved.csv...\tbeolvasása........HIBA a beolvasásnál!" + e);
            }
        }
        public static void beolv_dhcp()
        {
            try
            {
                //Fájl megnyitása
                FileStream file = new FileStream(@"dhcp.csv", FileMode.Open);
                //Fájl olvasásra készítése
                StreamReader read = new StreamReader(file);
                //Ciklus amíg van olvasható sor
                while (!read.EndOfStream)
                {
                    //sor mentése
                    string line = read.ReadLine();
                    //sor hozzáadása a külön osztályhoz
                    dhcp.Add(new DHCP(line));
                    dhcp_kesz.Add(new DHCP(line));

                }
                //olvasás majd a fájl bezárása
                read.Close();
                file.Close();
                Console.WriteLine("dhcp.csv...\tbeolvasása...Sikeresen megtörtént!");
            }
            catch (Exception e)
            {
                Console.WriteLine("dhcp.csv...\tbeolvasása....HIBA a beolvasásnál!" + e);
            }
        }
        public static void beolv_test()
        {
            try
            {
                //Fájl megnyitása
                FileStream file = new FileStream(@"test.csv", FileMode.Open);
                //Fájl olvasásra készítése
                StreamReader read = new StreamReader(file);
                //Ciklus amíg van olvasható sor
                while (!read.EndOfStream)
                {
                    //sor mentése
                    string line = read.ReadLine();
                    //sor hozzáadása a külön osztályhoz
                    test.Add(new Test(line));
                }
                //olvasás majd a fájl bezárása
                read.Close();
                file.Close();
                Console.WriteLine("test.csv...\tbeolvasása....Sikeresen megtörtént!");
            }
            catch (Exception e)
            {
                Console.WriteLine("test.csv...\tbeolvasása....HIBA a beolvasásnál!" + e);
            }
        }
        public static void read_test()
        {
            Console.WriteLine("\n2.Feladat:\t\"test.csv\" végrehajtása:\n");
            foreach (Test t in test)
            {
                if (t.getCommand() == "request")
                {
                    //van e már érvényes foglalása a dhcp.csv - ben
                    foreach (DHCP d in dhcp)
                    {
                        //szerepel
                        if (t.getAddress() == d.getMAC())
                            break;
                    }
                    //szerepel e a reserved.csv-ben
                    foreach (Reserved r in reserved)
                    {
                        //szerepel
                        if (t.getAddress() == r.getMAC())
                        {
                            foreach (DHCP d in dhcp)
                                //ipcím már ki van osztva?
                                if (r.getIP() == d.getIP())
                                    break;
                            dhcp.Add(new DHCP(r.getMAC(), r.getIP()));
                            break;
                        }
                    }
                    //nem szerepel a reserved-ben
                    //első kisztható cím eleje
                    string ipad = "192.168.10.";
                    //első kiosztható cím vége
                    int ip = 100;
                    foreach (DHCP d in dhcp)
                    {
                        //Cím már kivan osztva
                        if (d.getIP() == ipad + ip)
                        {
                            ip++;
                            if (ip > 199)
                            {
                                Console.WriteLine("Sikertelen IP cím kiosztás!");
                                break;
                            }
                        }
                        //cím nincs kiosztva
                        //Szerepel e a kizártak között excluded.csv
                        foreach (Excluded e in excluded)
                        {
                            //igen kivan zárva
                            if (e.getIP() == ipad + ip)
                            {
                                ip++;
                                if (ip > 199)
                                {
                                    Console.WriteLine("Sikertelen IP cím kiosztás!");
                                    break;
                                }
                            }
                        }
                        //Cím nincs kizárva
                        //szerepel e a fenttartások között
                        foreach(Reserved r in reserved)
                        {
                            //igen szerepel
                            if (r.getIP() == ipad + ip)
                            {
                                ip++;
                                if (ip > 199)
                                {
                                    Console.WriteLine("Sikertelen IP cím kiosztás!");
                                    break;
                                }
                            }
                        }
                        //nem szerepel
                        dhcp.Add(new DHCP(d.getMAC(), ipad+ip));
                        break;
                    }

                }
                //cím elengedése
                else if (t.getCommand() == "release")
                {
                    int i = 0;
                    foreach (DHCP d in dhcp)
                    {
                        if (t.getAddress() == d.getIP())
                        {
                            dhcp.RemoveAt(i);
                            break;
                        }
                        i++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            //Fájlok beolvasása
            beolv_excluded();
            beolv_reserved();
            beolv_dhcp();
            beolv_test();
            read_test();
            foreach (DHCP d in dhcp)
            {
                Console.WriteLine(d.ToString());
            }
            Console.ReadKey();

        }


    }
}
