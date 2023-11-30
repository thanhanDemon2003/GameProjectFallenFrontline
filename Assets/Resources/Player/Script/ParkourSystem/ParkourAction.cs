using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parkour System/Vault Action")]
public class ParkourAction : ScriptableObject
{
    public string animationName;

    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;

    [SerializeField] bool rotateToObstacle;


    [Header("Target Matching")]
    [SerializeField] bool enableTargetMatching = true;
    [SerializeField] AvatarTarget matchBodyPart;
    [SerializeField] float matchStartTime;
    [SerializeField] float matchTargetTime;
    public Vector3 MatchPosition { get; set; }
    public Quaternion targetRotation { get; set; }
    public bool checkPossible(ObstacleHitData hitData, Transform playerTransform)
    {
        float height = hitData.heightHitInfo.point.y - playerTransform.position.y;

        if (height < minHeight || height > maxHeight)
            return false;

        if (rotateToObstacle)
            targetRotation = Quaternion.LookRotation(-hitData.forwardHitInfo.normal);

        if (enableTargetMatching)
            MatchPosition = hitData.heightHitInfo.point;

        return true;
    }

    public string AnimName => animationName;
    public bool RotateToObstacle => rotateToObstacle;

    public bool EnableTargetMatching => enableTargetMatching;
    public AvatarTarget MatchBodyPart => matchBodyPart;
    public float MatchStartTime => matchStartTime;
    public float MatchTargetTime => matchTargetTime;

}
