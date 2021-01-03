using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Mutation", menuName = "Mutation")]
public class Mutation : ScriptableObject
{
    public new string name;
    public string description;
    public int level = 0;
    public float[] upgrades;
    public float[] costs;
}
