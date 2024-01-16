using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEngine;

public class enemyBulletControl : MonoBehaviour
{
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private int dmg = 10;
    [SerializeField] private float despawnTime = 2.0f;

    //Rigidbody rb;
    GameObject player;
    Vector3 target;

    private void Awake()
    {
        //rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        StartCoroutine(this.despawnBullet());
        if (player != null)
        {
            target = player.transform.position;
            //Vector3 direction = (player.transform.position - transform.position).normalized;
            //rb.velocity = direction * speed;
        }
    }

    private void Update()
    {
        if (target != null)
            this.transform.position = Vector3.MoveTowards(this.transform.position, target, speed);
    }


    private void OnDisable()
    {
        StopCoroutine(this.despawnBullet());
    }

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            playerHealth.upHealth(-dmg);
        }
        this.gameObject.SetActive(false);

    }

    IEnumerator despawnBullet()
    {
        yield return new WaitForSeconds(despawnTime);
        this.gameObject.SetActive(false);
    }
}
