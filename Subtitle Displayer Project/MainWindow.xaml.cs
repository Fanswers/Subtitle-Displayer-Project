using Microsoft.Win32;
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
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ConsoleAllocator.ShowConsoleWindow();
            
        }

        //permet de recupérer le chemin des fichiers
        public void GetFilePath(object sender, RoutedEventArgs e)
        {
            string SubtitlePath = "";
            string MoviePath = "";
            OpenFileDialog openFileDialogSubtitles = new OpenFileDialog();
            if (openFileDialogSubtitles.ShowDialog() == true)
                SubtitlePath = openFileDialogSubtitles.FileName;
            OpenFileDialog openFileDialogMovie = new OpenFileDialog();
            if (openFileDialogMovie.ShowDialog() == true)
                MoviePath = openFileDialogMovie.FileName;
            this.VideoME.Source = new Uri(MoviePath);
            VideoDisplayer(SubtitlePath);
        }

        //Permet L'affichage des sous titres
        public async Task Displayer(string SubtitlePath)
        {
            SubtitleParsing p = new SubtitleParsing();

            Task<List<Str>> parsingTask = p.Parsing(SubtitlePath);
            List<Str> subtitles = parsingTask.Result;

            for (int i = 1; i < subtitles.Count; i++)
            {
                Console.WriteLine("");
                this.SubtitleTB.Text = "";
                await Task.Delay(subtitles[i].FirstDate.Subtract(subtitles[i - 1].SecondDate));
                this.SubtitleTB.Text = subtitles[i].Content;
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

        //Permet de lancer l'affichage vidéo
        public async Task VideoDisplayer(string SubtitlePath)
        {
            this.VideoME.Play();
            var tsc = new TaskCompletionSource<bool>();
            this.VideoME.MediaOpened += (o, e) => { tsc.TrySetResult(true); };
            await tsc.Task;
            Displayer(SubtitlePath);
        }
    }
}
