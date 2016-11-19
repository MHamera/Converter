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
            File.WriteAllBytes("./test2.pdf", data);
        }

        private  void LoadJSON()
        {
            string data = File.ReadAllText(jsonFile);
            textContainer = JsonConvert.DeserializeObject<TextContainer>(data);

            foreach(var v in textContainer.list)
            {
                
            }
        }

        private void LoadImages()
        {
            images = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly).Reverse().ToArray();        
        }




        private byte[] CreatePdf(string[] bmpFilePaths)
        {



            using (var ms = new MemoryStream())
            {
                var rect = new Rectangle(8.5f * 72f, 11f * 72f);

                var document = new iTextSharp.text.Document(rect, 0, 0, 0, 0);
                var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms);
                writer.SetFullCompression();

                document.Open();
                int i = 10;


                var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);


                var img = textContainer.image;
                foreach (var path in bmpFilePaths)
                {
                    var imgStream = File.Open(path, FileMode.Open);
                    var image = iTextSharp.text.Image.GetInstance(imgStream);

                    image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                    document.Add(image);


                    var contentByte = writer.DirectContent;

                    

                    foreach(var item in textContainer.list)
                    {


                        if (item.Text == null)
                        {
                            continue;
                        }

                        //Check if we should even draw
                        if (item.page != i)
                        {
                            if (item.OtherPages == null) { item.OtherPages = new int[0]; }
                            if (!item.OtherPages.Contains(i))
                            {
                             //   continue;
                            }
                        }

                        float x, y;

                        x = item.x * 1.3f;
                        y = item.y * 1.27f;

                        //0,0 is the middle of the image but the bottom left of the pdf
                        //So we move the item halfway right, and up


                        contentByte.SetFontAndSize(baseFont, item.FontSize);
                        contentByte.BeginText();
                        contentByte.SetTextMatrix(x,y);
                        contentByte.ShowText(item.Text);
                        contentByte.EndText();
                    }
                    



                    i--;
                }
                document.Close();
                return ms.ToArray();
            }
        }
    }
}
