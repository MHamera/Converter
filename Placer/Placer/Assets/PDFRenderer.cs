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
}
public static class PDFRenderer  {
    public static void GeneratePDF()
    {
        var TC = new TextContainer();
        TC.list = new List<TextJSON>();
        
        foreach(var c in GameObject.FindObjectsOfType<TextItem>())
        {
            TC.list.Add(c.toJSON());
        }

       var str= JsonConvert.SerializeObject(TC.list, Formatting.Indented);
        EditorGUIUtility.systemCopyBuffer = str;

    }
}
