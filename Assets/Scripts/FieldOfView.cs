using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Diagnostics;
using UnityEngine.UIElements;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    public Vector3 GetVector3fromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    public float GetAnglefromFloat(Vector3 direction) 
    { 
        direction = direction.normalized;
        float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (n < 0) n = +360;
        return n;
    }
    private Mesh mesh;

    private void Start()
    {
        mesh = new Mesh();

    }
    private void Update()
    {
        float fov = 90f;
        int raycount = 60;
        float angle = 0f;
        float angleIncrease = fov / raycount;
        float viewDistance = 40f;
        Vector3 origin = Vector3.zero;

        // Createation of Triangles
        Vector3[] vertices = new Vector3[raycount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[raycount * 3];

        vertices[0] = origin;


        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i < raycount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVector3fromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                vertex = origin + GetVector3fromAngle(angle) * viewDistance;

            } else {
                vertex = raycastHit2D.point;
            }

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;
                triangleIndex += 3;
            }
            vertexIndex++;
            angle -= angleIncrease;

        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
    

}

