using klassen_Bibliothek;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        //SqlDataAdapter adapter;

       
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
                MySqlConnection con = new MySqlConnection("Server=localhost;Database=Team1;Uid=root;Convert Zero Datetime=true ");
                con.Open();

                //DateTime startdatum = (DateTime)DP_eintrittsdatum.SelectedDate;
                //var sqlFormattedDate = $"{startdatum.Year}-{startdatum.Month}-{startdatum.Day}";

                //DateTime startdatum1 = (DateTime)DP_geburtsdatum.SelectedDate;
                //var Gebdatum = $"{startdatum1.Year}-{startdatum1.Month}-{startdatum1.Day}";

                MySqlCommand mitarbeiter = new MySqlCommand($" select * from t_mitarbeiter ", con);


                var reader = mitarbeiter.ExecuteReader();


                while (reader.Read())

                {
                    TB_maID.Text = reader[0].ToString();
                    TB_Vorname.Text = reader[1].ToString();
                    TB_NName.Text = reader[2].ToString();
                    DP_geburtsdatum.SelectedDate = reader.GetDateTime(reader.GetOrdinal("Geburtsdatum"));
                    string position = reader[4].ToString();
                    Enum.TryParse<Position>(position, out Position p);
                    CB_stellung.SelectedItem = p;
                    string abteilung = reader[5].ToString();
                    Enum.TryParse<Abteilung>(abteilung, out Abteilung a);
                    CB_abteilung.SelectedItem = a;
                    DP_eintrittsdatum.SelectedDate = reader.GetDateTime(reader.GetOrdinal("Eintrittsdatum"));
                    TB_Gehalt.Text = reader[7].ToString();
                }


                this.Title = "Mitarbeiterdaten ändern";
                BT_OK.Content = "Daten ändern";
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



                //neu

                //Mitarbeiterliste.Add(new Mitarbeiter(TB_Vorname.Text, TB_NName.Text, (DateTime)DP_geburtsdatum.SelectedDate, (Position)CB_stellung.SelectedItem, (Abteilung)CB_abteilung.SelectedItem, (DateTime)DP_eintrittsdatum.SelectedDate, Convert.ToDecimal(TB_Gehalt.Text), new Bankverbindung(Convert.ToInt32(TB_Kontonummer.Text), Convert.ToInt32(TB_BLZ.Text), TB_Bankname.Text), new KontaktDaten(new Adresse(TB_Strasse.Text, TB_HSN.Text, TB_PLZ.Text, TB_Ort.Text), TB_Email.Text, TB_Telefon.Text)));

                MySqlConnection con = new MySqlConnection("Server=localhost;Database=Team1;Uid=root;;Convert Zero Datetime=True;");
                con.Open();
                //foreach (var item in Mitarbeiterliste)
                //{
                MySqlCommand adresse = new MySqlCommand($"insert into t_adresse values(null, '{ TB_Strasse.Text }' , '{ TB_HSN.Text}',' " + TB_PLZ.Text + "', ' " + TB_Ort.Text + "')", con);
                //MySqlCommand adresse = new MySqlCommand($"insert into t_adresse values(null, '{ item.Kontaktdaten.Adress.Strasse }' , '{ item.Kontaktdaten.Adress.Hausnummer}',' " + item.Kontaktdaten.Adress.PLZ + "', ' " + item.Kontaktdaten.Adress.Ort + "')", con);

                adresse.ExecuteNonQuery();

                MySqlCommand bankverbindung = new MySqlCommand($"insert into t_bankverbindung values(null,'{TB_Kontonummer.Text}' , '{ TB_BLZ.Text }' , '{TB_Bankname.Text}'  )", con);
                //MySqlCommand bankverbindung = new MySqlCommand($"insert into t_bankverbindung values('{item.Bankverbindung.Kontonummer}' , '{ item.Bankverbindung.BLZ }' , '{item.Bankverbindung.Bankname}'  )", con);

                bankverbindung.ExecuteNonQuery();

                MySqlCommand mitarbeiter = new MySqlCommand($"insert into t_mitarbeiter values(null,'{TB_Vorname.Text}' ,'{TB_NName.Text}' , '{Gebdatum}', ' { (Position)CB_stellung.SelectedItem }', ' { (Abteilung)CB_abteilung.SelectedItem }',  '{sqlFormattedDate}' , ' {Convert.ToDecimal(TB_Gehalt.Text) }','{TB_Kontonummer.Text}',null  )", con);
                //MySqlCommand mitarbeiter = new MySqlCommand($"insert into t_mitarbeiter values(null,'{item.Vorname}' ,'{item.Nachname}' , '{item.GebDatum}', ' { item.Position }', ' { item.Abteilung }',  '{item.Eintrintsdatum}' , ' {item.Gehalt }', null,null  )", con);

                mitarbeiter.ExecuteNonQuery();

                MySqlCommand kontaktdaten = new MySqlCommand($"insert into t_kontaktdaten values(null, null,'{TB_Telefon.Text}' , '{TB_Email.Text }'  )", con);
                //MySqlCommand kontaktdaten = new MySqlCommand($"insert into t_kontaktdaten values(null, null,'{item.Kontaktdaten.Telefon}' , '{item.Kontaktdaten.Email }'  )", con);

                kontaktdaten.ExecuteNonQuery();
            }

           else
            {
                //ändern

                //MySqlConnection con = new MySqlConnection("Server=localhost;Database=Team1;Uid=root;");
                //con.Open();

                //DateTime startdatum = (DateTime)DP_eintrittsdatum.SelectedDate;
                //var sqlFormattedDate = $"{startdatum.Year}-{startdatum.Month}-{startdatum.Day}";

                //DateTime startdatum1 = (DateTime)DP_geburtsdatum.SelectedDate;
                //var Gebdatum = $"{startdatum1.Year}-{startdatum1.Month}-{startdatum1.Day}";

                //MySqlCommand mitarbeiter = new MySqlCommand($" update  t_mitarbeiter set mitarbeiterid where id =   '{TB_Vorname.Text}' ,'{TB_NName.Text}' , '{Gebdatum}', ' { (Position)CB_stellung.SelectedItem }', ' { (Abteilung)CB_abteilung.SelectedItem }',  '{sqlFormattedDate}' , ' {Convert.ToDecimal(TB_Gehalt.Text) }', null,null  )", con);

                //mitarbeiter.ExecuteNonQuery();



                MySqlConnection conect = new MySqlConnection("Server=localhost;Database=Team1;Uid=root");
                conect.Open();
                string query = $"update t_mitarbeiter set Vorname='{TB_Vorname.Text}' where  MitarbeiterID= '{TB_maID.Text}' ";
                MySqlCommand comman = new MySqlCommand(query, conect);
                comman.ExecuteNonQuery();


                //conect.Close();




            }
            
            this.Close();
        }

        
    }
}
