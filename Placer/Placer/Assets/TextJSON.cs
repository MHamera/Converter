using System.Collections;

public class TextJSON {
    public int page;
    public TextType Type;
    public string Text;
    public string FieldName;
    public float x, y, width, height;
    public int FontSize;
    public int[] OtherPages;
}

public enum TextType {String, Rect};