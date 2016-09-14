using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class Installator : MonoBehaviour 
{
     private GameObject Raytrassert;
     private int gridWidth;
     private int gridLenght;
     private GameObject[] cells;
	 public int Repiter = 10;
	 public float Resolution = 10f;
	 public int Height = 40;
 
     void Start () 
     {
		 
		 GameObject Raytrassert = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		 Raytrassert.AddComponent<UsPgEraserBETA2>();
		 
		 float FloTerrX = Terrain.activeTerrain.terrainData.size.x / Resolution;
         int IntTerrX = Mathf.FloorToInt(FloTerrX);
		 gridWidth = IntTerrX;
		 
		 float FloTerrZ = Terrain.activeTerrain.terrainData.size.z / Resolution;
         int IntTerrZ = Mathf.FloorToInt(FloTerrZ);
		 gridLenght = IntTerrZ;
		 
         cells = new GameObject[gridWidth * gridLenght];

         for (int ZET = 0; ZET < gridLenght; ZET++)
         {
             for (int XE = 0; XE < gridWidth; XE++)
             {
                 int index = XE + ZET * gridWidth;
				 cells[index] = Raytrassert;
				 cells[index].gameObject.transform.position = Terrain.activeTerrain.transform.position;
				 cells[index].gameObject.transform.rotation = Terrain.activeTerrain.transform.rotation;
 
                 GameObject.Instantiate(cells[index], new Vector3(XE*Repiter,Height,ZET*Repiter)+Terrain.activeTerrain.transform.position, Quaternion.identity * Terrain.activeTerrain.transform.rotation);
 
             }
         }
 
     }
	}
	
	
	/*
	public int Count;
	public int RandomX;
	public int RandomZ;
	public Transform pref;
	
	void Start () 
	{

		

		for(int i=0; i<Count; i++)
		{
			Instantiate(pref,transform.position+new Vector3(Random.Range(-RandomX,RandomX),0,Random.Range(-RandomZ,RandomZ)), transform.rotation);
		}
	}
		*/
	