using UnityEngine;
using System;
using System.Collections;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffect;
    public AudioSource collectSound;
    public ParticleSystem onFinishEffect;
    public AudioSource FinishSound;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Rotate(0, rotationSpeed, 0);

    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            //destroy the collectible 
            Destroy(gameObject);
            // instantiate the particle effect 
            Instantiate(onCollectEffect, transform.position, transform.rotation);
            collectSound.Play();

            UpdateCollectibleDisplay();
            
            
            
        }

        

    }

    private void EpdateCollectibleDisplay()
    {
        GameObject any;

        any = GameObject.FindWithTag("Collectible");
        Debug.Log(any);
        if (any == null)
        {
            Instantiate(onFinishEffect, transform.position, Quaternion.Euler(-90f,0f,0f));
            FinishSound.Play();
        }
        
        
    }
    
    private void UpdateCollectibleDisplay()
    {
        int totalCollectibles = 0;

        // Check and count objects of type Collectible
        Type collectibleType = Type.GetType("Collectible");
        if (collectibleType != null)
        {
#if UNITY_6000_3_OR_NEWER
            totalCollectibles += FindObjectsByType(collectibleType).Length;
#else
            totalCollectibles += FindObjectsByType(collectibleType, FindObjectsSortMode.None).Length;
#endif
        }

        // Optionally, check and count objects of type Collectible2D as well if needed
        Type collectible2DType = Type.GetType("Collectible2D");
        if (collectible2DType != null)
        {
#if UNITY_6000_3_OR_NEWER
            totalCollectibles += FindObjectsByType(collectible2DType).Length;
#else
            totalCollectibles += FindObjectsByType(collectible2DType, FindObjectsSortMode.None).Length;
#endif
        }

        if (totalCollectibles <= 1)
        {
            Instantiate(onFinishEffect, transform.position, Quaternion.Euler(-90f,0f,0f));
            FinishSound.Play();
        }
    }

}
