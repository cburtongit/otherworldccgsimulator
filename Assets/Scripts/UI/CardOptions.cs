using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardOptions : MonoBehaviour
{
    public GameObject gameMaster, card;
    public Card cScript;
    public GameObject 
    b_summon, b_activate, b_summonfromdeck, b_revive, b_activatefromdeck, 
    b_handshuffleback, b_discard, b_discardvoid, 
    b_search, b_mill, b_millvoid,
    b_recover, b_graveshuffleback, b_void, b_info;

    // To Field
    public void Summon() // from hand - summon a MonsterCard
    {
        Debug.Log("Summon " + cScript.cardName);
    }
    public void Activate() // from hand - activate a SupportCard
    {
        Debug.Log("Play " + cScript.cardName);
    }
    public void SummonFromDeck() // from deck - summon a MonsterCard
    {
        Debug.Log("Summon (from deck) " + cScript.cardName);
    }
    public void Revive() // from grave - summon a MonsterCard
    {
        Debug.Log("Revive " + cScript.cardName);
    }
    public void ActivateFromDeck() // from deck - activate a SupportCard
    {
        Debug.Log("Activate (from deck) " + cScript.cardName);
    }
    // In-Hand
    public void HandShuffleBack() // add to deck
    {
        cScript.owner.ToDeck(card, Player.LOC.HAND);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowHand();  
    }
    public void Discard() // add to grave
    {
        cScript.owner.ToGrave(card, Player.LOC.HAND);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowHand();
    }
    public void DiscardVoid() // add to void
    {
        cScript.owner.ToVoid(card, Player.LOC.HAND);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowHand();
    }
    // In-Deck
    public void Search() // add to hand
    {
        cScript.owner.ToHand(card, Player.LOC.DECK);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowDeck();
    }
    public void Mill() // add to grave
    {
        cScript.owner.ToVoid(card, Player.LOC.DECK);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowDeck();
    }
    public void MillVoid() // add to void
    {
        cScript.owner.ToVoid(card, Player.LOC.DECK);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowDeck();
    }
    // In-Grave
    public void Recover() // add to hand
    {
        cScript.owner.ToHand(card, Player.LOC.GRAVE);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowGrave();
    }
    public void GraveShuffleBack() // add to deck
    {
        cScript.owner.ToDeck(card, Player.LOC.GRAVE);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowGrave();
    }
    public void Void() // add to void
    {
        cScript.owner.ToVoid(card, Player.LOC.GRAVE);
        foreach (GameObject view in GameObject.FindGameObjectsWithTag("uiCardViewer")) { Destroy(view); }
        card.GetComponentInParent<GameUI>().ShowGrave();
    }
    // Misc
    public void Info()
    {
        Debug.Log("NAME: " + cScript.name + '\n' + "TEXT: " + cScript.cardText);
    }
}
