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
        public async Task<List<Str>> Parsing(string SubtitlePath)
        {
            Subtitles = new List<Str>();
            DateTime date1 = DateTime.ParseExact("00:00:00,000", "HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            Subtitles.Add(new Str(0, date1, date1, null));

            StrToTab(SubtitlePath);

            return Subtitles;
        }


        //Permet d'insérer chaque ligne du fichier .str séparemment dans la liste 'strContent'
        public async Task<List<string>> StrInList(string SubtitlePath) 
        {
            List<string> strContent = new List<string>();

            using (StreamReader sr = new StreamReader(SubtitlePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    strContent.Add(line);
                }
                strContent.Add(null);
            }

            return strContent;
        }


        //Permet de mettre tout les élément d'un sous titre dans un tableau.
        public async Task StrToTab(string SubtitlePath)
        {
            List<string> strContent = await StrInList(SubtitlePath);
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

        //Permet d'ajouter chaque sous titres dans la liste principal sous forme d'objet Str
        public async Task AddInList(List<string> str)
        {
            List<string> strContent = str;

            int number = int.Parse(strContent[0]);
            DateTime date1 = DateTime.ParseExact(strContent[1].Substring(0, 12), "HH:mm:ss,fff",
                System.Globalization.CultureInfo.InvariantCulture);
            DateTime date2 = DateTime.ParseExact(strContent[1].Substring(17), "HH:mm:ss,fff",
                System.Globalization.CultureInfo.InvariantCulture);
            string content = "";

            for (int i = 2; i < strContent.Count; i++)
            {
                if (i == 2)
                    content = strContent[i];
                else
                    content += System.Environment.NewLine + strContent[i]; ;

            }

            Subtitles.Add(new Str(number, date1, date2, content));
        }
    }
}
