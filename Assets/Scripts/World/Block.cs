using UnityEngine;
using Assets.Scripts.Utility;
public class Block
{
    public int x, y, z;
    public bool isTransparent = false;

    public Vector2 texture = new Vector2(0, 0) * TextureUtils.textureUnit;

    public virtual MeshData GetMeshData()
    {
        if (!isTransparent)
            return GetCompleteBlock(x, y, z);
        return new MeshData();
    }

    public MeshData createUpFace(float x, float y, float z)
    {
        MeshData data = new MeshData();

        data.vertices.Add(new Vector3(x, y + 1, z + 1));
        data.vertices.Add(new Vector3(x + 1, y + 1, z + 1));
        data.vertices.Add(new Vector3(x + 1, y + 1, z));
        data.vertices.Add(new Vector3(x, y + 1, z));

        data.uv.Add(new Vector2(texture.x, texture.y));
        data.uv.Add(new Vector2(texture.x + TextureUtils.textureUnit, texture.y));
        data.uv.Add(new Vector2(texture.x + TextureUtils.textureUnit, texture.y + TextureUtils.textureUnit));
        data.uv.Add(new Vector2(texture.x, texture.y + TextureUtils.textureUnit));

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
    
    public MeshData GetCompleteBlock(float x, float y, float z)
    {
        return new MeshData()
            .Combine(createUpFace(x, y, z))
            .Combine(createDownFace(x, y, z))
            .Combine(createEastFace(x, y, z))
            .Combine(createWestFace(x, y, z))
            .Combine(createNorthFace(x, y, z))
            .Combine(createSouthFace(x, y, z));
    }
}
