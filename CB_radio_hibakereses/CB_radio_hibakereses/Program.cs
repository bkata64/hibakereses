﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CB_radio_hibakereses
{
    class Program
    {
        struct cbradio
        {
            public int Kezdo_ora;
            public int Kezdo_perc;
            public int adasDb;
            public string nev;
        }
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("cb.txt");
            cbradio[] radio = new cbradio[500];
            int index = 0;
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string sor = sr.ReadLine();
                string[] adat = sor.Split(';');
                radio[index].Kezdo_ora = int.Parse(adat[0]);
                radio[index].Kezdo_perc = int.Parse(adat[1]);
                radio[index].adasDb = int.Parse(adat[2]);
                radio[index].nev = adat[3];
                index++;
            }
            sr.Close();

            Console.WriteLine("3. feladat: Bejegyzések száma: {0} db", index);

            bool bejegyzes4 = false;
            for (int i = 0; i < index; i++)
            {                
                if (radio[i].adasDb == 4)
                {
                    bejegyzes4 = true;                    
                    break;
                }
            }
            if(bejegyzes4 == true)
                Console.WriteLine("Volt négy adást indító sofőr.");
            else             
                Console.WriteLine("Nem volt négy adást indító sofőr");
            
            Console.ReadKey();
        }
    }
}
