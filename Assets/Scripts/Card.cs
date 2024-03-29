using System.Collections;
using System.Collections.Generic;
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
   
    Player controller, owner; // Player who owns card (at start of game)
    
    // Card in-game Stats. original versions must be stored as are used in-game
    public string cardName, originalName;
    public List<string> alignments, originalAlignments;
    public int rpCost, originalRpCost;
    // public Sprite artwork = GetComponent<Sprite>();

    /* Status of card*/
    public bool isDestroyBattleImmune, isDestroyEffectImmune, isSacrificeable, isCountered;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // What does that card do on destruction
    public void DestroyCard(bool toVoid = false) {}
    public void DiscardCard(bool toVoid = false) {}
    public void CounterCard()
    {
        isCountered = true;
    }

    public void modifyRP(int change)
    {
        rpCost += change;
    }
}

public class MonsterCard : Card
{

    public int sp, originalSp;
    public bool isTethered, canAttack, isAttackable;

    void Start() 
    {
        // cardType = 0;
    }

    void Update() { }

    void Attack() {}
    void Summon() {}
    void ModifySP(int change) {
        sp += change;
    }
}

public class SupportCard : Card
{

    public bool staysOnField; // 0 = no, 1 = yes
    public int fastRp, originalFastRp;
    
    // Unity methods
    void Start() {}
    void Update() {}

    void modifyFastRp(int change)
    {
        fastRp += change;
    }
    // called when a card is activated
    // void activate() {}
    // void effect() {}

}

public class TetherSupportCard : SupportCard
{

    public MonsterCard target; // the monster card that this card is tethered to
    
    void Start() {
        staysOnField = true;
    }

    void Update() {}
}

public class FixedSupportCard : SupportCard
{
    void Start() {
        staysOnField = true;
    }
    void Update() {}
}
