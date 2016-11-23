using UnityEngine;
using System.Collections;

public class BulletDamage : MonoBehaviour
{
    GameObject enemy;

    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject == enemy)
        {
            Debug.Log("Enemy Hit");
            other.gameObject.SetActive(false);
        }
    }
}
