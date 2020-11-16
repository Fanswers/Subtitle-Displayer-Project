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
    class SubtitleDisplayer
    {
        //Permet de lancer l'affichage des sous titres
        public async Task Displayer(List<Str> Subtitles)
        {
            List<Str> subtitles = Subtitles;

            for (int i = 1; i < subtitles.Count; i++)
            {
                DateTime date1 = DateTime.ParseExact(subtitles[i - 1].SecondtDate, "HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);
                DateTime date2 = DateTime.ParseExact(subtitles[i].FirstDate, "HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);
                DateTime date3 = DateTime.ParseExact(subtitles[i].SecondtDate, "HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);

                Display(date2.Subtract(date1), date3.Subtract(date2), subtitles[i].Content);
            }
        }

        //Permet d'afficher les sous titres
        public async Task Display(TimeSpan time1, TimeSpan time2, List<string> content)
        {

        }
    }
}
