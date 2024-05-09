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
        gameObject.GetComponentInParent<GameUI>().playerIsViewingCards = false;
        Destroy(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) { CloseButton(); }
    }
}
