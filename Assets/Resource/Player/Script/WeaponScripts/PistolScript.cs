using FPS.Manager;
using FPS.Player;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Windows;

public class PistolScript : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    public Transform gunPivot;
    public int maxRange = 100;
    public float damage = 10;

    public int maxBullet = 8;
    public int currentBullet;
    public int impactForce;

    public float bulletSpreadAngle;

    public ParticleSystem muzzleFlash,smoke;
    public GameObject impactEffect;
    public GameObject fleshEffect;

    public LayerMask hitLayer;

    private Animator animator;

    public Transform shellPoint;
    public GameObject shell;

    public Transform magPoint;
    public GameObject mag;

    public Camera _camera;
    public float fov = 68;

    public Animator modelAnimator;

    public PlayerController player;
    public Recoil recoil;


    public float fireRate;
    private float fireRateCount;
    private bool readyToFire = true;

    private AudioSource audio;
    [SerializeField] AudioClip shootSFX,shootEmptySFX;
    [SerializeField] GameObject reloadSFX;
    private void Awake()
    {
        audio = GetComponent<AudioSource>();    
        animator = GetComponent<Animator>();
        fireRateCount = fireRate;
    }

    public bool canReload()
    {
        if (currentBullet < maxBullet)
        {
            return true;
        }
        return false;
    }

    private void Start()
    {
        currentBullet = maxBullet;
    }

    private void Update()
    {
        if (!this.enabled) return;

        animator.SetFloat("Speed", Mathf.Abs(player.currentVelocity.y));
        animator.SetInteger("Bullet", currentBullet);
        _camera.fieldOfView = fov;

        UseWeapon();
        AimDownSight();

        Shoot();

    }

    private void Shoot()
    {
        if (inputManager.Shoot && readyToFire)
        {
            readyToFire = false;
            if (currentBullet <= 0)
            {
                audio.PlayOneShot(shootEmptySFX);
                return;
            }
            animator.Play("Shoot");


            //model Animator
            if (player.state == PlayerController.State.Primary)
            {
                modelAnimator.Play("ShootSMG");
            }
            else if (player.state == PlayerController.State.Secondary)
            {
                modelAnimator.Play("ShootPistol");
            }

            recoil.RecoilShoot();
        }


        if (!readyToFire)
        {
            fireRateCount -= Time.deltaTime;
        }

        if (fireRateCount<=0 || !inputManager.Shoot)
        {
            fireRateCount = fireRate;
            readyToFire = true;
        }
    }

    private void UseWeapon()
    {
        if (inputManager.Reload && currentBullet<maxBullet)
        {
            StartCoroutine(Weapon("Reload"));
        }

        reloadSFX.SetActive(AnimCheck(animator, "Reload"));
    }

    private IEnumerator Weapon(string weapon)
    {
        //cameraArmAnimator.Play(weapon);
        animator.SetTrigger(weapon);
        modelAnimator.SetTrigger(weapon);
        yield return new WaitForSeconds(0.1f);
        animator.ResetTrigger(weapon);
        modelAnimator.ResetTrigger(weapon);
    }


    private bool AnimCheck(Animator anim, string stateName)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName(stateName) &&
                anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            return true;
        else
            return false;
    }


    private void AimDownSight()
    {
        if (inputManager.Aim)
        {
            Aim();
        }
        else
        {
            StartCoroutine(Unaim());
        }
    }

    private void Aim()
    {
        animator.SetBool("Aim", true);
    }

    private IEnumerator Unaim()
    {
        animator.SetBool("Aim", false);
        yield return new WaitForSeconds(1f);
    }



    public void Reload()
    {
        currentBullet = maxBullet;
    }

    public void EjectMag()
    {
        GameObject magEject = Instantiate(mag, magPoint);
        magEject.transform.SetParent(null);
        magEject.GetComponent<Rigidbody>().velocity = Vector3.zero;
        magEject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        Destroy(magEject, 10f);
    }

    public void Fire()
    {
        if (currentBullet > 0)
        {
            audio.PlayOneShot(shootSFX);
            muzzleFlash.Play();
            //smoke.Play();
            currentBullet--;
            RaycastHit hit;
            if (Physics.Raycast(gunPivot.transform.position, gunPivot.transform.forward, out hit, maxRange, hitLayer))
            {
                Debug.DrawRay(gunPivot.transform.position, gunPivot.transform.forward * hit.distance, Color.green);
                Debug.Log(hit.transform.name);
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                TargetScript target = hit.transform.GetComponent<TargetScript>();

                if (target != null)
                {
                    target.TakeDamage(damage);
                    GameObject impact1 = Instantiate(fleshEffect, hit.point, Quaternion.LookRotation(-hit.normal));
                    impact1.transform.SetParent(hit.transform, true);
                    Destroy(impact1, 10f);
                    Debug.Log(">>> target");
                }

                else if (hit.collider.gameObject.CompareTag("Wall"))
                {
                    GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(-hit.normal));
                    impact.transform.SetParent(hit.transform, true);
                    Destroy(impact, 5f);
                    Debug.Log(">>> Wall");
                }
                else
                {
                    GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(-hit.normal));
                    impact.transform.SetParent(hit.transform, true);
                    Destroy(impact, 5f);
                    Debug.Log(">>> orther");
                }
            }

        }

    }

    public void EjectShell()
    {
        GameObject bulletShell = Instantiate(shell, shellPoint);
        Vector3 force = transform.up + transform.right * 25f * UnityEngine.Random.Range(2f, 5f);
        bulletShell.GetComponent<Rigidbody>().AddForce(force);
        bulletShell.transform.SetParent(null);
        Destroy(bulletShell, 10f);
    }
}
