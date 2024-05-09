using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using JetBrains.Annotations;
using TMPro;
using UnityEditor;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameMaster : MonoBehaviour
{

    public GameObject p1, p2;
    Player p1script, p2script;
    public int turnCount;
    public GameObject turnPlayer;
    public enum stage {
        DRAW,
        SETUP,
        COMBAT
    }
    public stage turnStage = stage.DRAW;

    void Start()
    {
        // easily store script components, cleans up code
        p1script = p1.GetComponent<Player>();
        p2script = p2.GetComponent<Player>();
        // set HP
        p1script.hp = p2script.hp = 1000;
        p1script.rp = p2script.rp = 0;
        // load & shuffle decks
        GenPlayerDecksFromFile_debug(p1, "Decks/demo_fire");
        GenPlayerDecksFromFile_debug(p2, "Decks/demo_fire");
        p1script.ShuffleDeck();
        p2script.ShuffleDeck();
        // Draw starting hand
        p1script.DrawCard(5);
        p2script.DrawCard(5);
        // setup the turn
        turnCount = 0; turnPlayer = p2; NextTurn();
        
    }

    public void SwitchTurnPlayer()
    {
        if (turnPlayer == p2) { turnPlayer = p1; }
        else if (turnPlayer == p1) { turnPlayer = p2; }
        else { Debug.Log("Error - turn player not p1 or p2."); Application.Quit(); }
    }
    public void GoToDrawStage()
    {
        Player tpScript = turnPlayer.GetComponent<Player>();
        turnStage = stage.DRAW;
        // reset RP and Draw card.
        tpScript.rp = turnCount*2;
        tpScript.DrawCard();
    }
    public void GoToSetupStage()
    {
        turnStage = stage.SETUP;
    }
    public void GoToCombatStage()
    {
        turnStage = stage.COMBAT;
    }
    public void NextTurn()
    {
        // increase the turn count as the first action
        turnCount++;
        SwitchTurnPlayer();
        GoToDrawStage();
    }

    void Update()
    {
        
    }

    public void GenPlayerDecks_debug(GameObject player)
    {
        Sprite testPic = Resources.Load<Sprite>("Images/artwork/DarkProwler");
        
        for (int i = 0; i < 45; i++) {
            // create new object, add components
            GameObject card = new GameObject();
            card.name = "Dark Prowler-" + i + " (P " + player.GetComponent<Player>().playerId + ")";
            card.AddComponent<RectTransform>();
            card.AddComponent<MonsterCard>();
            card.AddComponent<SpriteRenderer>();
            card.AddComponent<UnityEngine.UI.Image>();
            
            /* ASSIGN STATS */
            card.GetComponent<Card>().controller = card.GetComponent<Card>().owner = player.GetComponent<Player>();
            card.GetComponent<Card>().cardName = card.GetComponent<MonsterCard>().originalName = "Dark Prowler " + i + " (playerID: " + player.GetComponent<Player>().playerId + ")";
            card.GetComponent<Card>().rPCost = card.GetComponent<MonsterCard>().originalRPCost = 2;
            card.GetComponent<Card>().alignments.Add("Dark");
            card.GetComponent<Card>().alignments.Add("Beast");
            card.GetComponent<Card>().originalAlignments = card.GetComponent<Card>().alignments;
            card.GetComponent<Card>().serial = "00000" + i;
            card.GetComponent<MonsterCard>().sP = card.GetComponent<MonsterCard>().originalSP = 125;
            card.GetComponent<MonsterCard>().isDestroyBattleImmune = card.GetComponent<MonsterCard>().isDestroyEffectImmune = card.GetComponent<MonsterCard>().isCountered = card.GetComponent<MonsterCard>().isTethered = false;
            
            card.GetComponent<SpriteRenderer>().sprite = testPic; // assignArtwork
            card.GetComponent<UnityEngine.UI.Image>().sprite = testPic; // ui image
            card.SetActive(false);
            player.GetComponent<Player>().deck.Add(card);
            card.transform.SetParent(player.transform);
        }
    }

    String[] LoadDeckFromFile(String deckname)
    {
        TextAsset deckFile = Resources.Load<TextAsset>(deckname);
        return deckFile.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    }
    public void GenPlayerDecksFromFile_debug(GameObject player, String deckname) {
        String[] deckList = LoadDeckFromFile(deckname);
        foreach (String id in deckList) {
            // create game object, set as inactive, assign object name in editor
            GameObject card = new GameObject();
            card.SetActive(false);
            card.name = "Card-" + id;
            // add necessary unity components
            card.AddComponent<RectTransform>();
            card.AddComponent<Card>();
            card.AddComponent<SpriteRenderer>();
            card.AddComponent<UnityEngine.UI.Image>();
            // add card stats (dummy values for now)
            card.GetComponent<Card>().controller = card.GetComponent<Card>().owner = player.GetComponent<Player>();
            card.GetComponent<Card>().cardName = card.GetComponent<Card>().originalName = "Card-" + id;
            card.GetComponent<Card>().rPCost = card.GetComponent<Card>().originalRPCost = 0;
            card.GetComponent<Card>().alignments.Add("Test");
            card.GetComponent<Card>().originalAlignments = card.GetComponent<Card>().alignments;
            card.GetComponent<Card>().serial = id;
            // add artwork from file
            Sprite art = Resources.Load<Sprite>("Images/cards/" + id);
            card.GetComponent<SpriteRenderer>().sprite = card.GetComponent<UnityEngine.UI.Image>().sprite = art;
            // add to player's deck & add it as a child of the player object
            player.GetComponent<Player>().deck.Add(card);
            card.transform.SetParent(player.transform);
        }
    }
}
