using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    /*    public float speed;
        public Vector3 moveDirection;
        private void Awake()
        {
            speed = 0.5f;
            moveDirection = new Vector3(Random.Range(-1f,1f), 0, 0).normalized;
        }
        private void Update()
        {
            //moveDirection = new Vector3(Random.Range(-5f, 5f), 0, 0).normalized;
            //transform.position += moveDirection * speed * Time.deltaTime;
            transform.Translate(moveDirection.x * 0.3f * speed, 0, speed * Time.deltaTime);
        }*/
    public float speed = 0.3f; // 이동 속도
    public float changeInterval = 1f; // 방향 변경 주기 (초)
    //public float forwardSpeed = 0.3f; // 앞으로 이동하는 속도

    private float timer = 0f; // 시간 추적
    private float currentDirection = 1f; // 현재 좌우 이동 방향

    private void Awake()
    {
        speed = 0.6f;
        changeInterval = 1.5f;
        GetComponent<DestroyScript>().delay = Random.Range(15f, 30f);

    }
    private void Update()
    {
        // 시간 추적
        timer += Time.deltaTime;

        // 지정된 시간이 지나면 새로운 랜덤 좌우 방향 설정
        if (timer >= changeInterval)
        {
            currentDirection = 2 * Random.Range(-2f, 2f); // 새로운 랜덤 좌우 방향
            timer = 0f; // 타이머 리셋
        }

        // 앞으로 계속 이동하고 좌우로 랜덤하게 움직임
        Vector3 moveDirection = new Vector3(currentDirection, 0, 1);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
