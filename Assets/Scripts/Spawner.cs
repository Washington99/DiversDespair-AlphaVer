using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Spawner : MonoBehaviour
{

    [SerializeField] private Bomb bombObject;
    [SerializeField] private int initialBombsToSpawn;


    [SerializeField] private Coin coinObject;
    [SerializeField] private int initialCoinsToSpawn;

    [SerializeField] private Oxygen oxygenObject;
    [SerializeField] private int initialOxygenToSpawn;

    [SerializeField] private Trap trapObject;
    [SerializeField] private int initialTrapToSpawn;
    [SerializeField] private int collectibleSpawnRate;
    [SerializeField] private int spawnWidth;
    [SerializeField] private depthTracker dt;

    private List<Bomb> bombs;
    private List<Coin> coins;
    private List<Oxygen> oxygen;
    private List<Trap> traps;

    private float bombsToSpawn;
    private float trapToSpawn;
    private float oxygenToSpawn;
    private float coinsToSpawn;
    private int depthScaling;
    // Start is called before the first frame update
    void Start()
    {
        bombs = new List<Bomb>();
        coins = new List<Coin>();
        oxygen = new List<Oxygen>();
        traps = new List<Trap>();
        bombsToSpawn = initialBombsToSpawn;
        coinsToSpawn = initialCoinsToSpawn;
        trapToSpawn = initialTrapToSpawn;
        oxygenToSpawn = initialOxygenToSpawn;
    }


    void FixedUpdate()
    {
        depthScaling = Mathf.FloorToInt(dt.points/10);
        Debug.Log(depthScaling);
        bombsToSpawn = initialBombsToSpawn + depthScaling;
        coinsToSpawn = initialCoinsToSpawn + depthScaling;
        trapToSpawn = initialTrapToSpawn + Mathf.FloorToInt(dt.points/50);    
        oxygenToSpawn = initialOxygenToSpawn - Mathf.FloorToInt(dt.points/30);
        spawnHazard();
        spawnCollectible();
    }


    void spawnHazard()
    {
        float spawnSeed = Random.Range(0, 10);

        // SPAWN BOMB
        if (spawnSeed > 8 && bombs.Count < bombsToSpawn) {
            GameObject bomb = Instantiate(
                bombObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            bomb.transform.parent = gameObject.transform;
            bomb.GetComponent<Bomb>().scrollSpeed = -1 * Random.Range(0.7f,1.4f) - dt.points*0.01f;
            bombs.Add(bomb.GetComponent<Bomb>());
        }

        // SPAWN TRAP
        if (spawnSeed < 8 && traps.Count < Mathf.Min(trapToSpawn,4)) {
            GameObject trap = Instantiate(
                trapObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            trap.transform.parent = gameObject.transform;
            trap.GetComponent<Trap>().scrollSpeed = -0.5f * Random.Range(0.7f,1.4f) - dt.points*0.01f;
            traps.Add(trap.GetComponent<Trap>());
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
                coinObject.gameObject, 
                transform.position + new Vector3(Random.Range(-spawnWidth, spawnWidth), 0.0f, 0.0f), 
                Quaternion.identity
                );

            // Place Instantiated bomb inside spawner object
            coin.transform.parent = gameObject.transform;
            coin.GetComponent<Coin>().scrollSpeed = -1 * Random.Range(0.7f,1.4f) - dt.points*0.01f;
            coins.Add(coin.GetComponent<Coin>());
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
