using System;
using System.Collections.Generic;
using System.Linq;
using NpgsqlTypes;

namespace VenttiiliProjekti
{
    class Program


    {
        private static int positioTunnus;
        private static int koko;
        private static int saldo;
        private static int hinta;



        static void TulostaOhjeet()
        {
            Console.WriteLine("\n\nValitse seuraavista:\n\n");
            Console.WriteLine("[1] Lisää varastonimike\n");
            Console.WriteLine("[2] Lisää prosessiventtiili\n");
            Console.WriteLine("[3] Lista nimikkeistä\n");
            Console.WriteLine("[4] Lista venttiileistä\n");
            Console.WriteLine("[5] Poista venttiili\n");
            Console.WriteLine("[6] Poista varastonimike\n");
            Console.WriteLine("[9] Ohjeet\n");
            Console.WriteLine("[Q] Lopetus\n\n");
        }

        static void Main(string[] args)
        {
            // Venttiililistan luonti
            List<Valve> valveList = new List<Valve>();

            // Nimikelistan luonti
            List<Nimike> nimikeLista = new List<Nimike>();

            // Ensimmäisen nimikenumeron asetus numeroksi 300001
            int seuraavaNimike = 300001;

            // Ohjelman jatkaminen kunnes muutetaan falseksi
            bool jatka = true;

            // Nimikelistan luonti
            List<Nimike> nimikkeet = new List<Nimike>();

            // Päivitetään venttiilista tietokannasta
            valveList = Sql.selectKaikkiVenttiilit();

            // Päivitetään nimikelista tietokannasta
            nimikkeet = Sql.selectKaikkiNimikkeet();

            // Rullataan 300001:stä nimikkeiden verran eteenpäin, että saadaan seuraava luotava nimike 
            foreach (Nimike Nimike in nimikkeet)
            {
                seuraavaNimike++;

            }



            //konstruktori nimikelistan tulostukselle
            void tulostanimikkeet()
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-12} | {3,-11} | {4,7} | {5,7} | {6,11}", "Nimike", "Nimi", "Valmistaja", "Myyjä", "Hinta", "Saldo", "Minimisaldo"));
                Console.WriteLine();

                foreach (Nimike Nimike in nimikkeet)
                {
                    Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-12} | {3,-11} | {4,7} | {5,7} | {6,11}", (Nimike.tarkistaNimikeNumero()), (Nimike.tarkistaNimi()), (Nimike.tarkistaValmistaja()), (Nimike.tarkistaMyyja()), (Nimike.tarkistaHinta()), (Nimike.tarkistaSaldo()), (Nimike.tarkistaMinimisaldo())));


                }
            }

            //konstruktori nimikelistan tulostukselle
            void tulostaventtiilit()
            { 
            Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-12} | {3,-13} | {4,7} | {5,12} | {6,15} | {7,20} | {8,10}", "Nimike", "Nimi", "Valmistaja", "Malli", "Koko", "Varastonimike", "Seuraava huolto", "Huollettu viimeksi", "Huoltoväli"));
            Console.WriteLine();

            foreach (Valve Valve in valveList)
            {
                Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-12} | {3,-13} | {4,7} | {5,12} | {6,15} | {7,20} | {8,10}", (Valve.tarkistaPositio()), (Valve.tarkistaNimi()), (Valve.tarkistaValmistaja()), (Valve.tarkistaMalli()), (Valve.tarkistaKoko()), (Valve.tarkistaNimike()), (Valve.tarkistaSeuraavahuolto()), (Valve.tarkistaEdellinenHuolto()), (Valve.tarkistaHuoltovali())));
            }

            }

            //Tulostetaan ohjeet ennen looppia
            TulostaOhjeet();
            //Käytttäjälle näkyvän loopin aloitus
            while (jatka)
            {
                //Loopin aloitus
                Console.WriteLine("\nAnna komento ohjeen mukaan, (Ohjeet uudelleen = 9)");
                string komento = Console.ReadLine();
                //Loopin ohjaus käyttäjän valitsemaan paikkaan
                switch (komento)
                {
                    case "1":
                        // Uuden varastonimikkeen luonti
                        // Asetetaan nimikenumeroksi tietokannasta haettu seuraava vapaa nimike
                        int nimikeNumero = seuraavaNimike;
                        // Lisätään seuraavaa nimikettä varten yksi lisää
                        seuraavaNimike++;
                        // Annetaan nimikkeelle nimitys
                        Console.WriteLine("Anna uuden nimikkeelle nimi: ");
                        string nimi = Console.ReadLine();
                        // Annetaan nimikkeelle valmistaja
                        Console.WriteLine("Anna uuden huoltosarjan valmistaja: ");
                        string Nvalmistaja = Console.ReadLine();
                        // Annetaan nimikkeelle myyjä
                        Console.WriteLine("Anna uuden nimikkeen jälleenmyyjä: ");
                        string myyja = Console.ReadLine();
                        // Annetaan nimikkeelle hinta
                        Console.WriteLine("Anna uuden nimikkeen hinta: ");
                        try
                        {
                            hinta = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Anna hinta uudelleen, vain numerot hyväksytään");
                            hinta = int.Parse(Console.ReadLine());
                        }
                        // Annetaan nimikkeelle saldo, montako niitä on laittaa hyllyyn
                        Console.WriteLine("Anna nimikkeelle varastosaldo ");
                        try
                        {
                            saldo = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Anna saldo uudelleen, vain numerot hyväksytään");
                            saldo = int.Parse(Console.ReadLine());
                        }
                        // Annetaan nimikkeelle minimisaldo, määrä joka saldoa pitää vähintään olla ennen kuin niitä pitää tilata lisää
                        Console.WriteLine("Anna nimikkeelle minimisaldo, mikä pitää aina vähintään olla ");
                        int minimisaldo = int.Parse(Console.ReadLine());
                        // Luodaan nimike listaan ja tietokantaan
                        Nimike newNimike = new Nimike(nimikeNumero, nimi, Nvalmistaja, myyja, hinta, saldo, minimisaldo);
                        Sql.AddNimike(newNimike);
                        nimikeLista.Add(newNimike);
                        // Tulostetaan teksti, että kyseinen nimike on luotu
                        Console.WriteLine($"\nNimike { newNimike.tarkistaNimikeNumero() } luotu.");
                       
                    break;

                    case "2":
                        // Annetaan venttiilille positionumero, jonka käyttäjä itse päättää
                        Console.WriteLine("Anna uuden venttiilin positio numeroina: ");
                        try
                        {
                            positioTunnus = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Anna positio uudelleen, vain numerot hyväksytään");
                            positioTunnus = int.Parse(Console.ReadLine());
                        }
                        // Annetaan venttiilille nimitys
                        Console.WriteLine("Anna uuden venttiilin nimitys: ");
                        string nimitys = Console.ReadLine();
                        // Annetaan venttiilille valmistaja
                        Console.WriteLine("Anna uuden venttiilin valmistaja: ");
                        string valmistaja = Console.ReadLine();
                        // Annetaan venttiilille malli
                        Console.WriteLine("Anna uuden venttiilin malli: ");
                        string malli = Console.ReadLine();
                        // Annetaan venttiilille koko
                        Console.WriteLine("Anna uuden venttiilin koko: ");
                        try
                        {
                            koko = int.Parse(Console.ReadLine());
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Anna koko uudelleen, vain numerot hyväksytään");
                            koko = int.Parse(Console.ReadLine());
                           
                        }
                         
                        // Annetaan venttiilille huollossa käytettävä varaston nimikenumero
                        
                        Console.WriteLine("Anna uuden venttiilin tiivisteiden varastonimike: (nimikelistaus 1 ");
                        
                       
                        int varastoNimike = int.Parse(Console.ReadLine());
                        if (varastoNimike == 1)
                        {
                            tulostanimikkeet();
                            Console.WriteLine("Anna uuden venttiilin tiivisteiden varastonimike: ");
                            
                            varastoNimike = int.Parse(Console.ReadLine());
                        }
                        
                        
                        NpgsqlDate huollettu = NpgsqlDate.Today;
                       
                        Console.WriteLine("Anna huoltoväli vuosina: ");
                        int huoltovali = int.Parse(Console.ReadLine());
                        NpgsqlDate seuraavaHuolto = huollettu.AddYears(huoltovali);
                        Valve newValve = new Valve(positioTunnus, nimitys, valmistaja, malli, koko, varastoNimike, seuraavaHuolto, huollettu, huoltovali);
                        Sql.AddValve(newValve);
                        valveList.Add(newValve);
                        Console.WriteLine($"Venttiili { newValve.tarkistaPositio() } luotu.");
                        break;





                    case "3":
                            //Nimikkeiden tulostus taulukkona
                            {
                                tulostanimikkeet();
                            }
                        break;

                    case "4":
                        //Luodaan listaus venttiileistä, jossa muotoillaan tulostusasetukset taulukkomaiseen muotoon
                        //Ensin tulostetaan otsikot, jonka jälkeen foreachillä haetaan kaikilta venttiileiltä tiedot
                        Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-12} | {3,-13} | {4,7} | {5,12} | {6,15} | {7,20} | {8,10}", "Nimike", "Nimi", "Valmistaja", "Malli", "Koko", "Varastonimike", "Seuraava huolto", "Huollettu viimeksi", "Huoltoväli"));
                        Console.WriteLine();

                        foreach (Valve Valve in valveList)
                        {
                            Console.WriteLine(String.Format("{0,-10} | {1,-15} | {2,-12} | {3,-13} | {4,7} | {5,12} | {6,15} | {7,20} | {8,10}", (Valve.tarkistaPositio()), (Valve.tarkistaNimi()), (Valve.tarkistaValmistaja()), (Valve.tarkistaMalli()), (Valve.tarkistaKoko()), (Valve.tarkistaNimike()), (Valve.tarkistaSeuraavahuolto()), (Valve.tarkistaEdellinenHuolto()), (Valve.tarkistaHuoltovali())));
                        }
 
                        break;

                    case "5":
                        {
                            
                            Sql.selectKaikkiVenttiilit();
                            tulostaventtiilit();
                            Console.WriteLine("Anna poistettavan venttiilin positio ");
                            int id = int.Parse(Console.ReadLine());
                         
                            Sql.poistaSql(id);
                            valveList = Sql.selectKaikkiVenttiilit();
                        }
                        break;

                    case "6":
                        {

                            Sql.selectKaikkiNimikkeet();
                            tulostanimikkeet();
                            Console.WriteLine("Anna poistettavan nimikkeen numero ");
                            int id = int.Parse(Console.ReadLine());

                            Sql.poistaNimike(id);
                            nimikkeet = Sql.selectKaikkiNimikkeet();
                        }
                        break;

                    


                    case "9":
                        {
                            TulostaOhjeet();
                        }
                        break;

                        // Ohjelman lopetus
                    case "Q":
                        {
                            jatka = false;
                        }
                        break;
                        

                       
                }
            }
        }
       
    }
}
