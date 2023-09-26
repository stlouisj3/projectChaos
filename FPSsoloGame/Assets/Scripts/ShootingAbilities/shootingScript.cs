using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingScript : MonoBehaviour
{
    public gunValues gun;

    public gunValues gun1;
    public gunValues gun2;

    private int gun1Ind;
    private int gun2Ind;

    public Transform barrel;
    public Transform barrelDual;

    private bool shooting;
    private bool dualShoot;

    [SerializeField]
    private InputManager input;

    [SerializeField]
    private GameObject cam;

    [SerializeField]
    private List<GameObject> guns;

    [SerializeField]
    private List<GameObject> gunsDual; //Seconed Gun for Dual Weild

    [SerializeField]
    private List<Transform> barrels;

    [SerializeField]
    private List<Transform> barrelsDual; //Seconed Barrel for Dual Weild

    [SerializeField]
    private float bulletSpeed = 2f;

    [SerializeField]
    private TrailRenderer laser;

    [SerializeField]
    private GameObject hitmarker;

    [SerializeField]
    private Animator ani1;   
    private Animator ani2;

    private int ammoNeeded;

    ObjectPool pool;
    audioManager audio;

    public classScriptObj gunClass;

    public delegate void shootingScrip();
    public static shootingScrip startShoot;

    public delegate void turnOff(float arg);
    public static turnOff gunsOff;
    public static turnOff addAmmo;

    void Start()
    {
        audio = audioManager.Instance;
        pool = ObjectPool.Instance;
        shooting = false;
        dualShoot = false;
        gun1 = gunClass.gun1;
        gun2 = gunClass.gun2;

        setGuns();
        startShoot = shootCheck;
        gunsOff = noGuns;
        addAmmo = addResAmmo;
    }

    private void shootCheck()
    {
        StartCoroutine(checkShoot());
    }

    IEnumerator checkShoot()
    {
        while(gameStateManager.currState())
        {
            
            if (input.getShoot() == 1)
            {
                if (gun.dualWeild && !dualShoot)
                {
                    StartCoroutine(shoot(barrelDual, false));
                }
                else if (!gun.dualWeild && !shooting)
                {
                    StartCoroutine(shoot(barrel, true));
                }

            }

            if (input.getRightShoot() == 1 && gun.dualWeild && !shooting)
            {
                StartCoroutine(shoot(barrel, true));
            }

            if (input.getReload())
            {
                StartCoroutine(reload());
            }

            if (input.getSwitch())
            {
                StartCoroutine(switchGuns());
            }
            yield return new WaitForEndOfFrame();
        }
    }

    // Update is called once per frame
    /*void Update()
    {
        

        if(input.getShoot() == 1)
        {
            if(gun.dualWeild && !dualShoot)
            {
                StartCoroutine(shoot(barrelDual,false));
            }
            else if(!gun.dualWeild && !shooting)
            {
                StartCoroutine(shoot(barrel,true));
            }
                  
        }

        if(input.getRightShoot() == 1 && gun.dualWeild && !shooting)
        {
            StartCoroutine(shoot(barrel,true));
        }

        if (input.getReload())
        {
            StartCoroutine(reload());
        }

        if (input.getSwitch())
        {
            StartCoroutine(switchGuns());
        }
    }*/

    private void setGuns()
    {
        for(int i = 0; i < guns.Count; i++)
        {
            if(gun1.gunFBX.name == guns[i].name)
            {
                gun1Ind = i;
                guns[i].SetActive(true);
                gun1.currAmmo = gun1.clipSize;
                gun1.reserveAmmo = gun1.startAmmo;
                barrel = barrels[gun1Ind];
                gun = gun1;
                AmmoUI.currentAmmo(gun1.currAmmo);
                AmmoUI.resAmmo(gun1.reserveAmmo);
                ani1 = guns[i].GetComponent<Animator>();

                if (gun1.dualWeild)
                {
                    gunsDual[gun1Ind].SetActive(true);
                    gun1.dualAmmo = gun1.clipSize;
                    AmmoUI.dualOn();
                    AmmoUI.dualWeildAmmo(gun1.dualAmmo);
                    barrelDual = barrelsDual[gun1Ind];
                    ani2 = gunsDual[gun1Ind].GetComponent<Animator>();
                }
                else
                {
                    gunsDual[gun1Ind].SetActive(false);
                    AmmoUI.dualOff();
                }

            }else if (gun2.gunFBX.name == guns[i].name)
            {
                gun2.currAmmo = gun2.clipSize;
                gun2.reserveAmmo = gun2.startAmmo;
                gun2Ind = i;
                guns[i].SetActive(false);
                gunsDual[i].SetActive(false);
            }
            else
            {
                guns[i].SetActive(false);
                gunsDual[i].SetActive(false);
            }
        }

    }

    private IEnumerator switchGuns()
    {
        yield return new WaitForSeconds(.5f);
        if (guns[gun1Ind].activeInHierarchy)
        {
            guns[gun1Ind].SetActive(false);
            guns[gun2Ind].SetActive(true);

            barrel = barrels[gun2Ind];
            gun = gun2;

            ani1 = guns[gun2Ind].GetComponent<Animator>();
            

            if (gun1.dualWeild)
            {
                gunsDual[gun1Ind].SetActive(false);
                AmmoUI.dualOff();
            }
            if (gun2.dualWeild)
            {
                gunsDual[gun2Ind].SetActive(true);
                AmmoUI.dualOn();
                AmmoUI.dualWeildAmmo(gun2.dualAmmo);
                barrelDual = barrelsDual[gun2Ind];
                ani2 = gunsDual[gun2Ind].GetComponent<Animator>();
            }

        }
        else
        {
            guns[gun1Ind].SetActive(true);
            guns[gun2Ind].SetActive(false);

            barrel = barrels[gun1Ind];
            gun = gun1;
            ani1 = guns[gun1Ind].GetComponent<Animator>();
            if (gun2.dualWeild)
            {
                gunsDual[gun2Ind].SetActive(false);
                AmmoUI.dualOff();
            }
            if (gun1.dualWeild)
            {
                gunsDual[gun1Ind].SetActive(true);
                AmmoUI.dualOn();
                AmmoUI.dualWeildAmmo(gun1.dualAmmo);
                barrelDual = barrelsDual[gun1Ind];
                ani2 = gunsDual[gun1Ind].GetComponent<Animator>();
            }
        }

        AmmoUI.currentAmmo(gun.currAmmo);
        AmmoUI.resAmmo(gun.reserveAmmo);
    }
    private IEnumerator shoot(Transform actBarrel,bool isRight) 
    {
        
        if ((gun.currAmmo > 0 && isRight) || (gun.dualAmmo > 0 && !isRight))

        {
            if (isRight)
            {
                gun.currAmmo--;
                AmmoUI.currentAmmo(gun.currAmmo);
            }
            else
            {
                gun.dualAmmo--;
                AmmoUI.dualWeildAmmo(gun.dualAmmo);
            }
            RaycastHit hit;
            if (isRight)
            {
                shooting = true;
            }
            else
            {
                dualShoot = true;
            }
            
            audio.PlayGun(gun.gunSound);
            //pool.SpawnFromPool("MuzzleFlash", actBarrel.position, Quaternion.identity);
            if (gun.isShotgun)
            {
                for (int i = 0; i < Mathf.Max(1, gun.pelletsPerSpread); i++)
                {                    
                    Vector3 shootDirection = cam.transform.forward;
                    shootDirection.x += Random.Range(-gun.spreadRadius, gun.spreadRadius);
                    shootDirection.y += Random.Range(-gun.spreadRadius, gun.spreadRadius);
                    var tracer = Instantiate(laser, actBarrel.position, Quaternion.identity);
                    tracer.AddPosition(actBarrel.position);
                    if (Physics.Raycast(cam.transform.position, shootDirection, out hit, 10))
                    {
                        tracer.transform.position = hit.point;
                        //pool.SpawnFromPool("HitEffect", hit.point, Quaternion.identity);

                        if (hit.collider.CompareTag("Enemy"))
                        {
                            //StartCoroutine(callHitmarker());
                            hit.collider.GetComponent<EnemyHealth>().takeDamage(gun.dmg);
                        }
                    }
                }
            }
            else
            {
                var tracer = Instantiate(laser, actBarrel.position, Quaternion.identity);
                tracer.AddPosition(actBarrel.position);
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, Mathf.Infinity))
                {
                    tracer.transform.position = hit.point;
                    //pool.SpawnFromPool("HitEffect", hit.point, Quaternion.identity);

                    if (hit.collider.CompareTag("Enemy"))
                    {
                        //StartCoroutine(callHitmarker());
                        hit.collider.GetComponent<EnemyHealth>().takeDamage(gun.dmg);
                    }
                }
            }
            yield return new WaitForSeconds(gun.fireRate);
            /*if (gun.dualWeild)
            {
                if (input.getShoot() == 1)
                {
                    StartCoroutine(shoot(barrelDual, false));
                }
                else
                {
                    dualShoot = false;
                }

                if (input.getRightShoot() == 1 && gun.dualWeild)
                {
                    StartCoroutine(shoot(barrel, true));
                }
                else
                {
                    shooting = false;
                }

            }
            else
            {
                if (input.getShoot() == 1)
                {
                    StartCoroutine(shoot(barrel, true));
                }
                else
                {
                    shooting = false;
                }
            }

            
            
        }
        else
        {*/
            if (isRight)
            {
                shooting = false;
            }
            else
            {
                dualShoot = false;
            }

        }
        else
        {
            StartCoroutine(reload());
        }
    }

    private void noGuns(float arg)
    {

        StartCoroutine(turnGunsOffThenOn(arg));
    }

    private IEnumerator turnGunsOffThenOn(float time)
    {
        
        gun = null;
        guns[gun2Ind].SetActive(false);
        guns[gun1Ind].SetActive(false);
        gunsDual[gun2Ind].SetActive(false);
        gunsDual[gun1Ind].SetActive(false);

        yield return new WaitForSeconds(time);

        setGuns();

    }

    private IEnumerator reload()
    {
        audio.PlayGun("reload");
        ani1.SetBool("reload", true);
        if (ani2 != null)
            ani2.SetBool("reload", true);
        yield return new WaitForSeconds(gun.reloadTime);
        if (gun.reserveAmmo > gun.clipSize)
        {
            ammoNeeded = gun.clipSize - gun.currAmmo;
            gun.currAmmo = gun.clipSize;
            gun.reserveAmmo -= ammoNeeded;
        }
        else
        {
            ammoNeeded = gun.clipSize - gun.currAmmo;
            if(ammoNeeded > gun.reserveAmmo)
            {
                gun.currAmmo += gun.reserveAmmo;
                gun.reserveAmmo = 0;
            }
            else
            {
                gun.currAmmo += ammoNeeded;
                gun.reserveAmmo -= ammoNeeded;
            }           
        }

        if (gun.dualWeild)
        {
            if (gun.reserveAmmo > gun.clipSize)
            {
                ammoNeeded = gun.clipSize - gun.dualAmmo;
                gun.dualAmmo = gun.clipSize;
                gun.reserveAmmo -= ammoNeeded;
            }
            else
            {
                ammoNeeded = gun.clipSize - gun.dualAmmo;
                if (ammoNeeded > gun.reserveAmmo)
                {
                    gun.dualAmmo += gun.reserveAmmo;
                    gun.reserveAmmo = 0;
                }
                else
                {
                    gun.dualAmmo += ammoNeeded;
                    gun.reserveAmmo -= ammoNeeded;
                }
            }
            AmmoUI.dualWeildAmmo(gun.dualAmmo);
        }
        AmmoUI.currentAmmo(gun.currAmmo);
        

    }

    private void addResAmmo(float arg)
    {
        gun.reserveAmmo += (int)arg;
        AmmoUI.resAmmo(gun.reserveAmmo);
    }
    private IEnumerator callHitmarker()
    {
        hitmarker.SetActive(true);
        yield return new WaitForSeconds(.2f);
        hitmarker.SetActive(false);
    }

    
    
}
