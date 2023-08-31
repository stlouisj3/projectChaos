using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class area
{
    
    public GameObject door;
  
    public List<Transform> spawnPoints;

    public bool open = false;
}

public class roundManager : MonoBehaviour
{
    
    private int round;

    ObjectPool pool;

    [SerializeField]
    private int startSpawn = 10;

    [SerializeField]
    private int spawnInc = 5;

    [SerializeField]
    private int openRnds = 5;

    [SerializeField]
    private float timeToSpawn = 1f;

    [SerializeField]
    private float timeBetweenRounds = 20f;

    [SerializeField]
    private TextMeshProUGUI roundUI;

    private int maxSpawn;

    private int areasOpen;

    private int spawnPoint;
    private int areaSpawn;
    private int pointsToSpawn;

    private int enemiesDead;

    private int enemiesSpawned;

    private Transform spawnTrans;

    

    [SerializeField]
    private List<area> areas;

    public delegate void roundStates();
    public static roundStates enemyCheck;
    public static roundStates stopSpawn;
    public static roundStates continueSpawn;

    private void Start()
    {
        enemyCheck += enemyDied;
        stopSpawn = pauseSpawning;
        continueSpawn = resumeSpawning;
        pool = ObjectPool.Instance; 
    }

    void OnEnable()
    {
        
        round = 1;
        maxSpawn = startSpawn;
        areas[0].open = true;
        areasOpen = 0;


        enemiesDead = 0;
        enemiesSpawned = 0;
        roundUI.text = round.ToString();
        //startRound();
    }

    
    private void startRound()
    {
        
        round++;
        enemiesDead = 0;
        enemiesSpawned =  0;
        roundUI.text = round.ToString();
        
        if (round % openRnds == 0)
            openNewArea();
        StartCoroutine(spawn());
    }

    IEnumerator spawn()
    {
        while(enemiesSpawned < maxSpawn)
        {
            yield return new WaitForSeconds(timeToSpawn);
            Debug.Log(enemiesSpawned + " " + maxSpawn);
            areaSpawn = Random.Range(0, areasOpen);
            pointsToSpawn = areas[areaSpawn].spawnPoints.Count;
            spawnPoint = Random.Range(0, pointsToSpawn);
            spawnTrans = areas[areaSpawn].spawnPoints[spawnPoint];
            pool.SpawnFromPool("Enemy", spawnTrans.position, Quaternion.identity);
            enemiesSpawned = enemiesSpawned + 1;

        }
            
        
        
    }

    


    IEnumerator roundWait() 
    {
        yield return new WaitForSeconds(timeBetweenRounds);
        
        startRound();
        
    }

    IEnumerator initialDelay(float arg)//If needed
    {
        yield return new WaitForSeconds(arg);
        startRound();
    }

    private void enemyDied()
    {

        enemiesDead++;
        
        if (enemiesDead >= maxSpawn)
        {
            //startRound();
            StartCoroutine(roundWait());
        }
    }

    private void pauseSpawning()
    {
        
        StopCoroutine(spawn());
    }

    private void resumeSpawning()
    {
        StartCoroutine(spawn());
    }

    private void openNewArea()
    {

        
        if(areasOpen < areas.Count)
        {   
            areasOpen++;
            areas[areasOpen].open = true;
            areas[areasOpen].door.SetActive(false);
            
        } 
    }
   
}
