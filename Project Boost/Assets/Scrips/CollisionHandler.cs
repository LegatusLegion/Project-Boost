using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    [SerializeField] float invokeValue = 1f;
    [SerializeField] AudioClip rocketCrash;
    [SerializeField] AudioClip reachingFinish;

    AudioSource audioSource;


    bool isTransitioning = false;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (isTransitioning) return;

        switch (collision.gameObject.tag)
        {
            case "Friendly":
                Debug.Log("Hit Friendly");
                break;
            case "Finish":
                NextLevelSequence();
                break;
            default:
                StartCrashSequence();
                break;
        }
    }

    void StartCrashSequence()
    {
        //todo add particle effect
        isTransitioning = true;
        audioSource.PlayOneShot(rocketCrash);
        GetComponent<Movment>().enabled = false;
        Invoke("ReloadLevel", invokeValue);
    }

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void NextLevelSequence()
    {
        //todo add particle effect
        isTransitioning = true;
        audioSource.PlayOneShot(reachingFinish);
        GetComponent<Movment>().enabled = false;
        Invoke("LoadNextLevel", invokeValue);
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
