using System;
using System.ComponentModel;
using System.Net;


namespace GmsDownloaderDll
{
    internal class Download
    {
        private static double _id;

        private WebClient _wc;
        public int Progress;
        public  double Id;
        public string Name;
        public double Complete;

        public Download(string link, string fileName)
        {
            Id = _id++;
            Name = fileName;
            _wc = new WebClient();
            _wc.DownloadProgressChanged += ProgressChanged;
            _wc.DownloadFileCompleted += Completed;
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
    }
}
