using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class navMeshFix : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent nav;

    public delegate void agentState(bool arg);
    public static agentState changeNav;

    private void Start()
    {
        changeNav += navState;
    }

    // Start is called before the first frame update
    private void OnEnable()
    {
        StartCoroutine(setPos());
    }

    IEnumerator setPos()
    {
        nav.enabled = false;
        nav.Warp(this.transform.position);
        yield return new WaitForEndOfFrame();
        nav.enabled = true;
    }

    private void navState(bool arg)
    {
        nav.enabled = arg;
    }
}
