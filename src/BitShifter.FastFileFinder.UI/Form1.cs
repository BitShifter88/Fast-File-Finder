using System.Diagnostics;
using BitShifter.FastFileFinder.Engine;

namespace BitShifter.FastFileFinder.UI
{
    public partial class Form1 : Form
    {
        FileSearch _search;
        List<SearchHit> _hits = new List<SearchHit>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string path = "C:\\repos\\";

            //SearchEngine se = new SearchEngine();

            //Stopwatch s = new Stopwatch();
            //s.Start();
            //var result = se.Search(true, path, "LoadData<TechnologyInfo>(Path.Combine(folder, ");
            //s.Stop();

            //MessageBox.Show(s.Elapsed.TotalSeconds.ToString() + " - " + result.Count);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            _search = new FileSearch();
            _search.Search(GetSearchDirectory(), GetSearchText(), true);

            Task.Run(() =>
            {
                while (!_search.Done)
                {
                    Thread.Sleep(100);
                    Invoke(() =>
                    {
                        status.Text = _search.Status;
                    });
                }

                //MessageBox.Show(s.Elapsed.TotalSeconds.ToString());
                DisplaySearchResult(_search.Result);
            });
        }

        private void DisplaySearchResult(List<SearchHit> hits)
        {
            _hits = hits;

            Parallel.ForEach(hits, hit =>
            {
                hit.Prepare();
            });

            Invoke(() =>
            {
                searchResult.Text = "";
            });

            foreach (SearchHit hit in hits)
            {
                Invoke(() =>
                {
                    searchResult.AppendText(hit.FilePath + "\n");
                });
            }
        }

        private string GetSearchDirectory()
        {
            return directory.Text;
        }

        private string GetSearchText()
        {
            return searchFor.Text;
        }

        private void searchResult_Click(object sender, EventArgs e)
        {
            var caretPosition = searchResult.SelectionStart;
            int lineIndex = searchResult.GetLineFromCharIndex(caretPosition);

            Invoke(() =>
            {
                fileContent.Text = _hits[lineIndex].FileContent;

                foreach (var hit in _hits[lineIndex].LineHits)
                {
                    foreach (int lineColumn in hit.LineColumns)
                    {
                        fileContent.SelectionStart = hit.LineOffset + lineColumn;
                        fileContent.SelectionLength = hit.Text.Length;
                        fileContent.SelectionBackColor = Color.LightYellow;
                        fileContent.SelectionColor = Color.Red;
                        fileContent.Select(fileContent.SelectionStart, 0);
                        fileContent.ScrollToCaret();
                    }
                }

            });
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void searchResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Click(object sender, EventArgs e)
        {

        }
    }
}