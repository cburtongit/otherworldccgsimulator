using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class Player : MonoBehaviour
{
    /*
        NOTES & IDEAS
        - Player should have boolean variables that track statuses similar to
            how Card objects do (e.g. canSummon, canAttack, canDraw).
        - Realised that cards with more restrictive effects might prove troublesome
            to implement neatly. E.g. a card that prevents the user from
            summoning cards without an [Earth] alignment.
        - Growing concerned that cards will have so many effects that storing
            Card and Player statuses in variables and checking them every action
            could slow down the game. Will investigate similar software.
    */

    public string playerId;
    public int hp;
    public int rp, originalRp;

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

    // in-game mechanic
    // topOfDeck is default as true, meaning it will add cards from the start of the array, false would add from bottom
    public void DrawCard(int numOfCards, bool topOfDeck = true) {
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

    // in-game mechanic
    public void DiscardCard(int numOfCards, bool randomDiscard = false, bool toVoid = false)
    {
        /* For loop runs until numOfCards is reached
            - Allow player to select a card to discard
            - Discard card, call DiscardCard() method on card obj
            - Remove card obj from PlayerHand.hand
            - If (toVoid) {
                // Add card obj to PlayerTheVoid.theVoid[]
            } Else {
                // Add card obj to PlayerGrave.grave[]
            } */
    }

    // Method to increase/decrease player's HP. Checks to see if player has lost after.
    public void ModifyHP(int dmg) 
    {
        hp += dmg;
        if (hp <= 0) { Debug.Log("Player " + playerId + " lost! Game Over"); } // Loss condition
    }



    

}
