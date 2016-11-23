using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Destroy", 3f);
    }

    void Destroy()
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        gameObject.SetActive(false);
    }

    void OnDisable()
    {
        CancelInvoke();
    }
}
