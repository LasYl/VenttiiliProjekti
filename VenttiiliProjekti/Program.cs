using System;
using System.Collections.Generic;
using System.Linq;

namespace VenttiiliProjekti
{
    class Program
    {
        static void TulostaOhjeet()
        {
            Console.WriteLine("\n\nValitse seuraavista:\n\n");
            Console.WriteLine("[1] Lisää varastonimike\n");
            Console.WriteLine("[2] Lisää prosessiventtiili\n");
            Console.WriteLine("[3] Hae varastonimikkeen tiedot\n");
            Console.WriteLine("[4] Hae prosessiventtiilin tiedot\n");
            Console.WriteLine("[5] Huolla venttiili\n");
            Console.WriteLine("[6] Ohjeet\n");
            Console.WriteLine("[Q] Lopetus\n\n");
        }

        static void Main(string[] args)
        {
            
            List<Valve> valveList = new List<Valve>();
            List<Nimike> nimikeLista = new List<Nimike>();
            int nimike = 299999;
            bool jatka = true;

            
            while (jatka)
            {
                TulostaOhjeet();

                Console.WriteLine("Anna komento");
                string komento = Console.ReadLine();
                

                switch (komento)
                {
                    case "1":
                        
                        int nimikeNumero = nimike + 1;
                        nimike++;
                        Console.WriteLine("Anna uuden nimikkeelle nimi: ");
                        string nimi = Console.ReadLine();
                        Console.WriteLine("Anna uuden huoltosarjan valmistaja: ");
                        string Nvalmistaja = Console.ReadLine();
                        Console.WriteLine("Anna uuden nimikkeen jälleenmyyjä: ");
                        string myyja = Console.ReadLine();
                        Console.WriteLine("Anna uuden nimikkeen hinta: ");
                        double hinta = double.Parse(Console.ReadLine());
                        Console.WriteLine("Anna nimikkeelle varastosaldo ");
                        int saldo = int.Parse(Console.ReadLine());
                        Nimike newNimike = new Nimike(nimikeNumero, nimi, Nvalmistaja, myyja, hinta, saldo);
                        nimikeLista.Add(newNimike);
                        Console.WriteLine($"Nimike { newNimike.tarkistaNimikeNumero() } luotu.");
                       
                        break;

                    case "2":
                        Console.WriteLine("Anna uuden venttiilin positio: ");
                        int positioTunnus = int.Parse(Console.ReadLine());
                        Console.WriteLine("Anna uuden venttiilin valmistaja: ");
                        string valmistaja = Console.ReadLine();
                        Console.WriteLine("Anna uuden venttiilin malli: ");
                        string malli = Console.ReadLine();
                        Console.WriteLine("Anna uuden venttiilin tyyppi: ");
                        string tyyppi = Console.ReadLine();
                        Console.WriteLine("Anna uuden venttiilin materiaali: ");
                        string materiaali = Console.ReadLine();
                        Console.WriteLine("Anna uuden venttiilin tiivisteiden varastonimike: ");
                        int varastoNimike = int.Parse(Console.ReadLine());
                        Valve newValve = new Valve(positioTunnus, valmistaja, malli, tyyppi, materiaali, varastoNimike);
                        valveList.Add(newValve);
                        Console.WriteLine($"Venttiili { newValve.tarkistaPositio() } luotu.");
                        break;

                    case "3":
                        foreach (Nimike Nimike in nimikeLista)
                        {
                            Console.WriteLine($"Nimike { Nimike.tarkistaNimikeNumero() }\tNimi: { Nimike.tarkistaNimi() } \tValmistaja: { Nimike.tarkistaValmistaja() } \tMyyjä: { Nimike.tarkistaMyyja() } \tHinta: { Nimike.tarkistaHinta() }");
                        }
                        break;

                    case "4":
                        foreach (Valve Valve in valveList)
                        {
                            Console.WriteLine($"Positio { Valve.tarkistaPositio() }\tValmistaja: { Valve.tarkistaValmistaja() } \tMalli: { Valve.tarkistaMalli() } \tTyyppi: { Valve.tarkistaTyyppi() } \tVarastonimike: { Valve.tarkistaNimike() }");
                        }
                        break;
                        /*Console.WriteLine("Anna haluamasi nimikkeen nimikenumero: ");
                        int haettavaNimike = int.Parse(Console.ReadLine());
                        Console.WriteLine($"Nimike { Nimike.tarkistaNimi() } luotu.");

                        break;*/

                        /*case "u": // uusi pelaaja
                            Console.Write("Pelaajan numero:");
                            nro = int.Parse(Console.ReadLine());
                            // TODO: lisää pelaaja listaan
                            pelaajat.Add(nro);
                            break;
                        case "h": // ohjeet
                            TulostaOhjeet();

                            break;
                        case "t": // tulosta
                            foreach (var item in pelaajat)
                            {
                                Console.Write(item + " ");
                            }
                            Console.WriteLine();
                            break;
                        case "q": // lopeta
                            jatka = false;
                            break;
                        case "s": // hae lineaarisesti taulukosta
                            // Toteuta pelaajan hakeminen
                            // Jos pelaaja löytyy, tulostetaan sen paikka 
                            // Jos ei löydy, tulostetaan -1
                            Console.Write("Pelaajan numero:");
                            nro = int.Parse(Console.ReadLine());
                            int paikka = pelaajat.IndexOf(nro);
                            // TODO: hae pelaaja listasta
                            // haku itse tehtynä
                            paikka = -1;

                            for (int i = 0; i < pelaajat.Count; i++)
                            {
                                if (pelaajat[i] == nro)
                                {
                                    paikka = i;
                                    break;
                                }

                            }
                            if (paikka == -1)
                                Console.WriteLine("ei löytynyt");
                            else
                                Console.WriteLine("löytyi paikasta " + paikka);
                            break;

                        // TODO: kokeile binäärihakua
                        case "p": // poista pelaaja
                            Console.Write("Pelaajan numero:");
                            nro = int.Parse(Console.ReadLine());

                            // TODO: poista pelaaja
                            pelaajat.Remove(nro);
                            break;

                        case "j":
                            // TODO: järjestä pelaajat
                            pelaajat.Sort();
                            break;
                        */
                }
            }
        }
        //static void Main(string[] args)
        //{
        //Console.WriteLine("Anna uuden venttiilin positio: ");
        //string positio = Console.ReadLine();
        //Console.WriteLine("Anna uuden venttiilin valmistaja: ");
        //string valmistaja = Console.ReadLine();
        //Console.WriteLine("Anna uuden venttiilin malli: ");
        //string malli = Console.ReadLine();
        //Console.WriteLine("Anna uuden venttiilin tyyppi: ");
        //string tyyppi = Console.ReadLine();
        //Console.WriteLine("Anna uuden venttiilin materiaali: ");
        //string materiaali = Console.ReadLine();

        //Valve ekaVenttiili = new Valve(positio);
        //}
    }
}
