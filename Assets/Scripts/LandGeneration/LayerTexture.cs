using UnityEngine;
using System.Collections;

public class LayerTexture : MonoBehaviour
{
    public Vector2 offset;

    [Range(2, 512)]
    public int resolution = 256;

    [Range(1, 50)]
    public float perlinResolution = 5;

    [Range(1, 8)]
    public int numOctaves = 4;

    [Range(0f, 1f)]
    public float persistance = 0.5f;

    [Range(1, 4f)]
    public float octaveFrequencyScale = 2f;

    [Range(2, 512)]
    public int numLevels = 16;

    private Texture2D texture;

    private void Update()
    {
        texture = new Texture2D(resolution, resolution, TextureFormat.RGB24, true);
        texture.name = "Procedural Texture";
        texture.wrapMode = TextureWrapMode.Clamp;
        texture.filterMode = FilterMode.Point;

        GetComponent<MeshRenderer>().material.mainTexture = texture;
        FillTexture();
    }

    private void FillTexture()
    {
        for (float y = 0; y < resolution; y++)
        {
            for (float x = 0; x < resolution; x++)
            {
                float color = 0;
                float amplitude = 1;
                float max = 0;
                float tempResolution = perlinResolution;
                for (int o = 0; o < numOctaves; o++)
                {
                    color += Mathf.PerlinNoise((x + (int)offset.x) / resolution * tempResolution,
                        (y + (int)offset.y) / resolution * tempResolution) * amplitude;

                    max += amplitude;
                    amplitude *= persistance;
                    tempResolution *= octaveFrequencyScale;
                }

                color /= max;

                color -= (color %= (1f/numLevels));
                
                texture.SetPixel((int)x, (int)y, color * Color.white);
            }
        }

        texture.Apply();
    }
}
