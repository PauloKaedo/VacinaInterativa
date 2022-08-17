using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float playerSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Transform groundChecker;
    [SerializeField] private LayerMask whatIsGround;

    [SerializeField] private List<GameObject> lifes;

    private int playerLifes;

    private Vector2 initialPosition;

    private bool isOnGround;
    private bool canDoubleJump;

    private Rigidbody2D playerRb;
    private Animator playerAnim;

    private List<string> colletedClues;

    private void Start() {
        colletedClues = new List<string>();
        playerLifes = 3;
        playerRb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponentInChildren<Animator>();
        initialPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        walk();
        jump();
    }

    public void addClue(string clue)
    {
        colletedClues.Add(clue);
    }

    void walk(){
        playerAnim.SetFloat("running",Mathf.Abs(Input.GetAxisRaw("Horizontal")));
        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = true;
        } else
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().flipX = false;
        }
        playerRb.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * playerSpeed, playerRb.velocity.y);
    }

    void jump(){
        isOnGround = Physics2D.OverlapCircle(groundChecker.position, 0.2f, whatIsGround);
        playerAnim.SetBool("isOnGround", isOnGround);
        if(Input.GetButtonDown("Jump") && (isOnGround || canDoubleJump))
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            
            if(isOnGround)
            {
                canDoubleJump = true;
            } else
            {
                canDoubleJump = false;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {
            collision.GetComponentInParent<NpcController>().openQuestion();

        }

        if (collision.gameObject.tag == "Respawn")
        {
            transform.position = initialPosition;
            loseLife();
        }

        if (collision.gameObject.tag == "Finish")
        {
            FindObjectOfType<GameController>().wonStage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "NPC")
        {

            FindObjectOfType<GameController>().closeQuestionarie();
            
        }
    }

    public void loseLife()
    {
        playerLifes--;
        if(playerLifes < 0)
        {
            FindObjectOfType<GameController>().gameOverScene();
        } else
        {
            switch (playerLifes)
            {
                case 2:
                    lifes[0].SetActive(false);
                    break;
                case 1:
                    lifes[1].SetActive(false);
                    break;
                case 0:
                    lifes[2].SetActive(false);
                    break;
            }
        }
    }
}
