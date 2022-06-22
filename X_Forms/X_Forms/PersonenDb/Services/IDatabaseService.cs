using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.PersonenDb.Services
{
    public interface IDatabaseService
    {
        SQLiteConnection GetConnection();
    }
}
