using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{

    public Player p1, p2;
    public GameObject p1HealthManaText;
    public int turnPlayer, turnStage;

    void Start()
    {
        
    }

    void Update()
    {
        p1HealthManaText.GetComponent<TMPro.TextMeshProUGUI>().text = "HP: " + p1.hp + " | RP: " + p1.rp;
    }
}
