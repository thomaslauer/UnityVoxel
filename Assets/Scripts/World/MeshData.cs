using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class MeshData
{
    public List<Vector3> vertices = new List<Vector3>();
    public List<int> triangles = new List<int>();
    public List<Vector2> uv = new List<Vector2>();

    // adds two MeshData
    public MeshData Combine(MeshData other)
    {
        // need to do this so when we add we preserve the number of vertices
        int numOurVerts = vertices.Count;
        foreach(int i in other.triangles)
        {
            triangles.Add(i + numOurVerts);
        }

        foreach (Vector3 i in other.uv)
        {
            vertices.Add(i);
        }

        foreach (Vector3 vert in other.vertices)
        {
            vertices.Add(vert);
        }

        return this;
    }

    public void AssignToMesh(Mesh mesh)
    {
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.uv = uv.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();
    }

    public void AssignToCollider(MeshCollider collider)
    {
        Mesh mesh = new Mesh();
        
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.Optimize();
        mesh.RecalculateNormals();
        collider.sharedMesh = mesh;
    }
}
