using System.Collections;

public class TextJSON {
    public TextType Type;
    public string Text;
    public float x1, y1, x2, y2;
    public int FontSize;
}

public enum TextType {String, Rect};