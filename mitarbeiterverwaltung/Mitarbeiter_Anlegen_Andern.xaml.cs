using klassen_Bibliothek;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace mitarbeiterverwaltung
{
    /// <summary>
    /// Логика взаимодействия для Mitarbeiter_Anlegen_Andern.xaml
    /// </summary>
    public partial class Mitarbeiter_Anlegen_Andern : Window
    {

        List<Mitarbeiter> Mitarbeiterliste;
        int index;
        public Mitarbeiter_Anlegen_Andern(List<Mitarbeiter> Mitarbeiterliste, int Index)
        {
            InitializeComponent();

            this.Mitarbeiterliste = Mitarbeiterliste;
            this.index = Index;
            InitializeComponent();

            CB_stellung.ItemsSource = Enum.GetValues(typeof(Position));
            CB_abteilung.ItemsSource = Enum.GetValues(typeof(Abteilung));

            if (index == -1)
            {
                //Neu Anlegen
                this.Title = "Neuer Mitarbeiter";
                BT_OK.Content = "Anlegen";

            }
            else
            {
                TB_Vorname.Text = Mitarbeiterliste[index].Vorname ;
                TB_NName.Text = Mitarbeiterliste[index].Nachname;
                //Mitarbeiterliste[index].Mitarbeiterid = Convert.ToInt32(TB_MitarbeiterID.Text);
                Mitarbeiterliste[index].Position = (Position)CB_stellung.SelectedItem;
                Mitarbeiterliste[index].Abteilung = (Abteilung)CB_abteilung.SelectedItem;
                Mitarbeiterliste[index].Eintrintsdatum = (DateTime)DP_eintrittsdatum.SelectedDate;
                Mitarbeiterliste[index].Eintrintsdatum = (DateTime)DP_geburtsdatum.SelectedDate;
                Mitarbeiterliste[index].Gehalt = Convert.ToDecimal(TB_Gehalt.Text);
                Mitarbeiterliste[index].Kontaktdaten.Adress.Strasse = TB_Strasse.Text;
                Mitarbeiterliste[index].Kontaktdaten.Adress.Hausnummer = TB_HSN.Text;
                Mitarbeiterliste[index].Kontaktdaten.Adress.PLZ = TB_PLZ.Text;
                Mitarbeiterliste[index].Kontaktdaten.Adress.Ort = TB_Ort.Text;
                Mitarbeiterliste[index].Bankverbindung.Kontonummer = Convert.ToInt32(TB_Kontonummer.Text);
                Mitarbeiterliste[index].Bankverbindung.BLZ = Convert.ToInt32(TB_BLZ.Text);
                Mitarbeiterliste[index].Bankverbindung.Bankname = TB_Bankname.Text;
                Mitarbeiterliste[index].Kontaktdaten.Telefon = TB_Telefon.Text;
                Mitarbeiterliste[index].Kontaktdaten.Email = TB_Email.Text;
            }

        }

        private void BT_OK_Click(object sender, RoutedEventArgs e)
        {
            if (index == -1)
            {

                DateTime startdatum = (DateTime)DP_eintrittsdatum.SelectedDate;
                var sqlFormattedDate = $"{startdatum.Year}-{startdatum.Month}-{startdatum.Day}";

                DateTime startdatum1 = (DateTime)DP_geburtsdatum.SelectedDate;
                var Gebdatum = $"{startdatum1.Year}-{startdatum1.Month}-{startdatum1.Day}";

                //DateTime myDateTime = DateTime.Now;
                //string sqlFormattedDate = myDateTime.Date.ToString("yyyy-MM-dd HH:mm:ss");
                //string sqlFormattedDate = myDateTime.Date.ToString("yyyy-MM-dd") + " " +myDateTime.TimeOfDay.ToString("HH:mm:ss");
                //sqlFormattedDate = DP_eintrittsdatum.SelectedDate.ToString();


                MySqlConnection con = new MySqlConnection("Server=localhost;Database=Team1;Uid=root;");
                con.Open();
                //neu
                MySqlCommand adresse = new MySqlCommand($"insert into t_adresse values(null, '{ TB_Strasse.Text }' , '{ TB_HSN.Text}',' " + TB_PLZ.Text + "', ' " + TB_Ort.Text + "')", con);

                adresse.ExecuteNonQuery();

                MySqlCommand bankverbindung = new MySqlCommand($"insert into t_bankverbindung values('{TB_Kontonummer.Text}' , '{ TB_BLZ.Text }' , '{TB_Bankname.Text}'  )", con);

                bankverbindung.ExecuteNonQuery();

                MySqlCommand Mitarbeiter = new MySqlCommand($"insert into t_mitarbeiter values(null,'{TB_Vorname.Text}' ,'{TB_NName.Text}' , '{Gebdatum}', ' { (Position)CB_stellung.SelectedItem }', ' { (Abteilung)CB_abteilung.SelectedItem }',  '{sqlFormattedDate}' , ' {Convert.ToDecimal(TB_Gehalt.Text) }', null,null  )", con);

                Mitarbeiter.ExecuteNonQuery();

                MySqlCommand kontaktdaten = new MySqlCommand($"insert into t_kontaktdaten values(null, null,'{TB_Telefon.Text}' , '{TB_Email.Text }'  )", con);

                kontaktdaten.ExecuteNonQuery();


                //Mitarbeiterliste.Add(new Mitarbeiter(TB_Vorname.Text, TB_NName.Text, Convert.ToInt32(TB_MitarbeiterID.Text), (Position)CB_stellung.SelectedItem, (Abteilung)CB_abteilung.SelectedItem, (DateTime)DP_eintrittsdatum.SelectedDate, Convert.ToDecimal(TB_Gehalt.Text), new Bankverbindung(Convert.ToInt32(TB_Kontonummer.Text), Convert.ToInt32(TB_BLZ.Text), TB_Bankname.Text), new KontaktDaten(new Adresse(TB_Strasse.Text, TB_HSN.Text, TB_PLZ.Text, TB_Ort.Text), TB_Email.Text, TB_Telefon.Text)));
            }
            else
            {
                //ändern

                MySqlConnection con = new MySqlConnection("Server=localhost;Database=Team1;Uid=root;Convert Zero Datetime=True");



                Mitarbeiterliste[index].Vorname = TB_Vorname.Text;
                Mitarbeiterliste[index].Nachname = TB_NName.Text;
                //Mitarbeiterliste[index].Mitarbeiterid = Convert.ToInt32(TB_MitarbeiterID.Text);
                Mitarbeiterliste[index].Position = (Position)CB_stellung.SelectedItem;
                Mitarbeiterliste[index].Abteilung = (Abteilung)CB_abteilung.SelectedItem;
                Mitarbeiterliste[index].Eintrintsdatum = (DateTime)DP_eintrittsdatum.SelectedDate;
                Mitarbeiterliste[index].Eintrintsdatum = (DateTime)DP_geburtsdatum.SelectedDate;
                Mitarbeiterliste[index].Gehalt = Convert.ToDecimal(TB_Gehalt.Text);
                Mitarbeiterliste[index].Kontaktdaten.Adress.Strasse = TB_Strasse.Text;
                Mitarbeiterliste[index].Kontaktdaten.Adress.Hausnummer = TB_HSN.Text;
                Mitarbeiterliste[index].Kontaktdaten.Adress.PLZ = TB_PLZ.Text;
                Mitarbeiterliste[index].Kontaktdaten.Adress.Ort = TB_Ort.Text;
                Mitarbeiterliste[index].Bankverbindung.Kontonummer = Convert.ToInt32(TB_Kontonummer.Text);
                Mitarbeiterliste[index].Bankverbindung.BLZ = Convert.ToInt32(TB_BLZ.Text);
                Mitarbeiterliste[index].Bankverbindung.Bankname = TB_Bankname.Text;
                Mitarbeiterliste[index].Kontaktdaten.Telefon = TB_Telefon.Text;
                Mitarbeiterliste[index].Kontaktdaten.Email = TB_Email.Text;





            }

            this.Close();
        }
    }
}
