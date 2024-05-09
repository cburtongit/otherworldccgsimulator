using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardOptions : MonoBehaviour
{
    public GameObject gameMaster, card;
    public Card cScript;

    public void Summon()
    {
        Debug.Log("Summon " + cScript.cardName);
    }
    public void Info()
    {
        Debug.Log("Info " + cScript.cardName);
    }
    public void Discard()
    {
        Debug.Log("Discard " + cScript.cardName);
    }
    public void Void()
    {
        Debug.Log("Void " + cScript.cardName);
    }
    public void ShuffleBack()
    {

    }

}
