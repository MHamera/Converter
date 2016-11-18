using System.Collections;

[System.Serializable]

public class TextJSON {
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
public enum TextType {String, Rect};