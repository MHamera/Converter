using System.Collections;

public class TextJSON {
    public TextType Type;
    public string Text;
    public float x, y, width, height;
    public int FontSize;
}

public enum TextType {String, Rect};