using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLevel : MonoBehaviour
{
    [SerializeField] private AudioSource audio;

    private bool levelCompleted = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name=="Player" && !levelCompleted)
        {
            audio.Play();
            levelCompleted = true;
            Invoke("CompletedLevel", 2f);
        }
    }

    private void CompletedLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
