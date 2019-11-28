using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;


namespace VenttiiliProjekti
{
    static class Sql
    {
        // DB Connection details
        private const string HOST = "localhost";
        private const string USERNAME = "postgres";
        private const string PASSWORD = "Grespost99";
        private const string DB = "Venttiili";
        private const string CONNECTION_STRING = "Host=" + HOST + ";Username=" + USERNAME + ";Password=" + PASSWORD + ";Database=" + DB;
        // Connection is private and gets opened in the constructor and used in all the db transactions
        static private NpgsqlConnection connection;
        static private NpgsqlCommand valitseKaikkiNimikkeet = null;
        static private NpgsqlCommand valitseKaikkiVenttiilit = null;
        static private NpgsqlCommand lisaaVenttiili = null;
        static private NpgsqlCommand lisaaNimike = null;

        // Constructor: creates the connection to the db
        static Sql()
        {
            try
            {
                connection = new NpgsqlConnection(CONNECTION_STRING);
                connection.Open(); // Avataan yhteys tietokantaan
            }
            catch (NpgsqlException ex)
            {
                throw new NpgsqlException($"Error in database connection ({ ex.Message }).");
            }

        }

        // Haetaan tietokannasta olemassaolevat nimikkeet
        static public List<Nimike> selectKaikkiNimikkeet()
        {
            List<Nimike> list = new List<Nimike>();
            using (valitseKaikkiNimikkeet = new NpgsqlCommand("SELECT * FROM varastonimike", connection))
            {
                valitseKaikkiNimikkeet.Prepare(); // Prepare the select query that gets all cars from the database

                using (NpgsqlDataReader results = valitseKaikkiNimikkeet.ExecuteReader())
                {
                    bool success;

                    while (results.Read())
                    {
                        list.Add(new Nimike(results.GetInt32(0), results.GetString(1), results.GetString(2), results.GetString(3), results.GetInt32(4), results.GetInt32(5), results.GetInt32(6), out success));
                    }
                }
            }
            
            return list;

        }


        // Haetaan tietokannasta olemassaolevat venttiilit, ja luodaan siitä konstruktori
        static public List<Valve> selectKaikkiVenttiilit()
        {
            List<Valve> list = new List<Valve>();
            using (valitseKaikkiVenttiilit = new NpgsqlCommand($"SELECT * FROM venttiili", connection))
            {
                valitseKaikkiVenttiilit.Prepare(); // Prepare the select query that gets all cars from the database

                using (NpgsqlDataReader results = valitseKaikkiVenttiilit.ExecuteReader())
                {
                    bool success;

                    while (results.Read())
                    {
                        list.Add(new Valve(results.GetInt32(0), results.GetString(1), results.GetString(2), results.GetString(3), results.GetInt32(4), results.GetInt32(5), results.GetDate(6), results.GetDate(7), results.GetInt32(8),  out success));
                    }
                }
            }

            return list;

        }

        // Lisätään nimike tietokantaan, ja luodaan siitä konstruktori
        static public void AddNimike(Nimike nimike)
        {
            using (lisaaNimike = new NpgsqlCommand("INSERT INTO varastonimike(id, nimi, valmistaja, myyjä, hinta, saldo, minimisaldo) " +
            "VALUES (@id, @nimi, @valmistaja, @myyjä, @hinta, @saldo, @minimisaldo)", connection))
            {
                lisaaNimike.Parameters.AddWithValue("id", nimike.tarkistaNimikeNumero());
                lisaaNimike.Parameters.AddWithValue("nimi", nimike.tarkistaNimi());
                lisaaNimike.Parameters.AddWithValue("valmistaja", nimike.tarkistaValmistaja());
                lisaaNimike.Parameters.AddWithValue("myyjä", nimike.tarkistaMyyja());
                lisaaNimike.Parameters.AddWithValue("hinta", nimike.tarkistaHinta());
                lisaaNimike.Parameters.AddWithValue("saldo", nimike.tarkistaSaldo());
                lisaaNimike.Parameters.AddWithValue("minimisaldo", nimike.tarkistaMinimisaldo());
                lisaaNimike.ExecuteNonQuery();
            }
        }

        // Lisätään venttiili tietokantaan
        static public void AddValve(Valve venttiili)
        {
            using (lisaaVenttiili = new NpgsqlCommand("INSERT INTO venttiili(id, nimi, valmistaja, malli, koko, id_varastonimike, seuraava_huolto, huollettu, huoltovali_vuosina) " +
            "VALUES (@id, @nimi, @valmistaja, @malli, @koko, @id_varastonimike, @seuraava_huolto, @huollettu, @huoltovali_vuosina)", connection))
            {
                lisaaVenttiili.Parameters.AddWithValue("id", venttiili.tarkistaPositio());
                lisaaVenttiili.Parameters.AddWithValue("nimi", venttiili.tarkistaNimi());
                lisaaVenttiili.Parameters.AddWithValue("valmistaja", venttiili.tarkistaMalli());
                lisaaVenttiili.Parameters.AddWithValue("malli", venttiili.tarkistaMalli());
                lisaaVenttiili.Parameters.AddWithValue("koko", venttiili.tarkistaKoko());
                lisaaVenttiili.Parameters.AddWithValue("id_varastonimike", venttiili.tarkistaNimike());
                lisaaVenttiili.Parameters.AddWithValue("seuraava_huolto", venttiili.tarkistaSeuraavahuolto());
                lisaaVenttiili.Parameters.AddWithValue("huollettu", venttiili.tarkistaEdellinenHuolto());
                lisaaVenttiili.Parameters.AddWithValue("huoltovali_vuosina", venttiili.tarkistaHuoltovali());
                lisaaVenttiili.ExecuteNonQuery();
            }
        }
    }
}