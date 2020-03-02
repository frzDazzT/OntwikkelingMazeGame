using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Objective
{
    public List<string> objectiveDescription = new List<string>();
    public List<ObjectiveType> objectiveOfType = new List<ObjectiveType>();
}

public enum ObjectiveType 
{ 
    Key,
    Exit
}

