using FPS.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recoil : MonoBehaviour
{
    public InputManager input;

    private Vector3 currentRotation;
    private Vector3 targetRotation;

    [SerializeField] private float recoilX;
    [SerializeField] private float recoilY;
    [SerializeField] private float recoilZ;

    [SerializeField] private float snap;
    [SerializeField] private float returnSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        targetRotation = Vector3.Lerp(targetRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        currentRotation = Vector3.Slerp(currentRotation,targetRotation, snap * Time.deltaTime);
        transform.localRotation= Quaternion.Euler(currentRotation);

    }

    public void RecoilShoot()
    {
        if (input.Aim)
        {
            targetRotation += new Vector3(recoilX/2, Random.Range(-recoilY/2, recoilY/2), Random.Range(-recoilZ/2, recoilZ/2));
            return;
        }

        targetRotation += new Vector3(recoilX, Random.Range(-recoilY, recoilY), Random.Range(-recoilZ, recoilZ));
    }
}
