using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTest : MonoBehaviour
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
        if (stage >= 2) {
            stage = 0;
        } else {
            stage++;
        }
        switch (stage) {
            case 0:
                Debug.Log("DRAW STAGE (0)");
                break;
            case 1:
                Debug.Log("SETUP STAGE (1)");
                break;
            case 2:
                Debug.Log("COMBAT STAGE (2)");
                break;
            default:
                Debug.Log("Error: Stage var not valid!");
                break;
        }
    }

    public void ShowHand()
    {
        // Unhide/Create UI panel
        // Populate with card images from card objs in player.hand list
        Debug.Log("Hand.");
    }

    public void ShowDeck()
    {
        // Unhide/Create UI panel
        // Populate with card images from card objs in player.deck list
        Debug.Log("Deck.");
    }

    public void ShowGrave()
    {
        // Unhide/Create UI panel
        // Populate with card images from card objs in player.grave list
        Debug.Log("Grave.");
    }

    public void ShowTheVoid()
    {
        // Unhide/Create UI panel
        // Populate with card images from card objs in player.theVoid list
        Debug.Log("Void.");
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
}
