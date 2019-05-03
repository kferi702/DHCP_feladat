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

        static void Main(string[] args)
        {
            //Fájlok beolvasása
            beolv_excluded();
            beolv_reserved();
            beolv_dhcp();
            beolv_test();

            Console.ReadKey();

        }


    }
}
