﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.NavigationBsp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShellBsp : Shell
    {
        public AppShellBsp()
        {
            InitializeComponent();
        }
    }
}