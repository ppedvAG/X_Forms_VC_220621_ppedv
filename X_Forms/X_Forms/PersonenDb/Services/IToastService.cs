using System;
using System.Collections.Generic;
using System.Text;

namespace X_Forms.PersonenDb.Services
{
    //vgl. IDatabaseService
    //vgl. X_Forms.Android/Services/AndroidToastService.cs
    public interface IToastService
    {
        void ShowLongToast(string msg);

        void ShowShortToast(string msg);
    }
}
