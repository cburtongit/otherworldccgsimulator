using System;
using System.Collections.Generic;
using System.Numerics;
using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public int stage = 0;
    public GameObject gameMaster;
    public GameObject player, op;
    public Player playerScript, opScript;
    public GameObject pHealthManaDisplay, cardView;

    public void Start()
    {
        player = gameMaster.GetComponent<GameMaster>().p1;
        op = gameMaster.GetComponent<GameMaster>().p2;
        playerScript = player.GetComponent<Player>();
        opScript = op.GetComponent<Player>();
    }
    
    public void Update()
    {
        //pHealthManaDisplay.GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + player.hp + " | RP: " + player.rp;   
    }
    
    public void DisplayHealthMana(Player player)
    {
        
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

    public void NextStage()
    {
        if (stage >= 2) {stage = 0;} 
        else {stage++;}
    }

    public void ShowHand()
    {
        List<GameObject> hand = new List<GameObject>();
        foreach (GameObject card in playerScript.hand) {
            GameObject copy = Instantiate(card);
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            hand.Add(copy);
        }
        ShowCardViewPanel(hand);
    }

    public void ShowDeck()
    {
        List<GameObject> deck = new List<GameObject>();
        foreach (GameObject card in playerScript.deck) {
            GameObject copy = Instantiate(card);
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            deck.Add(copy);
        }
        ShowCardViewPanel(deck);
    }

    public void ShowGrave()
    {
        List<GameObject> grave = new List<GameObject>();
        foreach (GameObject card in playerScript.grave) {
            GameObject copy = Instantiate(card);
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            grave.Add(copy);
        }
        ShowCardViewPanel(grave);
    }

    public void ShowTheVoid()
    {
        List<GameObject> theVoid = new List<GameObject>();
        foreach (GameObject card in playerScript.theVoid) {
            GameObject copy = Instantiate(card);
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            theVoid.Add(copy);
        }
        ShowCardViewPanel(theVoid);
    }  
    public void SurrenderGame()
    {
        Debug.Log("Surrendered.");
    }
    public void ShowCardViewPanel(List<GameObject> cards)
    {
        // Instantiate a new panel GameObject
        //GameObject viewPanel = new GameObject("Panel");
        GameObject view = Instantiate(cardView, new UnityEngine.Vector3(0, 0, 0), UnityEngine.Quaternion.identity);
        
        view.transform.SetParent(this.transform);
        view.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
        foreach (GameObject card in cards) {
            card.transform.SetParent(view.GetComponent<CardView>().content.transform);
            card.transform.localScale = new UnityEngine.Vector3(1f,1f,1f);
            card.GetComponent<RectTransform>().sizeDelta = new UnityEngine.Vector2(200, 280);
            card.SetActive(true);
        }
    }
}
