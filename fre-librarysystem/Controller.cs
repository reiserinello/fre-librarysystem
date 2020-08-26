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
        public List<ModelObjUser> getUser (string t_username)
        {
            // Try / Catch ??

            string dbHost = "LOCALHOST";
            string databaseName = "Librarysystem";

            // Connection string
            DataContext dbLibrarysystem = new DataContext("Server=" + dbHost + "\\SQLEXPRESS;Database=" + databaseName + ";Connection timeout=30;Integrated Security=True");

            Table<ModelMapping.tblUser> tblUserGet = dbLibrarysystem.GetTable<ModelMapping.tblUser>();

            var returnList = new List<ModelObjUser>();

            //Auswerten der typisierten Liste
            var tblUserValues =
                            from my_val in tblUserGet
                            where my_val.Username == t_username
                            select my_val;

            foreach (var value in tblUserValues)
            {
                var user = new ModelObjUser(value.PKey_1,value.Username,value.Password,value.Surname,value.Last_name,value.Adress,value.ZIP,value.City,value.Write,value.Write_rent);
                returnList.Add(user);
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
            var returnListFinal = new List<ModelObjBook>();

            //Auswerten der typisierten Liste
            var tblBookValues =
                        from my_val in tblBookGet
                        select my_val;
            
            foreach (var value in tblBookValues)
            {
                var book = new ModelObjBook(value.PKey_1,value.Name, value.ISBN, value.Author, value.Publisher);
                returnList.Add(book);
            }

            if (t_name != "All")
            {
                foreach (var value in returnList)
                {
                    if (value.name == t_name || value.isbn == t_name || value.author == t_name || value.publisher == t_name)
                    {
                        var book = new ModelObjBook(value.pkey,value.name, value.isbn, value.author, value.publisher);
                        returnListFinal.Add(book);
                    }
                }

                return returnListFinal;
            } else
            {
                return returnList;
            }
        }

        public void setReservation(int t_pkey_book, int t_pkey_user)
        {
            string dbHost = "LOCALHOST";
            string databaseName = "Librarysystem";

            // Connection string
            DataContext dbLibrarysystem = new DataContext("Server=" + dbHost + "\\SQLEXPRESS;Database=" + databaseName + ";Connection timeout=30;Integrated Security=True");

            Table<ModelMapping.tblReservation> tblReservationGet = dbLibrarysystem.GetTable<ModelMapping.tblReservation>();

            ModelMapping.tblReservation newEntry = new ModelMapping.tblReservation();

            newEntry.Reservation_date = DateTime.Now;
            newEntry.Done = false;
            newEntry.FKey_Book = t_pkey_book;
            newEntry.FKey_User = t_pkey_user;

            tblReservationGet.InsertOnSubmit(newEntry);

            dbLibrarysystem.SubmitChanges();
        }

        public bool bookAvaiable(int t_pkey)
        {
            string dbHost = "LOCALHOST";
            string databaseName = "Librarysystem";

            // Connection string
            DataContext dbLibrarysystem = new DataContext("Server=" + dbHost + "\\SQLEXPRESS;Database=" + databaseName + ";Connection timeout=30;Integrated Security=True");

            Table<ModelMapping.tblReservation> tblReservationGet = dbLibrarysystem.GetTable<ModelMapping.tblReservation>();

            var resultList = new List<ModelObjReservation>();

            //Auswerten der typisierten Liste
            var tblReservationValues =
                        from my_val in tblReservationGet
                        where my_val.FKey_Book == t_pkey && my_val.Done == false
                        select my_val;

            foreach (var value in tblReservationValues)
            {
                var reservation = new ModelObjReservation(value.Reservation_date, value.Done, value.FKey_Book, value.FKey_User);
                resultList.Add(reservation);
            }

            if (resultList.Count == 0)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
