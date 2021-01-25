using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using Random = UnityEngine.Random;
using BehaviorDesigner.Runtime;
using UnityEngine.Serialization;

public enum BathroomType
{
    Urinate = 1,
    Poop,
    Barf
}

public class TestAI : MonoBehaviour
{
    public BehaviorTree generalTree;
    [FormerlySerializedAs("Drunk")] public  bool drunk;
    [FormerlySerializedAs("NeedBathroom")] public bool needBathroom = false;
    public float bladderMax = 1000;
    public float bladder;
    public float bladderIncrement = 0.1f;
    public  int bladderNumber;
    public float drunkDecrement = 0.1f;
    public float drunkMeter;
    public float socialDecrement = 0.1f;
    public float socialMeter;
    // Trae- We should change change the sub traits and personalities into a dictionary, so we can better find traits that may change outcomes of events; so they will not be implemented until then.
    public string[] allPersonalities = {"Shy", "Rude", "Gregarious", "Oblivious"};
    public string[] allSubTraits = {"Alcoholic", "Fast", "Slow", "Clumsy", "Lightweight", "Fickle", "Sociable", "Serious"};
    public string personality;
    public string[] subTraits;
    



    public float IncrementNeedForBathroom()
    {
        bladder += bladderIncrement;
        if(bladder >= bladderMax) {
            generalTree.SendEvent<object>("GoBathroom", 1);
            needBathroom = true;
            bladderNumber = Random.Range(0,10) < 5 ? 1 : 2;
            bladder = 0;
            needBathroom = false;
        }

        return bladder;

    }
    public void RandomizeStats()
    {       
        if (Random.Range(0, 10) < 5)
        {
            drunk = true;
            drunkMeter = 100;
            socialMeter = 100;

        }
        else
        {
            drunk = false;
            socialMeter = 200;

        }

    }

    public void CheckNeedForBooze()
    {
        drunkMeter -= drunkDecrement;
       
        if (drunkMeter < 50)
        {
            generalTree.SendEvent<object>("GetDrink", 2);
        }
    }

    public void CheckNeedForSocializing()
    {
        if (socialMeter < 25)
        {
            generalTree.SendEvent<object>("GoTalk", 3);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        var behaviorTrees = GetComponents<BehaviorTree>();
        foreach (var behaviorTree in behaviorTrees)
        {
            if (behaviorTree.BehaviorName == "General Behavior")
            {
                generalTree = behaviorTree;
            }
        }
        RandomizeStats();
    }

    // Update is called once per frame
    void Update()
    {
        IncrementNeedForBathroom();
        CheckNeedForBooze();
    }
}