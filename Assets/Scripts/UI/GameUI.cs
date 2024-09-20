using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    public enum LOC {HAND, DECK, GRAVE, VOID, NONE}
    public GameObject gameMaster, player, op;
    public Player pScript, opScript;
    public GameObject pHPRP, oHPRP, cardView, cardOptions, cardOptTest;
    public bool playerIsViewingCards = false;
    public bool playerIsViewingCardOptions = false;

    public void Start()
    {
        // assign player variables from GameMaster
        player = gameMaster.GetComponent<GameMaster>().p1;
        op = gameMaster.GetComponent<GameMaster>().p2;
        pScript = player.GetComponent<Player>();
        opScript = op.GetComponent<Player>();
        // Update Player & Opponent health displays on the UI
        UpdateHPMP(pScript, true);
        UpdateHPMP(opScript, false);
    }
    public void Update()
    {
        
    }
    public void UpdateHPMP(Player p, bool isPlayer)
    {
        if (isPlayer) { pHPRP.GetComponent<TMPro.TextMeshProUGUI>().text = "(P1) HP: " + p.hp + " | RP: " + p.rp; } 
        else {oHPRP.GetComponent<TMPro.TextMeshProUGUI>().text = "(P1) HP: " + p.hp + " | RP: " + p.rp;}
    }
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting application...");
        Application.Quit();
        Debug.Log("Application quit.");
    }

    public void ShowHand()
    {
        foreach (GameObject viewer in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(viewer); }
        List<GameObject> hand = new List<GameObject>();
        foreach (GameObject card in pScript.hand) {
            GameObject copy = Instantiate(card);
            copy.GetComponent<Card>().selfRef = card;
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            hand.Add(copy);
        }
        ShowCardViewPanel(hand, LOC.HAND);
    }
    public void ShowDeck()
    {
        // destroy all over viewers - will need to change this when automated!
        foreach (GameObject viewer in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(viewer); }
        List<GameObject> deck = new List<GameObject>();
        foreach (GameObject card in pScript.deck) {
            GameObject copy = Instantiate(card);
            copy.GetComponent<Card>().selfRef = card;
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            deck.Add(copy);
        }
        ShowCardViewPanel(deck, LOC.DECK);
    }
    public void ShowGrave()
    {
        foreach (GameObject viewer in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(viewer); }
        List<GameObject> grave = new List<GameObject>();
        foreach (GameObject card in pScript.grave) {
            GameObject copy = Instantiate(card);
            copy.GetComponent<Card>().selfRef = card;
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            grave.Add(copy);
        }
        ShowCardViewPanel(grave, LOC.GRAVE);
    }
    public void ShowTheVoid()
    {
        List<GameObject> theVoid = new List<GameObject>();
        foreach (GameObject card in pScript.theVoid) {
            GameObject copy = Instantiate(card);
            copy.GetComponent<Card>().selfRef = card;
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            theVoid.Add(copy);
        }
        ShowCardViewPanel(theVoid, LOC.VOID);
    }  
    void ShowCardViewPanel(List<GameObject> cards, LOC loc = LOC.NONE)
    {
        // Create an instance of the CardView Prefab, set it as a child of the canvas
        GameObject view = Instantiate(cardView, new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity);
        view.name = "CardView"; view.tag = "uiCardViewer";
        view.transform.SetParent(this.transform);
        view.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
        // create copies of each card in the list and add them to the 'content' child of the viewer
        foreach (GameObject card in cards) {
            // set the scale and size of the cards
            card.transform.SetParent(view.GetComponent<CardView>().content.transform);
            card.transform.localScale = new UnityEngine.Vector3(1f,1f,1f);
            card.GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector2(200, 280);
            //CreateCardOptionsPanel(card);
            CreateCardOptions(card, loc);
            card.SetActive(true);
        }
    }
    void CreateCardOptions(GameObject card, LOC loc = LOC.NONE, bool isMonster = true)
    {
        GameObject options = Instantiate(cardOptions, card.transform.position, UnityEngine.Quaternion.identity);
        options.name = "CardOptions"; options.tag = "uiCardOptions";
        options.GetComponent<CardOptions>().gameMaster = gameMaster; 
        options.GetComponent<CardOptions>().card = card;
        options.GetComponent<CardOptions>().cScript = card.GetComponent<Card>();
        options.transform.SetParent(card.transform);
        options.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
         // set the options for the buttons depending on location
        SetButtonInCardOptions(options.GetComponent<CardOptions>(), loc, true);
        // align the panel from the TOP MIDDLE (like in the editor)
        options.GetComponent<RectTransform>().anchorMin = new UnityEngine.Vector2(0f, 0f);
        options.GetComponent<RectTransform>().anchorMax = new UnityEngine.Vector2(1f, 1f);
        options.GetComponent<RectTransform>().pivot = new UnityEngine.Vector2(0.5f, 0.5f);
        options.GetComponent<RectTransform>().offsetMin = new UnityEngine.Vector2(options.GetComponent<RectTransform>().offsetMin.x, 0);
        options.GetComponent<RectTransform>().offsetMin = new UnityEngine.Vector2(options.GetComponent<RectTransform>().offsetMin.y, 0);
        options.GetComponent<RectTransform>().offsetMax = new UnityEngine.Vector2(options.GetComponent<RectTransform>().offsetMin.x, 0);
        options.GetComponent<RectTransform>().offsetMax = new UnityEngine.Vector2(options.GetComponent<RectTransform>().offsetMin.y, 0);
        // create and set the function for the cardOptions panel, toggle it when clicked and toggle off any other ones.
        card.AddComponent<Toggle>();
        card.GetComponent<Toggle>().onValueChanged.AddListener(delegate { 
            foreach (GameObject menu in GameObject.FindGameObjectsWithTag("uiCardOptions")) {menu.SetActive(false);}
            options.SetActive(!options.activeSelf); 
        });
        options.SetActive(false);
    }
    void SetButtonInCardOptions(CardOptions opt, LOC loc, bool isMonster)
    {
        if (isMonster) { opt.b_activate.SetActive(false); opt.b_activatefromdeck.SetActive(false); } // remove supportcard options
        else { opt.b_summon.SetActive(false); opt.b_summonfromdeck.SetActive(false); opt.b_revive.SetActive(false); } // remove monstercard options
        switch (loc) {
            case LOC.HAND:
            opt.b_search.SetActive(false); opt.b_mill.SetActive(false); opt.b_millvoid.SetActive(false); opt.b_summonfromdeck.SetActive(false); // remove deck options
            opt.b_recover.SetActive(false); opt.b_graveshuffleback.SetActive(false); opt.b_void.SetActive(false); opt.b_revive.SetActive(false); opt.b_recover.SetActive(false); // remove grave options
            break;
            case LOC.DECK:
            opt.b_handshuffleback.SetActive(false); opt.b_discard.SetActive(false); opt.b_discardvoid.SetActive(false); opt.b_summon.SetActive(false); // remove hand options
            opt.b_recover.SetActive(false); opt.b_graveshuffleback.SetActive(false); opt.b_void.SetActive(false); opt.b_revive.SetActive(false); opt.b_recover.SetActive(false); // remove grave options
            break;
            case LOC.GRAVE:
            opt.b_handshuffleback.SetActive(false); opt.b_discard.SetActive(false); opt.b_discardvoid.SetActive(false); // remove hand options
            opt.b_search.SetActive(false); opt.b_mill.SetActive(false); opt.b_millvoid.SetActive(false); opt.b_summonfromdeck.SetActive(false); // remove deck options
            break;
            case LOC.VOID:
            opt.b_handshuffleback.SetActive(false); opt.b_discard.SetActive(false); opt.b_discardvoid.SetActive(false); opt.b_summon.SetActive(false); // remove hand options
            opt.b_search.SetActive(false); opt.b_mill.SetActive(false); opt.b_millvoid.SetActive(false); opt.b_summonfromdeck.SetActive(false); // remove deck options
            opt.b_recover.SetActive(false); opt.b_graveshuffleback.SetActive(false); opt.b_void.SetActive(false); opt.b_revive.SetActive(false); opt.b_recover.SetActive(false); // remove grave options
            break;
            case LOC.NONE: Debug.Log("SetButtonInCardOptions 'loc' param set to LOC.NONE"); break;
            default: Debug.Log("SetButtonInCardOptions switch(loc) default case reached"); break;
        }
    }

}
