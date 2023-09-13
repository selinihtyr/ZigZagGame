using System;
using System.Collections;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    GameManager gameManager;
    CharMovement charMovement;
    public GameObject audioEffectObject;
    public AudioClip soundEffect;
    private bool collected = false;

    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    
        charMovement = FindObjectOfType<CharMovement>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !collected )
        {
            collected = true;
            gameManager.IncreaseScore();
            charMovement.speed += gameManager.crystalSpeedMultiplier;
            charMovement.speed = Mathf.Min(charMovement.speed, charMovement.maxSpeed);

            // Instantiate the audio effect prefab
        GameObject audioEffectInstance = Instantiate(audioEffectObject, transform.position, Quaternion.identity);
        
        // Get the AudioSource component
        AudioSource audioSource = audioEffectInstance.GetComponent<AudioSource>();

        // Assign the sound effect to the AudioSource component
        audioSource.clip = soundEffect;

        // Play the sound effect
        audioSource.Play();

        // Destroy the audio effect instance after the clip has finished playing
        Destroy(audioEffectInstance, soundEffect.length);

        // Destroy the object
        Destroy(gameObject);
        }
    }
}
