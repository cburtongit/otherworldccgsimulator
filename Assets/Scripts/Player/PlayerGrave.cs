using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrave : MonoBehaviour
{
    
    public List<Card> grave = new List<Card>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown() 
    {
        Debug.Log("Grave clicked.");
        for (int i = 0; i < grave.Count; i++) {
            Debug.Log(grave[i]);
        }
    }

    // Adds a card to the top of the grave
    void PushGrave(Card card)
    {
        grave.Insert(0, card);
        Debug.Log("Done, top card in grave: " + grave[0]);
    }
}
