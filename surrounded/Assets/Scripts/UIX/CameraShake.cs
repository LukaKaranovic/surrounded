using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private CinemachineVirtualCamera cam;
    private CinemachineBasicMultiChannelPerlin mcp;
    public float shakeTime;
    public float amplitude;
    public float frequency;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineVirtualCamera>();
        mcp = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        StartCoroutine(ShakeCamera());
    }
    
    IEnumerator ShakeCamera(){
        mcp.m_AmplitudeGain = amplitude;
        mcp.m_FrequencyGain = frequency;
        yield return new WaitForSeconds(shakeTime);
        mcp.m_AmplitudeGain = 0;
    }  
}
