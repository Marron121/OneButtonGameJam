using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraShake : MonoBehaviour
{
    [SerializeField]
    CinemachineBasicMultiChannelPerlin shake;

    private bool shaking = false;
    private void Update()
    {
        if (shaking)
        {
            float reduce = shake.m_AmplitudeGain*0.1f;
            shake.m_AmplitudeGain -=reduce;
            shake.m_FrequencyGain -=reduce;
            if (shake.m_AmplitudeGain <= 0.1f)
            {
                shake.m_AmplitudeGain = 0.0f;
                shake.m_FrequencyGain = 0.0f;
                shaking = false;
            }
        }
    }

    public void ChargeAttack(int augment)
    {
        shake.m_AmplitudeGain = augment;
        shake.m_FrequencyGain = augment;
    }

    public void Attack()
    {
        shake.m_AmplitudeGain *=1.5f;
        shake.m_FrequencyGain *=1.5f;
        shaking = true;
    }
    private void StopShake()
    {
        shake.m_AmplitudeGain = 0.0f;
        shake.m_FrequencyGain = 0.0f;
    }

}
