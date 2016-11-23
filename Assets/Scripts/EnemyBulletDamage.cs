using UnityEngine;
using System.Collections;

public class EnemyBulletDamage : MonoBehaviour
{
    int attackDamage = 1;
    GameObject player;
    PlayerHealth playerHeatlth;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHeatlth = player.GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().LoseLife(attackDamage);
            gameObject.SetActive(false);
        }
    }
}
