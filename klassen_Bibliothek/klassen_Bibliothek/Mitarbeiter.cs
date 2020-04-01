using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_Bibliothek
{
    public enum Abteilung
    {
        Lager,
        Verkauf,
        Buchhaltung,
        Personal,
        Einkauf

    }
    public enum Position
    {
        Geschäftsführer,
        Abteilungsleiter,
        Teamleiter,
        Sachbearbeiter,
        Praktikant,
        Mitarbeiter
    }
    public class Mitarbeiter : Person
    {
        
        int _mitarbeiterid;
        Position _position;
        Abteilung _abteilung;
        DateTime _eintrintsdatum;
        decimal _gehalt;
        Bankverbindung _bankverbindung;
        List<Memo> _nachrichten = new List<Memo>();
        KontaktDaten _kontaktdaten;
        List<Termin> _termine = new List<Termin>();


        public Mitarbeiter(string VName, string NName, DateTime Gebdatum, int mitarbeiterid, Position position, Abteilung abteilung, DateTime eintrintsdatum, decimal gehalt, Bankverbindung bankverbindung, KontaktDaten kontaktdaten) : base(VName, NName,Gebdatum)
        {
            
            _mitarbeiterid = mitarbeiterid;
            _position = position;
            _abteilung = abteilung;
            _eintrintsdatum = eintrintsdatum;
            _gehalt = gehalt;
            _bankverbindung = bankverbindung;
            _kontaktdaten = kontaktdaten;

        }

         
        //public string Vorname { get => _vorname; set => _vorname = value; }
        //public string Nachname { get => _nachname; set => _nachname = value; }
        //public string GebDatum { get => _gebdatum.ToLongDateString(); set => _gebdatum = Convert.ToDateTime(value); }
        public int Mitarbeiterid { get => _mitarbeiterid; set => _mitarbeiterid = value; }
        public Position Position { get => _position; set => _position = value; }
        public Abteilung Abteilung { get => _abteilung; set => _abteilung = value; }
        public DateTime Eintrintsdatum { get => _eintrintsdatum; set => _eintrintsdatum = value; }     
        public decimal Gehalt { get => _gehalt; set => _gehalt = value; }
        public Bankverbindung Bankverbindung { get => _bankverbindung; set => _bankverbindung = value; }
        public List<Memo> Nachrichten { get => _nachrichten; set => _nachrichten = value; }
        public KontaktDaten Kontaktdaten { get => _kontaktdaten; set => _kontaktdaten = value; }
        public List<Termin> Termine { get => _termine; set => _termine = value; }



        public override string ToString()
        {
            return Vorname + Nachname + GebDatum + Mitarbeiterid + Position + Abteilung + Eintrintsdatum.ToShortDateString() + Gehalt + Bankverbindung + Nachrichten + Kontaktdaten + Termine;
        }
    }
}



