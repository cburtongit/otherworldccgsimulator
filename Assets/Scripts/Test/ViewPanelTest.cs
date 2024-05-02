using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ViewPanelTest : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    public GameObject cardView;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenViewPanel(GameObject[] cards)
    {
        foreach (GameObject card in cards) {
            // Copy, add to view panel
        }
    }

    public void TestAttacher ()
    {
        GameObject card = new GameObject();
        card.transform.SetParent(cardView.transform);
        card.transform.localScale = Vector3.one;
        card.transform.localPosition= Vector3.zero;

        card.AddComponent<SpriteRenderer>();
        card.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Images/artwork/DarkProwler");
    }
}
