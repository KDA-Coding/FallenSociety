using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    protected List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update() 
    {
        foreach(FloatingText txt in floatingTexts) 
        {
            txt.UpdateFloatingText();
        }
    }

    public void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration) 
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.text.text = message;
        floatingText.text.fontSize = fontSize;
        floatingText.text.color = color;

        // Convert world space to screen space for proper UI Usage.
        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position);

        //Transfer values from base floating text object.
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    private FloatingText GetFloatingText() 
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if(txt == null) 
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.text = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }

}
