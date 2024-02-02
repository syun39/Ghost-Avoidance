using UnityEngine;

/// <summary>
/// 現代的なキャラクター操作スキーマを実現する。
/// 「カメラから見た方向」にキャラクター「Rigidbody.AddForce を使って」動かす。
/// 止まる時の減速具合は Rigidbody.Drag か Physics Material で調整する。
/// </summary>
public class CharacterMoveAddForce : MonoBehaviour
{
    [SerializeField] float _movePower = 3;
    Rigidbody _rb = default;
    /// <summary>入力された方向の XZ 平面でのベクトル</summary>
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
        // 「カメラのローカル座標系を基準に dir を変換」する
        _dir = Camera.main.transform.TransformDirection(_dir);
        // カメラは斜め下に向いているので、Y 軸の値を 0 にして「XZ 平面上のベクトル」にする
        _dir.y = 0;
        // キャラクターを「現在の（XZ 平面上の）進行方向」に向ける
        Vector3 forward = _rb.velocity;
        forward.y = 0;

        if (forward != Vector3.zero)
        {
            this.transform.forward = forward;
        }
    }

    void FixedUpdate()
    {
        // 「力を加える」処理は力学的処理なので FixedUpdate で行うこと
        _rb.AddForce(_dir.normalized * _movePower, ForceMode.Force);
    }
}
