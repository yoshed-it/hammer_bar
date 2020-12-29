using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildFinder : MonoBehaviour
{
    // Start is called before the first frame update
    public void Start()
    {

        Debug.Log("Child Objects: " + CountChildren(transform));
    }

   public int CountChildren(Transform a)
    {
        int childCount = 0;
        foreach (Transform b in a)
        {
            Debug.Log("Child: " + b);
            childCount++;
            childCount += CountChildren(b);
        }
        return childCount;
    }
}
