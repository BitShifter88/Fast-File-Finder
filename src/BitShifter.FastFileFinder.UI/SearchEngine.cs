//using BitShifter.FastFileFinder.Engine;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BitShifter.FastFileFinder.UI
//{
//    internal class SearchEngine
//    {
//        public int FileCount { get; set; }
//        public int FilesMissing { get { return _scanner.QueueCount; } }
//        string _content;
//        FileScanner _scanner;

//        public List<SearchHit> Search(bool async, string dir, string content)
//        {
//            var test = IntPtr.Size;

//            _scanner = new FileScanner(async, content, false);
//            _content = content;

//            TraveseDir(dir);

//            while (!_scanner.IsDone)
//                Thread.Sleep(1);

//            _scanner.Stop();

//            return _scanner.Hits;
//        }

//        private void TraveseDir(string dir)
//        {
//            string[] files = Directory.GetFiles(dir);
//            string[] directories = Directory.GetDirectories(dir);

//            foreach (var childDir in directories)
//            {
//                TraveseDir(childDir);
//            }

//            foreach (var file in files)
//            {
//                _scanner.EnqueueFile(file);
//            }
//        }
//    }
//}
