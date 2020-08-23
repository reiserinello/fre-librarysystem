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
        public List<ModelObjCustomer> loginUser (string t_username)
        {
            // Try / Catch ??

            string dbHost = "LOCALHOST";
            string databaseName = "Librarysystem";

            // Connection string
            DataContext dbLibrarysystem = new DataContext("Server=" + dbHost + "\\SQLEXPRESS;Database=" + databaseName + ";Connection timeout=30;Integrated Security=True");

            Table<ModelMapping.tblCustomer> tblCustomerGet = dbLibrarysystem.GetTable<ModelMapping.tblCustomer>();

            var returnList = new List<ModelObjCustomer>();

            //Auswerten der typisierten Liste
            var tblCustomerValues =
                            from my_val in tblCustomerGet
                            where my_val.Username == t_username
                            select my_val;

            foreach (var value in tblCustomerValues)
            {
                var customer = new ModelObjCustomer(value.Username,value.Password,value.Surname,value.Last_name,value.Address,value.ZIP,value.City,value.Write,value.Write_rent);
                returnList.Add(customer);
            }

            return returnList;
        }
    }

    class ControllerBook
    {

        public List<ModelObjBook> getBooks(string t_name)
        {
            string dbHost = "LOCALHOST";
            string databaseName = "Librarysystem";

            // Connection string
            DataContext dbLibrarysystem = new DataContext("Server=" + dbHost + "\\SQLEXPRESS;Database=" + databaseName + ";Connection timeout=30;Integrated Security=True");

            Table<ModelMapping.tblBook> tblBookGet = dbLibrarysystem.GetTable<ModelMapping.tblBook>();

            var returnList = new List<ModelObjBook>();

            //Auswerten der typisierten Liste
            var tblBookValues =
                        from my_val in tblBookGet
                        select my_val;

            if (t_name != "All")
            {
                tblBookValues =
                        from my_val in tblBookGet
                        where my_val.Name == t_name || my_val.ISBN == t_name || my_val.Author == t_name || my_val.Publisher == t_name
                        select my_val;
            }
            
            foreach (var value in tblBookValues)
            {
                var book = new ModelObjBook(value.Name, value.ISBN, value.Author, value.Publisher);
                returnList.Add(book);
            }

            return returnList;
        }
    }
}
