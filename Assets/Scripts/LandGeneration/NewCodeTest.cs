using UnityEngine;
using System.Collections;
using Assets.Scripts.LandGeneration;


public class NewCodeTest : MonoBehaviour {

     TerrainGenerator terrainGenerator;

    public GameObject block;

	// Use this for initialization
	void Start () {
        terrainGenerator = new SimpleHills();

        MeshData mesh = new MeshData();
        Block b = new Block();

        for (int x = (int)transform.position.x; x < 20 + (int)transform.position.x; x++)
        {
            for(int z = (int)transform.position.z; z < 20 + (int)transform.position.z; z++)
            {
                //GameObject cube = Instantiate(block);

                float y = terrainGenerator.GetHeight(x, z);
                //cube.transform.position = new Vector3(x, y, z);

                mesh.Combine(b.GetCompleteBlock(x - transform.position.x, y, z - transform.position.z));
                
            }
        }
        mesh.AssignToMesh(GetComponent<MeshFilter>().mesh);
        mesh.AssignToCollider(GetComponent<MeshCollider>());
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
