using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;
using UnityEngine.XR;

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
    public int hp, rp;

    // Player card locations.
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> grave = new List<GameObject>();
    public List<GameObject> theVoid = new List<GameObject>();

    public enum LOC {
        HAND,
        DECK,
        GRAVE,
        VOID,
    }

    void Start()
    {

    }
    void Update()
    {
        
    }

    // in-game mechanic
    // topOfDeck is default as true, meaning it will add cards from the start of the array, false would add from bottom
    public void DrawCard(int numOfCards = 1)
    {
        int debug_j = 0;
        if (deck.Count > 0) { 
            for (int i = 0; i < numOfCards; i++) {
                hand.Add(deck[0]);
                deck.RemoveAt(0);
                debug_j++;
            }
        } else {Debug.Log("ERROR: Deck is empty!"); }
    }
    public void DiscardCard(GameObject target)
    {
        foreach (GameObject card in hand) {
            Debug.Log("");
            if (card==target) {
                Debug.Log("DISCARDING: " + card.GetComponent<MonsterCard>().cardName);
                grave.Add(card);
                hand.Remove(card);
                Debug.Log("DISCARD successful");
            }
        }
    }
    public void VoidFromGrave(GameObject target)
    {
        foreach (GameObject card in grave) {
            if (card == target) {
                theVoid.Add(card);
                grave.Remove(card);

            }
        }
    }

    public void SendToHand(GameObject target, LOC loc)
    {
        switch (loc) {
            case LOC.HAND:
                Debug.Log("Error - attempted to send a card in HAND to the same location");
                break;
            case LOC.DECK:
                hand.Add(target);
                deck.Remove(target);
                break;
            case LOC.GRAVE:
                hand.Add(target);
                grave.Remove(target);
                break;
            case LOC.VOID:
                Debug.Log("Error - game mechanics do not allow cards in the VOID to be RECOVERED");
                break;
            default:
                Debug.Log("Error - SendToHand() cannot source valid LOC param for location");
                break;
        }
    }

    public void SendToDeck(GameObject target, LOC loc)
    {
        switch (loc) {
            case LOC.HAND:
                deck.Add(target);
                ShuffleDeck();
                hand.Remove(target);
                break;
            case LOC.DECK:
                Debug.Log("Error - attempted to send a card in DECK to the same location");
                break;
            case LOC.GRAVE:
                deck.Add(target);
                ShuffleDeck();
                grave.Remove(target);
                break;
            case LOC.VOID:
                Debug.Log("Error - game mechanics do not allow cards in the VOID to be RECOVERED");
                break;
            default:
                Debug.Log("Error - SendToDeck() cannot source valid LOC param for location");
                break;
        }
    }

    public void SendToGrave(GameObject target, LOC loc)
    {
        switch (loc) {
            case LOC.HAND:
                grave.Add(target);
                hand.Remove(target);
                break;
            case LOC.DECK:
                grave.Add(target);
                deck.Remove(target);
                break;
            case LOC.GRAVE:
                Debug.Log("Error - attempted to send a card in GRAVE to the same location");
                break;
            case LOC.VOID:
                Debug.Log("Error - game mechanics do not allow cards in the VOID to be RECOVERED");
                break;
            default:
                Debug.Log("Error - SendToGrave() cannot source valid LOC param for location");
                break;
        }
    }

    public void SendToVoid(GameObject target, LOC loc)
    {
        switch (loc) {
            case LOC.HAND:
                theVoid.Add(target);
                hand.Remove(target);
                break;
            case LOC.DECK:
                theVoid.Add(target);
                deck.Remove(target);
                break;
            case LOC.GRAVE:
                theVoid.Add(target);
                grave.Remove(target);
                break;
            case LOC.VOID:
                Debug.Log("Error - game mechanics do not allow cards in the VOID to be RECOVERED");
                Debug.Log("Error - attempted to send a card in the VOID to same location");
                Debug.Log("Achievement Unlocked! - Dramatically mess up to the point you trigger 2 impossible errors."); // I will eat my laptop if someone manages to break my game this badly
                break;
            default:
                Debug.Log("Error - SendToVoid() cannot source valid LOC param for location");
                break;
        }
    }

    public void ModifyHP(int change) 
    {
        hp += change;
        if (hp <= 0) { Debug.Log("Player " + playerId + " lost! Game Over"); } // Loss condition
    }
    public void ModifyRP(int change)
    {
        rp += change;
    }

    public void ShuffleDeck()
    {
        // Fisher-Yates shuffling algo used here.
        for (int i = deck.Count-1; i > 0; i--)
		{
			int rnd = Random.Range(0,i);
			GameObject temp = deck[i];
			deck[i] = deck[rnd];
			deck[rnd] = temp;
		}
    }
}
