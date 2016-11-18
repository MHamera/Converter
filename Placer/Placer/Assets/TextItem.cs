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
}
