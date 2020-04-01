﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_Bibliothek
{
    public class KontaktDaten
    {
        Adresse _adress;
        string _email;
        string _telefon;

        public KontaktDaten(Adresse adress, string email, string telefon)
        {
            Adress = adress;
            Email = email;
            Telefon = telefon;
        }

        public Adresse Adress { get => _adress; set => _adress = value; }
        public string Email { get => _email; set => _email = value; }
        public string Telefon { get => _telefon; set => _telefon = value; }

        public override string ToString()
        {
            string output = "";

            output += $" {Adress} {Telefon} {Email}";

            return output;
        }
        public void daten_Aendern(string Telefonnummer, string Email)
        {
            _telefon = Telefonnummer;
            _email = Email;
        }
        public void daten_Aendern(int telmail, string datensatz)
        {
            if (telmail == 0)
            {
                _telefon = datensatz;
            }
            else
            {
                _email = datensatz;
            }

        }

    }
}
