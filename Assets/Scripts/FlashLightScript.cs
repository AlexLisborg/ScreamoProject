using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLightScript : MonoBehaviour
{
    private Camera _camera;
    // Start is called before the first frame update
    void Start()
    {
        _camera = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = _camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
        Vector2 playerPos2D = new Vector2(transform.position.x, transform.position.y);
        Vector2 playerToMouse = (mousePos2D - playerPos2D).normalized;
        float angle = Vector2.Angle(Vector2.down,playerToMouse);
        if (playerToMouse.x < 0) { angle = -angle; }
        transform.rotation = Quaternion.Euler(0,0,angle);
    }
}
