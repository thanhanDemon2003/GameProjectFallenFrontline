
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health;
    public float enemiesDmg;

    private void Start()
    {
        health = 1000f;
        enemiesDmg = 10f;
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        Debug.Log(">>> Target health: " + health);
        if (health <= 0f)
        {
            Debug.Log(">>> Target Die ");
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(enemiesDmg);
                Debug.Log(">>> Player damage: " + enemiesDmg);
            }
        }
    }

}
