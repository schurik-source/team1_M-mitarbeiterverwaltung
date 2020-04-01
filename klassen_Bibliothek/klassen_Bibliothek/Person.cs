using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_Bibliothek
{
    public abstract class Person
    {
        string _vorname;
         string _nachname;
         DateTime _gebdatum;

        public string Vorname { get => _vorname; set => _vorname = value; }
        public string Nachname { get => _nachname; set => _nachname = value; }
        public string GebDatum { get => _gebdatum.ToLongDateString(); set => _gebdatum = Convert.ToDateTime(value); }


        public Person(string VName, string NName, DateTime Gebdatum)
        {
            _vorname = NName;
            _nachname = VName;
            _gebdatum = Gebdatum;
        }
        //public override string ToString()
        //{
        //    string output = "";

        //    output += $"{Vorname} {Nachname}";

        //    return output;
        //}
    }
}
   
