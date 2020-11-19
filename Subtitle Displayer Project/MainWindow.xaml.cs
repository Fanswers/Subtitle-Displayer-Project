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
            Displayer();
        }

        public async Task Displayer()
        {
            SubtitleParsing p = new SubtitleParsing();

            Task<List<Str>> parsingTask = p.Parsing();
            List<Str> subtitles = parsingTask.Result;

            for (int i = 1; i < subtitles.Count; i++)
            {
                Console.WriteLine("");
                this.SubtitleTextBlock.Text = "";
                await Task.Delay(subtitles[i].FirstDate.Subtract(subtitles[i - 1].SecondDate));
                this.SubtitleTextBlock.Text = subtitles[i].Content;
                await Task.Delay(subtitles[i].SecondDate.Subtract(subtitles[i].FirstDate));
            }
        }

        //Permet d'afficher les sous titres
        public async Task Display(List<string> content)
        {
            for (int i = 0; i < content.Count; i++)
            {
                Console.WriteLine(content[i]);
            }
        }


    }
}
