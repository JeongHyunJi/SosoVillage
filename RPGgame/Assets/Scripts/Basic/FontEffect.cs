using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FontEffect : MonoBehaviour
{
    // Start is called before the first frame update
    public Text targetText;
    string textValue;
    //public Text[] targetTextAry;
    //string[] textValueAry;

    private void Start()
    {
        /*for(int i = 0; i < targetTextAry.Length; i++)
        {
            textValueAry[i] = targetTextAry[i].text;
        }*/

        textValue = targetText.text;
    }

    private void OnMouseEnter()
    {
        targetText.text = "<size=" + (targetText.fontSize + 5) + ">" + textValue + "</size>";
    }
    private void OnMouseExit()
    {
        targetText.text = textValue;
    }

    public void tartgetCall(string targetText)
    {
        textValue = targetText;
    }

}
