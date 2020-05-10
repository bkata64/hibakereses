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
    }
    class cbradio
    {
        static void Main()
        {
            StreamReader sr = new StreamReader("cb.txt");
            cbradio[] radio = new cbradio[500];
            int index = 0;
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adat = sor.Split(';');
                radio[index].KezdoOra = int.Parse(adat[0]);
                radio[index].KezdoPerc = int.Parse(adat[1]);
                radio[index].AdasDb = int.Parse(adat[2]);
                radio[index].Nev = adat[3];
                index++;
            }
            sr.Close();

            Console.WriteLine("3. feladat: Bejegyzések száma: {0}, db", index);

            bool volt4esBejegyzes = false;
            for (int i = 0; i < index; i++)
            {
                if (i.AdasDb == 4)
                {
                    volt4esBejegyzes = true;
                    Console.WriteLine("Volt négy adást indító sofőr.");
                }
                else (i.AdasDb != 4)
                        Console.WriteLine("Nem volt négy adást indító sofőr");
            }

            Console.Write("5. feladat: Kérek egy nevet: ");
            string bekert = Console.ReadLine();
            int adasDb = 0;
            for (int i = 0; i < index; i++)
            {
                if (i.Nev == bekert) adasDb += i.AdasDb;
            }
            if (adasDb == 0)
                Console.WriteLine("\tNincs ilyen nevű sofőr!");
            else
                Console.WriteLine("\t{0} {1}x használta a CB-rádiót.", bekert, adasDb);



            Console.WriteLine("9. feladat: Legtöbb adást indító sofőr");
            Console.WriteLine("\tNév: {0}", );
            Console.WriteLine("\tAdások száma: {} alkalom", );

            Console.ReadKey();
        }
    }
}
