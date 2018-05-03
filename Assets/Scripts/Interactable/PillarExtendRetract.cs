using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarExtendRetract : MonoBehaviour
{

    Animator anim;
    private bool extended = false;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
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
        anim.ResetTrigger("retracted");
        anim.SetTrigger("extend");
        extended = true;

    }

    public void RetractPillar()
    {

        anim.ResetTrigger("extended");
        anim.SetTrigger("retract");
        extended = false;

    }

}
