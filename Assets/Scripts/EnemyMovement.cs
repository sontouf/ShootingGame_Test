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
    public float speed = 0.3f; // �̵� �ӵ�
    public float changeInterval = 1f; // ���� ���� �ֱ� (��)
    //public float forwardSpeed = 0.3f; // ������ �̵��ϴ� �ӵ�

    private float timer = 0f; // �ð� ����
    private float currentDirection = 1f; // ���� �¿� �̵� ����

    private void Awake()
    {
        speed = 0.6f;
        changeInterval = 1.5f;
        GetComponent<DestroyScript>().delay = Random.Range(15f, 30f);

    }
    private void Update()
    {
        // �ð� ����
        timer += Time.deltaTime;

        // ������ �ð��� ������ ���ο� ���� �¿� ���� ����
        if (timer >= changeInterval)
        {
            currentDirection = 2 * Random.Range(-2f, 2f); // ���ο� ���� �¿� ����
            timer = 0f; // Ÿ�̸� ����
        }

        // ������ ��� �̵��ϰ� �¿�� �����ϰ� ������
        Vector3 moveDirection = new Vector3(currentDirection, 0, 1);
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }
}
