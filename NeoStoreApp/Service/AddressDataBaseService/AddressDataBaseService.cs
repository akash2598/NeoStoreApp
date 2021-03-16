using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using NeoStoreApp.Model.AddressModel;
using SQLite;


namespace NeoStoreApp.Service.AddressDataBaseService
{
    public class AddressDataBaseService
    {
        SQLiteAsyncConnection _database;
        public AddressDataBaseService()
        {
            //generating database path and connection object
             _database=new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Adressdb.db3"));
            _database.CreateTableAsync<AddressModel>().Wait();

        }

        //method to show data.
        public Task<List<AddressModel>> GetDataAsync()
        {
            return _database.Table<AddressModel>().ToListAsync();
        }
        //method to stre data in db
        public Task<int> SaveAddressAsync(AddressModel address)
        {
            return _database.InsertAsync(address);
        }
        //method to delete data from db
        public Task<int> DeleteNoteAsync(AddressModel address)
        {
            return _database.DeleteAsync(address);
        }
    }
}
