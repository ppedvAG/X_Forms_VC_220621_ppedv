using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using X_Forms.Droid.Services;
using X_Forms.PersonenDb.Services;
using Xamarin.Forms;

//vgl. AndroidDatabaseService.cs
[assembly: Dependency(typeof(AndroidToastService))]
namespace X_Forms.Droid.Services
{
    public class AndroidToastService : IToastService
    {
        public void ShowLongToast(string msg)
        {
            Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Long).Show();
        }

        public void ShowShortToast(string msg)
        {
            Toast.MakeText(Android.App.Application.Context, msg, ToastLength.Short).Show();
        }
    }
}