using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour
{
    public int startingLives = 1;
    public int currentLives;

    public void Death(int amount)
    {
        currentLives -= amount;
        Destroy(gameObject);
    }
}
