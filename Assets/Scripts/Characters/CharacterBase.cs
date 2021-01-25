using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

//Yosh -- I read something about using an abstract modifier so that this can never be instantiated, but has to be inherited from a subclass.
// Abstact class for all Character types
public abstract class CharacterBase : MonoBehaviour
{
    public Stat intox;
    public Stat stress;
    public Stat endurance;
    public int money;
}
