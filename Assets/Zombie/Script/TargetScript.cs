
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health = 100;
    public float enemiesDmg;
    private Zombie zombie;
    private Animator animator;

    public GameObject ammoPrimaryBox;
    public GameObject ammoSecondaryBox;
    public GameObject painkiller;

    private ScoreTrack score;
    private void Start()
    {
        animator = GetComponent<Animator>();
        zombie = GetComponent<Zombie>();
        score = GameObject.FindGameObjectWithTag("ScoreTrack").GetComponent<ScoreTrack>();
    }
    public void TakeDamage(float amount)
    {
        health -= amount;
    }

    private void Update()
    {
        if (zombie != null)
        {
            if (health <= 0)
            {
                this.enabled = false;
                score.ZombieKilled += 1;

                if (zombie.RandomChance() > 8)
                {
                    Instantiate(painkiller, transform.position, Quaternion.identity);
                }

                else if (zombie.RandomChance() > 6)
                {
                    Instantiate(ammoPrimaryBox, transform.position, Quaternion.identity);
                }
                else if (zombie.RandomChance() > 4)
                {
                    Instantiate(ammoSecondaryBox, transform.position, Quaternion.identity);
                }
                else return;
            }
        }
    }
}
