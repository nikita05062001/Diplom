using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimScript : MonoBehaviour
{
    private Animator anim;
    public bool isLevelOpa;
    
    void Start()
    {
        anim = GetComponent<Animator>();  
        
    }

    private void Update()
    {
       
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && isLevelOpa != true)
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
         if (isLevelOpa != true)   anim.SetBool("isRunning", false);
        }
        
        
    }
}
