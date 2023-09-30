
using System.Collections;
using System.Collections.Generic;
using FPS.Player;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float timer;
    public int newtarget;
    public Vector3 Target;
    private int timeMove = 0;

    public float speed = 2f;
    public float distanceAttach = 1f;
    public float distanceRada = 10f;
    public Transform myEnemy;
    private GameObject _player;
    public Transform PlayerTarget;

    private Vector3 slowdownV;
    private Vector2 horizontalMovement;
    private bool grounded;
    public float deaccelerationSpeed = 15.0f;
    public float currentSpeed;
    public int health = 200;
    public int damge = 1;
    bool Deaft = false;
    int demDestroy = 1000;
    void Start()
    {
        PlayerReal = GameObject.FindGameObjectWithTag("Player");
        _player = GameObject.FindGameObjectWithTag("tam");
        PlayerTarget = _player.transform;
        amt = gameObject.GetComponent<Animator>();
        TanCong(false);
        ChetLaCaiChat(false);
    }
    public void HitGun(int damge)
    {
        health -= damge;
        Debug.Log(health);
        if (health <= 0)
        {
            Deaft = true;
            ChetLaCaiChat(true);
        }
    }
    void TanCong(bool x)
    {
        amt.SetBool("TanCong", x);
    }
    void ChetLaCaiChat(bool x)
    {
        amt.SetBool("ChetCMMD", x);
    }

    void Update()
    {
        if (Deaft)
        {
            demDestroy--;
        }
        if (demDestroy <= 0)
        {
            Destroy(gameObject);
        }
    }
    float xPos = 50;
    float zPos = 50;

    Animator amt;
    RaycastHit hit;
    public int timeRoi;
    void RoiTuDo()
    {
        if (timeRoi <= 0)
        {
            amt.SetBool("DungIm", true);
            if (!Deaft)
            {
                if (Vector3.Distance(myEnemy.position, PlayerTarget.position) <= distanceRada && Vector3.Distance(myEnemy.position, PlayerTarget.position) > distanceAttach)
                {
                    myEnemy.position = Vector3.MoveTowards(myEnemy.position, PlayerTarget.position, speed * Time.deltaTime);
                    myEnemy.LookAt(PlayerTarget);
                    TanCong(false);
                }
                else if (Vector3.Distance(myEnemy.position, PlayerTarget.position) <= distanceAttach && Vector3.Distance(myEnemy.position, PlayerTarget.position) >= 0f)
                {

                    speed = 0f;
                    myEnemy.LookAt(PlayerTarget);
                    TanCong(true);
                    AttackPlayer();

                }
                else
                {
                    MoveRandom();
                    TanCong(false);
                }
            }
            else
            {
                Debug.Log("Chet");
            }

        }
        else
        {
            amt.SetBool("DungIm", false);
            timeRoi--;
        }

    } 

    void FixedUpdate()
    {
        RoiTuDo();
    }

    public GameObject PlayerReal;
    void AttackPlayer()
    {
       
        PlayerReal.GetComponent<PlayerController>();
    }

    Vector3 positRandom = Vector3.zero;
    void MoveRandom()
    {


        if (timeMove >= 100)
        {
            float myX = myEnemy.transform.position.x;
            float myZ = myEnemy.transform.position.z;
            xPos = myX + Random.Range(myX - 1000, myX + 1000);
            zPos = myZ + Random.Range(myZ - 1000, myZ + 1000);
            timeMove = 0;
        }
        else
        {
            timeMove++;
        }
        positRandom = new Vector3(xPos, myEnemy.transform.position.y, zPos);
        myEnemy.position = Vector3.MoveTowards(myEnemy.position, positRandom, speed * Time.deltaTime);
        myEnemy.LookAt(positRandom);
    }
}
   