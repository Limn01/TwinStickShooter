using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 1;
    public bool hit;
    public Transform enemy;
    public Transform target;
    public float moveSpeed = 0.0f;
    
    public bool playerInRange;
    GameObject player;
    //EnemyHealth enemyHealth;
    PlayerHealth playerLives;
    float timer;
    float xMin = -115f;
    float xMax = 115f;
    float vMin = -46.3f;
    float vMax = 46.3f;
    int points = 10;
    EnemySpawn enemySpawn;
   
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
        playerLives = player.GetComponent<PlayerHealth>();
        enemySpawn = GetComponent<EnemySpawn>();

        
        //enemyHealth = GetComponent<EnemyHealth>();
    }

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            Debug.Log("Triggered");
            other.gameObject.GetComponent<PlayerHealth>().LoseLife(attackDamage);
            this.gameObject.SetActive(false);
        }

        if (other.gameObject.tag == ("Bullet"))
        {
           gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            ScoreManager.score += points; 
        }
    }

    void FixedUpdate()
    {
        HandleMovement();
        HandleLook(); 
    }

    void HandleMovement()
    {      
        float dist = Vector3.Distance(transform.position, target.position);

        target = GameObject.FindGameObjectWithTag("Player").transform;
        transform.position = Vector3.MoveTowards(enemy.position, target.position, Time.deltaTime * moveSpeed);

        if (ScoreManager.score > 100)
        {
            moveSpeed = 20f;
        }

        if (ScoreManager.score > 150)
        {
            moveSpeed = 30f;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), 0, Mathf.Clamp(transform.position.z, vMin, vMax));  
    }

    void HandleLook()
    {
        transform.LookAt(player.transform.position);
    }
}
