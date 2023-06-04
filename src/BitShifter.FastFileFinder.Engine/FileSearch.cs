using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitShifter.FastFileFinder.Engine
{
    public class FileSearch
    {
        public List<SearchHit> Result { get; set; }
        public bool Done { get; set; }
        public string Status { get; set; }

        public void Search(string dir, string searchString, bool ignoreCase)
        {
            Task.Run(() =>
            {
                DoSearch(dir, searchString, ignoreCase);
            });
        }

        private void DoSearch(string dir, string searchString, bool ignoreCase)
        {
            // Find all the files in the folder structure (recursivly)
            Status = "Scanning for files...";
            DirectoryMap dirMap = new DirectoryMap();
            dirMap.Search(dir);

            // Scan each file
            FileScanner search = new FileScanner(true, new SearchParameters() { Text = searchString, IgnoreCase = ignoreCase }, dirMap.Files);

            Stopwatch s = new Stopwatch();
            s.Start();

            while(!search.IsDone)
            {
                Thread.Sleep(100);
                double percDone = 1.0 - (double)(dirMap.Files.Count - search.FilesDone) / (double)dirMap.Files.Count;
                double timeLeft = (1.0 - percDone) * (s.Elapsed.TotalMinutes / percDone );
                Status = $"{(int)(percDone * 100.0)}% - ETA {(int)timeLeft}m";
            }

            Status = "Done";
            Result = search.Hits;
            Done = true;
        }
    }
}
