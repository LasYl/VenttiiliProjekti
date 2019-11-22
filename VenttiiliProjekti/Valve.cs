using System;
using System.Collections.Generic;
using System.Text;

namespace VenttiiliProjekti
{
    class Valve
    {
        private int _positioTunnus;
        private string _valmistaja;
        private string _malli;
        private string _tyyppi;
        private string _materiaali;
        private int _varastoNimike;
        private int _huoltovali;
        
        public Valve (int positioTunnus, string valmistaja, string malli, string tyyppi, string materiaali, int varastoNimike)
        {
            _positioTunnus = positioTunnus;
            _valmistaja = valmistaja;
            _malli = malli;
            _tyyppi = tyyppi;
            _materiaali = materiaali;
            _varastoNimike = varastoNimike;
    }

        //public void setValmistaja(s)


        public string tarkistaValmistaja()
        {
            return _valmistaja;
        }

        public string tarkistaMalli()
        {
            return _malli;
        }

        public string tarkistaTyyppi()
        {
            return _tyyppi;
        }

        public string tarkistaMateriaali()
        {
            return _materiaali;
        }

        public int tarkistaNimike()
        {
            return _varastoNimike;
        }

        public int tarkistaHuoltovali()
        {
            return _huoltovali;
        }


    }
}
