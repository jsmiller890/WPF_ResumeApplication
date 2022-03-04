using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_ResumeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        public string[] GetSongInfo()
        {

            string title = titleTxtBox.Text;
            string album = albumTxtBox.Text;
            string artist = artistTxtBox.Text;
            string genre = genreTxtBox.Text;
            string time = timeTxtBox.Text;

            string[] s = new string[5] { title, album, artist, genre, time };
            return s;
        }
        
    }

}
