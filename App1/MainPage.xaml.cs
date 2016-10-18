using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btn_zip_click(object sender, RoutedEventArgs e)
        {
           
        }

        private void  btn_unzip_click(object sender, RoutedEventArgs e)
        {
            UnzipFile();
        }

        private void btn_send_mail(object sender, RoutedEventArgs e)
        {

        }
        private async Task UnzipFile()
        {
            try {
                var localFolder = ApplicationData.Current.LocalFolder;
                var file = await localFolder.GetFileAsync("project.json");
                await file.DeleteAsync();
                var archive = await localFolder.GetFileAsync("test.zip");
                ZipFile.ExtractToDirectory(archive.Path, localFolder.Path);
            }
            catch( Exception g)
            {

            }
          

        }

    }
}
