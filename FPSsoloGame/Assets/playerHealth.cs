using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHealth : MonoBehaviour
{
    [SerializeField]
    private int health = 100;

    [SerializeField]
    private bool invinceAble;

    [SerializeField]
    private GameObject random;

    [SerializeField]
    private int maxHealth = 100;

    public delegate void addHealth(int arg);
    public static addHealth upHealth;
    public static addHealth restoreFull;
    public static addHealth maxUpgrade;

    audioManager audioSfx;

    private void Awake()
    {
        audioSfx = audioManager.Instance;
    }

    private void Start()
    {
        upHealth = changeHealth;
        restoreFull = restoreHealth;
        maxUpgrade = upgradeMax;
    }

    private void changeHealth(int arg)
    {
        
        if(arg < 0 && invinceAble)
        {
            
        }
        else if(arg > 0)
        {
            health += arg;
            StartCoroutine(AmmoUI.updateHealth(health, maxHealth,false));
            StartCoroutine(enableInvince(1));
        }else if(arg < 0)
        {
            if (health > maxHealth)
                health = maxHealth;
            StartCoroutine(AmmoUI.updateHealth(health, maxHealth,true));
            audioSfx.PlayPlayerSound("playerHurt", 1);
        }
        
        if(health < 0)
        {
            gameStateManager.dead();
        }
    }

    private void restoreHealth(int arg)
    {
        health = maxHealth;
        StartCoroutine(enableInvince(arg));
    }

    private void upgradeMax(int arg)
    {
        maxHealth += arg;
    }

    IEnumerator enableInvince(float arg)
    {
        random.SetActive(false);
        invinceAble = true;
        
        yield return new WaitForSeconds(arg);
        random.SetActive(true);
        invinceAble = false;
        
    }
}
