using UnityEngine;
using System.Collections;

public class PlayerRespawn : MonoBehaviour
{
    public GameObject player;
    public Transform playerSpawn;
    public float spawnTimer;
    public float timer;
    public float maxSpawnTime = 2;
    public int startingLives = 5;
    public int currentLives;
    public bool hit;

    bool invisable;
    float invTimer;
    float invMaxTime = 0.5f;
    

    // Use this for initialization
    void Start ()
    { 
        currentLives = startingLives;
	}

    // Update is called once per frame
    void Update()
    {

    }

    public void LoseLife(int amount)
    {
        hit = true;

        currentLives -= amount;
        Debug.Log("Player Hit");
        Destroy(gameObject);
       // HandleRespawn();
    }

    //void HandleRespawn()
    //{
    //    if (hit)
    //    {
    //        spawnTimer += Time.deltaTime;
    //
    //        if (spawnTimer > maxSpawnTime)
    //        {
    //            GameObject playerClone = Instantiate(player, transform.position, Quaternion.identity) as GameObject;
    //            HandleInvisabilty();
    //            spawnTimer = 0;
    //        }
    //    }
    //}
    //
    //void HandleInvisabilty()
    //{
    //    if (hit)
    //    {
    //        invMaxTime += Time.deltaTime;
    //
    //        if (invTimer > invMaxTime)
    //        {
    //            invisable = false;
    //            invTimer = 0;
    //        }
    //    }
    //}
}
