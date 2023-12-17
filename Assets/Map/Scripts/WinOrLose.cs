
using FPS.Player;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static ApiReward;
public class WinOrLose : MonoBehaviour
{
    // [SerializeField] BackgroundMusic music;
    [SerializeField] RandomEnemies randomEnemies;
    [SerializeField] RandomEnemies randomEnemies_1;
    [SerializeField] GameObject endPanel;
    [SerializeField] RawImage videoBackGround;
    [SerializeField] TextMeshProUGUI result;

    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI dotcoin;

    [SerializeField] AudioClip musicWin;
    [SerializeField] AudioClip musicLose;

    AudioSource audio;
    PlayerHealth health;
    ScoreTrack track;
    PlayerController player;

    public int TimeCount;
    public bool isEnded;
    public int bonus;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<PlayerHealth>();
        audio = endPanel.GetComponentInChildren<AudioSource>();
        track = GameObject.FindGameObjectWithTag("ScoreTrack").GetComponent<ScoreTrack>();
        player = GetComponent<PlayerController>();
        StartCoroutine(countTime());
        bonus = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (health.currentHP <= 0)
        {
            EndALevel(false);
        }
    }

    private IEnumerator countTime()
    {
        while (!isEnded)
        {
            yield return new WaitForSeconds(1);
            TimeCount++;
        }
    }

    public void EndALevel(bool win)
    {
        player.canControl = false;
        isEnded = true;
        GameObject[] enemy = GameObject.FindGameObjectsWithTag("Zombie");
        foreach (GameObject zombie in enemy)
        {
            Destroy(zombie);
        }
        randomEnemies.enabled = false;
        randomEnemies_1.enabled = false;
        endPanel.SetActive(true);
        // music.TurnOffMusic();

        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;

        time.text = "Time: " + TimeCount;

        if (win)
        {
            result.text = "MISSION COMPLETE";
            audio.clip = musicWin;
            videoBackGround.color = Color.white;

            dotcoin.text = "Dotcoin:" + bonus;
        }
        else
        {
            result.text = "MISSION FAILED";
            audio.clip = musicLose;
            videoBackGround.color = Color.red;
        }
    }

    public void UpRewardMap2(string playingTime, int dotcoin)
    {
        StartCoroutine(UpRewardMode2(playingTime, dotcoin));
    }
    public void Restart()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
    }
    public void BackToMenu()
    {
        SceneManager.LoadSceneAsync(1);
    }
}
