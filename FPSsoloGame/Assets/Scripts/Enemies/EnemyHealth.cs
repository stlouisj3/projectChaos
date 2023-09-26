using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private int startHealth;

    [SerializeField]
    private bool survival;

    [SerializeField]
    private int healthDropPerc;

    [SerializeField]
    private int ammoDropPerc;

    private int ranNum;

    private Vector3 dropTrans;



    private int health;

    public delegate void healthInc(int arg);
    public static healthInc incHealth;

    ObjectPool pool;
    audioManager audio;

    private bool isDead;

    private void Start()
    {
        incHealth = IncStrtHealth;
        pool = ObjectPool.Instance;
        audio = audioManager.Instance;
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
            //audio.PlaySFX("emyDeath");
            pool.SpawnFromPool("DeathPart", this.transform.position, Quaternion.identity);
            dropPower();
            this.gameObject.SetActive(false);
        }
    }

    private void dropPower()
    {
        dropTrans = this.gameObject.transform.position;
        dropTrans.x += .5f;
        dropTrans.y += 1;
        ranNum = Random.Range(0, 100);

        if(ranNum < healthDropPerc)
        {
            pool.SpawnFromPool("healthDrop", dropTrans, Quaternion.identity);
        }
        dropTrans.y += .5f;
        ranNum = Random.Range(0, 100);
        if (ranNum < ammoDropPerc)
        {
            pool.SpawnFromPool("ammoDrop", dropTrans, Quaternion.identity);
        }
    }

}
