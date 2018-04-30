using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenFader : MonoBehaviour { //Controlls the fade animations (when warping)

    Animator anim;
    public bool isFading = false;

	void Start () {
        anim = GetComponent<Animator> ();

    }

    public IEnumerator FadeToClear()
    {
        isFading = true;
        anim.SetTrigger("FadeIn");

        while (isFading)
        {
            yield return null;
        }
        
        
    }

    public IEnumerator FadeToBlack()
    {
        isFading = true;
        anim.SetTrigger("FadeOut");

        while (isFading)
        {
            yield return null;
        }
        
    }

    void AnimationComplete() //This function is called at the end of the animation
    {
        isFading = false;

    }

}
