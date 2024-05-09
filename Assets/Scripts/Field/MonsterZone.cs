using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterZone : MonoBehaviour
{
    
    public int zoneId;
    public bool occupied;
    public GameObject owner, monster;
    
    void OnMouseDown()
    {
        // Debug.Log("MonsterZone " + zoneId + " clicked");
    }
}
