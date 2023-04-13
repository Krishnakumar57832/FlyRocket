using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 100f;
    [SerializeField] float roThrust = 1f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem MainthrustParticles;
    [SerializeField] ParticleSystem RightThrustParticles;
    [SerializeField] ParticleSystem LeftThrustParticles;

    Rigidbody rb;
    AudioSource audioSource;
    bool istransitionning = false;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if(istransitionning) { return;  }
        if(Input.GetKey(KeyCode.Space))
        {
            StartThrusting();

        }
        else
        {
            StopThrusting();
        }


    }
    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            RotateRight();
        }
        else
        {
            StopRotating();
        }
    }



    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEngine);
        }
        if (!MainthrustParticles.isPlaying)
        {
            MainthrustParticles.Play();
        }
    }

    void StopThrusting()
    {
        audioSource.Stop();
        MainthrustParticles.Stop();
    }

    void RotateLeft()
    {
        ApplyRotation(roThrust);
        if (!RightThrustParticles.isPlaying)
        {
            RightThrustParticles.Play();
        }
    }
    void RotateRight()
    {
        ApplyRotation(-roThrust);
        if (!LeftThrustParticles.isPlaying)
        {
            LeftThrustParticles.Play();
        }
    }

    void StopRotating()
    {
        RightThrustParticles.Stop();
        LeftThrustParticles.Stop();
    }

    public void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
    
   
}
