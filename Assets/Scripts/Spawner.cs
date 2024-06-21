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

    [SerializeField] private HypnoFish hypnoFishObject;
    [SerializeField] private int initialHypnoFishToSpawn;

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
    private float hypnoFishSpawnTime;

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
        hypnoFishSpawnTime = 10;
    }


    void FixedUpdate()
    {
        depthScaling = dt.points * 10;

        oxygenSpawnTime -= Time.fixedDeltaTime;
        bombSpawnTime -= Time.fixedDeltaTime;
        coinSpawnTime -= Time.fixedDeltaTime;
        trapSpawnTime -= Time.fixedDeltaTime;
        lightResetSpawnTime -= Time.fixedDeltaTime;
        shieldSpawnTime -= Time.fixedDeltaTime;
        scoreMultiplierSpawnTime -= Time.fixedDeltaTime;
        hypnoFishSpawnTime -= Time.fixedDeltaTime;    

        SpawnOxygen();
        if (depthScaling > 50) {
            SpawnCoin();
        }

        if (depthScaling > 150) {
            SpawnScoreMultiplier();
            SpawnBomb();
        }

        if (depthScaling > 250) {
            SpawnShield();
            SpawnBomb();
        }

        if (depthScaling > 350) {
            SpawnLightReset();
        }

        if (depthScaling > 450) {
            SpawnTrap();
        }

        if (depthScaling > 550) {  
            SpawnHypno();
        }
    }


    void SpawnBomb()
    {
        if (bombSpawnTime <= 0) {
            GameObject bomb = Instantiate(
            bombObject[Random.Range(0, bombObject.Length)].gameObject, 
            transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
            Quaternion.identity
            );

            // Place Instantiated bomb inside spawner object
            bomb.transform.parent = gameObject.transform;

            bombSpawnTime = Random.Range(10, 15);
        }
    }

    void SpawnTrap () 
    {
        if (trapSpawnTime <= 0) {
            GameObject trap = Instantiate(
                trapObject[Random.Range(0, trapObject.Length)].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            trap.transform.parent = gameObject.transform;

            trapSpawnTime = Random.Range(15, 25);
        }  
    }

    void SpawnCoin () 
    {
        if (coinSpawnTime <= 0) {
            GameObject coin = Instantiate(
                coinObject[Random.Range(0,2)].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            coin.transform.parent = gameObject.transform;

            coinSpawnTime = Random.Range(2, 4);
        }
        
    }

    void SpawnOxygen ()
    {
        if (oxygenSpawnTime <= 0) {
            GameObject o2 = Instantiate(
                oxygenObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            o2.transform.parent = gameObject.transform;

            oxygenSpawnTime = Random.Range(1, 2);
        }
    }

    void SpawnLightReset()
    {
        if (lightResetSpawnTime <= 0) {
            GameObject lightReset = Instantiate(
                    lightResetPowerup.gameObject, 
                    transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                    Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            lightReset.transform.parent = gameObject.transform;

            lightResetSpawnTime = Random.Range(10, 15);
        }
    }

    void SpawnShield () 
    {
        if (shieldSpawnTime <= 0) {
            GameObject shield = Instantiate(
                shieldPowerup.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            shield.transform.parent = gameObject.transform;

            shieldSpawnTime = Random.Range(10, 15);
        }
    }
    void SpawnScoreMultiplier () 
    {
        if (scoreMultiplierSpawnTime <= 0) {
            GameObject scoreMultiplier = Instantiate(
                scoreMultiplierPowerup.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            scoreMultiplier.transform.parent = gameObject.transform;

            scoreMultiplierSpawnTime = Random.Range(10, 15);
        }
        
    }

    void SpawnHypno () 
    {
        if (hypnoFishSpawnTime <= 0) {
            GameObject hypnoFish = Instantiate(
                hypnoFishObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            hypnoFish.transform.parent = gameObject.transform;

            hypnoFishSpawnTime = Random.Range(10, 15);
        }
        
    }
}
