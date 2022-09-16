using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CinemachineScript : MonoBehaviour
{
    public CinemachineVirtualCamera cinenmachinecamera;
    private CinemachineBasicMultiChannelPerlin noiseyeri;
    private float shaketime = 2f;

    private void Start()
    {
        cinenmachinecamera = GetComponent<CinemachineVirtualCamera>();
        noiseyeri = cinenmachinecamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void camerashake()
    {
        shaketime -= Time.deltaTime;
        Debug.Log(shaketime);
        if (shaketime >= 0)
        {

            noiseyeri.m_AmplitudeGain = 5;
            noiseyeri.m_FrequencyGain = 10;

        }
        else if (shaketime <= 0)
        {
            noiseyeri.m_AmplitudeGain = 1;
            noiseyeri.m_FrequencyGain = 0;
        }
        shaketime = 2;

    }
    public void Update()
    {
        
    }



}
