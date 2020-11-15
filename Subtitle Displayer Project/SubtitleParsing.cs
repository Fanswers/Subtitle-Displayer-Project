using System;
using System.Collections.Generic;
using System.IO;
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
    class SubtitleParsing
    {
        public List<Str> Subtitles;


        //Permet de lancer le parsing
        public async Task<List<Str>> Parsing()
        {
            Subtitles = new List<Str>();

            StrToTab();

            return Subtitles;
        }


        //Permet d'insérer chaque ligne du fichier .str séparemment dans la liste 'strContent'
        public async Task<List<string>> StrInList() 
        {
            List<string> strContent = new List<string>();
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using (StreamReader sr = new StreamReader(mydocpath + @"\testsrt\Chris Brown - Forever.srt"))
            {
                string line;
                int i = 0;
                while ((line = sr.ReadLine()) != null)
                {
                    strContent.Add(line);
                }
            }

            return strContent;
        }

        public async Task StrToTab()
        {
            List<string> strContent = await StrInList();
            List<string> str = new List<string>();

            for (int i = 0; i < strContent.Count; i++)
            {
                if (String.IsNullOrEmpty(strContent[i]) == false)
                {
                    str.Add(strContent[i]);
                }
                else
                {
                    await ParsingDate(str);
                    str.Clear();
                }
            }
            
        }

        public async Task ParsingDate(List<string> str)
        {
            

        }

        public async Task AddInList()
        {

        }
    }
}
