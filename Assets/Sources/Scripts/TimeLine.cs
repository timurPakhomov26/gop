using UnityEngine;

public class TimeLine : MonoBehaviour
{
    private void Awake()
    {
        RunTime();
    }

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void PauseTime() => Time.timeScale = 0;
    public void RunTime() => Time.timeScale = 1;
    
}
