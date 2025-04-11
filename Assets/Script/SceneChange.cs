using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    [SerializeField] string _sceneNameToBeLoaded = "";
    float _timer = 0f;

    public void SceneLoad(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ボタンで使用
    public void SceneLoad(float delaySeconds)
    {
        _timer = delaySeconds;
    }

    private void Update()
    {
        if (_timer > 0f)
        {
            _timer -= Time.deltaTime;
        }

        if (_timer < 0f)
        {
            SceneLoad(_sceneNameToBeLoaded);
        }
    }
}
