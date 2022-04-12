using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF_ResumeApplication.Model;

namespace WPF_ResumeApplication.ViewModel
{
    class FileIO<T>
    {

        char splitter = '|';

        private IList<T> _tList;
        public string CreateSaveFile(T t)
        {
            string fileName = t.ToString() + ".txt";
            if (!File.Exists(fileName))
                File.Create(fileName);
            return fileName;
        }

        public void SaveInfo(IList<T> ts, T t)
        {
            string fileName = CreateSaveFile(t);

            File.WriteAllText(fileName, "");

            using (StreamWriter sw = File.AppendText(fileName))
            {
                foreach (T datum in ts)
                {

                }
            };
        }

        public void LoadFileData(T t)
        {
            string fileName = t.ToString() + ".txt";
            _tList = new List<T> { };
            if (!File.Exists(fileName))
                MessageBox.Show("The file " + fileName + "does not exist.");

            using (StreamReader sr = File.OpenText(fileName))
            {
                string fileContents = sr.ReadLine();
                _tList.Clear();
                if (t.GetType().ToString().Equals("Song"))
                {
                    while (fileContents != null)
                    {
                        string[] dividedContents = fileContents.Split(splitter);
                        //_tList.Add(new Song { Title = dividedContents[0], Artist = dividedContents[1], Album = dividedContents[2], Time = dividedContents[3], Genre = dividedContents[4] });


                        fileContents = sr.ReadLine();
                    }
                }
                

            }
        }
    }
}
