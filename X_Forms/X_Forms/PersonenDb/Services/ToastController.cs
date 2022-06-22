using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.PersonenDb.Services
{
    internal static class ToastController
    {
        //Globaler Zugriff auf ToastService erfolgt hier über statische Klasse
        public static void ShowToast(string message, bool isLong = true)
        {
            switch (isLong)
            {
                case true:
                    toastService.ShowLongToast(message);
                    break;
                case false:
                    toastService.ShowShortToast(message);
                    break;
            }
        }

        //Zugriff auf DI-System zur Instanzierung des plattformspezifischen Objekt (vgl. AndroidToastService)
        private static IToastService toastService { get; set; } = DependencyService.Get<IToastService>();
    }
}
