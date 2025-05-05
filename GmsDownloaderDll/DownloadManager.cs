using System;
using System.Collections.Generic;
using System.IO;

namespace GmsDownloaderDll
{
    public class DownloadManager
    {
        private static Dictionary<double, Download> _downloads = new Dictionary<double, Download>();

        private static string _downDir = "";

        [DllExport("DownloadDirectory")]
        public static string DownloadDirectory(string dir)
        {
            _downDir = dir;
            return dir;
        }


        [DllExport("DownloadFile")]
        public static double DownloadFile(string link, string fileName)
        {
            Download download = new Download(link, _downDir + fileName);
            _downloads.Add(download.Id, download);
            return download.Id;
        }


        [DllExport("DownloadAddHeader")]
        public static double AddHeader(double downloadId, string name, string value)
        {
            if (!_downloads.ContainsKey(downloadId))
            {
                return -1.0;
            }
            _downloads[downloadId].AddHeader(name, value);
            return 1.0;
        }

        [DllExport("DownloadDelete")]
        public static double DownloadDelete(double downloadId)
        {
            if (!_downloads.ContainsKey(downloadId))
            {
                return -1.0;
            }
            _downloads[downloadId].CancelDownload();
            _downloads.Remove(downloadId);
            return 1.0;
        }

        [DllExport("DownloadStatus")]
        public static double DownloadStatus(double downloadId)
        {
            if (!_downloads.ContainsKey(downloadId))
            {
                return -1.0;
            }
            return Convert.ToDouble(_downloads[downloadId].Progress);
        }

        [DllExport("DownloadComplete")]
        public static double DownloadComplete(double downloadId)
        {
            if (!_downloads.ContainsKey(downloadId))
            {
                return -2.0;
            }
            return _downloads[downloadId].Complete;
        }

        [DllExport("DownloadResult")]
        public static string DownloadResult(double downloadId)
        {
            if (!_downloads.ContainsKey(downloadId))
            {
                return "";
            }
            return (_downDir == "") ? (Directory.GetCurrentDirectory() + "\\" + _downloads[downloadId].Name) : _downloads[downloadId].Name;
        }
    }
}
