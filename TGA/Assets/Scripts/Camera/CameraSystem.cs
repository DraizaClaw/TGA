using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    [SerializeField] private float speed;
    private Vector3 TargetPos;

    private void Update()
    {
        if (Target != null)
        {
            TargetPos = new Vector3(Target.transform.position.x, Target.transform.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, TargetPos, speed * Time.deltaTime);
        }
    }
}
