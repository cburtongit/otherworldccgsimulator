using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class CardView : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject viewScroller, view, content;

    public void CloseButton()
    {
        Destroy(gameObject);
    }

    public void Debug_LogObjName()
    {
        Debug.Log(gameObject.name);
    }
}
