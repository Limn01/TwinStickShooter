using UnityEngine;
using System.Collections;

public class ColorChangeScript : MonoBehaviour
{
    public Material[] materials;

    Renderer rend;
	// Use this for initialization
	void Start ()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = materials[0];
	}
	
	void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            rend.sharedMaterial = materials[1];
        }

        else
        {
            rend.sharedMaterial = materials[0];
        }
    }
}
