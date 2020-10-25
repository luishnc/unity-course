using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            anim.SetBool("Turn_Left", true);
            anim.SetBool("Turn_Right", false);
        }

         else if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            anim.SetBool("Turn_Left", false);
            anim.SetBool("Turn_Right", false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            anim.SetBool("Turn_Left", false);
            anim.SetBool("Turn_Right", true);
        } else if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            anim.SetBool("Turn_Left", false);
            anim.SetBool("Turn_Right", false);
        }
        
    }
}
