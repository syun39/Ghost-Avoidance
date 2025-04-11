using UnityEngine;

public class CharacterMoveAddForce : MonoBehaviour
{
    [SerializeField] float _movePower = 3;
    Rigidbody _rb = default;
   
    Vector3 _dir;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        _dir = Vector3.forward * v + Vector3.right * h;
       
        _dir = Camera.main.transform.TransformDirection(_dir);
        _dir.y = 0;
        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }
    }

    void FixedUpdate()
    {
        _rb.AddForce(_dir.normalized * _movePower, ForceMode.Force);
    }
}
