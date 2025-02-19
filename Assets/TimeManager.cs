using UnityEngine;
using UnityEngine.Audio;

public class TimeManager : MonoBehaviour
{

    bool timeIsSlowed = false;
    public float slowTimeScale = 0.25f;
    public float physicsTimeScale = .02f;
    public float pitchSlowdown = 0.5f;
    public AudioMixer audioMixer;

    public void ToggleSlowTime(){
        timeIsSlowed = !timeIsSlowed;
        if(timeIsSlowed){
            Time.timeScale = slowTimeScale;
            audioMixer.SetFloat("MasterPitch", pitchSlowdown);
        }else{
            Time.timeScale = 1;
            audioMixer.SetFloat("MasterPitch", 1f);
        }
        Time.fixedDeltaTime = Time.timeScale * physicsTimeScale;

        float a = 5.0f / Time.timeScale;
    }
}
