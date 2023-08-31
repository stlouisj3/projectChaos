using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Class", menuName = "Class")]
public class classScriptObj : ScriptableObject
{
    public string className;

    public gunValues gun1;
    public gunValues gun2;

    public ability1 abil1;
    public ability2 abil2;
}
