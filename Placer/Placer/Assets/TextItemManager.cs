using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.UI;

[CanEditMultipleObjects]
[CustomEditor(typeof(TextItem))]

public class TextItemManager : Editor {

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        int page = (int)FindObjectOfType<Slider>().value;
        if (GUILayout.Button("Add to page"))
        {

            foreach (var t in targets)
            {
                var myScript = (TextItem)t;
                if (!myScript.otherPages.Contains(page))
                {
                    myScript.otherPages.Add(page);
                    FindObjectOfType<TextManager>().SliderChanged();
                }
            }
        }
    }
}
