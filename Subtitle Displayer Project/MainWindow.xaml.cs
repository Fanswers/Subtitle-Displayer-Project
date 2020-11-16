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

namespace Subtitle_Displayer_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConsoleAllocator.ShowConsoleWindow();

            SubtitleParsing p = new SubtitleParsing();
            SubtitleDisplayer d = new SubtitleDisplayer();

            Task<List<Str>> parsingTask = p.Parsing();
            List<Str> subtitles = parsingTask.Result;
            d.Displayer(subtitles);

        }

        
    }
}
