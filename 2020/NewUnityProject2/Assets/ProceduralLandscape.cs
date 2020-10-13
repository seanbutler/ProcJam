using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralLandscape : MonoBehaviour
{
    int xSize = 32;
    int ySize = 32;

    Vector3[] vertices;
    Vector2[] uv;
    int[] triangles;

	private void Generate () {
		Mesh mesh = GetComponent<MeshFilter>().mesh = new Mesh();
		vertices = new Vector3[(xSize + 1) * (ySize + 1)];
		uv = new Vector2[vertices.Length];
        float x, y;
        int i;
		float noise;

		for (i = 0, y = 0; y <= ySize; y++) {
			for (x = 0; x <= xSize; x++, i++) {
				// height += 1.5f * (Mathf.Sin((y / ySize)*6.28f) + Mathf.Sin((x / xSize)*6.28f));
				// height += 0.5f * (Mathf.Sin((y / ySize)*36.28f) + Mathf.Sin((x / xSize)*24.28f));
				// height = Mathf.PerlinNoise(x/xSize, y/ySize) * 10.0f;
				noise = 16.0f * Mathf.PerlinNoise(x / xSize, y / ySize);
				Debug.Log(x / xSize + " " + y / ySize + " " + noise);

				vertices[i] = new Vector3(x, noise - 16.0f, y);
                uv[i] = new Vector2(x / xSize, y / ySize);
			}
		}
		mesh.vertices = vertices;
		mesh.uv = uv;

		int[] triangles = new int[xSize * ySize * 6];
        int ti = 0, vi = 0;
		for (ti = 0, vi = 0, y = 0; y < ySize; y++, vi++) {
			for (x = 0; x < xSize; x++, ti += 6, vi++) {
				triangles[ti] = vi;
				triangles[ti + 3] = triangles[ti + 2] = vi + 1;
				triangles[ti + 4] = triangles[ti + 1] = vi + xSize + 1;
				triangles[ti + 5] = vi + xSize + 2;
			}
		}
		mesh.triangles = triangles;
        mesh.RecalculateNormals();
	}

    void Start()
    {
        Generate();
    }

    void Update()
    {
    }


}
