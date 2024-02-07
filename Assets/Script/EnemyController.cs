using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 5.0f; //ˆÚ“®‘¬“x
    [SerializeField] string _destroyTag = "Destroy";

    void Update()
    {
        transform.Translate(0, 0, _movementSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == _destroyTag)
        {
            Destroy(gameObject) ;
        }
    }
}
