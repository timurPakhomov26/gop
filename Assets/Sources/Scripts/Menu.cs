using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int _levelValue;
    [SerializeField] private Scene[] _scenes;
    public void GetLevelValue(int value)
    {
        _levelValue = value;
    }

    public void OnPlayButton()
    {
        var  level = "";
        switch (_levelValue)
        {
            case 0 : level = "Level 1";
                break;
            case 1 : level = "Level 2";
                break;
            case 2 : level = "Level 3";
                break;
        }
        SceneManager.LoadScene(level);
    }
}
