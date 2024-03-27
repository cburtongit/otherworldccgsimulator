using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public string playerId;
    public int hp;
    public int rp;

    // Player card locations.
    public PlayerHand hand; // private knowledge
    public PlayerDeck deck; // private knowledge
    public PlayerGrave grave; // public knowledge
    public PlayerTheVoid theVoid; // public knowledge

    
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
                Debug.Log("Attempting to draw card: " + deck.deck[0]);
                hand.AddToHand(deck.deck[0]);
                deck.deck.RemoveAt(0);
                Debug.Log("Add successful.");
            }
        } else {
            for (int i = 0; i < numOfCards; i++) {
                Debug.Log("Attempting to draw card (from bottom of deck): " + deck.deck[0]);
                hand.AddToHand(deck.deck[deck.deck.Count - 1]);
                deck.deck.RemoveAt(deck.deck.Count - 1);
                Debug.Log("Add successful.");
            }
        }
    }

    void discard() { }
    void discardToVoid() { }

    // Method to increase/decrease player's HP. Checks to see if player has lost after.
    void modHP(int dmg) 
    {
        hp += dmg;
        if (hp <= 0) {
            Debug.Log("Player " + playerId + " lost! Game Over");
        }
    }



    

}
