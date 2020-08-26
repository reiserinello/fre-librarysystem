using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fre_librarysystem
{
    public class ModelMapping
    {

        // Mappingclass User
        [Table(Name = "User")]
        public class tblUser
        {
            //Mapper on primary key
            [Column(Name = "PKey", IsDbGenerated = true, IsPrimaryKey = true)]
            public int PKey_1
            {
                get;
                set;
            }

            //Mapper on field names (table properties)
            [Column]
            public string Username;
            [Column]
            public string Password;
            [Column]
            public string Surname;
            [Column]
            public string Last_name;
            [Column]
            public string Adress;
            [Column]
            public int ZIP;
            [Column]
            public string City;
            [Column]
            public bool Write;
            [Column]
            public bool Write_rent;
        }

        // Mappingclass Book
        [Table(Name = "Book")]
        public class tblBook
        {
            //Mapper on primary key
            [Column(Name = "PKey", IsDbGenerated = true, IsPrimaryKey = true)]
            public int PKey_1
            {
                get;
                set;
            }

            //Mapper on field names (table properties)
            [Column]
            public string Name;
            [Column]
            public string ISBN;
            [Column]
            public string Author;
            [Column]
            public string Publisher;
        }

        // Mappingclass Reservation
        [Table(Name = "Reservation")]
        public class tblReservation
        {
            //Mapper on primary key
            [Column(Name = "PKey", IsDbGenerated = true, IsPrimaryKey = true)]
            public int PKey_1
            {
                get;
                set;
            }

            //Mapper on field names (table properties)
            [Column]
            public DateTime Reservation_date;
            [Column]
            public bool Done;
            [Column]
            public int FKey_Book;
            [Column]
            public int FKey_User;
        }
    }

    class ModelObjUser
    {
        public int pkey { get; }
        public string username { get; }
        public string password { get; }
        public string surname { get; }
        public string last_name { get; }
        public string adress { get; }
        public int zip { get; }
        public string city { get; }
        public bool write { get; }
        public bool write_rent { get; }

        public ModelObjUser(int t_pkey, string t_username, string t_password, string t_surname, string t_last_name, string t_adress, int t_zip, string t_city, bool t_write, bool t_write_rent)
        {
            pkey = t_pkey;
            username = t_username;
            password = t_password;
            surname = t_surname;
            last_name = t_last_name;
            adress = t_adress;
            zip = t_zip;
            city = t_city;
            write = t_write;
            write_rent = t_write_rent;
        }
    }

    class ModelObjBook
    {
        public int pkey { get; }
        public string name { get; }
        public string isbn { get; }
        public string author { get; }
        public string publisher { get; }

        public ModelObjBook(int t_pkey, string t_name, string t_isbn, string t_author, string t_publisher)
        {
            pkey = t_pkey;
            name = t_name;
            isbn = t_isbn;
            author = t_author;
            publisher = t_publisher;
        }
    }

    class ModelObjReservation
    {
        public DateTime reservation_date { get; }
        public bool done { get; }
        public int fkey_book { get; }
        public int fkey_user { get; }

        public ModelObjReservation(DateTime t_reservation_date, bool t_done, int t_fkey_book, int t_fkey_user)
        {
            reservation_date = t_reservation_date;
            done = t_done;
            fkey_book = t_fkey_book;
            fkey_user = t_fkey_user;
        }
    }
}
