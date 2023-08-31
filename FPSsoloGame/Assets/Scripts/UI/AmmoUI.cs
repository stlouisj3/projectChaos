using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AmmoUI : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currAmmo;

    [SerializeField]
    private TextMeshProUGUI reserveAmmo;

    [SerializeField]
    private TextMeshProUGUI dualAmmo;

    [SerializeField]
    private GameObject slashDual;

    [SerializeField]
    private Image ability1;
    [SerializeField]
    private Image ability2;

    [SerializeField]
    private Slider health;
    [SerializeField]
    private Image damgeImg;

    private Color trans;
    private Color opaq;



    public delegate void ammoUpdates(int arg);
    public static ammoUpdates currentAmmo;
    public static ammoUpdates resAmmo;
    public static ammoUpdates dualWeildAmmo;

    public delegate void activateDual();
    public static activateDual dualOn;
    public static activateDual dualOff;

    public delegate void activateAbility(bool arg);
    public static activateAbility abil1;
    public static activateAbility abil2;

    public delegate IEnumerator newHealth(int arg, int arg2);
    public static newHealth updateHealth;


    void Awake()
    {
        currentAmmo = UpdateCurrAmmo;
        resAmmo = UpdateReserveAmmo;
        dualWeildAmmo = UpdateDualAmmo;

        dualOn = turnOnDual;
        dualOff = turnOffDual;

        abil1 = changeAbility1;
        abil2 = changeAbility2;

        updateHealth = changeHealth;

        trans = Color.white;
        opaq = Color.white;

        trans.a = 0;
        opaq.a = 1;

        damgeImg.color = trans;
        health.value = 1;

    }

    private void UpdateCurrAmmo(int arg)
    {

        currAmmo.text = arg.ToString();
    }

    private void UpdateReserveAmmo(int arg)
    {
        reserveAmmo.text = arg.ToString();
    }

    private void UpdateDualAmmo(int arg)
    {
        dualAmmo.text = arg.ToString();
    }

    private void turnOnDual()
    {
        dualAmmo.gameObject.SetActive(true);
        slashDual.SetActive(true);
    }

    private void turnOffDual()
    {
        dualAmmo.gameObject.SetActive(false);
        slashDual.SetActive(false);
    }

    private void changeAbility1(bool arg)
    {
        if (arg)
        {
            ability1.color = Color.green;
        }
        else
        {
            ability1.color = Color.red;
        }
    }

    private void changeAbility2(bool arg)
    {
        if (arg)
        {
            ability2.color = Color.green;
        }
        else
        {
            ability2.color = Color.red;
        }
    }


    IEnumerator changeHealth(int arg, int maxHealth)
    {
        damgeImg.color = opaq;
        health.value = (float)arg / maxHealth;

        float elapsedTime = 0;
        float totalTime = 2f;
        yield return new WaitForSeconds(.5f);

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            damgeImg.color = Color.Lerp(opaq, trans, elapsedTime / totalTime);
            yield return new WaitForEndOfFrame();
        }

        damgeImg.color = trans;


    }
}
