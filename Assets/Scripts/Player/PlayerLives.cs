using UnityEngine;
using System.Collections;

public class PlayerLives : MonoBehaviour
{
    public int startingLives = 5;
    public int currentLives;
    public float invMaxTime = 5f;

    bool isDead;
    public bool hit;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    MeshRenderer mesh;
    GameObject player;
    bool isInvisiable;
    public float invTimer;
    float respawnTimer;
    float respawnMaxTime = 1;
    public float timer;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerShooting = GetComponent<PlayerShooting>();
        mesh = GetComponentInChildren<MeshRenderer>();

        currentLives = startingLives;
    }

    void Update()
    {
        HandleInvisablity();
        HandleRespawn();   
    }

    public void LoseLife(int amount)
    {
        hit = true;
        currentLives -= amount;

        if (hit)
        {
            mesh.enabled = false;
            playerMovement.enabled = false;
            playerShooting.enabled = false;
        }
        

        if (currentLives <= 0)
        {
            GameOver();
        }
    }

    void HandleRespawn()
    {
        if (hit)
        {
            respawnTimer += Time.deltaTime;

            if (respawnTimer > respawnMaxTime)
            {
               // mesh.enabled = false;

                
                //gameObject.SetActive(true);
            }
        }
    }

    void HandleInvisablity()
    {
        mesh.enabled = true;
        playerMovement.enabled = true;
        playerShooting.enabled = true;

        if (isInvisiable)
        {
            invTimer += Time.deltaTime;

            if (invTimer > invMaxTime)
            {
                isInvisiable = false;
                invTimer = 0;
            }
        }
    }

    void GameOver()
    {
        //player.SetActive(false);
    }
}
