using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
[ExecuteInEditMode]
public class TextItem : MonoBehaviour {
    public int page;
    public List<int> otherPages;

    public string storedValue = "";
    public Sprite storedImage;
	// Use this for initialization
	void Start () {
        page = (int)FindObjectOfType<Slider>().value;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public TextJSON toJSON()
    {
        var json = new TextJSON();
        var text = GetComponent<Text>();

        if (text==null)
        {
            json.Type = TextType.Rect;
        }
        else
        {
            json.Type = TextType.String;
            json.Text = text.text;
            json.FontSize = text.fontSize;
        }

        var rt = GetComponent<RectTransform>();
        var r = rt.rect;

        json.width = r.width;
        json.height = r.height;
        json.x = rt.offsetMin.x;
        json.y = rt.offsetMin.y;
        json.page = page;
        json.OtherPages = otherPages.ToArray();
        json.FieldName = gameObject.transform.name;


        return json;
    }
}
