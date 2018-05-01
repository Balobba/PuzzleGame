using UnityEngine;

public class StoneInteractable : MonoBehaviour
{

    private GameObject thePlayer;
    public float pushDistance = 1f;


    private void Start()
    {
        thePlayer = GameObject.FindWithTag("Player");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {


            if (Mathf.Abs(gameObject.transform.position.y - thePlayer.transform.position.y) > Mathf.Abs(gameObject.transform.position.x - thePlayer.transform.position.x))
            {
                if (Mathf.Abs(thePlayer.transform.position.y) > Mathf.Abs(gameObject.transform.position.y))
                {
                    Debug.Log("rock over player");
                    gameObject.transform.Translate(0, pushDistance, 0);

                }
                else
                {
                    Debug.Log("rock under player");
                    gameObject.transform.Translate(0, -pushDistance, 0);
                }
            }
            else
            {
                if (Mathf.Abs(thePlayer.transform.position.x) > Mathf.Abs(gameObject.transform.position.x))
                {
                    Debug.Log("rock left of player");
                    gameObject.transform.Translate(-pushDistance, 0, 0);

                }
                else
                {
                    Debug.Log("rock right of player");
                    gameObject.transform.Translate(pushDistance, 0, 0);

                }
            }
        }
    }
}
