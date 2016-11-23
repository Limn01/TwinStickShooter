using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerShooting : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed = 0.0f;
    public Transform gunEnd;
    public float timeBetweenShoot = 0.1f;

    bool isShooting;
    Vector3 playerDirection;
    float coolDownTime = 100f;
    float timer;
    bool nextLevel;
    GameObject enemy;
    BulletDamage bulletDamage;

    void Start()
    {
        bulletDamage = GetComponent<BulletDamage>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        Turning();
    }

    void Shooting()
    {
        timer = 0f;

        //creating a local obj from our object pooling script
        GameObject obj = BulletObjectPooling.current.GetPooledObject();
        //create a list of pooledObjs
        List<GameObject> pooledObj = new List<GameObject>();
        //adding to the list of our pooled obj
        pooledObj.Add(obj);

        //random index within the list
        int randomIndex = Random.Range(0, pooledObj.Count);
        //checks to see if its not active in scene
        if(!pooledObj[randomIndex].activeInHierarchy)
        {
            pooledObj[randomIndex].SetActive(true);
            pooledObj[randomIndex].transform.position = gunEnd.transform.position;
            pooledObj[randomIndex].transform.rotation = transform.rotation;
            pooledObj[randomIndex].GetComponent<Rigidbody>().AddForce(gunEnd.forward * bulletSpeed, ForceMode.Impulse);
        }

        if (ScoreManager.score == 100)
        {
            timeBetweenShoot = 0.1f;
        }
        //add a bool 'Level2'
        //create another local obj
        //add to list
        //do the ifpooled!inhierarchy thing

    }

    void Turning()
    {
        playerDirection = Vector3.right * Input.GetAxisRaw("RightStickHorizontal") + Vector3.forward * -Input.GetAxisRaw("RightStickVertical");

        if (playerDirection.sqrMagnitude > 0.0f )
        {
            transform.rotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            if (timer >= timeBetweenShoot)
            {
                Shooting();
            }
            
        }
    }
}
