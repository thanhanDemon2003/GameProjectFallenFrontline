using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentScan : MonoBehaviour
{
    [SerializeField] Transform hipPoint;
    [SerializeField] float distance = 0.8f;
    [SerializeField] float heightLenght = 5f;
    [SerializeField] LayerMask obstacleLayer;
    public ObstacleHitData ObstacleCheck()
    {
        var hitData = new ObstacleHitData();
        RaycastHit hitInfo;
        hitData.forwardHitFound = Physics.Raycast(hipPoint.position, hipPoint.forward, out hitData.forwardHitInfo, distance, obstacleLayer);

        Debug.DrawRay(hipPoint.position, hipPoint.forward * distance, (hitData.forwardHitFound) ? Color.red : Color.white);


        if (hitData.forwardHitFound)
        {
            var heightOrigin = hitData.forwardHitInfo.point + Vector3.up * heightLenght;
            hitData.heightHitFound = Physics.Raycast(heightOrigin, Vector3.down, out hitData.heightHitInfo, obstacleLayer);

            Debug.DrawRay(heightOrigin, Vector3.down * heightLenght, (hitData.heightHitFound) ? Color.red : Color.white);

        }
        return hitData;
    }
}

public struct ObstacleHitData
{
    public bool forwardHitFound;
    public bool heightHitFound;
    public RaycastHit forwardHitInfo;
    public RaycastHit heightHitInfo;
}
