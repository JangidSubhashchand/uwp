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
            FolderPicker folderPicker = new FolderPicker();
            folderPicker.SuggestedStartLocation = PickerLocationId.Desktop;
            folderPicker.FileTypeFilter.Add(".dll");
            folderPicker.FileTypeFilter.Add(".json");
            folderPicker.FileTypeFilter.Add(".xml");
            folderPicker.FileTypeFilter.Add(".pdb");
            StorageFolder folder = await folderPicker.PickSingleFolderAsync();
            if (folder != null)
            {
                // Application now has read/write access to all contents in the picked folder (including other sub-folder contents)
                StorageApplicationPermissions.FutureAccessList.AddOrReplace("PickedFolderToken", folder);
                OutputTextBlock.Text = $"Picked folder: {folder.Name}";

                var files = await folder.GetFilesAsync();
                foreach (var file in files)
                {
                    OutputTextBlock.Text += $"\n {file.Name}";
                }

                await Task.Run(() =>
                {
                    try
                    {
                        ZipFile.CreateFromDirectory(folder.Path, $"{folder.Path}\\{Guid.NewGuid()}.zip",
                            CompressionLevel.NoCompression, true);
                        Debug.WriteLine("folder zipped");
                    }
                    catch (Exception w)
                    {
                        Debug.WriteLine(w);
                    }
                });
            }
            else
            {
                OutputTextBlock.Text = "Operation cancelled.";
            }
        }
    }
}
