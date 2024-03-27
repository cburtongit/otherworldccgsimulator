using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
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
    void DestroyCard() 
    {

    }
    void Counter()
    {
        isCountered = true;
    }

    void modifyRP(int change)
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

    void attack() {}
    void summon() {}
    void modifySP(int change) {
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
