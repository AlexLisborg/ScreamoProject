using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class INTROCameraScript : MonoBehaviour
{

    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("GAME");
        }
    }

    private void FixedUpdate()
    {
        if (transform.position.y >= -3)
        {
            transform.position += Vector3.down * 0.0013f;
        }
    }
}
