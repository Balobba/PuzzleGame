using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarExtendRetract : MonoBehaviour
{

    Animator anim;
    private bool extended;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        extended = anim.GetBool("extended");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space")){

            if (!extended)
            {

                ExtendPillar();
            }
            else
            {
                RetractPillar();
            }

        }
    }


    public void ExtendPillar()
    {
        anim.SetTrigger("switch");
        anim.SetBool("extended", true);
        extended = true;

    }

    public void RetractPillar()
    {

        anim.SetTrigger("switch");
        anim.SetBool("extended", false);
        extended = false;

    }

}
