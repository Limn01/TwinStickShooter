using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyShootingSpawn : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate;
    public Transform[] spawnPoints;
    public PlayerHealth playerHealth;
    public float spawnRadius = 5f;
    public float spawnEnemy = 6f;
    public ParticleSystem spawnPart;
    Transform spawnPosition;
    Vector3 spawnVector;
    Vector3 randomPoint;
    float spawnTimer = 0f;
    float enemySpawnTimer = 0;
    

    bool canSpawn;



    void Update()
    {
        spawnTimer += Time.deltaTime;
        enemySpawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnRate)
        {
            GetSpawnPos();
            spawnTimer = 0f;
        }

        if (enemySpawnTimer >= spawnEnemy)
        {
            Spawn();
            enemySpawnTimer = 0;
        }
    }
    
    void GetSpawnPos()
    {
        Debug.Log("Getting spawn position");
        int randPos = Random.Range(0, spawnPoints.Length);
        spawnPosition = spawnPoints[randPos].transform;
        spawnVector = new Vector3(spawnPosition.transform.position.x, spawnPosition.transform.position.y);
        randomPoint = Random.insideUnitSphere * spawnRadius;
        Debug.Log(spawnVector.ToString());
        ParticleSpawn();
    }

    void Spawn()
    {
        if (playerHealth.currentHeatlh <= 0f)
        {
            Debug.Log("Player Dead");

            return;
        }

        GameObject enemyObject = EnemyShootingPool.current.GetPooledObject();

        List<GameObject> pooledEnemy = new List<GameObject>();

        pooledEnemy.Add(enemyObject);

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if (!pooledEnemy[spawnPointIndex].activeInHierarchy && canSpawn == true)
        {
            pooledEnemy[spawnPointIndex].SetActive(true);
            pooledEnemy[spawnPointIndex].transform.position = spawnVector + randomPoint;
            pooledEnemy[spawnPointIndex].transform.rotation = transform.rotation;
            canSpawn = false;
        }

        if (ScoreManager.score > 150)
        {
            spawnRate = 1f;
        }

    }

    void ParticleSpawn()
    {
        if (playerHealth.currentHeatlh <= 0 )
        {
            return;
        }

        Debug.Log("Spawning particles");
        GameObject particleObject = ParticlePoolScript.current.GetPooledObject();

        List<GameObject> pooledParticle = new List<GameObject>();

        pooledParticle.Add(particleObject);


        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        if (!pooledParticle[spawnPointIndex].activeInHierarchy)
        {
            //Vector3 randomPoint = Random.insideUnitSphere * spawnRadius;
            pooledParticle[spawnPointIndex].SetActive(true);
            pooledParticle[spawnPointIndex].transform.position = spawnVector + randomPoint;
            //////////
            Debug.Log(pooledParticle[spawnPointIndex].transform.position.ToString());
            ///////////
            pooledParticle[spawnPointIndex].transform.rotation = Quaternion.Euler(-90f, 0f, 0f);
        }
       // StartCoroutine(waitTime(1.5f));
    }

    //IEnumerator waitTime(float time)
    //{
    //    yield return new WaitForSeconds(time);
    //    canSpawn = true;
    //    Spawn();
    //    
    //}
}
