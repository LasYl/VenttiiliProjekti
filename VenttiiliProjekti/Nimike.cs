using System;
using System.Collections.Generic;
using System.Text;

namespace VenttiiliProjekti
{
    class Nimike
    {
        private int _nimikeNumero;
        private string _nimi;
        private string _Nvalmistaja;
        private string _myyja;
        private double _hinta;
        private int _saldo;
        

        public Nimike(string nimi, string Nvalmistaja, string myyja, double hinta, int saldo)
        {
           
            _nimi = nimi;
            _Nvalmistaja = Nvalmistaja;
            _myyja = myyja;
            _hinta = hinta;
            _saldo = saldo;
        }

        //public void setValmistaja(s)

        public int tarkistaNimikeNumero()
        {
            return _nimikeNumero;
        }


        public string tarkistaNimi()
        {
            return _nimi;
        }

        public string tarkistaValmistaja()
        {
            return _valmistaja;
        }

        public string tarkistaMyyja()
        {
            return _myyja;
        }

        public double tarkistaHinta()
        {
            return _hinta;
        }

        public int tarkistaSaldo()
        {
            return _saldo;
        }

      
        public static implicit operator int(Nimike v)
        {
            throw new NotImplementedException();
        }
    }
}

