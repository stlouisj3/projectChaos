using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    private Vector3 target;

    [SerializeField]
    private float speed;
    
    public void moveToTarget(Vector3 tar)
    {
        target = tar;
        Debug.Log(tar);
    }

    private void Update()
    {
        //Debug.Log(transform.position);
        //transform.position = Vector2.MoveTowards(this.transform.position, target, speed * Time.deltaTime);
        if (Vector2.Distance(this.transform.position, target) < .02)
            this.gameObject.SetActive(false);
    }
    IEnumerator disableGameobject()
    {
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
    }
}
