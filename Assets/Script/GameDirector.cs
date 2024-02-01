using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _goal;
    [SerializeField] GameObject _text;
    [SerializeField] GameObject _timer;
    //制限時間
    [SerializeField] float _timeLimit = 60.0f;
    
    void Start()
    {
        _player = GameObject.Find("Player");
        _goal = GameObject.Find("Goal");
        _text = GameObject.Find("Distance");
        _timer = GameObject.Find("Timer");
    }

    void Update()
    {
        float length = _goal.transform.position.z - _player.transform.position.z;
        _text.GetComponent<Text>().text = "ゴールまで" + length.ToString("F1") + "m";

        _timeLimit -= Time.deltaTime;
        _timer.GetComponent<Text>().text = "残り" + _timeLimit.ToString("F1") + "秒";

        //制限時間が0になったらゲームオーバーシーンに遷移
        if (_timeLimit < 0)
        {
            ChangeSceneGO();
        }
    }

    void ChangeSceneGO()
    {
        SceneManager.LoadScene("GameOver");
    }
}
