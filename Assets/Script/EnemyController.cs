using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float _movementSpeed = 5.0f; //ˆÚ“®‘¬“x

    void Update()
    {
        transform.Translate(0, 0, _movementSpeed);

        if (transform.position.z < 0)
        {
            Destroy(gameObject);
        }
    }
}
