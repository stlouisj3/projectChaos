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
    [SerializeField]
    private Image incImg;

    private Color trans;
    private Color opaq;

    [SerializeField]
    private Sprite forcePush;
    [SerializeField]
    private Sprite opeOpe;
    [SerializeField]
    private Sprite timeFreeze;
    [SerializeField]
    private Sprite conqHaki;
    [SerializeField]
    private Sprite sheild;
    [SerializeField]
    private Sprite laser;




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

    public delegate void setAbil1Sprite(ability1 arg);
    public static setAbil1Sprite setSprite1;
    public delegate void setAbil2Sprite(ability2 arg);
    public static setAbil2Sprite setSprite2;


    public delegate IEnumerator newHealth(int arg, int arg2,bool arg3);
    public static newHealth updateHealth;


    void Awake()
    {
        currentAmmo = UpdateCurrAmmo;
        resAmmo = UpdateReserveAmmo;
        dualWeildAmmo = UpdateDualAmmo;

        setSprite1 = setAbil1Img;
        setSprite2 = setAbil2Img;

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
        incImg.color = trans;
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
            ability1.color = opaq;
        }
        else
        {
            ability1.color = trans;
        }
    }

    private void changeAbility2(bool arg)
    {


        if (arg)
        {
            ability2.color = opaq;
        }
        else
        {
            ability2.color = trans;
        }
    }

    private void setAbil1Img (ability1 abil)
    {
        switch (abil)
        {
            case global::ability1.teleport:
                ability1.sprite = opeOpe;
                break;

            case global::ability1.heal:
                ability1.sprite = sheild;
                break;
            case global::ability1.freeze:
                ability1.sprite = timeFreeze;               
                break;
        }

    }

    private void setAbil2Img(ability2 abil)
    {
        switch (abil)
        {
            case global::ability2.debris:
                ability2.sprite = forcePush;
                break;

            case global::ability2.laser:
                ability2.sprite = laser;
                break;
            case global::ability2.quake:
                ability2.sprite = conqHaki;
                break;
        }

    }

    IEnumerator changeHealth(int arg, int maxHealth, bool dec)
    {
        if (dec)
            damgeImg.color = opaq;
        else
            incImg.color = opaq;
        health.value = (float)arg / maxHealth;

        float elapsedTime = 0;
        float totalTime = 2f;
        yield return new WaitForSeconds(.5f);

        while (elapsedTime < totalTime)
        {
            elapsedTime += Time.deltaTime;
            if(dec)
                damgeImg.color = Color.Lerp(opaq, trans, elapsedTime / totalTime);
            else
                incImg.color = Color.Lerp(opaq, trans, elapsedTime / totalTime);
            yield return new WaitForEndOfFrame();
        }
        incImg.color = trans;
        damgeImg.color = trans;


    }
}
