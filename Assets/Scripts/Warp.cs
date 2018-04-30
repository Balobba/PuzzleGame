using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warp : MonoBehaviour {//The script that is applied to all warp zones. Teleports the player from point A to point B

    public Transform warpTarget;

    IEnumerator OnTriggerEnter2D(Collider2D other)
    {

        if (other.transform.tag == "Player") //Only the player can go through the warp zone
        {

            ScreenFader sf = GameObject.FindGameObjectWithTag("Fader").GetComponent<ScreenFader>();



            yield return StartCoroutine(sf.FadeToBlack());


            //Debug.Log("collidied");
            other.gameObject.transform.position = warpTarget.position; //moves the object that collided to the target spot
            Camera.main.transform.position = warpTarget.position; //the camera follows to the target spot



            yield return StartCoroutine(sf.FadeToClear());

        }
    }

}
