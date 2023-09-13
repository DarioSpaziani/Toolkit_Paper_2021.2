using UnityEngine;
using UnityEngine.UIElements;

namespace _01_Scripts.line_chart
{
    public class TestMeshAPI : MonoBehaviour
    {
        Vector3[] newVertices;
        Vector2[] newUV;
        int[] newTriangles;

        void Start()
        {
            Mesh mesh = new Mesh();
            GetComponent<MeshFilter>().mesh = mesh;
            mesh.vertices = newVertices;
            mesh.uv = newUV;
            mesh.triangles = newTriangles;
        }
        
        void Update()
        {
            Mesh mesh = GetComponent<MeshFilter>().mesh;
            Vector3[] vertices = mesh.vertices;
            Vector3[] normals = mesh.normals;

            for (var i = 0; i < vertices.Length; i++)
            {
                vertices[i] += normals[i] * Mathf.Sin(Time.time);
            }

            mesh.vertices = vertices;
        }
    }
}