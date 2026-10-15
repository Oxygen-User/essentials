using UnityEngine;

public class BallImpactSound : MonoBehaviour
{
    public AudioSource hitSound;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            hitSound.Play();
        }
    }
}
