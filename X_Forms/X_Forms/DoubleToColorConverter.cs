using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace X_Forms
{
    //ValueConverter werden verwendet um es XAML-Bindings zu ermöglichen Werte unterschiedlicher Typen zu verknüpfen oder die Werte vor der
    //Übertragung zu manipulieren. Converter werden in den Resourcen definiert und in der Binding-Expression mit angegeben.
    //Converter müssen das IValueConverter-Interface implementieren.
    internal class DoubleToColorConverter : IValueConverter
    {
        //(vgl. MainPage.xaml / Bereich: Bindings)

        //Source -> Target
        //Parameter: value = Wert aus der Quelle, targetType = Typ der Zielproperty, parameter = ConverterParameter-Property der Quelle)
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //Erstellung eines Color-Objekts (für die angebundene BackgroundColor-Eigenschaft) aus dem angebundenen
            //Double-Wert (value) und einem String-Wert (parameter)
            return Color.FromRgb((byte)(double)value, System.Convert.ToByte(parameter), 0);
        }

        //Target->Source (in diesem Bsp nicht nötig, da One-Way-Bindung)
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
