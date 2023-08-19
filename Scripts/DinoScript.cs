using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

[RequireComponent(typeof(CharacterController))]
public class DinoScript : MonoBehaviour
{
    private CharacterController character;
    private Vector3 direction;
    private AudioSource audioSource;
    public float volume;

    public float dinoStrength = 8f;
    public float gravity = 9.81f * 2f;

    private void Awake()
    {
        character = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Start()
    {
        direction = Vector3.up * dinoStrength;
        
    }
    private void OnEnable()
    {
        direction = Vector3.zero;
    }

    private void Update()
    {
         direction += Vector3.down * gravity * Time.deltaTime;

        if (character.isGrounded)
        {
            direction = Vector3.down;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                audioSource.volume = volume;
                audioSource.Play(); 
                direction = Vector3.up * dinoStrength;
            }
        }

        character.Move(direction * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider obj)
    {
        if(obj.CompareTag("Obstacle"))
        {
            FindObjectOfType < GameManager>().gameOver();
        }
    }
}



