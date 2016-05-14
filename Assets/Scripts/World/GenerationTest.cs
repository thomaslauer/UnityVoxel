using UnityEngine;
using System.Collections.Generic;



[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class GenerationTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        float x = 0;
        float y = 0;
        float z = 0;

        Mesh mesh = GetComponent<MeshFilter>().mesh;

        MeshData up = createSouthFace(x, y, z)
            .Combine(createNorthFace(x, y, z))
            .Combine(createUpFace(x, y, z))
            .Combine(createDownFace(x, y, z))
            .Combine(createEastFace(x, y, z))
            .Combine(createWestFace(x, y, z));

        mesh.Clear();
        mesh.vertices = up.vertices.ToArray();
        mesh.triangles = up.triangles.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

	public MeshData createUpFace(float x, float y, float z)
    {
        MeshData data = new MeshData();

        data.vertices.Add(new Vector3(x, y + 1, z + 1));
        data.vertices.Add(new Vector3(x + 1, y + 1, z + 1));
        data.vertices.Add(new Vector3(x + 1, y + 1, z));
        data.vertices.Add(new Vector3(x, y + 1, z));

        data.triangles.Add(0);
        data.triangles.Add(1);
        data.triangles.Add(3);

        data.triangles.Add(1);
        data.triangles.Add(2);
        data.triangles.Add(3);

        return data;
    }

    public MeshData createDownFace(float x, float y, float z)
    {
        MeshData data = new MeshData();

        data.vertices.Add(new Vector3(x, y, z + 1));
        data.vertices.Add(new Vector3(x + 1, y, z + 1));
        data.vertices.Add(new Vector3(x + 1, y, z));
        data.vertices.Add(new Vector3(x, y, z));

        data.triangles.Add(3);
        data.triangles.Add(1);
        data.triangles.Add(0);

        data.triangles.Add(3);
        data.triangles.Add(2);
        data.triangles.Add(1);

        return data;
    }

    public MeshData createNorthFace(float x, float y, float z)
    {
        MeshData data = new MeshData();

        data.vertices.Add(new Vector3(x, y + 1, z + 1));
        data.vertices.Add(new Vector3(x + 1, y + 1, z + 1));
        data.vertices.Add(new Vector3(x + 1, y, z + 1));
        data.vertices.Add(new Vector3(x, y, z + 1));

        data.triangles.Add(3);
        data.triangles.Add(1);
        data.triangles.Add(0);

        data.triangles.Add(3);
        data.triangles.Add(2);
        data.triangles.Add(1);

        return data;
    }

    public MeshData createSouthFace(float x, float y, float z)
    {
        MeshData data = new MeshData();

        data.vertices.Add(new Vector3(x, y + 1, z));
        data.vertices.Add(new Vector3(x + 1, y + 1, z));
        data.vertices.Add(new Vector3(x + 1, y, z));
        data.vertices.Add(new Vector3(x, y, z));

        data.triangles.Add(0);
        data.triangles.Add(1);
        data.triangles.Add(3);

        data.triangles.Add(1);
        data.triangles.Add(2);
        data.triangles.Add(3);

        return data;
    }

    public MeshData createEastFace(float x, float y, float z)
    {
        MeshData data = new MeshData();

        data.vertices.Add(new Vector3(x + 1, y, z));
        data.vertices.Add(new Vector3(x + 1, y + 1, z));
        data.vertices.Add(new Vector3(x + 1, y + 1, z + 1));
        data.vertices.Add(new Vector3(x + 1, y, z + 1));

        data.triangles.Add(0);
        data.triangles.Add(1);
        data.triangles.Add(3);

        data.triangles.Add(1);
        data.triangles.Add(2);
        data.triangles.Add(3);

        return data;
    }

    public MeshData createWestFace(float x, float y, float z)
    {
        MeshData data = new MeshData();

        data.vertices.Add(new Vector3(x, y, z));
        data.vertices.Add(new Vector3(x, y + 1, z));
        data.vertices.Add(new Vector3(x, y + 1, z + 1));
        data.vertices.Add(new Vector3(x, y, z + 1));

        data.triangles.Add(3);
        data.triangles.Add(1);
        data.triangles.Add(0);

        data.triangles.Add(3);
        data.triangles.Add(2);
        data.triangles.Add(1);

        return data;
    }
}
