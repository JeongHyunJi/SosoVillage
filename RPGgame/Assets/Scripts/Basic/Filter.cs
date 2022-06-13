using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Filter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (TimeController.time.Hour < 6 || TimeController.time.Hour >= 21) { this.GetComponent<Image>().color = new Color(0, 0, 22 / 255f, 181 / 255f); } // «—π„¡ﬂ
        else if (TimeController.time.Hour < 9) { this.GetComponent<Image>().color = new Color(0, 0, 87 / 255f, 174 / 255f); } // ªı∫Æ≥Ë
        else if (TimeController.time.Hour < 18) { this.GetComponent<Image>().color = new Color(255, 255, 255, 0); } // ≥∑
        else if (TimeController.time.Hour < 21) { this.GetComponent<Image>().color = new Color(135 / 255f, 0, 0, 51 / 255f); } //«ÿ¡˙≥Ë
    }
}
