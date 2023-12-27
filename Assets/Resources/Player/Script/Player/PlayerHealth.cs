using FPS.Player;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float maxHP;

    [Range(0,100)]
    public float currentHP;


    [Header("Dead animation")]
    [SerializeField] Animator animator;
    [SerializeField] PlayerController player;
    [SerializeField] GameObject model;
    [SerializeField] GameObject modelArm;
    [SerializeField] GameObject cameraArm;


    [SerializeField] GameObject HitVFX;
    private Transform mainCamera;
    private float xRotation;

    [Header("UI")]
    public UnityEngine.UI.Slider healthBar;
    public Image healthImage;

    EndLevel endLevel;
    WinOrLose winOrLose;

    // Start is called before the first frame update
    void Start()
    {
        currentHP = maxHP;
        mainCamera = Camera.main.transform;
        endLevel = GetComponent<EndLevel>();
    }

    private void Update()
    {
        if (currentHP <= 0f)
        {
            xRotation = Mathf.Lerp(mainCamera.localRotation.x, 0f, 2 * Time.deltaTime);
            Dead();
            mainCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);
            animator.SetBool("PistolEquip", false);
        }

        UI();
    }

    private void UI()
    {
        healthBar.value = currentHP;
        healthImage.color = Color.Lerp(Color.red, Color.blue, healthBar.value / 100);
    }

    public void TakeDamage(float amount)
    {
        currentHP -= amount;
        Debug.Log(">>> Player HP: " + currentHP);
        animator.Play("Hit");
        Destroy(Instantiate(HitVFX), 2f);
    }

    public void Dead()
    {
        player.state = PlayerController.State.Unarmed;
        cameraArm.SetActive(false);
        animator.SetTrigger("Dead");
        player.canControl = false;
        transform.gameObject.layer = LayerMask.NameToLayer("Default");
    }

}
