using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Player Save", menuName = "Player Save")]
public class PlayerSaveData : ScriptableObject
{
    public float xSens;
    public float ySens;

    public float masterVol;
    public float musicVol;
    public float sfxVol;
}
