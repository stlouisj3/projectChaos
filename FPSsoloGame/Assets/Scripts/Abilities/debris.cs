using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debris : MonoBehaviour
{
    [SerializeField]
    private int dmg;

    [SerializeField]
    private float speed;

    [SerializeField]
    private int disableTime = 2;

    private Vector3 target;

    private void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.CompareTag("Enemy")){
            coll.collider.GetComponent<EnemyHealth>().takeDamage(dmg);
        }

        this.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        StopCoroutine(disable());
        StartCoroutine(disable());
    }

    public void attack(Vector3 arg)
    {
        StartCoroutine(goToTarget(arg));
    }
    private IEnumerator goToTarget(Vector3 arg)
    {
        while (true)
        {
            transform.position = Vector3.MoveTowards(this.gameObject.transform.position, arg,speed);
            yield return new WaitForFixedUpdate();

        }

    }

    private IEnumerator disable()
    {
        for(int i = 0; i < disableTime; i++)
        {
            yield return new WaitForSeconds(1);
        }
        this.gameObject.SetActive(false);
    }
}
