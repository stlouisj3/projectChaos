using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int startHealth;

    [SerializeField]
    private bool survival;

    private int health;

    public delegate void healthInc(int arg);
    public static healthInc incHealth;

    ObjectPool pool;

    private bool isDead;

    private void Start()
    {
        incHealth = IncStrtHealth;
        pool = ObjectPool.Instance;
    }
    private void OnEnable()
    {
        health = startHealth;
        isDead = false;

    }

    private void IncStrtHealth(int arg)
    {
        startHealth += arg;
    }

    public void takeDamage(int arg)
    {
        health -= arg;
        if(health <= 0 && !isDead)
        {
            
            isDead = true;
            if (survival)
            {
                
                roundManager.enemyCheck();
            }

            pool.SpawnFromPool("DeathPart", this.transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
    }
}
