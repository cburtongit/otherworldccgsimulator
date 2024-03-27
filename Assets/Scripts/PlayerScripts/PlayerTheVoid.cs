using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTheVoid : MonoBehaviour
{
    
    public List<Card> theVoid = new List<Card>();
    
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
        Debug.Log("The Void clicked.");
        for (int i = 0; i < theVoid.Count; i++) {
            Debug.Log(theVoid[i]);
        }
    }

    // adds card to theVoid
    void pushToVoid(Card card)
    {
        theVoid.Insert(0, card);
        Debug.Log("Done, top card in theVoid: " + theVoid[0]);
    }
}
