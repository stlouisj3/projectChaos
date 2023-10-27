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
    private List<string> enemyNames;
    private int enemyType;

    audioManager audio;

    [SerializeField]
    private List<area> areas;

    public delegate void roundStates();
    public static roundStates enemyCheck;
    public static roundStates stopSpawn;
    public static roundStates continueSpawn;
    public static roundStates startRounds;

    private void Start()
    {
        enemyCheck += enemyDied;
        stopSpawn = pauseSpawning;
        continueSpawn = resumeSpawning;
        startRounds = startRound;
        pool = ObjectPool.Instance;
        audio = audioManager.Instance;
    }

    void OnEnable()
    {
        
        round = 0;
        maxSpawn = startSpawn;
        areas[0].open = true;
        areasOpen = 0;


        enemiesDead = 0;
        enemiesSpawned = 0;
        roundUI.text = round.ToString();
        
    }

    
    private void startRound()
    {
        int enemies = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemies != 0)
            return;
        if(audio != null)
            audio.PlaySFX("newRound");
        
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
        while(enemiesSpawned < maxSpawn && gameStateManager.currState())
        {
            
            
            yield return new WaitForSeconds(timeToSpawn);
            
            areaSpawn = Random.Range(0, areasOpen);
            pointsToSpawn = areas[areaSpawn].spawnPoints.Count;
            spawnPoint = Random.Range(0, pointsToSpawn);
            spawnTrans = areas[areaSpawn].spawnPoints[spawnPoint];
            enemyType = Random.Range(0, enemyNames.Count);
            enemiesSpawned = enemiesSpawned + 1;
            pool.SpawnFromPool(enemyNames[enemyType], spawnTrans.position, Quaternion.identity);
            print(enemiesSpawned);
            
            
        }
            
        
        
    }

    
    IEnumerator bossSpawn()
    {
        int spawnTimes = round / openRnds;

        for(int i = 0; i < spawnTimes; i++)
        {
            int areasSpawn = Random.Range(0, areasOpen);
            int pointsToSpawns = areas[areasSpawn].spawnPoints.Count;
            int spawnsPoint = Random.Range(0, pointsToSpawns);
            Transform spawnsTrans = areas[areasSpawn].spawnPoints[spawnsPoint];
            yield return new WaitForSeconds(1);
            pool.SpawnFromPool("Boss", spawnsTrans.position, Quaternion.identity); 
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

        if(round > 1)
        {
            StartCoroutine(bossSpawn());
        }

        if(areasOpen < areas.Count)
        {   
            areasOpen++;
            areas[areasOpen].open = true;
            areas[areasOpen].door.SetActive(false);
            
        } 
    }
   
}
