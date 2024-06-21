using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
        depthScaling = dt.points;

        oxygenSpawnTime -= Time.fixedDeltaTime;
        bombSpawnTime -= Time.fixedDeltaTime;
        coinSpawnTime -= Time.fixedDeltaTime;
        trapSpawnTime -= Time.fixedDeltaTime;
        lightResetSpawnTime -= Time.fixedDeltaTime;
        shieldSpawnTime -= Time.fixedDeltaTime;
        scoreMultiplierSpawnTime -= Time.fixedDeltaTime;
        hypnoFishSpawnTime -= Time.fixedDeltaTime;    

        SpawnOxygen(1, 3);

        if (depthScaling < 50) {
            SpawnCoin(5, 10);
        }

        else if (depthScaling < 150) {
            SpawnCoin(5, 10);
            SpawnScoreMultiplier(0, 20);
            SpawnBomb(0, 6, 8);
        }

        else if (depthScaling < 300) {
            SpawnCoin(5, 10);
            SpawnScoreMultiplier(0, 20);
            SpawnShield(25, 50);
            SpawnBomb(1, 4, 6);
        }

        else if (depthScaling < 500) {
            SpawnCoin(5, 10);

            SpawnScoreMultiplier(20, 40);
            SpawnShield(25, 50);
            SpawnLightReset(50, 100);
        
            SpawnBomb(2, 4, 6);
            SpawnTrap(0, 10, 15);
        }

        else if (depthScaling >= 500) {
            SpawnCoin(5, 10);

            SpawnScoreMultiplier(35, 40);
            SpawnShield(35, 50);
            SpawnLightReset(75, 100);
        
            SpawnBomb(2, 4, 6);
            SpawnTrap(1, 10, 15);
            SpawnHypno(10, 15);
        }
    }


    void SpawnBomb(int structureIndex, float minSpawnTime, float maxSpawnTIme)
    {
        if (bombSpawnTime <= 0) {
            GameObject bomb = Instantiate(
            bombObject[structureIndex].gameObject, 
            transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
            Quaternion.identity
            );

            // Place Instantiated bomb inside spawner object
            bomb.transform.parent = gameObject.transform;

            bombSpawnTime = Random.Range(minSpawnTime, maxSpawnTIme);
        }
    }

    void SpawnTrap (int structureIndex, float minSpawnTime, float maxSpawnTIme) 
    {
        if (trapSpawnTime <= 0) {
            GameObject trap = Instantiate(
                trapObject[structureIndex].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            trap.transform.parent = gameObject.transform;

            trapSpawnTime = Random.Range(minSpawnTime, maxSpawnTIme);
        }  
    }

    void SpawnHypno (float minSpawnTime, float maxSpawnTIme) 
    {
        if (hypnoFishSpawnTime <= 0) {
            GameObject hypnoFish = Instantiate(
                hypnoFishObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            hypnoFish.transform.parent = gameObject.transform;

            hypnoFishSpawnTime = Random.Range(minSpawnTime, maxSpawnTIme);
        }
        
    }

    void SpawnCoin (float minSpawnTime, float maxSpawnTIme) 
    {
        if (coinSpawnTime <= 0) {
            GameObject coin = Instantiate(
                coinObject[Random.Range(0, coinObject.Length)].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            coin.transform.parent = gameObject.transform;

            coinSpawnTime = Random.Range(minSpawnTime, maxSpawnTIme);
        }
        
    }

    void SpawnOxygen (float minSpawnTime, float maxSpawnTIme)
    {
        if (oxygenSpawnTime <= 0) {
            GameObject o2 = Instantiate(
                oxygenObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            o2.transform.parent = gameObject.transform;

            oxygenSpawnTime = Random.Range(minSpawnTime, maxSpawnTIme);
        }
    }

    void SpawnLightReset(float minSpawnTime, float maxSpawnTIme)
    {
        if (lightResetSpawnTime <= 0) {
            GameObject lightReset = Instantiate(
                    lightResetPowerup.gameObject, 
                    transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                    Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            lightReset.transform.parent = gameObject.transform;

            lightResetSpawnTime = Random.Range(minSpawnTime, maxSpawnTIme);
        }
    }

    void SpawnShield (float minSpawnTime, float maxSpawnTIme) 
    {
        if (shieldSpawnTime <= 0) {
            GameObject shield = Instantiate(
                shieldPowerup.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            shield.transform.parent = gameObject.transform;

            shieldSpawnTime = Random.Range(minSpawnTime, maxSpawnTIme);
        }
    }
    void SpawnScoreMultiplier (float minSpawnTime, float maxSpawnTIme) 
    {
        if (scoreMultiplierSpawnTime <= 0) {
            GameObject scoreMultiplier = Instantiate(
                scoreMultiplierPowerup.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            scoreMultiplier.transform.parent = gameObject.transform;

            scoreMultiplierSpawnTime = Random.Range(minSpawnTime, maxSpawnTIme);
        }
        
    }

    
}
