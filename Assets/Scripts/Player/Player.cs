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
    public int rp;

    // Player card locations.
    public List<Card> hand = new List<Card>();
    public List<Card> deck = new List<Card>();
    public List<Card> grave = new List<Card>();
    public List<Card> theVoid = new List<Card>();

    
    // Start is called before the first frame update
    void Start()
    {
        hp = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (hp <= 0) {Debug.Log("PLAYER " + playerId + " has lost.");}
    }

    // in-game mechanic
    // topOfDeck is default as true, meaning it will add cards from the start of the array, false would add from bottom
    public void DrawCard(int numOfCards)
    {
        int debug_j = 0;
        for (int i = 0; i < numOfCards; i++) {
            Debug.Log("DRAWING: " + deck[0]);
            hand.Add(deck[0]);
            deck.RemoveAt(0);
            Debug.Log("DRAW successful.");
            debug_j++;
        }
        Debug.Log(debug_j + " card(s) drawn.");
        /*for (int i = 0; i < numOfCards; i++) { // draws from bottom of the deck
            Debug.Log("Attempting to draw card (from bottom of deck): " + deck[0]);
            hand.Add(deck[deck.Count - 1]);
            deck.RemoveAt(deck.Count - 1);
            Debug.Log("Add successful.");
        }*/
    }

    public void DiscardCard(Card target)
    {
        foreach (Card card in hand) {
            Debug.Log("");
            if (card==target) {
                Debug.Log("DISCARDING: " + card.cardName);
                grave.Add(card);
                hand.Remove(card);
                Debug.Log("DISCARD successful");
            }
        }
    }

    public void voidFromGrave(Card target)
    {
        foreach (Card card in grave) {
            if (card == target) {
                Debug.Log("VOIDING: " + card.cardName);
                theVoid.Add(card);
                grave.Remove(card);
                Debug.Log("VOID success");
            }
        }
    }

    // Method to increase/decrease player's HP. Checks to see if player has lost after.
    public void ModifyHP(int dmg) 
    {
        hp += dmg;
        if (hp <= 0) { Debug.Log("Player " + playerId + " lost! Game Over"); } // Loss condition
    }
}
