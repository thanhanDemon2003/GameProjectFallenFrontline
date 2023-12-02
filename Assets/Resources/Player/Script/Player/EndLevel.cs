
using FPS.Player;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EndLevel : MonoBehaviour
{
    [SerializeField] SpawnWave spawnWave;
    [SerializeField] BackgroundMusic music;
    [SerializeField] GameObject endPanel;
    [SerializeField] RawImage videoBackGround;
    [SerializeField] TextMeshProUGUI result;


    [SerializeField] TextMeshProUGUI kill;
    [SerializeField] TextMeshProUGUI time;
    [SerializeField] TextMeshProUGUI dotcoin;

    [SerializeField] AudioClip musicWin;
    [SerializeField] AudioClip musicLose;

    AudioSource audio;
    PlayerHealth health;
    ScoreTrack track;
    PlayerController player;

    public float TimeCount;
    public bool isEnded;
    // Start is called before the first frame update
    void Start()
    {
        health= GetComponent<PlayerHealth>();
        audio = endPanel.GetComponentInChildren<AudioSource>();
        track= GameObject.FindGameObjectWithTag("ScoreTrack").GetComponent<ScoreTrack>();
        player = GetComponent<PlayerController>();
        StartCoroutine(countTime());
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
        //spawnWave.enabled = false;
        endPanel.SetActive(true);
        music.TurnOffMusic();

        UnityEngine.Cursor.lockState = CursorLockMode.Confined;
        UnityEngine.Cursor.visible = true;

        kill.text = "Kill: " + track.ZombieKilled;
        time.text = "Time: " + TimeCount;

        if (win)
        {
            result.text = "YOU SURVIVED THE NIGHT";
            audio.clip = musicWin;
            videoBackGround.color = Color.white;
        }
        else
        {
            result.text = "ANOTHER FALLEN SOLDIER";
            audio.clip = musicLose;
            videoBackGround.color = Color.red;
        }
    }
}
