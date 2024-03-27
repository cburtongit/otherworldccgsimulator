using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    
    public List<Card> hand = new List<Card>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToHand(Card card) 
    {
        hand.Add(card);
        Debug.Log("Added card: " + card + " to hand.");
    }

    void OnMouseDown()
    {
        Debug.Log("Hand clicked.");
        for (int i = 0; i < hand.Count; i++) {
            Debug.Log(hand[i]);
        }
    }

    // shuffles the hand. Used the Fisher-Yates algorithm, unashamedly stolen from StackOverflow
    public void Shuffle()
    {
        System.Random random = new System.Random();
        int n = hand.Count;  
        while (n > 1) {  
            n--;  
            int k = random.Next(n + 1);  
            Card value = hand[k];  
            hand[k] = hand[n];  
            hand[n] = value;
        }
    } 
}
