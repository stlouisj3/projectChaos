using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI xSens;

    [SerializeField]
    private TextMeshProUGUI ySens;

    [SerializeField]
    private GameObject loadingScreen;


    public classScriptObj gameClass;
    public classScriptObj classObj;

    private void OnEnable()
    {
        if(xSens != null)
        {
            xSens.text = (CameraControl.changeX(0) / 10).ToString();
        }

        if (ySens != null)
        {
            ySens.text = (CameraControl.changeY(0) / 10).ToString();
        }
    }


    public void updateXSens(float arg)
    {
        xSens.text = (CameraControl.changeX(arg) / 10).ToString();
    }

    public void updateYSens(float arg)
    {
        ySens.text = (CameraControl.changeY(arg) / 10).ToString();
    }

    public void changeScene(int arg)
    {
        StartCoroutine(sceneTransition(arg));
    }

    IEnumerator sceneTransition(int arg)
    {
        loadingScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        AsyncOperation operation = SceneManager.LoadSceneAsync(arg);
        

        while (!operation.isDone)
        {
            
            yield return null;
        }
    }

    public void selectClass()
    {
        
        gameClass.abil1 = classObj.abil1;
        gameClass.abil2 = classObj.abil2;
        gameClass.gun1 = classObj.gun1;
        gameClass.gun2 = classObj.gun2;
    }
}
