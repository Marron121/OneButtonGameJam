using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
    [SerializeField]
    CinemachineVirtualCamera cam;

    private CinemachineBasicMultiChannelPerlin shake;

    private bool shaking = false;
    Coroutine charging = null;
    private void Start()
    {
        shake = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        Debug.Log(shake);
    }
    private void Update()
    {
        if (shaking)
        {
            float reduce = shake.m_AmplitudeGain * 0.05f;
            shake.m_AmplitudeGain -= reduce;
            shake.m_FrequencyGain -= reduce;
            if (shake.m_AmplitudeGain <= 0.1f)
            {
                shake.m_AmplitudeGain = 0.0f;
                shake.m_FrequencyGain = 0.0f;
                shaking = false;
            }
        }
    }

    public void StartCharge()
    {
        if (shake.m_AmplitudeGain < 0.75f)
        {
            shaking = false;
            shake.m_AmplitudeGain += 0.05f;
            shake.m_FrequencyGain += 0.05f;
        }
    }

    public void Attack()
    {
        if (shaking is false)
        {
            shake.m_AmplitudeGain = 2f;
            shake.m_FrequencyGain = 2f;
            shaking = true;
        }
    }
    private void StopShake()
    {
        shake.m_AmplitudeGain = 0.0f;
        shake.m_FrequencyGain = 0.0f;
    }

}
