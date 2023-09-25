using FPS.Manager;
using FPS.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMelee : MonoBehaviour
{
    private Animator animator;
    private InputManager inputManager;
    private PlayerController playerController;
    private int _kickHash;
    private bool _hasAnimator;
    [SerializeField] Transform lookDirection;
    [SerializeField] AvatarTarget matchBodyPart;
    // Start is called before the first frame update
    void Start()
    {
        _hasAnimator = TryGetComponent<Animator>(out animator);
        playerController = GetComponent<PlayerController>();
        inputManager= GetComponent<InputManager>();

        _kickHash = Animator.StringToHash("Kick");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Kick();
    }

    private void Kick()
    {
        if (!_hasAnimator) return;
        if (!inputManager.Kick) return;
        animator.Play("Kick");
        StartCoroutine(setControl());
    }

    IEnumerator setControl()
    {
        playerController.canControl = false;
        yield return new WaitForSeconds(0.6f);
        playerController.canControl = true;
    }

}
