using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
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

        public FormSettings settings;

        public string inputFolder;
        public string jsonFile;

        float xScale = 1.26f;
        float yScale = 1.27f;

        bool loaded = false;

        public PDFManager()
        {

        }

        
        public byte[] GeneratePDF(FormSettings settings)
        {

            if (loaded == false)
            {
                loaded = true;
                LoadImages();
                LoadJSON();
            }


            this.settings = settings;
            var data = CreatePdf(images);
            return data;
        }

        private  void LoadJSON()
        {
            string data = File.ReadAllText(jsonFile);
            textContainer = JsonConvert.DeserializeObject<TextContainer>(data);


            foreach (var item in textContainer.list)
            {
                item.height *= yScale;
                item.width *= xScale;
            }
        }

        private void LoadImages()
        {
            images = Directory.GetFiles(inputFolder, "*.png", SearchOption.TopDirectoryOnly).Reverse().ToArray();        
        }




        private byte[] CreatePdf(string[] bmpFilePaths)
        {

            float textYOffset = -0.01f;
            using (var ms = new MemoryStream())
            {
                var rect = new Rectangle(8.5f * 72f, 11f * 72f);

                var document = new iTextSharp.text.Document(rect, 0, 0, 0, 0);
                var writer = iTextSharp.text.pdf.PdfWriter.GetInstance(document, ms);
                writer.SetFullCompression();

                document.Open();
                int i = 11;


                var baseFont = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);



                var img = textContainer.image;
                foreach (var path in bmpFilePaths)
                {
                    var imgStream = File.Open(path, FileMode.Open);
                    var image = iTextSharp.text.Image.GetInstance(imgStream);

                    image.ScaleToFit(document.PageSize.Width, document.PageSize.Height);
                    document.Add(image);


                    var contentByte = writer.DirectContent;
                    contentByte.SetColorFill(BaseColor.BLACK);
                    

                    foreach(var item in textContainer.list)
                    {

                        //Check if we should even draw
                        if (item.page != i)
                        {
                            if (item.OtherPages == null) { item.OtherPages = new int[0]; }

                            if (!item.OtherPages.Contains(i))
                            {
                                continue;
                            }
                        }

                        if (item.Text == null)
                        {

                            if (settings.GetFieldBool(item.FieldName)==false)
                            {
                                continue;
                            }
                            float bx = item.x * xScale;
                            float by = item.y * (yScale + textYOffset);

                            //We need to move the boxes away from the corners
                            float boxOffset = 2f;

                            //It's a box
                            contentByte.MoveTo(bx + boxOffset, by + boxOffset);
                            contentByte.LineTo(bx + item.width - boxOffset, by + item.height - boxOffset);
                            contentByte.MoveTo(bx + item.width - boxOffset, by + boxOffset);
                            contentByte.LineTo(bx + boxOffset, by + item.height - boxOffset);
                            //Filled, but not stroked or closed
                            contentByte.Stroke();



                            continue;
                        }



                        float x, y;

                        x = item.x * xScale;
                        y = item.y * yScale;

                        //0,0 is the middle of the image but the bottom left of the pdf
                        //So we move the item halfway right, and up
                        var text = settings.GetFieldString(item.FieldName).Split('\n');
                        int j = 0;
                        foreach (var str in text)
                        {
                            contentByte.SetFontAndSize(baseFont, item.FontSize);
                            contentByte.BeginText();
                            contentByte.SetTextMatrix(x, y - (j * (item.FontSize + 2)));
                            contentByte.ShowText(str);
                            contentByte.EndText();
                            j++;
                        }
                    }
                    



                    i--;
                }
                document.Close();
                return ms.ToArray();
            }
        }
    }
}
