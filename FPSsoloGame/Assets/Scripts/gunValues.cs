using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class gunValues : ScriptableObject
{
    public string gunName;

    public int clipSize;

    public int startAmmo;

    public int currAmmo;

    public int dualAmmo;

    public int reserveAmmo;

    public float reloadTime;

    public int dmg;

    public float spreadRadius;

    public float fireRate;

    public GameObject gunFBX;

    public bool dualWeild;

    public bool isShotgun;

    public int pelletsPerSpread;

    public string gunSound;

}
