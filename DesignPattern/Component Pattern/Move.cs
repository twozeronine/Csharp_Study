
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum MOVE2
{
    MOVE_RIGHT,
    MOVE_LEFT
}

public class MoveAct : MonoBehaviour
{

    MOVE2 move = MOVE2.MOVE_RIGHT;

    void Start()
    {
        StartCoroutine("Move");
    }

    // 0.5초마다 (글로벌 방향으로) 이동시키기
    IEnumerator Move()
    {
        while (true)
        {
            if (transform.position.x < -4)
            {
                move = MOVE2.MOVE_RIGHT;
            }
            else if (transform.position.x > 4)
            {
                move = MOVE2.MOVE_LEFT;
            }

            if (move == MOVE2.MOVE_RIGHT)
            {
                transform.Translate(1.0f * Vector3.right, Space.World);
            }
            else
            {
                transform.Translate(-1.0f * Vector3.right, Space.World);
            }

            yield return new WaitForSeconds(0.5f);
        }
    }
}
