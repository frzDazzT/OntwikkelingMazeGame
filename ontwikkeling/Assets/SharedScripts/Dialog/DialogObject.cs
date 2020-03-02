using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Dialog", menuName ="Dialog")]
public class DialogObject : ScriptableObject
{
    public string nameOfInteractible;
    public List<string> dialog = new List<string>();
}
