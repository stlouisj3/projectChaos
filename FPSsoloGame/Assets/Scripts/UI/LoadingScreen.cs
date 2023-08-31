using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField]
    private bool wait;

    [SerializeField]
    private TextMeshProUGUI loadText;

    private string loading = "Loading";
    private string currentStr = "";

    private int strInd;
    private int strMax;
    /*IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        if (wait)
        {
            StartCoroutine(disableLoad());
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }*/

    private void OnEnable()
    {
        strMax = loading.Length;
        strInd = 0;
        StartCoroutine(movingText());
    }

    IEnumerator disableLoad()
    {
        
        gameStateManager.pauseGame();
        yield return new WaitForSeconds(5);
        gameStateManager.resumeGame();
        this.gameObject.SetActive(false);
    }

    IEnumerator movingText()
    {
        while (true)
        {
            loadText.text = loading.Substring(0, strInd);
            strInd++;

            if(strInd > strMax)
            {
                strInd = 0;
            }

            yield return new WaitForSeconds(.25f);
        }
    }

    
}
