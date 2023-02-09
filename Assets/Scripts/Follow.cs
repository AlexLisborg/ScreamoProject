using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{

    [SerializeField] GameObject follow;

    void Update()
    {
        Vector3 followVec = follow.transform.position;
        followVec.z = transform.position.z;
        transform.position = followVec;
    }
}
