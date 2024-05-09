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
    public void Activate()
    {
        Debug.Log("Play " + cScript.cardName);
    }
    public void Revive()
    {
        Debug.Log("Revive " + cScript.cardName);
    }
    public void Info()
    {
        Debug.Log("NAME: " + cScript.name + '\n' + "TEXT: " + cScript.cardText);
    }
    public void Discard()
    {
        cScript.owner.ToGrave(card, Player.LOC.HAND);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowHand();
    }
    public void DiscardVoid()
    {
        cScript.owner.ToVoid(card, Player.LOC.HAND);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
    }
    public void HandShuffleBack()
    {
        cScript.owner.ToDeck(card, Player.LOC.DECK);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }   
    }
    public void Search()
    {
        cScript.owner.ToHand(card, Player.LOC.DECK);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
    }
    public void Recover()
    {
        cScript.owner.ToHand(card, Player.LOC.GRAVE);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
    }
    public void Mill()
    {
        cScript.owner.ToVoid(card, Player.LOC.DECK);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
    }
    public void MillVoid()
    {
        cScript.owner.ToVoid(card, Player.LOC.DECK);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
    }
}
