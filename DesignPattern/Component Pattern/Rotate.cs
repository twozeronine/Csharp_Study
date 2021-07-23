
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAct : MonoBehaviour
{

    void Start()
    {
        StartCoroutine("Rotate");
    }

    // 0.5초마다 객체 회전시키기
    IEnumerator Rotate()
    {
        while (true)
        {
            transform.Rotate(90.0f * Vector3.up);

            yield return new WaitForSeconds(0.3f);
        }
    }
}
