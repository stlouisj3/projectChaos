using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class abilityManager : MonoBehaviour
{
    [SerializeField]
    private InputManager input;

    private float coolDown1 = 2;

    private float coolDown2 = 2;

    private bool ready1;
    private bool ready2;

    private GameObject switchObj;//Values for Laws ability
    private bool hasObj;
    private Vector3 objPos;

    [SerializeField]
    private List<Transform> throwableSpawn;

    [SerializeField]
    private int invinceTime = 3;

    [SerializeField]
    private float pauseTime = 4f;

    [SerializeField]
    private float laserTime = 4f;

    [SerializeField]
    private LineRenderer laser;

    [SerializeField]
    private Transform barrel;

    public classScriptObj abilitiy;

    private ObjectPool pool;
    private audioManager audio;


    Vector3[] positions = new Vector3[2];

    public delegate void abils();
    public static abils getInput;

    private Renderer rend;
    private MeshRenderer mesh;
    private Material tempMat;

    [SerializeField]
    private Material changeMat;

    [SerializeField]
    private float swapCoolDown = 2f;
    [SerializeField]
    private float pushCoolDown = 4f;
    [SerializeField]
    private float healthCoolDown = 5f;
    [SerializeField]
    private float freezeCoolDown = 5f;
    [SerializeField]
    private float hakiCoolDown = 5f;
    [SerializeField]
    private float laserCoolDown = 5f;


    [SerializeField]
    private Volume vol;

    private ColorAdjustments effect;

    private float Starthue;

    
    private float randomHue;

    private float startSat;
    private float greySat = -100;


    //private GameObject temp;

    void Start()
    {
        if (vol != null)
        {
            Debug.Log("Volume component found!");
            if (vol.profile.TryGet(out effect))
            {
                //Debug.Log("Color Adjustments found!");
                startSat = effect.saturation.value;
                Starthue = effect.hueShift.value;

                
            }
            else
            {
                Debug.LogError("Color Adjustments not found!");
            }
        }
        else
        {
            Debug.LogError("Volume component not assigned!");
        }
        audio = audioManager.Instance;
        pool = ObjectPool.Instance;
        ready1 = true;
        ready2 = true;
        getInput = abilityCheck;
        
        AmmoUI.abil2(ready2);
        AmmoUI.abil1(ready1);
        AmmoUI.setSprite1(abilitiy.abil1);
        AmmoUI.setSprite2(abilitiy.abil2);

        //effect = vol.GetComponent<ColorAdjustments>();
        

        //abilityCheck();
    }


   /* void Update()
    {
        while (gameStateManager.currState()) { 

        if (input.getAbilityOne() && ready1)
        {
            switch (abilitiy.abl1)
            {
                case ability1.teleport: 
                    opeOpe();
                    break;

                case ability1.heal:
                    restoreHealth();
                    break;
                case ability1.freeze:
                    timeStop();
                    break;
            }
            
        }*/

        

    IEnumerator coolDownAbil1(float arg)
    {
        AmmoUI.abil1(ready1);
        yield return new WaitForSeconds(arg);
        ready1 = true;
        AmmoUI.abil1(ready1);

    }

    IEnumerator coolDownAbil2(float arg)
    {
        AmmoUI.abil2(ready2);
        yield return new WaitForSeconds(arg);
        ready2 = true;
        AmmoUI.abil2(ready2);
    }

    private void opeOpe()
    {

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {

            if (hit.collider.gameObject.CompareTag("Enemy") || hit.collider.gameObject.CompareTag("Swap"))//Gets the object
            {
                hasObj = true;

                switchObj = hit.collider.gameObject;

                if(hasObj && rend != null)
                   rend.material = tempMat;
                rend = hit.collider.GetComponent<Renderer>();
                tempMat = rend.materials[0];
                rend.material = changeMat;
                //
            }
            else if (hasObj)//Swaps the player and object
            {
                ready1 = false;
                hasObj = false;
                objPos = switchObj.transform.position;
                objPos.y += 1; //Adjustment to not fall through floor
                switchObj.transform.position = this.transform.position;
                this.transform.position = objPos;
                rend.material = tempMat;
                StartCoroutine(coolDownAbil1(swapCoolDown));
            }

        }
    }

    private void forcePush()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {

            for (int i = 0; i < throwableSpawn.Count; i++)
            {
                GameObject temp = pool.SpawnFromPool("debris", throwableSpawn[i].position, Quaternion.identity);
                temp.GetComponent<debris>().attack(hit.point);
            }
        }
        ready2 = false;
        StartCoroutine(coolDownAbil2(pushCoolDown));
    }

    private void restoreHealth()
    {
        playerHealth.restoreFull(invinceTime);
        ready1 = false;
        StartCoroutine(coolDownAbil1(healthCoolDown));
    }

    private void conqHaki()
    {
        if(audio != null)
            audio.Playability2("conq");
        StartCoroutine(conqEffect());
        //animationController.stumble(true);
        ready2 = false;
        StartCoroutine(coolDownAbil2(hakiCoolDown));
    }

    IEnumerator conqEffect()
    {
        randomHue = Random.Range(-180, -20);

        effect.hueShift.value = randomHue;
            yield return new WaitForSeconds(.5f);
        

        effect.hueShift.value = Starthue;

    }

    private void timeStop()
    {
        StartCoroutine(stopTime());
        ready1 = false;
        StartCoroutine(coolDownAbil1(freezeCoolDown + pauseTime));
    }

    IEnumerator stopTime()
    {
        audio.setFreezeSnap(.5f);
        effect.saturation.value = greySat;
        
        animationController.stopTime(true);
        navMeshFix.changeNav(false);
        
        yield return new WaitForSeconds(pauseTime);
        audio.setGameSnap(.5f);
        yield return new WaitForSeconds(.5f);
        effect.saturation.value = startSat;
        animationController.stopTime(false);
        navMeshFix.changeNav(true);
        
    }

    private void laserBeam()
    {
        ready2 = false;
        shootingScript.gunsOff(laserTime);
        StartCoroutine(startLaserBeam());
        StartCoroutine(coolDownAbil2(laserCoolDown + laserTime));
    }

    private IEnumerator startLaserBeam()
    {
        float time = 0;
        while(time < laserTime)
        {
            time += Time.deltaTime;
            RaycastHit hit;
            var tracer = Instantiate(laser, barrel.position, Quaternion.identity);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {

                
                positions[0] = barrel.position;
                positions[1] = hit.point;
                tracer.positionCount = positions.Length;
                tracer.SetPositions(positions);
                if (hit.collider.CompareTag("Enemy"))
                {
                    hit.collider.GetComponent<EnemyHealth>().takeDamage(1);
                }
                
            }
            yield return new WaitForEndOfFrame();
            Destroy(tracer);
        }

        

    }

    private void switchCheck()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Swap")) {
                mesh = hit.collider.GetComponent<MeshRenderer>();
                tempMat = mesh.materials[0];
                mesh.materials[0] = changeMat;

            } else if (mesh != null)
            {
                mesh.materials[0] = tempMat;
            }
        }

        }
    private void abilityCheck()
    {
        StartCoroutine(recieveInput());
            
    }

    IEnumerator recieveInput()
        {
        
        while (gameStateManager.currState())
            {

            if (input.getAbilityOne() && ready1)
            {
                //AmmoUI.setSprite1(abilitiy.abil1);
                
                switch (abilitiy.abil1)
                {
                    case ability1.teleport:
                        opeOpe();
                        break;

                    case ability1.heal:
                        restoreHealth();
                        break;
                    case ability1.freeze:
                        timeStop();
                        break;
                }
            }


            if (input.getAbilityTwo() && ready2)
            {
                //AmmoUI.setSprite2(abilitiy.abil2);
                switch (abilitiy.abil2)
                {
                    case ability2.debris:
                        forcePush();
                        break;

                    case ability2.quake:
                        conqHaki();
                        break;
                    case ability2.laser:
                        laserBeam();
                        break;
                }
            }

            

            yield return new WaitForEndOfFrame();
        }
            }
    }

