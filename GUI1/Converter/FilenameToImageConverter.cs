using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace GUI1.Converter
{
    public class FilenameToImageConverter : IValueConverter
    {
        private readonly Assembly assembly = Assembly.GetExecutingAssembly();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string filename = value as string;
            if (filename == null) 
                return null;

            BitmapImage image = new BitmapImage();
            using Stream resourceStream = this.assembly.GetManifestResourceStream(this.assembly.GetName().Name + ".Images.Map." + filename + ".png");

            if (resourceStream != null)
            {
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = resourceStream;
                image.EndInit();
            }

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
