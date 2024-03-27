using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Stack-like structure
public class PlayerDeck : MonoBehaviour
{
    
    public List<Card> deck = new List<Card>();
    
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
        Debug.Log("Deck clicked.");
        for (int i = 0; i < deck.Count; i++) {
            Debug.Log(deck[i]);
        }
    }

    // Removes a card from the top of the deck and returns it.
    Card PopDeck()
    {
        Card card = deck[0];
        deck.RemoveAt(0);
        Debug.Log(card);
        return card;
    }

    // Adds a card to the top of the deck
    void PushDeck(Card card)
    {
        Debug.Log("Attempting, Top of Deck: " + deck[0]);
        deck.Insert(0, card);
        Debug.Log("Done, Top of Deck: " + deck[0]);
    }

    // Adds a card to BOTTOM of deck (not very stack-like but some cards will require this)
    void PushDeckBottom(Card card)
    {
        Debug.Log("Attempting, Bottom of Deck: " + deck[deck.Count-1]);
        deck.Add(card);
        Debug.Log("Done, Bottom of Deck: " + deck[deck.Count-1]);
    }

    // shuffles the deck. Used the Fisher-Yates algorithm, unashamedly stolen from StackOverflow
    public void Shuffle()
    {
        System.Random random = new System.Random();
        int n = deck.Count;  
        while (n > 1) {  
            n--;  
            int k = random.Next(n + 1);  
            Card value = deck[k];  
            deck[k] = deck[n];  
            deck[n] = value;
        }
    } 
}
