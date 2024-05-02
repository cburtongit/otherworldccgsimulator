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
    public Player player, opp;
    public GameObject pHealthManaDisplay, cardView;

    public void Start()
    {
        player = gameMaster.GetComponent<GameMaster>().p1.GetComponent<Player>();
        opp = gameMaster.GetComponent<GameMaster>().p2.GetComponent<Player>();
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

    public void ShowHand(Player player)
    {
        List<GameObject> hand = new List<GameObject>();
        foreach (GameObject card in player.hand) {
            GameObject copy = Instantiate(card);
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            hand.Add(copy);
        }
        ShowCardViewPanel(hand);
    }

    public void ShowDeck(Player player)
    {
        List<GameObject> deck = new List<GameObject>();
        foreach (GameObject card in player.deck) {
            GameObject copy = Instantiate(card);
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            deck.Add(copy);
        }
        ShowCardViewPanel(deck);
    }

    public void ShowGrave(Player player)
    {
        List<GameObject> grave = new List<GameObject>();
        foreach (GameObject card in player.grave) {
            GameObject copy = Instantiate(card);
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            grave.Add(copy);
        }
        ShowCardViewPanel(grave);
    }

    public void ShowTheVoid(Player player)
    {
        List<GameObject> daVoid = new List<GameObject>();
        foreach (GameObject card in player.theVoid) {
            GameObject copy = Instantiate(card);
            Destroy(copy.GetComponent<SpriteRenderer>()); // remove unecessary component
            daVoid.Add(copy);
        }
        ShowCardViewPanel(daVoid);
    }

    public void ShowCardList(List<GameObject> list)
    {
        String cardsDebug = "Cards in hand: ";
        foreach(GameObject card in list) {
            cardsDebug += card.GetComponent<Card>().cardName += ", ";
        }
        Debug.Log(cardsDebug);
    }

    public void CheckHP()
    {
        GameObject[] Players;
        Players = GameObject.FindGameObjectsWithTag("Player");
        int i = 0;
        foreach (GameObject player in Players) {
            Debug.Log("Player " + i + " HP: " + player.GetComponent<Player>().hp);
            i++;
        }
    }
    public void CheckRP()
    {
        GameObject[] Players;
        Players = GameObject.FindGameObjectsWithTag("Player");
        int i = 0;
        foreach (GameObject player in Players) {
            Debug.Log("Player " + i + " RP: " + player.GetComponent<Player>().rp);
            i++;
        }
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
