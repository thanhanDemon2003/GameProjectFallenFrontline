using System.Collections;
using UnityEngine;

public class TargetScript : MonoBehaviour
{
    public float health;
    public float enemiesDmg;
    [SerializeField]
    private RagdollEnabler RagdollEnabler;
    [SerializeField]
    private float FadeOutDelay = 10f;

    public delegate void DeathEvent(TargetScript TargetScript);
    public DeathEvent OnDie;

    public delegate void TakeDamageEvent();
    public TakeDamageEvent OnTakeDamage;

    private void Start()
    {
        if (RagdollEnabler != null)
        {
            RagdollEnabler.EnableAnimator();
        }
    }
    public void TakeDamage (float amount)
    {
        health -= amount;
        Debug.Log(">>> Target health: " + health);
        //if (health <= 0f)
        //{
        //    Debug.Log(">>> Target Die ");
        //    Destroy(gameObject);
        //}
        if (health <= 0f && RagdollEnabler != null)
        {
            Debug.Log(">>> Target Die ");
            OnDie?.Invoke(this);
            RagdollEnabler.EnableRagdoll();
            StartCoroutine(FadeOut());
        }
    }

    private IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(FadeOutDelay);

        if (RagdollEnabler != null)
        {
            RagdollEnabler.DisableAllRigidbodies();
        }

        float time = 0;
        while (time < 1)
        {
            transform.position += Vector3.down * Time.deltaTime;
            time += Time.deltaTime;
            yield return null;
        }

        gameObject.SetActive(false);
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
