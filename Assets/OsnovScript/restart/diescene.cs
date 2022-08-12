using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class diescene : MonoBehaviour
{
    public AudioSource Myfxdeath;
    public AudioClip DeadSound;
    private int level;

    private void Awake()
    {
        Myfxdeath.PlayOneShot(DeadSound);
    }
    private void Start()
    {
        level = PlayerPrefs.GetInt("Level");
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            switch (level) {
                case 1:
                    SceneManager.LoadScene("Game") ;
                    break;
                case 2:
                    SceneManager.LoadScene("level2");
                    break;
                case 3:
                    SceneManager.LoadScene("level3");
                    break;
                case 4:
                    SceneManager.LoadScene("level4");
                    break;
                case 5:
                    SceneManager.LoadScene("level5");
                    break;
                case 6:
                    SceneManager.LoadScene("level6");
                    break;
                case 7:
                    SceneManager.LoadScene("level7");
                    break;
                case 8:
                    SceneManager.LoadScene("level8");
                    break;
            }
        }
    }
}
