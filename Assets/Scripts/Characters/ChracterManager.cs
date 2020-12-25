using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Yosh -- I read something about using an abstract modifier so that this can never be instantiated, but has to be inherited from a subclass.
public class CharacterManager : MonoBehaviour
{

    //Yosh -- Maybe learn more about 'Enum'.. but for now this works.
    public IntoxPoints intoxPoints;
    public float maxIntoxPoints;
    public float startingIntoxPoints;
    public int stressPoints;
    public int maxStressPoints;
    public int endurancePoints;
    public int maxEndurancePoints;
}
