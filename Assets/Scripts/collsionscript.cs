using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class collsionscript : MonoBehaviour
{
    AudioSource audioSource;
    [SerializeField] AudioClip Landengine;
    [SerializeField] AudioClip Crash;

    [SerializeField] ParticleSystem SuccessParticles;
    [SerializeField] ParticleSystem CrashParticles;

    bool istransitioning = false; 
    bool collisionDisabled = false;
    void Start()
    {
        audioSource= GetComponent<AudioSource>();
    }

    void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L)) 
        {
            LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C)) 
        {
            collisionDisabled = !collisionDisabled;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (istransitioning || collisionDisabled){return;}
        switch (other.gameObject.tag) 
        { 
            case "Friendly":
                Debug.Log("this is Friendly");
                break;
            case "Finish":
                StartSuccessSequence();
                break;
            default:
                startCrashSequence();
                break;
              
        }
    }
    public void StartSuccessSequence()
    {
        
        audioSource.Stop();
        istransitioning= true;
        audioSource.PlayOneShot(Landengine);
        SuccessParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("LoadNextLevel", 1f);

    }

    public void startCrashSequence()
    {
        audioSource.Stop();
        istransitioning = true;
        audioSource.PlayOneShot(Crash);
        CrashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", 1f);
    }
    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
}
