using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
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
    public enum LOC {HAND, DECK, GRAVE, VOID, NONE}
    public string playerId;
    public int hp, rp;
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> grave = new List<GameObject>();
    public List<GameObject> theVoid = new List<GameObject>();

    public void DrawCard(int numOfCards = 1)
    {
        if (deck.Count > 0) { 
            for (int i = 0; i < numOfCards; i++) {
                hand.Add(deck[0]);
                deck.RemoveAt(0);
            }
        } else {Debug.Log("ERROR: Deck is empty!"); }
    }
    public void ShuffleDeck()
    {
        // Fisher-Yates shuffling algo used here.
        for (int i = deck.Count-1; i > 0; i--) {
			int rnd = UnityEngine.Random.Range(0,i);
			GameObject temp = deck[i];
			deck[i] = deck[rnd];
			deck[rnd] = temp;
		}
    }
    public void ToHand(GameObject target, LOC loc)
    {
        switch (loc) {
            case LOC.HAND: Debug.Log("Error - attempted to send a card in HAND to the same location"); break;
            case LOC.DECK:
                if (deck.Contains(target.GetComponent<Card>().selfRef)) {
                    hand.Add(target.GetComponent<Card>().selfRef);
                    deck.Remove(target.GetComponent<Card>().selfRef);
                } else { Debug.Log("No target in deck to add to hand."); }
                break;
            case LOC.GRAVE:
                if (grave.Contains(target.GetComponent<Card>().selfRef)) {
                    hand.Add(target.GetComponent<Card>().selfRef);
                    grave.Remove(target.GetComponent<Card>().selfRef);
                } else { Debug.Log("No target in grave to add to hand."); }
                break;
            case LOC.VOID: Debug.Log("Error - game mechanics do not allow cards in the VOID to be RECOVERED"); break;
            default: Debug.Log("Error - SendToHand() cannot source valid LOC param for location"); break;
        }
    }
    public void ToDeck(GameObject target, LOC loc)
    {
        switch (loc) {
            case LOC.HAND:
                if (hand.Contains(target.GetComponent<Card>().selfRef)) {
                    deck.Add(target.GetComponent<Card>().selfRef);
                    hand.Remove(target.GetComponent<Card>().selfRef);
                    ShuffleDeck();
                } else { Debug.Log("No target in hand to add to deck."); }
                break;
            case LOC.DECK: Debug.Log("Error - attempted to send a card in DECK to the same location"); break;
            case LOC.GRAVE:
                if (grave.Contains(target.GetComponent<Card>().selfRef)) {
                    deck.Add(target.GetComponent<Card>().selfRef);
                    grave.Remove(target.GetComponent<Card>().selfRef);
                    ShuffleDeck();
                } else { Debug.Log("No target in deck."); }
                break;
            case LOC.VOID: Debug.Log("Error - game mechanics do not allow cards in the VOID to be RECOVERED"); break;
            default: Debug.Log("Error - SendToDeck() cannot source valid LOC param for location"); break;
        }
    }
    public void ToGrave(GameObject target, LOC loc)
    {
        switch (loc) {
            case LOC.HAND:
                if (hand.Contains(target.GetComponent<Card>().selfRef)) {
                    grave.Add(target.GetComponent<Card>().selfRef);
                    hand.Remove(target.GetComponent<Card>().selfRef);
                } else { Debug.Log("No target in hand to add to grave."); }
                break;
            case LOC.DECK:
                if (deck.Contains(target.GetComponent<Card>().selfRef)) {
                    grave.Add(target.GetComponent<Card>().selfRef);
                    deck.Remove(target.GetComponent<Card>().selfRef);
                    ShuffleDeck();
                } else { Debug.Log("No target in deck to add to grave."); }
                break;
            case LOC.GRAVE: Debug.Log("Error - attempted to send a card in GRAVE to the same location"); break;
            case LOC.VOID: Debug.Log("Error - game mechanics do not allow cards in the VOID to be RECOVERED"); break;
            default: Debug.Log("Error - ToGrave() cannot source valid LOC param for location"); break;
        }
    }
    public void ToVoid(GameObject target, LOC loc)
    {
        switch (loc) {
            case LOC.HAND:
                if (hand.Contains(target.GetComponent<Card>().selfRef)) {
                    theVoid.Add(target.GetComponent<Card>().selfRef);
                    hand.Remove(target.GetComponent<Card>().selfRef);
                } else { Debug.Log("No target in hand."); }
                break;
            case LOC.DECK:
                if (deck.Contains(target.GetComponent<Card>().selfRef)) {
                    theVoid.Add(target.GetComponent<Card>().selfRef);
                    deck.Remove(target.GetComponent<Card>().selfRef);
                } else { Debug.Log("No target in hand."); }
                break;
            case LOC.GRAVE:
                if (grave.Contains(target.GetComponent<Card>().selfRef)) {
                    theVoid.Add(target.GetComponent<Card>().selfRef);
                    grave.Remove(target.GetComponent<Card>().selfRef);
                } else { Debug.Log("No target in hand."); }
                break;
            case LOC.VOID:
                Debug.Log("Error - game mechanics do not allow cards in the VOID to be RECOVERED");
                Debug.Log("Error - attempted to send a card in the VOID to same location");
                Debug.Log("Achievement Unlocked! - Dramatically mess up to the point you trigger 2 impossible errors."); // I will eat my laptop if someone manages to break my game this badly
                break;
            default: Debug.Log("Error - SendToVoid() cannot source valid LOC param for location"); break;
        }
    }

    public void ModifyHP(int change) { hp += change; if (hp <= 0) { Debug.Log("Player " + playerId + " lost! Game Over"); } }
    public void ModifyRP(int change) { rp += change; }
}
