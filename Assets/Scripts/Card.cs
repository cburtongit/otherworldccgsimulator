using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    Player controller, owner; // Player who owns card (at start of game)
    
    // Card in-game Stats. original versions must be stored as are used in-game
    string cardName, originalName;
    List<string> alignments, originalAlignments;
    int rpCost, originalRpCost;
    // public Sprite artwork = GetComponent<Sprite>();

    /* Status of card*/
    public bool isDestroyBattleImmune, isDestroyEffectImmune, isSacrificeable;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // What does that card do on destruction
    void Destroy() { }

}

public class MonsterCard : Card
{

    public int sp, originalSp;
    public bool isCountered;
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

    public int staysOnField; // 0 = no, 1 = yes
    public int fastRp, originalFastRp;
    
    void Start() { }
    void Update() { }
}

public class TetherSupportCard : SupportCard
{
    
    
    public MonsterCard target;
    
    void Start(MonsterCard tetherTarget) {
        staysOnField = 1;
        target = tetherTarget;
    }

    void Update() { }
}

public class FixedSupportCard : SupportCard
{

}
