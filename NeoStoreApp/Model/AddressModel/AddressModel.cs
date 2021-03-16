using System;
using SQLite;
namespace NeoStoreApp.Model.AddressModel
{
    public class AddressModel
    {
        

        
     
            [PrimaryKey, AutoIncrement]
            public int ID { get; set; }
            public string Address { get; set; }
           
        }
    
}
