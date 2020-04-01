﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_Bibliothek
{
    public class Adresse
    {
        string _strasse;
        string _hausnum;
        string _PLZ;
        string _ort;

        public Adresse(string strasse, string hausnum, string pLZ, string ort)
        {
            _strasse = strasse;
            _hausnum = hausnum;
            _PLZ = pLZ;
            _ort = ort;
        }

        public string Strasse { get => _strasse; set => _strasse = value; }
        public string Hausnummer { get => _hausnum; set => _hausnum = value; }
        public string PLZ { get => _PLZ; set => _PLZ = value; }
        public string Ort { get => _ort; set => _ort = value; }

        public override string ToString()
        {
            return $"{Strasse} , {Hausnummer} , {PLZ} , {Ort} ";
        }

    }
}
