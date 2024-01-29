using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private Rigidbody2D player;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private float jumpForce = 18f;
    [SerializeField] private GameObject flag;
    private int score = 0;
    private bool isStart;

    void Update()
    {
        isStart = gm.GetStatus();
        if (isStart)
        {
            if (Input.GetKeyDown("space"))
            {
                player.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
            if (Input.GetKeyDown("right"))
            {
                playerAnim.SetBool("isRun", true);
            }
            if (player.position.y < -3.0f)
            {
                playerAnim.SetBool("isStuck", true);
                gm.EndGame();
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        playerAnim.SetBool("isStuck", false);

        if (collision.gameObject.CompareTag("Ground"))
        {
            if (player.position.y - 0.4f > collision.gameObject.GetComponent<Transform>().position.y)
            {
                playerAnim.SetBool("isStuck", false);
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable") || collision.gameObject.CompareTag("Obstacle")
            || collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("End"))
        {
            playerAnim.SetBool("isStuck", true);
        }
        if (collision.gameObject.CompareTag("Collectable"))
        {
            collision.gameObject.SetActive(false);
            score += 1;
        }
        if (collision.gameObject.CompareTag("End"))
        {
            playerAnim.SetBool("isRun", false);
            flag.SetActive(true);
            gm.EndGame();
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (player.position.y - 0.4f < collision.gameObject.GetComponent<Transform>().position.y)
            {
                playerAnim.SetBool("isStuck", true);
            }
        }
    }
    public int GetScore()
    {
        return score;
    }
}
