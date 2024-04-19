using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuFunctions : MonoBehaviour
{
    public int stage = 0;

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
        ShowCardList(player.hand);
        // Unhide/Create UI panel
        // Populate with card images from card objs in player.hand list
        String cardsInHand = "Cards in hand: ";
        foreach(GameObject card in player.hand) {
            cardsInHand += card.GetComponent<Card>().cardName += ", ";
        }
        Debug.Log(cardsInHand);
    }

    public void ShowDeck(Player player)
    {
        // Unhide/Create UI panel
        // Populate with card images from card objs in player.deck list
        ShowCardList(player.deck);
    }

    public void ShowGrave(Player player)
    {
        // Unhide/Create UI panel
        // Populate with card images from card objs in player.grave list
        ShowCardList(player.grave);
    }

    public void ShowTheVoid(Player player)
    {
        // Unhide/Create UI panel
        // Populate with card images from card objs in player.theVoid list
        ShowCardList(player.theVoid);
    }

    public void ShowCardList(List<GameObject> list)
    {
        foreach(GameObject card in list) {
            Debug.Log(card.GetComponent<Card>().cardName);
        }
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

    public void ShowHandView(GameObject hand)
    {
        hand.SetActive(!hand.activeSelf);
        GameObject[] hoverItems = GameObject.FindGameObjectsWithTag("hoverMenu");
        foreach (GameObject item in hoverItems) {
            item.SetActive(false);
        }
    }
}
