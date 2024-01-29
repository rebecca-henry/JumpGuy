using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int score;
    private float time;
    private bool isStart;
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private PlayerController player;
    [SerializeField] private TextMeshProUGUI scoreVal;
    [SerializeField] private TextMeshProUGUI timeVal;

    [SerializeField] private TextMeshProUGUI endScore;
    [SerializeField] private TextMeshProUGUI endTime;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject endPanel;

    // Update is called once per frame
    void Update()
    {
        if (isStart)
        {
            score = player.GetScore();
            scoreVal.SetText(score.ToString());
            if (playerAnim.GetBool("isStuck") == false)
            {
                time += Time.deltaTime;
            }
            timeVal.SetText(Mathf.RoundToInt(time).ToString());
        }
    }

    public void StartGame()
    {
        startPanel.SetActive(false);
        endPanel.SetActive(false);
        pausePanel.SetActive(false);
        isStart = true;
        time = 0;
        score = 0;
    }

    public void EndGame()
    {
        endPanel.SetActive(true);
        pausePanel.SetActive(true);
        isStart = false;
        endScore.SetText(score.ToString());
        endTime.SetText(Mathf.RoundToInt(time).ToString());
    }

    public bool GetStatus()
    {
        return isStart;
    }
}
