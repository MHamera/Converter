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

    public class MainImage
    {
        public int totalPages;
        public float x, y, width, height;
    }
    public enum TextType { String, Rect };
}
