using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    [SerializeField] float maxspeed = 3.0f;
    [SerializeField] float rotatespeed = 360.0f;

    private SimpleAnimation _simpleAnimation = null; // Unity製 SimpleAnimationシステムを使用する。
    private Camera mainCamera = null;

    // 入力保持用
    private Vector3 inputDirection;
    private Vector3 lookingDirection;


    // Start は最初のフレーム更新の前に呼び出されます。
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _simpleAnimation = GetComponent<SimpleAnimation>();
        lookingDirection = new Vector3(1, 0, 1);
        _simpleAnimation.GetState("WAIT").speed = 0.7f; // アニメーションクリップの再生速度を1.0倍
        _simpleAnimation.GetState("RUN").speed = 1.2f;  // アニメーションクリップの再生速度を1.0倍


        mainCamera = Camera.main;

    }
    // Update is called once per frame
    void Update()
    {
        // キー入力を取得

        inputDirection.z = Input.GetAxis("Horizontal");
        inputDirection.x = Input.GetAxis("Vertical");

        // メインカメラの向きによって入力を調整
        Vector3 cameraForward = Vector3.Scale(mainCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        inputDirection = cameraForward * inputDirection.x + mainCamera.transform.right * inputDirection.z;

        moveDirection = inputDirection * maxspeed;
        // いずれかの方向に入力がある場合。
        if (inputDirection != Vector3.zero)
        {
            // 回転！
            lookingDirection = inputDirection;
            // 走行アニメーションに遷移
            _simpleAnimation.CrossFade("RUN", 0.2f);
        }
        else
        {
            // コントローラからの入力がなく、停止アニメーションに遷移。
            _simpleAnimation.CrossFade("WAIT", 0.2f);
        }

        // 方向転換処理(スムーズに回転するよう、若干ディレイをかけています)
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(lookingDirection), (rotatespeed * Time.deltaTime));
        controller.Move(moveDirection * Time.deltaTime);
    }
}
