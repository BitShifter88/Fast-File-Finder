//using BitShifter.FastFileFinder.Engine;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace BitShifter.FastFileFinder.UI
//{
//    internal class FileScanner
//    {
//        private Thread[] _threads;
//        private bool _stop = false;
//        public List<SearchHit> Hits { get; set; } = new List<SearchHit>();
//        private Queue<string> _fileQueue = new Queue<string>();
//        private object _fileQueLock = new object();
//        private object _hitLock = new object();
//        private string _content;
//        byte[] _searchStrUtf8Upper;
//        byte[] _searchStrUtf8Lower;
//        byte[] _searchStrUtf8;

//                const int BufferSize = 10000;
//        public bool IsDone { get { return _fileQueue.Count == 0; } }
//        public int QueueCount { get { return _fileQueue.Count; } }

//        bool _ignoreCase = true;

//        public FileScanner(bool async, string searchStr, bool ignoreCase)
//        {
//            _ignoreCase = ignoreCase;
//            _content = searchStr;
//            _searchStrUtf8Upper = Encoding.UTF8.GetBytes(_content.ToUpper());
//            _searchStrUtf8Lower = Encoding.UTF8.GetBytes(_content.ToLower());
//            _searchStrUtf8 = Encoding.UTF8.GetBytes(_content);

//            // Use all cores available, except one, so that the windos and other apps still can run
//            int coreCount = Environment.ProcessorCount - 1;
//            if (!async)
//                coreCount = 1;

//            _threads = new Thread[coreCount];
//            for (int i = 0; i < _threads.Length; i++)
//            {
//                _threads[i] = new Thread(new ThreadStart(ThreadProcessor));
//                _threads[i].Start();
//            }
//        }

//        private void ThreadProcessor()
//        {
//            while (!_stop)
//            {
//                while (true)
//                {
//                    string file = DequeueFile();
//                    if (file == null)
//                        break;

//                    SearchFileBin(file);
//                }

//                Thread.Sleep(0);
//            }
//        }

//        private void SearchFileBin(string file)
//        {
//            SearchHit hit = new SearchHit(file);

//            byte[] fileBytes = File.ReadAllBytes(file);
//            //string fileUtf8 = Encoding.UTF8.GetString(fileBytes);
//            //byte[] contentAscii = Encoding.ASCII.GetBytes(_content);

//            if (_ignoreCase)
//            {
//                SearchArray(fileBytes, _searchStrUtf8Lower, _searchStrUtf8Upper, hit);
//            }
//            else
//            {
//                SearchArray(fileBytes, _searchStrUtf8, _searchStrUtf8, hit);
//            }

//            if (hit.Positions.Count > 0)
//            {
//                RegisterHit(hit);
//            }
//        }

//        private unsafe void SearchArray(byte[] fileBytes, byte[] searchStrA, byte[] searchStrB, SearchHit hits)
//        {
//            if (fileBytes.Length == 0)
//                return;

//            fixed (byte* fileBytesP = &fileBytes[0])
//            {
//                fixed (byte* searchStrAP = &searchStrA[0])
//                {
//                    fixed (byte* searchStrBP = &searchStrB[0])
//                    {
//                        for (int i = 0; i < fileBytes.Length; i++)
//                        {
//                            byte c = fileBytesP[i];
//                            if (c == searchStrAP[0] || c == searchStrBP[0])
//                            {
//                                bool found = true;
//                                for (int j = 1; j < _searchStrUtf8.Length; j++)
//                                {
//                                    if (
//                                        i + j >= fileBytes.Length ||
//                                        (searchStrAP[j] != fileBytesP[i + j] && searchStrBP[j] != fileBytesP[i + j]))
//                                    {
//                                        found = false;
//                                        break;
//                                    }
//                                }
//                                if (found)
//                                    hits.Positions.Add(i);
//                            }
//                        }
//                    }
//                }
//            }
//        }

//        private void RegisterHit(SearchHit hit)
//        {
//            lock (_hitLock)
//            {
//                Hits.Add(hit);
//            }
//        }

//        private string DequeueFile()
//        {
//            lock (_fileQueLock)
//            {
//                if (_fileQueue.Count > 0)
//                    return _fileQueue.Dequeue();
//                else
//                    return null;
//            }
//        }

//        public void EnqueueFile(string file)
//        {
//            lock (_fileQueLock)
//            {
//                _fileQueue.Enqueue(file);
//            }
//        }

//        public void Stop()
//        {
//            _stop = true;
//        }
//    }
//}
