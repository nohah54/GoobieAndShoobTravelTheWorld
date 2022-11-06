using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public static void SetDialog(TextMeshProUGUI textObject, string fullText, MonoBehaviour instance)
    {
        instance.StartCoroutine(ShowText(textObject,fullText));
    }

    public static IEnumerator ShowText(TextMeshProUGUI textObject, string fullText)
    {
        string currentText = "";

        textObject.GetComponent<WordWobble>().enabled = false;
        for (int i = 0; i <= fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textObject.text = currentText;
            yield return new WaitForSeconds(0.05f);
        }
        textObject.GetComponent<WordWobble>().enabled = true;
        textObject.GetComponent<WordWobble>().SetTextArrays();
    }
}
