using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace DigitalFishing
{
    public class bdd
    {
        private static MySqlConnection connection;
        private static string server;
        private static string database;
        private static string uid;
        private static string password;



        //Initialisation des valeurs
        public static void Initialize()
        {
            server = "localhost";
            database = "digital_phishing";
            uid = "root";
            password = "root";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private static bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                Console.WriteLine("Erreur connexion BDD");
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private static bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }


        public static void InsertMagazine(string dateB, string dateP, string datePt, double budget)
        {
            //Requête Insertion Magazine
            string query = "INSERT INTO magazine (DateBouclageMagazine, DateSortieMagazine, DatePaiementMagazine, BudgetMagazine) VALUES('" + dateB + "','" + dateP + "','" + datePt + "'," + budget + ")";
            Console.WriteLine(query);

            //open connection
            if (bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                bdd.CloseConnection();
            }
        }
        public static void InsertPigiste(string nomP, string prenomP, string adresseP, string CPP, string villeP, string mailP, string numSecuP, string ccP)
        {
            //Requête Insertion Pigisite
            string query = "INSERT INTO pigistes (NomPigiste, PrenomPigiste, AdressePigiste, CPPigiste, VillePigiste, MailPigiste, NumSecuPigiste, ContratCadrePigiste) VALUES('" + nomP + "','" + prenomP + "','" + adresseP + "'," + CPP + ",'" + villeP + "','" + mailP + "'," + numSecuP + ",'" + ccP + "')";
            Console.WriteLine(query);

            //open connection
            if (bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                bdd.CloseConnection();
            }
        }
        public static void InsertContrat(string la, double mttB, double mttN, int etat, bool fact, bool agessa, string c_datePaiement, Pigiste lePigiste, Magazine leMagazine)
        {
            //Requête Insertion Contrat
            string query = "INSERT INTO contrat (LettreAccordCollaboration, EtatCollaboration, AgessaCollaboration, FactureCollaboration, MontantCollaboration, MontantNCollaboration, DatePaiementCollaboration, NumPigiste, NumMagazine) VALUES('" + la + "'," + etat + "," + agessa + "," + fact + "," + mttB + "," + mttN + ",'" + c_datePaiement + "','" + lePigiste.Num + "'," + leMagazine + ")";
            Console.WriteLine(query);

            //open connection
            if (bdd.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                bdd.CloseConnection();
            }
        }


        public static void UpdateMagazine(int numM, string dateB, string dateP, string datePt, double budget)
        {
            //Update Magazine
            string query = "UPDATE magazine SET DateBouclageMagazine='" + dateB + "', DateSortieMagazine='" + dateP + "', DatePaiementMagazine='" + datePt + "', BudgetMagazine = " + budget + " WHERE NumMagazine=" + numM;
            Console.WriteLine(query);
            //Open connection
            if (bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                bdd.CloseConnection();
            }
        }
        public static void UpdatePigiste(int numP, string nomP, string prenomP, string adresseP, string CPP, string villeP, string mailP, string numSecuP, string ccP)
        {
            //Update Magazine
            string query = "UPDATE pigistes SET NomPigiste='" + nomP + "', PrenomPigiste='" + prenomP + "', AdressePigiste = '" + adresseP + "', CPPigiste = '" + CPP + "', VillePigiste = '" + villeP + "', MailPigiste = '" + mailP + "',NumSecuPigiste = " + numSecuP + ", ContratCadrePigiste = '" + ccP + "' WHERE NumPigiste=" + numP ;
            Console.WriteLine(query);
            //Open connection
            if (bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                bdd.CloseConnection();
            }
        }
        public static void UpdateContrat(int numC, string la, double mttB, double mttNet, int etat, bool fact, bool agessa, int NumPigiste, int NumMagazine)
        {
            //Update Magazine
            string query = "UPDATE contrat SET LettreAccordCollaboration='" + la + "', MontantCollaboration='" + mttB + "', MontantNCollaboration='" + mttNet + "', EtatCollaboration = " + etat + "', FactureCollaboration='" + fact + "', AgessaCollaboration='" + agessa + "', NumPigiste='" + NumPigiste + "', NumMagazine='" + NumMagazine + " WHERE NumCollaboration=" + numC;
            Console.WriteLine(query);
            //Open connection
            if (bdd.OpenConnection() == true)
            {
                //create mysql command
                MySqlCommand cmd = new MySqlCommand();
                //Assign the query using CommandText
                cmd.CommandText = query;
                //Assign the connection using Connection
                cmd.Connection = connection;

                //Execute query
                cmd.ExecuteNonQuery();

                //close connection
                bdd.CloseConnection();
            }
        }


        public static void DeleteMagazine(int numM)
        {
            //Delete Magazine
            string query = "DELETE FROM magazine WHERE NumMagazine=" + numM;

            if (bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                bdd.CloseConnection();
            }
        }
        public static void DeletePigiste(int numP)
        {
            //Delete Pigiste
            string query = "DELETE FROM pigistes WHERE NumPigiste=" + numP;

            if (bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                bdd.CloseConnection();
            }
        }
        public static void DeleteContrat(int numC)
        {
            //Delete Contrat
            string query = "DELETE FROM contrat WHERE NumCollaboration=" + numC;

            if (bdd.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                bdd.CloseConnection();
            }
        }


        public static List<Magazine> SelectMagazine()
        {
            //Select statement
            string query = "SELECT * FROM magazine";

            //Create a list to store the result
            List<Magazine> dbMagazine = new List<Magazine>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Magazine leMagazine = new Magazine(Convert.ToInt32(dataReader["NumMagazine"]), Convert.ToString(dataReader["DateBouclageMagazine"]), Convert.ToString(dataReader["DateSortieMagazine"]), Convert.ToString(dataReader["DatePaiementMagazine"]), Convert.ToInt32(dataReader["BudgetMagazine"]));
                    dbMagazine.Add(leMagazine);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbMagazine;
            }
            else
            {
                return dbMagazine;
            }
        }

        public static List<Pigiste> SelectPigiste()
        {
            //Select statement
            string query = "SELECT * FROM pigistes";

            //Create a list to store the result
            List<Pigiste> dbPigiste = new List<Pigiste>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                    Pigiste lePigiste = new Pigiste(Convert.ToInt16(dataReader["NumPigiste"]), Convert.ToString(dataReader["NomPigiste"]), Convert.ToString(dataReader["PrenomPigiste"]), Convert.ToString(dataReader["AdressePigiste"]), Convert.ToString(dataReader["CPPigiste"]), Convert.ToString(dataReader["VillePigiste"]), Convert.ToString(dataReader["MailPigiste"]), Convert.ToString(dataReader["NumSecuPigiste"]), Convert.ToString(dataReader["ContratCadrePigiste"]));
                    dbPigiste.Add(lePigiste);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbPigiste;
            }
            else
            {
                return dbPigiste;
            }
        }

        public static List<Contrat> SelectContrat()
        {
            //Select statement
            string query = "SELECT * FROM contrat";

            //Create a list to store the result
            List<Contrat> dbContrat = new List<Contrat>();

            //Ouverture connection
            if (bdd.OpenConnection() == true)
            {
                //Creation Command MySQL
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Création d'un DataReader et execution de la commande
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Lecture des données et stockage dans la collection
                while (dataReader.Read())
                {
                   Contrat leContrat = new Contrat(Convert.ToInt16(dataReader["NumCollaboration"]), Convert.ToString(dataReader["LettreAccordCollaboration"]), Convert.ToInt16(dataReader["MontantCollaboration"]), Convert.ToInt16(dataReader["MontantNCollaboration"]), Convert.ToBoolean(dataReader["AgessaCollaboration"]), Convert.ToBoolean(dataReader["FactureCollaboration"]), Convert.ToInt16(dataReader["EtatCollaboration"]), Convert.ToString(dataReader["DatePaiementCollaboration"]), SearchPigiste(Convert.ToInt32(dataReader["NumPigiste"])), SearchMagazine(Convert.ToInt32(dataReader["NumMagazine"])) );
                   dbContrat.Add(leContrat);
                }

                //fermeture du Data Reader
                dataReader.Close();

                //fermeture Connection
                bdd.CloseConnection();

                //retour de la collection pour être affichée
                return dbContrat;
            }
            else
            {
                return dbContrat;
            }
        }

        public static Pigiste SearchPigiste(int numP)
        {
            //Select statement
            string query = "SELECT * FROM pigistes WHERE NumPigiste = " + numP;

            //Create a list to store the result
            List<Pigiste> dbPigiste = new List<Pigiste>();


            //Creation Command MySQL
            MySqlCommand cmdS = new MySqlCommand(query, connection);
            //Création d'un DataReader et execution de la commande
            MySqlDataReader dataReaderS = cmdS.ExecuteReader();

            //Lecture des données et stockage dans la collection
            while (dataReaderS.Read())
            {
                Pigiste lePigiste = new Pigiste(Convert.ToInt32(dataReaderS["NumPigiste"]), Convert.ToString(dataReaderS["NomPigiste"]), Convert.ToString(dataReaderS["PrenomPigiste"]), Convert.ToString(dataReaderS["AdressePigiste"]), Convert.ToString(dataReaderS["CPPigiste"]), Convert.ToString(dataReaderS["VillePigiste"]), Convert.ToString(dataReaderS["MailPigiste"]), Convert.ToString(dataReaderS["NumSecuPigiste"]), Convert.ToString(dataReaderS["ContratCadrePigiste"]));
                dbPigiste.Add(lePigiste);
            }

            //fermeture du Data Reader
            dataReaderS.Close();

            //retour de la collection pour être affichée
            return dbPigiste[0];


        }

        public static Magazine SearchMagazine(int numM)
        {
            //Select statement
            string query = "SELECT * FROM magazine WHERE NumMagazine = " + numM;

            //Create a list to store the result
            List<Magazine> dbMagazine = new List<Magazine>();


            //Creation Command MySQL
            MySqlCommand cmdS = new MySqlCommand(query, connection);
            //Création d'un DataReader et execution de la commande
            MySqlDataReader dataReaderS = cmdS.ExecuteReader();

            //Lecture des données et stockage dans la collection
            while (dataReaderS.Read())
            {
                Magazine leMagazine = new Magazine(Convert.ToInt16(dataReaderS["NumMagazine"]), Convert.ToString(dataReaderS["DateBouclageMagazine"]), Convert.ToString(dataReaderS["DateSortieMagazine"]), Convert.ToString(dataReaderS["DatePaiementMagazine"]), Convert.ToInt16(dataReaderS["BudgetMagazine"]));
                dbMagazine.Add(leMagazine);
            }

            //fermeture du Data Reader
            dataReaderS.Close();

            //retour de la collection pour être affichée
            return dbMagazine[0];
        }
    }
}


