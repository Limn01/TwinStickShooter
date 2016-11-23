using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 5;
    public int currentHeatlh;
    public Image damageImage;
    public float flashSpeed = 0.5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
    public Slider healthBar;
    //public Material[] materials;
    
    //Renderer rend;
    bool hit;
    bool gameOver;
    GameObject cam;
    CameraShake camShake;
    bool camShaking = false;
    
	// Use this for initialization
	void Start ()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
        camShake = cam.GetComponent<CameraShake>();
        //rend = GetComponentInChildren<Renderer>();
        //rend.enabled = true;
        //rend.sharedMaterial = materials[0];
        currentHeatlh = startingHealth;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (hit)
        {
            damageImage.color = flashColor;
            //rend.sharedMaterial = materials[1];
            
            //rend.enabled = ;
            camShaking = true;
            camShake.Shake(0.5f, 0.2f);
        }
        else
        {
            damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
            //rend.sharedMaterial = materials[0];
            //rend.enabled = true;
            camShaking = false;
        }

        hit = false;
	}

    public void LoseLife(int amount)
    {
        Debug.Log("Hit");
        hit = true;
        currentHeatlh -= amount;
        healthBar.value = currentHeatlh;

        if (currentHeatlh <= 0)
        {
            gameObject.SetActive(false);
        }
    }

   
}
