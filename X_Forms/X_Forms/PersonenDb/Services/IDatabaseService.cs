using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.PersonenDb.Services
{
    //Interface zur Definition der plattformspezifischen Klassen
    //Implementierung in X_Forms.Android/Services/AndroidDatabaseService.cs
    public interface IDatabaseService
    {
        SQLiteConnection GetConnection();
    }
}
