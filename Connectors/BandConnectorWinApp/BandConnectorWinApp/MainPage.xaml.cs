using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BandConnectorWinApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool recording;
        GSR band;
        public MainPage()
        {
            this.InitializeComponent();

            this.btnStart.Click += BtnStart_Click;
            this.btnStop.Click += BtnStop_Click;
        }

        private async void BtnStop_Click(object sender, RoutedEventArgs e)
        {
            recording = false;
            if (band != null && band.Events.Count > 0)
            {
                Debug.WriteLine("Logging File");
                StringBuilder csv = new StringBuilder();
                foreach (var evt in band.Events)
                {
                    // C# 6.0 feature.
                    csv.AppendLine($"{evt.UnixTimeSecondsDotMilliseconds},{evt.GSR}");
                }
                // Because this is an universal app, we have some constraints on how we can access the file system.
                // http://stackoverflow.com/questions/33082835/windows-10-universal-app-file-directory-access
                FolderPicker picker = new FolderPicker();
                picker.FileTypeFilter.Add(".csv");
                StorageFolder folder = await picker.PickSingleFolderAsync();
                
                StorageFile file = await folder.CreateFileAsync("EDA_" + DateTime.Now.ToFileTime() + ".csv");
                await WriteAllTextAsync(file, csv.ToString());
            }
        }

        private void BtnStart_Click(object sender, RoutedEventArgs e)
        {
            if (recording)
                return;
            recording = true;
            // GSR
            if (band == null)
            {
                band = new GSR();
                band.GetBand();
            }
            // clear old events
            band.Events.Clear();
        }

        async public Task WriteAllTextAsync(StorageFile storageFile, string content)
        {
            var inputStream = await storageFile.OpenAsync(FileAccessMode.ReadWrite);
            var writeStream = inputStream.GetOutputStreamAt(0);
            DataWriter writer = new DataWriter(writeStream);
            writer.WriteString(content);
            await writer.StoreAsync();
            await writeStream.FlushAsync();
        }
    }
}
