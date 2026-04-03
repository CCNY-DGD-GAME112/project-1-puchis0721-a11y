using UnityEngine;

public class SpeedBoostItem : MonoBehaviour
{
    public float boostAmount = 3f;
    public float duration = 2f;

    
    public AudioClip boostSound;  
    private AudioSource audioSource;

    private void Start()
    {
        
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = boostSound;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();

        if (player != null)
        {
            
            player.StartCoroutine(player.SpeedBoost(boostAmount, duration));

            
            if (audioSource != null && boostSound != null)
            {
                audioSource.Play();
                
                Destroy(gameObject, boostSound.length);
            }
            else
            {
                
                Destroy(gameObject);
            }
        }
    }
}