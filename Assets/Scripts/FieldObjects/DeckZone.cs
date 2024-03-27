using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        Console.WriteLine("Deck Clicked!");
        Destroy(gameObject);
    }
}
