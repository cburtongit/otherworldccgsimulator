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
        summon();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCountered) {
            if (!effectSpGained) {
             effect();
            }
        }
    }

    void summon() {
        effectSpGained = false;   
    }
    
    void effect() {
        // EFFECT TEXT: (While you control no other monsters) This card’s original SP is doubled.
        
        // if (Controller.Monsters[].length < 2) and (!effectSpGained) {
            // currentSP += 100;
            // effectSpGained = true
        // }
    }
}
