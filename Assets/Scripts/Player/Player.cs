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
    public List<GameObject> hand = new List<GameObject>();
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> grave = new List<GameObject>();
    public List<GameObject> theVoid = new List<GameObject>();

    
    // Start is called before the first frame update
    void Start()
    {
        /* TESTING */
        /* hp = 1000;
        Sprite testPic = Resources.Load<Sprite>("Images/artwork/DarkProwler");
        for (int i = 0; i < 10; i++) {
            // create new object, add components
            GameObject card = new GameObject();
            card.name = "Card " + i;
            card.AddComponent<RectTransform>();
            card.AddComponent<MonsterCard>();
            card.AddComponent<SpriteRenderer>();
            // ASSIGN STATS 
            card.GetComponent<Card>().controller = card.GetComponent<Card>().owner = this;
            card.GetComponent<MonsterCard>().cardName = card.GetComponent<MonsterCard>().originalName = "Dark Prowler " + i;

            card.GetComponent<MonsterCard>().rPCost = card.GetComponent<MonsterCard>().originalRPCost = 2;
            
            card.GetComponent<MonsterCard>().alignments.Add("Dark");
            card.GetComponent<MonsterCard>().alignments.Add("Beast");
            card.GetComponent<MonsterCard>().originalAlignments = card.GetComponent<MonsterCard>().alignments;

            card.GetComponent<MonsterCard>().serial = "00000" + i;

            card.GetComponent<MonsterCard>().isDestroyBattleImmune = card.GetComponent<MonsterCard>().isDestroyEffectImmune = card.GetComponent<MonsterCard>().isCountered = card.GetComponent<MonsterCard>().isTethered = false;

            card.GetComponent<SpriteRenderer>().sprite = testPic;

            card.SetActive(false);
            deck.Add(card);
        } */
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
        if (deck.Count > 0) { 
            for (int i = 0; i < numOfCards; i++) {
                Debug.Log("DRAWING: " + deck[0]);
                hand.Add(deck[0]);
                deck.RemoveAt(0);
                Debug.Log("DRAW successful.");
                debug_j++;
            }
        } else {Debug.Log("Deck is empty!"); }
        Debug.Log(debug_j + " card(s) drawn.");
        /*for (int i = 0; i < numOfCards; i++) { // draws from bottom of the deck
            Debug.Log("Attempting to draw card (from bottom of deck): " + deck[0]);
            hand.Add(deck[deck.Count - 1]);
            deck.RemoveAt(deck.Count - 1);
            Debug.Log("Add successful.");
        }*/
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

    public void voidFromGrave(GameObject target)
    {
        foreach (GameObject card in grave) {
            if (card == target) {
                Debug.Log("VOIDING: " + card.GetComponent<MonsterCard>().cardName);
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
