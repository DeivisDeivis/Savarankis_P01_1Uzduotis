﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Savarankiskas_Darbelis
{

    internal class Program
    {
        class Turistai
        {
            private int eurai, centai;    
         public Turistai(int eurai, int centai)
            {
                this.eurai = eurai;
                this.centai = centai;
            }

            public int ImtiEurus() { return eurai; }
            public int ImtiCentus() { return centai; }
        }

        const int Cn = 100;
        const string CFd = "TextFile1.txt";

        static void Main(string[] args)
        {
            Turistai[] D = new Turistai[Cn];
            
             int kiekis;
            Skaityti(CFd, D, out kiekis);
            Console.WriteLine("Turistu kiekis: {0}", kiekis);

            Console.WriteLine("Eurai    Centai");
            for (int i = 0; i<kiekis; i++)
            {
                Console.WriteLine("{0} {1,5:d}", D[i].ImtiEurus(), D[i].ImtiCentus());
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Suma: {0} eurai  {1} centai ", (suma(D, kiekis)/100), (suma(D, kiekis)%100));
            Console.WriteLine("Kiek vidutiniskai vienam nariui: {0} eurai  {1} centai ", (suma(D, kiekis) / 100)/5, (suma(D, kiekis) % 100)/5);
            Console.WriteLine("Is viso surinkta bendroms islaidoms suma: {0} eurai  {1} centai ", (vidutiniskai(D, kiekis) / 100), (vidutiniskai(D, kiekis) % 100));
        }

        static void Skaityti(string fv, Turistai[] D, out int kiekis)
        {
            int eurai;
            int centai;
            using (StreamReader reader = new StreamReader(fv))
            {
                string line;
                line = reader.ReadLine();
                string[] parts;
                kiekis = int.Parse(line);
                for (int i = 0; i < kiekis; i++)
                {
                    line = reader.ReadLine();
                    parts = line.Split(';');
                    eurai = int.Parse(parts[0]);
                    centai = int.Parse(parts[1]);
                    D[i] = new Turistai(eurai, centai);

                }
            }
        }
        static int suma(Turistai [] D, int kiekis)
        {
            int suma = 0;

            for (int i = 0; i<kiekis;i++)
            {
                suma += (D[i].ImtiEurus()*100) + D[i].ImtiCentus();
  
            }
return suma;
        }

        static int vidutiniskai(Turistai[] D, int kiekis)
        {
            int vidutinisk = 0;
            for (int i =0; i<kiekis; i++)
            {
                vidutinisk += ((D[i].ImtiEurus() * 100)/4 + D[i].ImtiCentus()/4);
            }
            return vidutinisk;

        }

        }

    }
 
