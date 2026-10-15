using UnityEngine;

public class BlockSound : MonoBehaviour
{
    public AudioSource fallSound;

    void OnCollisionEnter()
    {
        
        fallSound.Play();
        
    }
}
