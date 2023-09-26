using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationController : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public delegate void changeState(bool arg);
    public static changeState stumble;
    public static changeState stopTime;

    bool stopAni = false;

    private void Start()
    {
        stumble += setStumble;
        stopTime += pause;

    }
    public void setRun(bool arg)
    {
        animator.SetBool("Run", arg);
    }

    public void setIdle(bool arg)
    {
        animator.SetBool("Idle", arg);
    }

    public void setAttack(bool arg)
    {
        animator.SetBool("Attack", arg);
    }

    private void setStumble(bool arg)
    {
        animator.SetBool("Stumble", arg);
    }

    private void pause(bool arg)
    {
        stopAni = arg;

        if (arg)
            animator.speed = 0f;
        else
            animator.speed = 1f;
    }

    private void Update()
    {
        if (stopAni)
            animator.speed = 0f;
        else
            animator.speed = 1f;
    }
}
