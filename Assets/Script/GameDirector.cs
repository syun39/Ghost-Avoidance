using UnityEngine;
using UnityEngine.UI;

public class GameDirector : MonoBehaviour
{
    [SerializeField] GameObject _player;
    [SerializeField] GameObject _goal;
    [SerializeField] GameObject _text;
    [SerializeField] GameObject _timer;
    [SerializeField] float _time = 60.0f;
    
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
        _text.GetComponent<Text>().text = "ÉSÅ[ÉãÇ‹Ç≈" + length.ToString("F2") + "m";

        _time -= Time.deltaTime;
        _timer.GetComponent<Text>().text = "écÇË" + _time.ToString("F1") + "ïb";
    }
}
