using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public string playerId;
    public int hp;
    public List<Card> deck, hand, grave, theVoid = new List<Card>();

    
    // Start is called before the first frame update
    void Start()
    {
        hp = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // topOfDeck is default as true, meaning it will add cards from the start of the array, false would add from bottom
    void draw(int numOfCards, bool topOfDeck = true) {
        if (topOfDeck) {
            for (int i = 0; i < numOfCards; i++) {
                hand.Add(deck[0]);
                deck.RemoveAt(0);
            }
        } else {
            for (int i = 0; i < numOfCards; i++) {
                hand.Add(deck[deck.Count - 1]);
                deck.RemoveAt(deck.Count - 1);
            }
        }
    }

    void discard() { }
    void discardToVoid() { }

    

}
