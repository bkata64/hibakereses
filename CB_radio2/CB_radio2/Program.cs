using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CB_radio2
{
    class Bejegyzes
    {
        public int KezdoOra;
        public int KezdoPerc;
        public int AdasDb;
        public string Nev;

        public Bejegyzes(string sor)
        {
            string[] adat = sor.Split(';');
            KezdoOra = int.Parse(adat[0]);
            KezdoPerc = int.Parse(adat[1]);
            AdasDb = int.Parse(adat[2]);
            Nev = adat[3];
        }

        public int OsszPerc
        {
            get { return KezdoOra * 60 + KezdoPerc; }
        }


        //public int AtszamolPercre()
        //{
        //    return KezdoOra * 60 + KezdoPerc;
        //}
    }

    class cbradio
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("cb.txt");
            Bejegyzes[] radio = new Bejegyzes[500];
            int index = 0;
            sr.ReadLine();
            while (!sr.EndOfStream)
            {                
                radio[index] = new Bejegyzes(sr.ReadLine());               
                index++;
            }
            sr.Close();

            Console.WriteLine("3. feladat: Bejegyzések száma: {0} db", index);

            bool volt4esBejegyzes = false;
            for (int i = 0; i < index; i++)
            {
                if (radio[i].AdasDb == 4)
                {
                    volt4esBejegyzes = true;
                    break;
                }           
            }
            if(volt4esBejegyzes)
                Console.WriteLine("Volt négy adást indító sofőr.");
            else
                Console.WriteLine("Nem volt négy adást indító sofőr");

            Console.Write("5. feladat: Kérek egy nevet: ");
            string bekert = Console.ReadLine();
            int adasDb = 0;
            for (int i = 0; i < index; i++)
            {
                if (radio[i].Nev == bekert)
                    adasDb += radio[i].AdasDb;
            }
            if (adasDb == 0)
                Console.WriteLine("\tNincs ilyen nevű sofőr!");
            else
                Console.WriteLine("\t{0} {1}x használta a CB-rádiót.", bekert, adasDb);

            StreamWriter sw = new StreamWriter("cb2.txt");
            sw.WriteLine("Kezdes;Nev;AdasDb");
            for (int i = 0; i < index; i++)
            {
                int percek = radio[i].OsszPerc;
                sw.WriteLine("{0};{1};{2}", percek, radio[i].Nev, radio[i].AdasDb);                
            }
            sw.Close();

            string[] nevek = new string[500];
            int szamlalo = 0;
            for (int i = 0; i < index; i++)
            {
                if (!nevek.Contains(radio[i].Nev))
                {
                    nevek[szamlalo] = radio[i].Nev;
                    szamlalo++;
                }
            }
            Console.WriteLine("8.feladat: Sofőrök száma: {0} fő", szamlalo);

            int maxAdasDb = 0;
            string maxNev = "";
            for (int i = 0; i < szamlalo; i++)
            {
                int osszAdasDb = 0;
                for (int j = 0; j < index; j++)
                {
                    if (radio[j].Nev == nevek[i])
                        osszAdasDb += radio[j].AdasDb;
                }
                if (osszAdasDb > maxAdasDb)
                {
                    maxAdasDb = osszAdasDb;
                    maxNev = nevek[i];
                }
            }
                       
            Console.WriteLine("9. feladat: Legtöbb adást indító sofőr");
            Console.WriteLine("\tNév: {0}", maxNev);
            Console.WriteLine("\tAdások száma: {0} alkalom", maxAdasDb);

            Console.ReadKey();
        }       
    }
}
