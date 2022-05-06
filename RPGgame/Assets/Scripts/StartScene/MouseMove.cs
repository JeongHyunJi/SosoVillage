using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMove : MonoBehaviour
{

    public Texture2D cursorTexture;
    public Vector2 adjustHotSpot = Vector2.zero;

    private Vector2 hotSpot;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MyCursor");
    }
    IEnumerator MyCursor()
    {
        yield return new WaitForEndOfFrame();

        hotSpot.x = cursorTexture.width / 2;
        hotSpot.y = cursorTexture.height / 2;

        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

}
