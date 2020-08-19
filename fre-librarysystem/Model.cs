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

        // Mappingclass Customer
        [Table(Name = "Customer")]
        public class tblCustomer
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
            public string Address;
            [Column]
            public int ZIP;
            [Column]
            public string City;
        }
    }

    class ModelObjCustomer
    {
        public string username { get; }
        public string password { get; }
        public string surname { get; }
        public string last_name { get; }
        public string adress { get; }
        public int zip { get; }
        public string city { get; }

        public ModelObjCustomer(string t_username, string t_password, string t_surname, string t_last_name, string t_adress, int t_zip, string t_city)
        {
            username = t_username;
            password = t_password;
            surname = t_surname;
            last_name = t_last_name;
            adress = t_adress;
            zip = t_zip;
            city = t_city;
        }
    }
}
