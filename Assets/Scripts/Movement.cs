using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody rb;
    private AudioSource _audio;
    private bool isAlive;

    [SerializeField] private float thrust = 100.0f;
    [SerializeField] private float rotateSpeed = 10.0f;
    [SerializeField] private AudioClip mainEngine;

    [SerializeField] private ParticleSystem thrustParticle;
    [SerializeField] private ParticleSystem RightRotateParticle;
    [SerializeField] private ParticleSystem LeftRotateParticle;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        _audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }
    
    private void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            if (!_audio.isPlaying)
            {
                _audio.PlayOneShot(mainEngine);
            }
            if (!thrustParticle.isPlaying)
            {
                thrustParticle.Play();   
            }
        }
        else
        {
            _audio.Stop();
            thrustParticle.Stop();
        }

    }
    
    private void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotateSpeed);
            if (!LeftRotateParticle.isPlaying)
            {
                LeftRotateParticle.Play();
            }
            
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotateSpeed);
            if (!RightRotateParticle.isPlaying)
            {
                RightRotateParticle.Play();
            }
        }
        else
        {
            RightRotateParticle.Stop();
            LeftRotateParticle.Stop();
        }
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true; // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false; // unfreezing rotation
    }
}
