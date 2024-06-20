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


    private List<StructureManager> bombs;
    private List<StructureManager> coins;
    private List<Oxygen> oxygen;
    private List<StructureManager> traps;

    private float bombsToSpawn;
    private float trapToSpawn;
    private float oxygenToSpawn;
    private float coinsToSpawn;
    private int depthScaling;
    // Start is called before the first frame update
    void Start()
    {
        bombs = new List<StructureManager>();
        coins = new List<StructureManager>();
        oxygen = new List<Oxygen>();
        traps = new List<StructureManager>();
        bombsToSpawn = initialBombsToSpawn;
        coinsToSpawn = initialCoinsToSpawn;
        trapToSpawn = initialTrapToSpawn;
        oxygenToSpawn = initialOxygenToSpawn;
    }


    void FixedUpdate()
    {
        depthScaling = Mathf.FloorToInt(dt.points/100);
        Debug.Log(depthScaling);
        bombsToSpawn = initialBombsToSpawn + depthScaling;
        coinsToSpawn = initialCoinsToSpawn + depthScaling;
        trapToSpawn = initialTrapToSpawn + Mathf.FloorToInt(dt.points/500);    
        oxygenToSpawn = initialOxygenToSpawn - Mathf.FloorToInt(dt.points/300);
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
            bomb.GetComponent<StructureManager>().scrollSpeed = -1 * Random.Range(0.7f,1.4f) - dt.points*0.001f;
            bombs.Add(bomb.GetComponent<StructureManager>());
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
            trap.GetComponent<StructureManager>().scrollSpeed = -0.5f * Random.Range(0.7f,1.4f) - dt.points*0.001f;
            traps.Add(trap.GetComponent<StructureManager>());
        }

        // Remove all Destroyed bombs
        bombs.RemoveAll(GameObject => GameObject == null);
        traps.RemoveAll(GameObject => GameObject == null);
    }

    void spawnCollectible()
    {
        float spawnSeed = Random.Range(0, 10);

        // SPAWN COIN
        if (coins.Count < Mathf.Min(coinsToSpawn,8) && spawnSeed > collectibleSpawnRate) {
            GameObject coin = Instantiate(
                coinObject[Random.Range(0,2)].gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            coin.transform.parent = gameObject.transform;
            coin.GetComponent<StructureManager>().scrollSpeed = -1 * Random.Range(0.7f,1.4f) - dt.points*0.001f;
            coins.Add(coin.GetComponent<StructureManager>());
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
            o2.GetComponent<Oxygen>().scrollSpeed = -3 * Random.Range(0.7f,1.4f) - dt.points*0.001f;
            oxygen.Add(o2.GetComponent<Oxygen>());
        }

        // Remove all Destroyed collectible
        
        coins.RemoveAll(GameObject => GameObject == null);
        oxygen.RemoveAll(GameObject => GameObject == null);
    }
}
