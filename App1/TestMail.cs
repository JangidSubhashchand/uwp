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
            EmailMessage emailMessage = new EmailMessage();
            emailMessage.To.Add(new EmailRecipient("m.mskaira@gmail.com"));
            string messageBody = "Hello World";
            emailMessage.Body = messageBody;
            StorageFolder MyFolder = Windows.ApplicationModel.Package.Current.InstalledLocation;
            StorageFile attachmentFile = await MyFolder.GetFoldersAsync("File");
            if (attachmentFile != null)
            {
                var stream = Windows.Storage.Streams.RandomAccessStreamReference.CreateFromFile(attachmentFile);
                var attachment = new Windows.ApplicationModel.Email.EmailAttachment(
                         attachmentFile.Name,
                         stream);
                emailMessage.Attachments.Add(attachment);
            }
            await EmailManager.ShowComposeNewEmailAsync(emailMessage);
        }
    }
}
