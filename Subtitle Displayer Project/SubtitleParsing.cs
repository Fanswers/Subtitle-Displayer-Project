﻿using System;
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
    class SubtitleParsing
    {
        public List<Str> Subtitles;
        public async Task<List<Str>> Parsing()
        {
            Subtitles = new List<Str>();
            
            return Subtitles;
        }
    }
}
