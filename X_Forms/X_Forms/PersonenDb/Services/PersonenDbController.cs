using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.PersonenDb.Services
{
    public class PersonenDbController
    {
        SQLiteConnection database;

        static object locker = new object();

        public PersonenDbController()
        {
            IDatabaseService dbService = DependencyService.Get<IDatabaseService>();

            database = dbService.GetConnection();

            database.CreateTable<Model.Person>();
        }

        public List<Model.Person> GetPeople()
        {
            lock (locker)
            {
                return database.Table<Model.Person>().ToList();
            }
        }

        public void AddPerson(Model.Person person)
        {
            lock (locker)
            {
                database.Insert(person);
            }
        }

        public void DeletePerson(Model.Person person)
        {
            lock (locker)
            {
                database.Delete(person);
            }
        }
    }
}
