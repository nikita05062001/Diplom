using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CastSceneScript : MonoBehaviour
{
    private int level;
    // Start is called before the first frame update
    void Start()
    {
        level = PlayerPrefs.GetInt("Level");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && level == 1)
        {
            SceneManager.LoadScene("Game");
        }
        //второй уровень
        if (Input.GetKey(KeyCode.Space) && level == 2)
        {

            SceneManager.LoadScene("level2");

        }
        if (Input.GetKey(KeyCode.Space) && level == 3)
        {

            SceneManager.LoadScene("level3");

        }
        if (Input.GetKey(KeyCode.Space) && level == 4)
        {

            SceneManager.LoadScene("level4");

        }
        if (Input.GetKey(KeyCode.Space) && level == 5)
        {

            SceneManager.LoadScene("level5");

        }
        if (Input.GetKey(KeyCode.Space) && level == 6)
        {

            SceneManager.LoadScene("level6");

        }
        if (Input.GetKey(KeyCode.Space) && level == 7)
        {

            SceneManager.LoadScene("level7");

        }
        if (Input.GetKey(KeyCode.Space) && level == 8)
        {

            SceneManager.LoadScene("level8");

        }
    }
}
