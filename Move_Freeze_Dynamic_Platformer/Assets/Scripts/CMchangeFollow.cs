using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CMchangeFollow : MonoBehaviour
{
    [SerializeField] private GameObject rook, knight, king, bishop;
    public Transform followTarget;
    private CinemachineVirtualCamera vcam;
    float changePlayer = 1, maxPlayerNum = 4;
    private float TimeToSwitch = 10, internalTime = 0;
    // Start is called before the first frame update
    void Start()
    {
        internalTime = 0;
        vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        ChangeFollowTarget();
        InternalTimer();
    }
    void InternalTimer()
    {
        internalTime += Time.deltaTime;
        Debug.Log(Mathf.FloorToInt(internalTime));
    }
    bool InternalTimerSwitch()
    {
        if(Mathf.FloorToInt(internalTime) == TimeToSwitch)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    void ChangeFollowTarget()
    {
        if(Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.O)||InternalTimerSwitch())
        {
            changePlayer++;
            internalTime = 0;
            if(changePlayer > maxPlayerNum)
            {
                changePlayer = 1;
            }
            switch(changePlayer)
            {
                case 1:
                followTarget = rook.transform;
                vcam.LookAt = followTarget;
                vcam.Follow = followTarget;
                break;

                case 2:
                followTarget = knight.transform;
                vcam.LookAt = followTarget;
                vcam.Follow = followTarget;
                break;

                case 3:
                followTarget = king.transform;
                vcam.LookAt = followTarget;
                vcam.Follow = followTarget;
                break;

                case 4:
                followTarget = bishop.transform;
                vcam.LookAt = followTarget;
                vcam.Follow = followTarget;
                break;

                default:
                Debug.LogError("default should never show up. something is changing the changePlayer float value");
                break;
            }
        }
    }
}
