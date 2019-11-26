using System;
using System.Collections.Generic;
using System.Text;
using NpgsqlTypes;

namespace VenttiiliProjekti
{
    class Valve
    {
        private int _positioTunnus;
        private string _nimi;
        private string _valmistaja;
        private string _malli;
        private int _koko;
        private int _varastoNimike;
        private NpgsqlDate _seuraavaHuolto;
        private NpgsqlDate _huollettu;

        private int _huoltovali;
        private int v1;
        private string v2;
        private string v3;
        private string v4;
        private int v5;
        private int v6;
        private NpgsqlDate npgsqlDate1;
        private NpgsqlDate npgsqlDate2;
        

        public Valve (int positioTunnus, string nimitys, string valmistaja, string malli, int koko, int varastoNimike, NpgsqlDate seuraavaHuolto, NpgsqlDate huollettu, int huoltovali )
        {
            _positioTunnus = positioTunnus;
            _nimi = nimitys;
            _valmistaja = valmistaja;
            _malli = malli;
            _koko = koko;
            _varastoNimike = varastoNimike;
            _seuraavaHuolto = seuraavaHuolto;
            _huollettu = huollettu;
            _huoltovali = huoltovali;
        }

        public Valve(int positioTunnus, string nimitys, string valmistaja, string malli, int koko, int varastoNimike, NpgsqlDate seuraavaHuolto, NpgsqlDate huollettu, int huoltovali, out bool success) : this(positioTunnus, nimitys, valmistaja, malli, koko, varastoNimike, seuraavaHuolto, huollettu, huoltovali)
        {

            success = false;
        }

        /*public Valve(int v1, string v2, string v3, string v4, int v5, int v6, NpgsqlDate npgsqlDate1, NpgsqlDate npgsqlDate2, int v9, out bool success)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
            this.v4 = v4;
            this.v5 = v5;
            this.v6 = v6;
            this.npgsqlDate1 = npgsqlDate1;
            this.npgsqlDate2 = npgsqlDate2;
            
            success = false;
        }*/

        //public void setValmistaja(s)

        public int tarkistaPositio()
        {
            return _positioTunnus;
        }

        public string tarkistaNimi()
        {
            return _nimi;
        }


        public string tarkistaValmistaja()
        {
            return _valmistaja;
        }

        public string tarkistaMalli()
        {
            return _malli;
        }

        public int tarkistaKoko()
        {
            return _koko;
        }

        public int tarkistaNimike()
        {
            return _varastoNimike;
        }

        public NpgsqlDate tarkistaSeuraavahuolto()
        {
            return _seuraavaHuolto;
        }

        public NpgsqlDate tarkistaEdellinenHuolto()
        {
            return _huollettu;
        }
        public int tarkistaHuoltovali()
        {
            return _huoltovali;
        }

        public static implicit operator int(Valve v)
        {
            throw new NotImplementedException();
        }
    }
}
