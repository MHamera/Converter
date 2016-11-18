using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
public class TextManager : MonoBehaviour {
    public List<Sprite> images;
    public Image myImage;
    public Slider slider;


	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    public void SliderChanged()
    {
        //Deactivate all UI items
        //Activate the items on the current slider page
        int sliderVal = (int)slider.value;
        myImage.sprite = images[sliderVal];

        var items = FindObjectsOfType<TextItem>();
        //Assert each item has its unique name

        foreach(var i in items)
        {
            var itemText = i.GetComponent<Text>();
            if (itemText != null)
            {
                if (itemText.text != "")
                {
                    i.storedValue = itemText.text;
                    itemText.text = "";
                }
            }

            //If it's an image rect
            var img = i.GetComponent<Image>();
            if (img!=null)
            {
                img.color = new Color(0, 0, 0, 0);
            }
        }

        foreach(var i in items)
        {
            if (i.page == sliderVal)
            {
                var text = i.GetComponent<Text>();
                if (text!=null)
                {
                    text.text = i.storedValue;
                }

                var IMG = i.GetComponent<Image>();
                if (IMG != null)
                {
                    IMG.color = Color.black;
                }
            }
        }
    }
}
