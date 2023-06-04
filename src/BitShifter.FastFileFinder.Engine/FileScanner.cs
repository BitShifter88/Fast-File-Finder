using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitShifter.FastFileFinder.Engine
{
    internal class FileScanner
    {
        private bool _stop = false;
        public List<SearchHit> Hits { get; set; } = new List<SearchHit>();
        public List<string> Files { get; set; } = new List<string>();
        private object _fileQueLock = new object();
        private object _hitLock = new object();

        byte[] _searchStrUtf8Upper;
        byte[] _searchStrUtf8Lower;
        byte[] _searchStrUtf8;

        const int BufferSize = 10000;
        public bool IsDone { get; private set; }
        public int FilesDone { get; set; } = 0;

        SearchParameters _searchParm;

        public FileScanner(bool async, SearchParameters searchParm, List<string> files)
        {
            Files = files;
            _searchParm = searchParm;

            _searchStrUtf8Upper = Encoding.UTF8.GetBytes(_searchParm.Text.ToUpper());
            _searchStrUtf8Lower = Encoding.UTF8.GetBytes(_searchParm.Text.ToLower());
            _searchStrUtf8 = Encoding.UTF8.GetBytes(_searchParm.Text);

            Task.Run(() =>
            {
                Parallel.ForEach(Files, file =>
                {
                    SearchFileBin(file);
                    FilesDone++;
                });
                IsDone = true;
            });
        }

        private void SearchFileBin(string file)
        {
            SearchHit hit = new SearchHit(file, _searchParm);

            byte[] fileBytes;
            try
            {
                fileBytes = File.ReadAllBytes(file);
            }
            catch (Exception e)
            {
                return;
            }
            //string fileUtf8 = Encoding.UTF8.GetString(fileBytes);
            //byte[] contentAscii = Encoding.ASCII.GetBytes(_content);

            if (_searchParm.IgnoreCase)
            {
                SearchArray(fileBytes, _searchStrUtf8Lower, _searchStrUtf8Upper, hit);
            }
            else
            {
                SearchArray(fileBytes, _searchStrUtf8, _searchStrUtf8, hit);
            }

            if (hit.Positions.Count > 0)
            {
                RegisterHit(hit);
            }
        }

        private unsafe void SearchArray(byte[] fileBytes, byte[] searchStrA, byte[] searchStrB, SearchHit hits)
        {
            if (fileBytes.Length == 0)
                return;

            fixed (byte* fileBytesP = &fileBytes[0])
            {
                fixed (byte* searchStrAP = &searchStrA[0])
                {
                    fixed (byte* searchStrBP = &searchStrB[0])
                    {
                        for (int i = 0; i < fileBytes.Length; i++)
                        {
                            byte c = fileBytesP[i];
                            if (c == searchStrAP[0] || c == searchStrBP[0])
                            {
                                bool found = true;
                                for (int j = 1; j < _searchStrUtf8.Length; j++)
                                {
                                    if (
                                        i + j >= fileBytes.Length ||
                                        (searchStrAP[j] != fileBytesP[i + j] && searchStrBP[j] != fileBytesP[i + j]))
                                    {
                                        found = false;
                                        break;
                                    }
                                }
                                if (found)
                                    hits.Positions.Add(i);
                            }
                        }
                    }
                }
            }
        }

        private void RegisterHit(SearchHit hit)
        {
            lock (_hitLock)
            {
                Hits.Add(hit);
            }
        }

        public void Stop()
        {
            _stop = true;
        }
    }

    public class SearchHit
    {
        public string FilePath { get; set; }
        public SearchParameters SearchParm { get; set; }
        public List<int> Positions { get; set; } = new List<int>();

        public List<LineHit> LineHits { get; set; } = new List<LineHit>();
        public string[] Lines { get; set; }
        public string FileContent { get; set; }

        public SearchHit(string filePath, SearchParameters searchParm)
        {
            FilePath = filePath;
            SearchParm = searchParm;
        }

        public void Prepare()
        {
            Lines = File.ReadAllLines(FilePath);
            FileContent = File.ReadAllText(FilePath);

            int lineOffset = 0;
            for (int i = 0; i < Lines.Length; i++)
            {
                string line = Lines[i];
                List<int> linesColumns = line.AllIndexesOf(SearchParm.Text,
                                                           SearchParm.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
                if (!linesColumns.Any())
                {
                    lineOffset += line.Length + 1;
                    continue;
                }

                LineHit lineHit = new LineHit(lineOffset, i, linesColumns, SearchParm.Text);
                LineHits.Add(lineHit);
                lineOffset += line.Length + 1;
            }
        }
    }

    public class LineHit
    {
        public string Text { get; set; }
        public int LineOffset { get; set; }
        public int LineNumber { get; set; }
        public List<int> LineColumns { get; set; }

        public LineHit(int lineOffset, int lineNumber, List<int> lineColumns, string text)
        {
            LineOffset = lineOffset;
            LineNumber = lineNumber;
            LineColumns = lineColumns;
            Text = text;
        }
    }

    public class SearchParameters
    {
        public string Text { get; set; }
        public bool IgnoreCase { get; set; }
    }
}
