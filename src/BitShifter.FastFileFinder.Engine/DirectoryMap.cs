using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BitShifter.FastFileFinder.Engine
{
    public class DirectoryMap
    {
        public List<string> Files { get; set; } = new List<string>();
        object _lock = new object();

        public DirectoryMap()
        {
        }

        public void Search(string root)
        {
            try
            {
                string[] files = Directory.GetFiles(root);
                string[] directories = Directory.GetDirectories(root);

                foreach (var file in files)
                {
                    lock (_lock)
                    {
                        Files.Add(file);
                    }
                }

                Parallel.ForEach(directories, dir => {
                    Search(dir);
                });
                //foreach (var dir in directories)
                //{
                //    Search(dir);
                //}
            }
            catch (Exception ex)
            {

            }
        }
    }
}
