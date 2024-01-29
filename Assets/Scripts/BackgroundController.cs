using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField] private GameManager gm;
    [SerializeField] private Transform bg;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private float speed;
    [SerializeField] private Transform[] objects;
    private bool isStart;

    void Update()
    {
        isStart = gm.GetStatus();
        if (isStart)
        {
            if (playerAnim.GetBool("isStuck") == false && playerAnim.GetBool("isRun") == true)
            {
                bg.position += Vector3.left * speed * 0.5f * Time.deltaTime;
                foreach (Transform obj in objects) { obj.position += Vector3.left * speed * 0.5f * Time.deltaTime; }
            }
            else if (playerAnim.GetBool("isStuck") == true || playerAnim.GetBool("isRun") == false)
            {
                bg.position += Vector3.left * 0;
                foreach (Transform obj in objects) { obj.position += Vector3.left * 0; }
            }
            if (bg.position.x <= -30f)
            {
                playerAnim.SetBool("isStuck", true);
                playerAnim.SetBool("isRun", false);
                gm.EndGame();
            }
        }
    }
}
