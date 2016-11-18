using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

using UnityEditor;
using System.IO;
[System.Serializable]
public class TextContainer
{
    public List<TextJSON> list;
    public MainImage image;
}
public static class PDFRenderer  {
    public static void GeneratePDF()
    {
        var TC = new TextContainer();


        var img = new MainImage();

        var textManager = GameObject.FindObjectOfType<TextManager>();
        var TMrect = textManager.GetComponent<RectTransform>().rect;
        img.x = TMrect.x;
        img.y = TMrect.y;
        img.width = TMrect.width;
        img.height = TMrect.height;
        img.totalPages = textManager.images.Count;

        TC.image = img;

        TC.list = new List<TextJSON>();
        
        foreach(var c in GameObject.FindObjectsOfType<TextItem>())
        {
            TC.list.Add(c.toJSON());
        }

       var str= JsonConvert.SerializeObject(TC, Formatting.Indented);
        EditorGUIUtility.systemCopyBuffer = str;

    }
}
