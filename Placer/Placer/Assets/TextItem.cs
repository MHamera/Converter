using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[ExecuteInEditMode]
public class TextItem : MonoBehaviour {
    public int page;
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
        }




        return json;
    }
}
