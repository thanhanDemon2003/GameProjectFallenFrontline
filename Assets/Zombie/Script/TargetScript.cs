
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

    private void Start()
    {
        animator = GetComponent<Animator>();
        zombie = GetComponent<Zombie>();
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
