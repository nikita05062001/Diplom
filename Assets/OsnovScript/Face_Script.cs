using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face_Script : MonoBehaviour
{
    public bool IsLevelOsel = false;
  
    private SpriteRenderer sprite;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (IsLevelOsel == false)
        if (Input.GetButton("Horizontal")) Run();
    }
    private void Run()
    {

        Vector3 direction = transform.right * Input.GetAxis("Horizontal");
        sprite.flipX = direction.x < 0.0f;
    }
}
