using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class ChunkTest : MonoBehaviour
    {

        public GameObject chunk;

        void Awake()
        {
            int width = 10;
            int height = 10;

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    GameObject cube = Instantiate(chunk) as GameObject;
                    cube.transform.position = new Vector3(x * 20, 0, z * 20);
                    print(x + " " + z);
                }
            }
        }
    }
}
