using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemy : MonoBehaviour
{
    ObjectPool pool;


    [SerializeField] string bulletName;
    [SerializeField] Transform barrel1;
    [SerializeField] Transform barrel2;

    void Start()
    {
        pool = ObjectPool.Instance;
    }

    public void shoot1()
    {
        pool.SpawnFromPool(bulletName,barrel1.position,barrel1.rotation);
    }

    public void shoot2()
    {
        pool.SpawnFromPool(bulletName, barrel2.position, barrel2.rotation);
    }
}
