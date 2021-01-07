using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TestAI : MonoBehaviour
{
    public bool CheckState;
    public  bool Drunk;
    public  int Strength;

    public void RandomizeStats()
    {
        if (Random.Range(0, 10) < 5)
        {
            Drunk = true;
        }
        else
        {
            Drunk = false;
        } 
        Strength = Random.Range(0, 10);

    }

    // Start is called before the first frame update
    void Start()
    {
        RandomizeStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
