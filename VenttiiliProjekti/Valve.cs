using System;
using System.Collections.Generic;
using System.Text;

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
        private DateTime _seuraavaHuolto;
        private DateTime _huollettu;

        private int _huoltovali;
        
        public Valve (int positioTunnus, string nimitys, string valmistaja, string malli, int koko, int varastoNimike, DateTime seuraavaHuolto, DateTime huollettu, int huoltovali )
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

        public DateTime tarkistaSeuraavahuolto()
        {
            return _seuraavaHuolto;
        }

        public DateTime tarkistaEdellinenHuolto()
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
