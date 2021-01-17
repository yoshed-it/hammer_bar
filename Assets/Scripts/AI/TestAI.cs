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
    public BehaviorTree bathroomTree;
    [FormerlySerializedAs("Drunk")] public  bool drunk;
    [FormerlySerializedAs("Strength")] public  int strength;
    [FormerlySerializedAs("NeedBathroom")] public bool needBathroom = false;
    [FormerlySerializedAs("BathroomType")] public BathroomType bathroomType;
    [FormerlySerializedAs("BathroomCurrent")] public  int bathroomCurrent = 0;
    [FormerlySerializedAs("BathroomMax")] public int bathroomMax = 2000;





    public void IncrementNeedForBathroom()
    {
        bathroomCurrent++;
        if(bathroomCurrent >= bathroomMax) {
         bathroomTree.SendEvent<object>("GoBathroom", 1);
            needBathroom = true;
            bathroomType = Random.Range(0,10) < 5 ? BathroomType.Urinate : BathroomType.Poop;
            bathroomCurrent = 0;
            needBathroom = false;
        }

    }
    public void RandomizeStats()
    {       
        if (Random.Range(0, 10) < 5)
        {
            drunk = true;
            
        }
        else
        {
            drunk = false;
           
        } 
        strength = Random.Range(0, 10);

    }

    // Start is called before the first frame update
    void Start()
    {
        var behaviorTrees = GetComponents<BehaviorTree>();
        foreach (var behaviorTree in behaviorTrees)
        {
            if (behaviorTree.BehaviorName == "Bathroom")
            {
                bathroomTree = behaviorTree;
            }
        }
        RandomizeStats();
    }

    // Update is called once per frame
    void Update()
    {
     IncrementNeedForBathroom();
    }
}
