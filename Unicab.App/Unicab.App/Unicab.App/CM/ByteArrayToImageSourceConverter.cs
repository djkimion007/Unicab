using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Unicab.App.CM
{
    public class ByteArrayToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
          System.Globalization.CultureInfo culture)
        {
            ImageSource imgsrc = null;
            try
            {
                if (value == null)
                    return null;
                byte[] bArray = (byte[])value;

                imgsrc = ImageSource.FromStream(() =>
                {
                    var ms = new MemoryStream(bArray)
                    {
                        Position = 0
                    };
                    return ms;
                });
            }
            catch (System.Exception sysExc)
            {
                System.Diagnostics.Debug.WriteLine(sysExc.Message);
            }
            return imgsrc;
        }

        public object ConvertBack(object value, Type targetType, object parameter,
          System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
