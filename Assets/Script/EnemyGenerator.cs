using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //敵
    [SerializeField] GameObject _enemyPrefab;
    //墓
    [SerializeField] GameObject _tombPrefab;
    //時間間隔の最小値
    [SerializeField] float _minTime = 2f;
    //時間間隔の最大値
    [SerializeField] float _maxTime = 5f;
    //生成場所X軸
    [SerializeField] float _appearancePositionX = 0f;
    //生成場所Y軸
    [SerializeField] float _appearancePositionY = 0f;
    //生成場所Z軸
    [SerializeField] float _appearancePositionZ = 0f;

    //敵生成時間間隔
    private float _interval;
    //経過時間
    private float _time = 0f;

    void Start()
    {
        //時間間隔を決定する
        _interval = GetRandomTime();
        //墓を生成
        GameObject tomb = Instantiate(_tombPrefab);
        //生成場所
        tomb.transform.position = new Vector3(_appearancePositionX,_appearancePositionY,_appearancePositionZ);
    }

    void Update()
    {
        //時間計測
        _time += Time.deltaTime;

        //生成時間より大きくなったとき)
        if (_time > _interval)
        {
            //enemy生成する
            GameObject enemy = Instantiate(_enemyPrefab);
            //生成した敵の座標を決定する(
            enemy.transform.position = new Vector3(_appearancePositionX, _appearancePositionY, _appearancePositionZ);
            //経過時間を初期化
            _time = 0f;
            //次の時間間隔を決定する
            _interval = GetRandomTime();
        }
    }

    //ランダムな時間を生成する
    private float GetRandomTime()
    {
        return Random.Range(_minTime, _maxTime);
    }
}
