using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.IO;

namespace Converter
{
    //Takes a series of images and JSON data then outputs a PDF
    class PDFManager
    {
        private List<string> images;
        private TextContainer textContainer;

        public string inputFolder = @"../../Images/";
        public string jsonFile = "../../JSON/JSONData.json";
        public PDFManager()
        {
            LoadImages();
            LoadJSON();
        }

        private  void LoadJSON()
        {
            string data = File.ReadAllText(jsonFile);
            textContainer = JsonConvert.DeserializeObject<TextContainer>(data);
        }

        private void LoadImages()
        {
            images = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly).ToList();        
        }
    }
}
