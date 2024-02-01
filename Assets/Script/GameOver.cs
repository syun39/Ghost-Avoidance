using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    [SerializeField] string _enemyTag = "Enemy";
    [SerializeField] string _goalTag = "Goal";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == _enemyTag)
        {
            ChangeSceneGO();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _goalTag)
        {
            ChangeSceneGC();
        }
    }

    //ゲームオーバーシーンに遷移
    void ChangeSceneGO()
    {
        SceneManager.LoadScene("GameOver");
    }
    //ゲームクリアシーンに遷移
    void ChangeSceneGC()
    {
        SceneManager.LoadScene("GameClear");
    }
}
