using UnityEngine;

public class StoneSliderInteractable : MonoBehaviour
{

    private GameObject thePlayer;
    public float thrust = 1f;
    private int slideDirection = 0;
    Rigidbody2D stoneBody;



    private void Start()
    {
        thePlayer = GameObject.FindWithTag("Player");
        stoneBody = gameObject.GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        if(slideDirection == 0)
        {
            gameObject.transform.Translate(0, 0, 0);
            stoneBody.velocity = new Vector2(0, 0);
        }
        else
        {
            SlideStone();

        }
        
    }

    private void SlideStone()
    {

        switch (slideDirection)
        {
            case 1:
                gameObject.transform.Translate(0, thrust * Time.deltaTime, 0);
                break;
            case 2:
                gameObject.transform.Translate(0, -thrust * Time.deltaTime, 0);
                break;
            case 3:
                gameObject.transform.Translate(-thrust * Time.deltaTime, 0, 0);
                break;
            case 4:
                gameObject.transform.Translate(thrust * Time.deltaTime, 0, 0);
                break;
            case 0:
                gameObject.transform.Translate(0, 0, 0);
                stoneBody.velocity = new Vector2(0, 0);
                break;
            default:
                gameObject.transform.Translate(0, 0, 0);
                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Hit by Player");

            if (Mathf.Abs(gameObject.transform.position.y - thePlayer.transform.position.y) > Mathf.Abs(gameObject.transform.position.x - thePlayer.transform.position.x))
            {
                if (Mathf.Abs(thePlayer.transform.position.y) > Mathf.Abs(gameObject.transform.position.y))
                {
                    Debug.Log("rock over player");
                    slideDirection = 1;

                }
                else
                {
                    Debug.Log("rock under player");
                    slideDirection = 2;
                }
            }
            else
            {
                if (Mathf.Abs(thePlayer.transform.position.x) > Mathf.Abs(gameObject.transform.position.x))
                {
                    Debug.Log("rock left of player");
                    slideDirection = 3;

                }
                else
                {
                    Debug.Log("rock right of player");
                    slideDirection = 4;

                }
            }
        }

        if (collision.gameObject.tag != "Player")
        {
            Debug.Log("Hit by Obstacle");
            slideDirection = 0;
        }
    }
}

