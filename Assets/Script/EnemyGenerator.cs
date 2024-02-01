using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    //“G
    [SerializeField] GameObject _enemyPrefab;
    //•æ
    [SerializeField] GameObject _tombPrefab;
    //ŠÔŠÔŠu‚ÌÅ¬’l
    [SerializeField] float _minTime = 2f;
    //ŠÔŠÔŠu‚ÌÅ‘å’l
    [SerializeField] float _maxTime = 5f;
    //¶¬êŠX²
    [SerializeField] float _appearancePositionX = 0f;
    //¶¬êŠY²
    [SerializeField] float _appearancePositionY = 0f;
    //¶¬êŠZ²
    [SerializeField] float _appearancePositionZ = 0f;

    //“G¶¬ŠÔŠÔŠu
    private float _interval;
    //Œo‰ßŠÔ
    private float _time = 0f;

    void Start()
    {
        //ŠÔŠÔŠu‚ğŒˆ’è‚·‚é
        _interval = GetRandomTime();
        //•æ‚ğ¶¬
        GameObject tomb = Instantiate(_tombPrefab);
        //¶¬êŠ
        tomb.transform.position = new Vector3(_appearancePositionX,_appearancePositionY,_appearancePositionZ);
    }

    void Update()
    {
        //ŠÔŒv‘ª
        _time += Time.deltaTime;

        //¶¬ŠÔ‚æ‚è‘å‚«‚­‚È‚Á‚½‚Æ‚«)
        if (_time > _interval)
        {
            //enemy¶¬‚·‚é
            GameObject enemy = Instantiate(_enemyPrefab);
            //¶¬‚µ‚½“G‚ÌÀ•W‚ğŒˆ’è‚·‚é(
            enemy.transform.position = new Vector3(_appearancePositionX, _appearancePositionY, _appearancePositionZ);
            //Œo‰ßŠÔ‚ğ‰Šú‰»
            _time = 0f;
            //Ÿ‚ÌŠÔŠÔŠu‚ğŒˆ’è‚·‚é
            _interval = GetRandomTime();
        }
    }

    //ƒ‰ƒ“ƒ_ƒ€‚ÈŠÔ‚ğ¶¬‚·‚é
    private float GetRandomTime()
    {
        return Random.Range(_minTime, _maxTime);
    }
}
