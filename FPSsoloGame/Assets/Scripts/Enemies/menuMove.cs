using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMove : MonoBehaviour
{
    [SerializeField]
    Animator ani;

    [SerializeField]
    private List<Transform> movingPoints;

    [SerializeField]
    private float speed = 1f;

    [SerializeField]
    private float waitSec = 1.5f;

    private int point;
    private void OnEnable()
    {
        point = 0;
        StartCoroutine(moveToPoint());
    }

    IEnumerator moveToPoint()
    {
        while (true)
        {
            if(point < movingPoints.Count)
            {
                ani.SetBool("Run", true);
                ani.SetBool("Idle", false);

                if(Vector3.Distance(this.gameObject.transform.position,movingPoints[point].position) > .01)
                {
                    
                    this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, movingPoints[point].position,speed);
                    yield return new WaitForEndOfFrame();
                }
                else
                {
                    point++;
                }

            }
            else
            {
                ani.SetBool("Run", false);
                ani.SetBool("Idle", true);
                yield return new WaitForSeconds(waitSec);
                point = 0;
            }

        }
    }
}
