using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace klassen_Bibliothek
{
    public class Memo
    {
        int _memoid;
        int _absenderid;
        int _empfängerid;
        DateTime _versendetezeit;
        string _text;

        public Memo(int memoid, int absenderid, int empfängerid, DateTime versendetezeit, string text)
        {
            _memoid = memoid;
            _absenderid = absenderid;
            _empfängerid = empfängerid;
            _versendetezeit = versendetezeit;
            _text = text;
        }

        public int Memoid { get => _memoid; set => _memoid = value; }
        public int Absenderid { get => _absenderid; set => _absenderid = value; }
        public int Empfängerid { get => _empfängerid; set => _empfängerid = value; }
        public DateTime Versendetezeit { get => _versendetezeit; set => _versendetezeit = value; }
        public string Text { get => _text; set => _text = value; }
    }
}
