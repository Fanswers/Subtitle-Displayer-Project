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
                strContent.Add(null);
            }

            return strContent;
        }


        //Permet de mettre tout les élément d'un sous titre dans un tableau.
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
                    await AddInList(str);
                    str.Clear();
                }
            }
            
        }

        public async Task AddInList(List<string> str)
        {
            List<string> strContent = str;

            int number = int.Parse(strContent[0]);
            string firstDate = strContent[1].Substring(0, 12);
            string secondDate = strContent[1].Substring(17);
            List<string> content = new List<string>();

            for (int i = 2; i < strContent.Count; i++)
            {
                content.Add(strContent[i]);
            }

            Subtitles.Add(new Str(number, firstDate, secondDate, content));
        }
    }
}
