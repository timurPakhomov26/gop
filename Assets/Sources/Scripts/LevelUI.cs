using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject _pausePanel;
    [SerializeField] private TimeLine _timeLine;
     
    [Space(30)]
    [SerializeField] private bool _useTimerImage = false;

    [SerializeField] private Image _timeLeftImage;
    [SerializeField] private TextMeshProUGUI _timerLeftText;

    [SerializeField] private float _timeLeft = 5;

    [SerializeField] private GameObject _timerLeft;

    private bool _canRecreaseTime = false;
    private float _maxFillAmount = 5;
    
    private void Start()
    {
        _pausePanel.SetActive(false);
        _timerLeft.SetActive(false);
        _timeLeftImage.fillAmount = _maxFillAmount;
    }

    private void Update()
    {
        if (_canRecreaseTime)
        {
            RecreaseTime();
        }
    }
    public void OnPause()
    {
        _pausePanel.SetActive(true);
        _animator.SetTrigger("Pause");
        _timeLine.PauseTime();
    }

    public void OnBack()
    {
        _pausePanel.SetActive(false);
        _timeLine.RunTime();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void RecreaseTime()
    {
        int time = 0;
        if (_useTimerImage == false)
            return;
        
        _timerLeft.SetActive(true);
        _timeLeft -= Time.deltaTime;
        time = (int)_timeLeft;
        _timerLeftText.text = time.ToString();
        _timeLeftImage.fillAmount = _timeLeft / _maxFillAmount;
        
        if (_timeLeft <= 0)
        {
            _timeLeft = 0;
            _canRecreaseTime = false;
            StartCoroutine(GoToMAinMenu());
        }
    }

    public bool ChangeCanRecreaseTime() => _canRecreaseTime = true;

    private IEnumerator GoToMAinMenu()
    {
        yield return  new WaitForSeconds(1.5f);
        SceneManager.LoadScene("MainMenu");
    }
    
}
