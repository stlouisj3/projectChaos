using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttack : MonoBehaviour
{
    [SerializeField]
    private int dmg;

    Transform player;
    float dis;

    public void meleeAttack()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        dis = Vector3.Distance(player.position, transform.position);
        if(dis < 2)
        {
            playerHealth.upHealth(-50);
        }
    }
}
