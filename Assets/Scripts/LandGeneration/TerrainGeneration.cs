using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.LandGeneration
{
    public abstract class TerrainGenerator
    {
        public float frequency;
        public float amplitude;

        public float perlinScale;
        public int octaves;

        public float persistance;
        public float frequencyChange;

        public abstract float GetHeight(int x, int z);
    }

    public class Test : TerrainGenerator
    {
        public override float GetHeight(int x, int z)
        {
            return (int)((Mathf.Sin(x * .2f) + Mathf.Sin(z * .2f)) * 3);
        }
    }

    public class Perlin : TerrainGenerator
    {
        public override float GetHeight(int x, int z)
        {
            amplitude = 4;
            return (int)(Mathf.PerlinNoise(x / 10f, z / 10f) * amplitude);
        }
    }

    public abstract class SimpleLandGenerator : TerrainGenerator
    {
        public override float GetHeight(int x, int z)
        {
            float height = 0;
            float max = 0;
            float tempFrequency = frequency;
            float tempAmplitude = amplitude;

            for (int o = 0; o < octaves; o++)
            {
                height += Mathf.PerlinNoise(x * perlinScale * tempFrequency, z * perlinScale * tempFrequency) * tempAmplitude;
                max += tempAmplitude;
                tempFrequency *= frequencyChange;
                tempAmplitude *= persistance;
            }

            return (int)height;
        }
    }

    public class SimpleDesert : SimpleLandGenerator
    {
        public SimpleDesert()
        {
            frequency = .1f;
            amplitude = 3;

            perlinScale = .5f;
            octaves = 3;

            persistance = 1 / 3f;
            frequencyChange = 2f;
        }
    }

    public class SimpleHills : SimpleLandGenerator
    {
        public SimpleHills()
        {
            frequency = .1f;
            amplitude = 10;

            perlinScale = .5f;
            octaves = 3;

            persistance = 1 / 2f;
            frequencyChange = 2f;
        }
    }
}