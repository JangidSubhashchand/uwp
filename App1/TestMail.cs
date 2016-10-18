using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Email;
using Windows.Storage;

namespace App1
{
    public class TestMail
    {

        private async void SendEmailButton_Click(object sender, RoutedEventArgs e)
        {
            ZipFile.CreateFromDirectory(folder.Path, $"{folder.Path}\\{Guid.NewGuid()}.zip",
                    CompressionLevel.NoCompression, true);
        }
    }
}
