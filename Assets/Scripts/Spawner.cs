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

    [SerializeField] private Oxygen oxygenObject;
    [SerializeField] private int initialOxygenToSpawn;

    [SerializeField] private StructureManager[] trapObject;
    [SerializeField] private int initialTrapToSpawn;
    [SerializeField] private int collectibleSpawnRate;
    [SerializeField] private int spawnWidth;
    [SerializeField] private depthTracker dt;

    private List<GameObject> bombs;
    private List<GameObject> coins;
    private List<Oxygen> oxygen;
    private List<GameObject> traps;

    private float bombsToSpawn;
    private float trapToSpawn;
    private float oxygenToSpawn;
    private float coinsToSpawn;
    private int depthScaling;
    // Start is called before the first frame update
    void Start()
    {
        bombs = new List<GameObject>();
        coins = new List<GameObject>();
        oxygen = new List<Oxygen>();
        traps = new List<GameObject>();
        bombsToSpawn = initialBombsToSpawn;
        coinsToSpawn = initialCoinsToSpawn;
        trapToSpawn = initialTrapToSpawn;
        oxygenToSpawn = initialOxygenToSpawn;
    }


    void FixedUpdate()
    {
        // depthScaling = dt.points % 200;
        // bombsToSpawn = initialBombsToSpawn + Mathf.FloorToInt(dt.points / 20);
        // coinsToSpawn = initialCoinsToSpawn + depthScaling;
        // trapToSpawn = initialTrapToSpawn + Mathf.FloorToInt(dt.points/50);    
        // oxygenToSpawn = initialOxygenToSpawn - Mathf.FloorToInt(dt.points/30);
        spawnHazard();
        spawnCollectible();
    }


    void spawnHazard()
    {
        float spawnSeed = Random.Range(0, 10);

        // SPAWN BOMB
        if (spawnSeed > 8 && bombs.Count < bombsToSpawn) {
            GameObject bomb = Instantiate(
                bombObject[Random.Range(0,2)].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            bomb.transform.parent = gameObject.transform;
            bomb.GetComponent<StructureManager>().scrollSpeed = -1 * Random.Range(0.7f,1.4f) - dt.points*0.01f;
            bombs.Add(bomb);
            
        }

        // SPAWN TRAP
        if (spawnSeed < 8 && traps.Count < Mathf.Min(trapToSpawn,4)) {
            GameObject trap = Instantiate(
                trapObject[Random.Range(0,1)].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            trap.transform.parent = gameObject.transform;
            trap.GetComponent<StructureManager>().scrollSpeed = -0.5f * Random.Range(0.7f,1.4f) - dt.points*0.01f;
            traps.Add(trap);
        }

        // Remove all Destroyed bombs
        bombs.RemoveAll(GameObject => GameObject == null);
        traps.RemoveAll(GameObject => GameObject == null);
    }

    void spawnCollectible()
    {
        float spawnSeed = Random.Range(0, 10);

        // SPAWN COIN
        if (coins.Count < Mathf.Min(coinsToSpawn, 8) && spawnSeed > collectibleSpawnRate) {
            GameObject coin = Instantiate(
                coinObject[Random.Range(0,2)].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            coin.transform.parent = gameObject.transform;
            coin.GetComponent<StructureManager>().scrollSpeed = -1 * Random.Range(0.7f,1.4f) - dt.points*0.01f;
            coins.Add(coin);
        }

        // SPAWN OXYGEN
        if (oxygen.Count < Mathf.Max(oxygenToSpawn,1) && spawnSeed <= collectibleSpawnRate) {
            GameObject o2 = Instantiate(
                oxygenObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            o2.transform.parent = gameObject.transform;
            o2.GetComponent<Oxygen>().scrollSpeed = -3 * Random.Range(0.7f,1.4f) - dt.points*0.01f;
            oxygen.Add(o2.GetComponent<Oxygen>());
        }

        // Remove all Destroyed collectible
        
        coins.RemoveAll(GameObject => GameObject == null);
        oxygen.RemoveAll(GameObject => GameObject == null);
    }
}
