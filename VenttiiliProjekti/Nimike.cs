using System;
using System.Collections.Generic;
using System.Text;

namespace VenttiiliProjekti
{
    class Nimike
    {
        //Nimikkeiden 
        private int _nimikeNumero;
        private string _nimi;
        private string _Nvalmistaja;
        private string _myyja;
        private int _hinta;
        private int _saldo;
        private int _minimisaldo;

        //
        public Nimike(int nimikeNumero, string nimi, string Nvalmistaja, string myyja, int hinta, int saldo, int minimisaldo)
        {
            _nimikeNumero = nimikeNumero;
            _nimi = nimi;
            _Nvalmistaja = Nvalmistaja;
            _myyja = myyja;
            _hinta = hinta;
            _saldo = saldo;
            _minimisaldo = minimisaldo;
        }

        public Nimike(int nimikeNumero, string nimi, string Nvalmistaja, string myyja, int hinta, int saldo, int minimisaldo, out bool success) : this(nimikeNumero, nimi, Nvalmistaja, myyja, hinta, saldo, minimisaldo)
        {
            success = false;
        }

        

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
            return _Nvalmistaja;
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

        public int tarkistaMinimisaldo()
        {
            return _minimisaldo;
        }


        public static implicit operator int(Nimike v)
        {
            throw new NotImplementedException();
        }
    }
}

