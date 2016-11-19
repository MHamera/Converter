using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter
{
    [System.Serializable]
    public class TextContainer
    {
        public List<TextJSON> list;
        public MainImage image;
    }


    [System.Serializable]

    //A TextJSON item can appear on one or more pages
    //"page" refers to the main page on the PDF it will show up on
    //If it shows up on multiple pages, the secondary pages will be contained inside otherPages[]
    //x and y indicates where the text or box start at
    //width and height is only used for the text boxes
    //FieldName corresponds exactly to a variable in FormSettings, acquired via reflection
    //Finally, "text" is the value that shows up in my PDF editor, or a description. It remains unused when rendering.

    public class TextJSON
    {
        public int page;
        public TextType Type;
        public string Text;
        public string FieldName;
        public float x, y, width, height;
        public int FontSize;
        public int[] OtherPages;
    }

    [System.Serializable]

    //This contains basic information about the PDF images
    public class MainImage
    {
        public int totalPages;
        public float x, y, width, height;
    }
    public enum TextType { String, Rect };
}
