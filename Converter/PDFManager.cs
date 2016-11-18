using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace Converter
{
    //Takes a series of images and JSON data then outputs a PDF
    class PDFManager
    {
        private List<string> images;
        public string inputFolder = @"../../Images/";
        public 
        public PDFManager()
        {
            LoadImages();
        }

        private  void LoadJSON()
        {

        }

        private void LoadImages()
        {
            images = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly).ToList();        
        }
    }
}
