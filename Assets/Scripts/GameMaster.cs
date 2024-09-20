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

    public enum LOC { HAND, DECK, GRAVE, VOID, NONE }
    public GameObject p1, p2;
    Player p1script, p2script;
    public int turnCount;
    public GameObject turnPlayer;
    public enum STAGE { DRAW, SETUP, COMBAT } public STAGE turnStage = STAGE.DRAW;
    public TextAsset cardDB;
    [System.Serializable] public class DBitem { public string serial, name, type, alignments, sp, rp, fastrp, text; }
    [System.Serializable] public class DBitemList { public DBitem[] dbitems; }
    DBitemList dbList = new DBitemList();

    public string[] DBAfterSplit;
    void Start()
    {
        // easily store script components, cleans up code
        p1script = p1.GetComponent<Player>();
        p2script = p2.GetComponent<Player>();
        // set HP
        p1script.hp = p2script.hp = 1000;
        p1script.rp = p2script.rp = 0;
        // load & shuffle decks
        GenDecksFromFile_debug(p1, "Decks/demo_fire");
        GenDecksFromFile_debug(p2, "Decks/demo_fire");
        p1script.ShuffleDeck();
        p2script.ShuffleDeck();
        // Draw starting hand
        p1script.DrawCard(5);
        p2script.DrawCard(5);
        // setup the turn
        turnCount = 0; turnPlayer = p2; NextTurn();

        LoadCardDB();
        
    }

    void SwitchTurnPlayer()
    {
        if (turnPlayer == p2) { turnPlayer = p1; }
        else if (turnPlayer == p1) { turnPlayer = p2; }
        else { Debug.Log("Error - turn player not p1 or p2."); Application.Quit(); }
    }
    public void GoToDrawStage()
    {
        Player tpScript = turnPlayer.GetComponent<Player>();
        turnStage = STAGE.DRAW;
        // reset RP and Draw card.
        tpScript.rp = turnCount*2;
        tpScript.DrawCard();
    }
    public void GoToSetupStage()
    {
        turnStage = STAGE.SETUP;
    }
    public void GoToCombatStage()
    {
        turnStage = STAGE.COMBAT;
    }
    public void NextTurn()
    {
        // increase the turn count as the first action
        turnCount++;
        SwitchTurnPlayer();
        GoToDrawStage();
    }
    String[] LoadDeckFromFile(String deckname)
    {
        TextAsset deckFile = Resources.Load<TextAsset>(deckname);
        return deckFile.ToString().Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
    }
    void GenDecksFromFile_debug(GameObject player, String deckname)
    {
        String[] deckList = LoadDeckFromFile(deckname);
        foreach (String id in deckList) {
            // create game object, set as inactive, assign object name in editor
            GameObject card = new GameObject("Card-" + id, typeof(RectTransform), typeof(Card), typeof(SpriteRenderer), typeof(UnityEngine.UI.Image));
            card.SetActive(false);
            // add card stats (dummy values for now)
            card.GetComponent<Card>().controller = card.GetComponent<Card>().owner = player.GetComponent<Player>();
            card.GetComponent<Card>().cardName = card.GetComponent<Card>().originalName = "card-" + id;
            card.GetComponent<Card>().rPCost = card.GetComponent<Card>().originalRPCost = 0;
            card.GetComponent<Card>().alignments.Add("test");
            card.GetComponent<Card>().originalAlignments = card.GetComponent<Card>().alignments;
            card.GetComponent<Card>().serial = id;
            card.GetComponent<Card>().cardText = "This is a test card. It does nothing.";
            // add artwork from file
            Sprite art = Resources.Load<Sprite>("Images/cards/" + id);
            card.GetComponent<SpriteRenderer>().sprite = card.GetComponent<UnityEngine.UI.Image>().sprite = art;
            // add to player's deck & add it as a child of the player object
            player.GetComponent<Player>().deck.Add(card);
            card.transform.SetParent(player.transform);
        }
    }
    void GenDecksFromDB(GameObject player, String deckname)
    {
        String[] deckList = LoadDeckFromFile(deckname);
        foreach (String id in deckList) {
            // create game object, set as inactive, assign object name in editor
            GameObject card = new GameObject("Card-" + id, typeof(RectTransform), typeof(Card), typeof(SpriteRenderer), typeof(UnityEngine.UI.Image));
            card.SetActive(false);
            // check card ID
            // load in from database using ID
            // check if monster or spel
            // assign values from database
            // load artwork from folder using ID

        }
    }
    void LoadCardDB(String dbName = "")
    {
        cardDB = Resources.Load<TextAsset>("Database/owccg_db");
        ReadCSV();
    }
    void ReadCSV()
    {
        string[] data = cardDB.text.Split(new string[] {",", "\n"}, StringSplitOptions.None);
        DBAfterSplit = data;
        int tableSize = data.Length / 4 - 1;
        dbList.dbitems = new DBitem[tableSize];

        for (int i = 0; i < tableSize; i++) {
            dbList.dbitems[i] = new DBitem();
            dbList.dbitems[i].serial = data[8 * (i + 1)];
            dbList.dbitems[i].name = data[8 * (i + 1) + 1];
            dbList.dbitems[i].type = data[8 * (i + 1) + 2];
            dbList.dbitems[i].alignments = data[8 * (i + 1) + 3];
            dbList.dbitems[i].sp = data[8 * (i + 1) + 4];
            dbList.dbitems[i].rp = data[8 * (i + 1) + 5];
            dbList.dbitems[i].fastrp = data[8 * (i + 1) + 6];
            dbList.dbitems[i].text = data[8 * (i + 1) + 7];

            // ATTENTION!: 'Alignments' field has commas in it and are counted as separate items in the separation process!
        }
    }

}
