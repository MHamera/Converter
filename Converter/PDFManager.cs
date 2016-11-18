using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ImageProcessor;
using iTextSharp.text.pdf;
using iTextSharp.text;


using System.IO;

namespace Converter
{
    //Takes a series of images and JSON data then outputs a PDF
    class PDFManager
    {
        private string[] images;
        private TextContainer textContainer;

        public string inputFolder = @"../../Images/";
        public string jsonFile = @"../../JSON/JSONData.json";

        public PDFManager()
        {
            LoadImages();
            LoadJSON();
            GeneratePDF();
        }

        private void GeneratePDF()
        {
            var data = CreatePdf(images);
            File.WriteAllBytes("./test.pdf", data);
        }

        private  void LoadJSON()
        {
            string data = File.ReadAllText(jsonFile);
            textContainer = JsonConvert.DeserializeObject<TextContainer>(data);
        }

        private void LoadImages()
        {
            images = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly);        
        }


        private byte[] CreatePdf(string[] bmpFilePaths)
        {
            using (var ms = new MemoryStream())
            {
                var document = new iTextSharp.text.Document(iTextSharp.text.PageSize.EXECUTIVE., 0, 0, 0, 0);
                iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms).SetFullCompression();
                document.Open();
                foreach (var path in bmpFilePaths)
                {
                    var imgStream = File.Open(path, FileMode.Open);
                    var image = iTextSharp.text.Image.GetInstance(imgStream);
                    image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                    document.Add(image);
                }
                document.Close();
                return ms.ToArray();
            }
        }
    }
}
