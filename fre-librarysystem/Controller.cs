using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fre_librarysystem
{
    class ControllerLogin
    {
        public void loginUser ()
        {
            try
            {
                string dbHost = "LOCALHOST";
                string databaseName = "Librarysystem";

                // Connection string
                DataContext dbLibrarysystem = new DataContext("Server=" + dbHost + "\\SQLEXPRESS;Database=" + databaseName + ";Connection timeout=30;Integrated Security=True");

                ModelCustomer Customer = new ModelCustomer();
                Table<ModelCustomer.tblCustomer> my_inhalt = dbLibrarysystem.GetTable<ModelCustomer.tblCustomer>();

                //Auswerten der typisierten Liste
                var eintraege =
                                from my_i in my_inhalt
                                select my_i;
                
                /*
                string result = "";

                //Ausgabe
                foreach (var i in eintraege)
                {
                    result += i.Befund;
                }

                return result;*/
            }

            catch (Exception ex)
            {
                //Schief gelaufen
                //MessageBox.Show(ex.Message);

                //return ex.Message;
            }
        }   
    }
}
