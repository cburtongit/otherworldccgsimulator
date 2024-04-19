using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class DarkProwler : MonsterCard
{
    private bool effectSpGained; // flag that determines if the attack has alread been doubled.
    
    // Start is called before the first frame update
    void Start()
    {
        // card stats
        cardName = "Dark Prowler";
        originalName = "Dark Prowler";
        
        alignments.Add("dark");
        alignments.Add("beast");
        originalAlignments.Add("dark");
        originalAlignments.Add("beast");

        rPCost = 2;
        originalRPCost = 2;

        sP = 125;
        originalSP = 125;

        isDestroyBattleImmune = false;
        isDestroyEffectImmune = false;
        isSacrificeable = false;
        isCountered = false;

        isTethered = false;
        canAttack = true;
        isAttackable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCountered) {
            if (!effectSpGained) {
             Effect();
            }
        }
    }

    void Summon() {
        effectSpGained = false;
    }
    
    void Effect() {
        // EFFECT TEXT: (While you control no other monsters) This card’s original SP is doubled.
        
        // if (Controller.Monsters[].length < 2) and (!effectSpGained) {
            // currentSP += 100;
            // effectSpGained = true
        // }
    }
}
