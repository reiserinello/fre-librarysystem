using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fre_librarysystem
{
    public class ModelCustomer
    {

        public ModelCustomer ()
        {

        }

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
}
