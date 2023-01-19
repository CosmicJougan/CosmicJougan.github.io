using MySql.Data.MySqlClient;
using NuGet.Packaging.Signing;
using System.Security.Cryptography.X509Certificates;
using VoorbeeldCRUD.Models;

namespace VoorbeeldCRUD.Persistence
{
    public class PersistenceCode
    {
        string ConnStr = "server=localhost;user id=root; password=Test123; database=dbklanten";

        public List<klant> loadKlanten()
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "select * from tblklanten";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            List<klant> lijst = new List<klant>();
            while (dtr.Read()){
                klant Klant = new klant();
                Klant.Id = Convert.ToInt32(dtr["ID"]);
                Klant.Naam = Convert.ToString(dtr["NAAM"]);
                Klant.Saldo = Convert.ToDouble(dtr["SALDO"]);
                lijst.Add(Klant);
            }
            conn.Close();
            return lijst;
        }
        public void insertKlant(klant Klant)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string corrSaldo = Klant.Saldo.ToString().Replace(",", ".");
            string qry = "insert into tblklanten (naam, saldo) values ('"+Klant.Naam+"',"+corrSaldo+")";
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
        public void deleteKlant(int ID)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "delete from tblklanten where id="+ID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public klant loadKlant(int KlantID)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string qry = "select * from tblklanten where id=" + KlantID;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            MySqlDataReader dtr = cmd.ExecuteReader();
            klant Klant = new klant();
            while (dtr.Read())
            {
                
                Klant.Id = Convert.ToInt32(dtr["ID"]);
                Klant.Naam = Convert.ToString(dtr["NAAM"]);
                Klant.Saldo = Convert.ToDouble(dtr["SALDO"]);
            }
            conn.Close();
            return Klant;
        }
        public void UpdateKlant(klant Klant)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            conn.Open();
            string corrSaldo = Klant.Saldo.ToString().Replace(",", ".");
            string qry = "update tblklanten set naam='"+Klant.Naam+"', saldo="+corrSaldo + " where id="+Klant.Id;
            MySqlCommand cmd = new MySqlCommand(qry, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}
