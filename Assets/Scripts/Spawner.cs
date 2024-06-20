using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{

    [SerializeField] private StructureManager[] bombObject;
    [SerializeField] private int initialBombsToSpawn;


    [SerializeField] private StructureManager[] coinObject;
    [SerializeField] private int initialCoinsToSpawn;

    [SerializeField] private StructureManager[] trapObject;
    [SerializeField] private int initialTrapToSpawn;

    [SerializeField] private Oxygen oxygenObject;
    [SerializeField] private int initialOxygenToSpawn;

    [SerializeField] private LightResetter lightResetPowerup;
    [SerializeField] private int initialLightResetToSpawn;

    [SerializeField] private ShieldPowerUp shieldPowerup;
    [SerializeField] private int initialShieldToSpawn;

    [SerializeField] private ScoreMultiplier scoreMultiplierPowerup;
    [SerializeField] private int initialScoreMultiplierToSpawn;

    [SerializeField] private int collectibleSpawnRate;
    [SerializeField] private int spawnWidth;
    [SerializeField] private depthTracker dt;

    private List<GameObject> bombs;
    private List<GameObject> coins;
    private List<Oxygen> oxygen;
    private List<GameObject> traps;
    private List<GameObject> lightReset;

    private float bombSpawnTime;
    private float trapSpawnTime;
    private float oxygenSpawnTime;
    private float coinSpawnTime;
    private float lightResetSpawnTime;
    private float shieldSpawnTime;
    private float scoreMultiplierSpawnTime;

    private int depthScaling;
    // Start is called before the first frame update
    void Start()
    {
        bombs = new List<GameObject>();
        coins = new List<GameObject>();
        oxygen = new List<Oxygen>();
        traps = new List<GameObject>();
        bombSpawnTime = 10;
        coinSpawnTime = 1;
        trapSpawnTime = 15;
        oxygenSpawnTime = 1;
        lightResetSpawnTime = 10;
        shieldSpawnTime = 1;
        scoreMultiplierSpawnTime = 1;
    }


    void FixedUpdate()
    {
        depthScaling = dt.points * 10;

        // bombsToSpawn = initialBombsToSpawn + Mathf.FloorToInt(dt.points / 20);
        // coinsToSpawn = initialCoinsToSpawn + depthScaling;
        // trapToSpawn = initialTrapToSpawn + Mathf.FloorToInt(dt.points/50);    
        // oxygenToSpawn = initialOxygenToSpawn - Mathf.FloorToInt(dt.points/30);

        oxygenSpawnTime -= Time.fixedDeltaTime;
        bombSpawnTime -= Time.fixedDeltaTime;
        coinSpawnTime -= Time.fixedDeltaTime;
        trapSpawnTime -= Time.fixedDeltaTime;
        lightResetSpawnTime -= Time.fixedDeltaTime;
        shieldSpawnTime -= Time.fixedDeltaTime;
        scoreMultiplierSpawnTime -= Time.fixedDeltaTime;

        if (oxygenSpawnTime <= 0) {
            SpawnOxygen();
            oxygenSpawnTime = Random.Range(1, 2);
        }

        if (coinSpawnTime <= 0) {
            SpawnCoin();
            coinSpawnTime = Random.Range(2, 4);
        }

        if (trapSpawnTime <= 0) {
            SpawnTrap();
            trapSpawnTime = Random.Range(15, 25);
        }

        if (bombSpawnTime <= 0) {
            SpawnBomb();
            bombSpawnTime = Random.Range(10, 15);
        }

        if (lightResetSpawnTime <= 0) {
            SpawnLightReset();
            lightResetSpawnTime = Random.Range(10, 15);
        }
        if (shieldSpawnTime <= 0) {
            SpawnShield();
            shieldSpawnTime = Random.Range(10, 15);
        }
        if (scoreMultiplierSpawnTime <= 0) {
            SpawnScoreMultiplier();
            scoreMultiplierSpawnTime = Random.Range(10, 15);
        }

        if (depthScaling > 100) {
            
        }
    }


    void SpawnBomb()
    {
        float spawnSeed = Random.Range(0, 10);

        GameObject bomb = Instantiate(
            bombObject[Random.Range(0,2)].gameObject, 
            transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
            Quaternion.identity
            );

        // Place Instantiated bomb inside spawner object
        bomb.transform.parent = gameObject.transform;

        /***
        // SPAWN BOMB
        // if (spawnSeed > 8 && bombs.Count < bombsToSpawn) {
            
        //     bomb.GetComponent<StructureManager>().scrollSpeed = -1 * Random.Range(0.7f,1.4f) - dt.points*0.01f;
        //     bombs.Add(bomb);
            
        // }

        // SPAWN TRAP

        // if (spawnSeed < 8 && traps.Count < Mathf.Min(trapToSpawn,4)) {
        //     GameObject trap = Instantiate(
        //         trapObject[Random.Range(0,1)].gameObject, 
        //         transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
        //         Quaternion.identity
        //         );

        //     // Place Instantiated bomb inside spawner object
        //     trap.transform.parent = gameObject.transform;
        //     trap.GetComponent<StructureManager>().scrollSpeed = -0.5f * Random.Range(0.7f,1.4f) - dt.points*0.01f;
        //     traps.Add(trap);
        // }

        // Remove all Destroyed bombs
        // bombs.RemoveAll(GameObject => GameObject == null);
        // traps.RemoveAll(GameObject => GameObject == null);
        ***/
    }

    void SpawnTrap () 
    {
        GameObject trap = Instantiate(
                trapObject[Random.Range(0,1)].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

        // Place Instantiated bomb inside spawner object
        trap.transform.parent = gameObject.transform;
    }

    void SpawnCoin () 
    {
        GameObject coin = Instantiate(
                coinObject[Random.Range(0,2)].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

        // Place Instantiated bomb inside spawner object
        coin.transform.parent = gameObject.transform;
    }

    void SpawnOxygen ()
    {
        GameObject o2 = Instantiate(
                oxygenObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

        // Place Instantiated bomb inside spawner object
        o2.transform.parent = gameObject.transform;
    }

    void SpawnLightReset()
    {
        float spawnSeed = Random.Range(0, 10);

        GameObject lightReset = Instantiate(
                lightResetPowerup.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
            );

        // Place Instantiated bomb inside spawner object
        lightReset.transform.parent = gameObject.transform;


        /***
        // SPAWN COIN
        // if (coins.Count < Mathf.Min(coinsToSpawn, 8) && spawnSeed > collectibleSpawnRate) {
            
        //     coin.GetComponent<StructureManager>().scrollSpeed = -1 * Random.Range(0.7f,1.4f) - dt.points*0.01f;
        //     coins.Add(coin);
        // }

        // SPAWN OXYGEN
        // if (oxygen.Count < Mathf.Max(oxygenToSpawn,1) && spawnSeed <= collectibleSpawnRate) {
            
        //     o2.GetComponent<Oxygen>().scrollSpeed = -3 * Random.Range(0.7f,1.4f) - dt.points*0.01f;
        //     oxygen.Add(o2.GetComponent<Oxygen>());
        // }

        // SPAWN LIGHT RESETTER
        // if (oxygen.Count < Mathf.Max(oxygenToSpawn,1) && spawnSeed <= collectibleSpawnRate) {
            
        //     // o2.GetComponent<Oxygen>().scrollSpeed = -3 * Random.Range(0.7f,1.4f) - dt.points*0.01f;
        //     // oxygen.Add(o2.GetComponent<Oxygen>());
        // }

        // Remove all Destroyed collectible
        
        // coins.RemoveAll(GameObject => GameObject == null);
        // oxygen.RemoveAll(GameObject => GameObject == null);
        ***/
    }

    void SpawnShield () 
    {
        GameObject shield = Instantiate(
                shieldPowerup.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

        // Place Instantiated bomb inside spawner object
        shield.transform.parent = gameObject.transform;
    }
    void SpawnScoreMultiplier () 
    {
        GameObject scoreMultiplier = Instantiate(
                scoreMultiplierPowerup.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

        // Place Instantiated bomb inside spawner object
        scoreMultiplier.transform.parent = gameObject.transform;
    }
}
