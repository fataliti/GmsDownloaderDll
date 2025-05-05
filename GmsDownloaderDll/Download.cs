using System;
using System.ComponentModel;
using System.Net;


namespace GmsDownloaderDll
{
    internal class Download : IDisposable
    {
        private static double _id;

        private WebClient _wc;
        public int Progress;
        public  double Id;
        public string Name;
        public double Complete;

        public Download()
        {
            Id = _id++;
            _wc = new WebClient();
            _wc.DownloadProgressChanged += ProgressChanged;
            _wc.DownloadFileCompleted += Completed;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            Console.WriteLine("Download create with Id: " + Id);
        }

        public void DownloadStart(string link, string fileName)
        {
            Name = fileName;
            _wc.DownloadFileAsync(new Uri(link), fileName);
            Console.WriteLine("Download start with Id: " + Id);
        }

        public void AddHeader(string name, string value)
        {
            _wc.Headers.Add(name, value);
        }

        private void ProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            Progress = e.ProgressPercentage;
        }

        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Complete = -1.0;
                Console.WriteLine("Download failed: " + Id);
            }
            else
            {
                Complete = 1.0;
                Console.WriteLine("Download completed: " + Id);
            }
        }

        public void CancelDownload()
        {
            _wc.CancelAsync();
        }


        public void Dispose()
        {
            _wc.Dispose();
        }
    }
}
