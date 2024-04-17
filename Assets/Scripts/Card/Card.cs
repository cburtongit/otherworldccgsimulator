using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor.UI;
using UnityEngine;

public class Card : MonoBehaviour
{
    
    /* NOTES & PLANS
    - Card objects should have methods for EVERY action performed on them (e.g. destroyed,
        countered, discarded, summoned etc.). this is so if they have an effect (optional 
        or mandatory) when this action is performed, they do not have constantly check in 
        Update() that the action has happened.
    - Card objects should also have boolean variables for every status a card can have
        (e.g. countered, can attack, in the void, tethered etc.) for the same reasons.
    - Possible switch-like statement in Update() to check this?
    - (For Card Scripts) End-of-turn/next turn/stage effects: possible implementation:
        + Cards have a 
    - Checking if a card can activate: 
        Each card could have a bool CanActivate(var eventType) method that determines if a
        card can actiavte in response to a certain event happening (e.g. monster
        destroyed in combat, Support card actiavted, card was discarded etc.)
        Then if the card CAN activate, the method returns TRUE. Example:
        public bool CanActivate(GameEvent event)
        {
            switch (event) {
                case PLAYER_DRAW:
                    return true;
                case PLAYER_DISCARD:
                    return true;
                case SUPPORT_DESTROYED_MONSTER:
                    return true;
                ...
                default:
                    return false
            }
        }
    */
   
    public Player controller, owner; // Player who owns card (at start of game)
    
    // Card in-game Stats. original versions must be stored as are used in-game
    public string cardName, originalName;
    public List<string> alignments, originalAlignments;
    public int rpCost, originalRpCost;
    // public Sprite artwork = GetComponent<Sprite>();

    /* --- CARD STATUSES ---*/
    public bool isDestroyBattleImmune, isDestroyEffectImmune, isSacrificeable, isCountered;

    public void DestroyCard(bool toVoid = false) {}
    public void DiscardCard(bool toVoid = false) {}
    public void Counter()
    {
        isCountered = true;
    }

    public void modifyRP(int change)
    {
        rpCost += change;
    }
}