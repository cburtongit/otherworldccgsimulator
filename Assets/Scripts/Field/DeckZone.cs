using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeckZone : MonoBehaviour
{
    public GameObject gameMaster;
    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = gameMaster.GetComponent<GameMaster>().p1.GetComponent<Player>();
    }
    void OnMouseEnter()
    {
        
    }

    void OnMouseDown()
    {
        player.DrawCard();
    }
}
