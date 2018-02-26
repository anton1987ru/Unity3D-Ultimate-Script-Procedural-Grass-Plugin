using UnityEngine;
using System.Collections;

//[ExecuteInEditMode]
public class UsPgEraser : MonoBehaviour {
[HideInInspector]
public float radius = 99999999f;
public float radiusBig = 175f;
public float radiusMed = 60f;
public float radiusSmall = 20f;
private LayerMask layerMask;
private Collider[] colliders;
Terrain t;


	void Start () {
	layerMask = LayerMask.GetMask("BigObj", "MedObj" ,"SmallObj");
	colliders = Physics.OverlapSphere(transform.position, radius, layerMask);
	foreach(Collider col in colliders)
	{	
	float X = col.gameObject.transform.localScale.x;
	float Z = col.gameObject.transform.localScale.z;
	float xz1 = radiusBig + (X + Z);
	float xz2 = radiusMed + (X + Z);
	float xz3 = radiusSmall + (X + Z);
	
	if(col.gameObject.layer == LayerMask.NameToLayer("BigObj")){
    CutGrassBig(null, col.gameObject.transform.position,  xz1);
	}
	if(col.gameObject.layer == LayerMask.NameToLayer("MedObj")){
    CutGrassMed(null, col.gameObject.transform.position,  xz2);
	}
	if(col.gameObject.layer == LayerMask.NameToLayer("SmallObj")){
    CutGrassSmall(null, col.gameObject.transform.position,  xz3);
	}
	}
	}

	
	
	
public void CutGrassBig(Terrain t, Vector3 position,  float xz)
{

if(t == null)
t = gameObject.GetComponent<Terrain>();

int TerrainDetailMapSize = Terrain.activeTerrain.terrainData.detailResolution;
float PrPxSize = TerrainDetailMapSize / t.terrainData.size.x;
Vector3 TexturePoint3D = position - Terrain.activeTerrain.transform.position;
TexturePoint3D = TexturePoint3D * PrPxSize;


float[] xymaxmin = new float[4];
xymaxmin[0] = TexturePoint3D.z + radiusBig;
xymaxmin[1] = TexturePoint3D.z - radiusBig;
xymaxmin[2] = TexturePoint3D.x + radiusBig;
xymaxmin[3] = TexturePoint3D.x - radiusBig;


int[,] map = Terrain.activeTerrain.terrainData.GetDetailLayer(0,0, Terrain.activeTerrain.terrainData.detailWidth, Terrain.activeTerrain.terrainData.detailHeight, 0);

for (int y = 0; y < Terrain.activeTerrain.terrainData.detailHeight; y++) {
for (int x = 0; x < Terrain.activeTerrain.terrainData.detailWidth; x++) {

if(xymaxmin[0] > x && xymaxmin[1] < x && xymaxmin[2] > y && xymaxmin[3] < y )
map[x,y] = 0;
}
}

Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,0,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,1,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,2,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,3,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,4,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,5,map);

}


////////////////////////////////////////

public void CutGrassMed(Terrain t, Vector3 position,  float xz)
{
if(t == null)
t = gameObject.GetComponent<Terrain>();

int TerrainDetailMapSize = Terrain.activeTerrain.terrainData.detailResolution;
float PrPxSize = TerrainDetailMapSize / t.terrainData.size.x;
Vector3 TexturePoint3D = position - Terrain.activeTerrain.transform.position;
TexturePoint3D = TexturePoint3D * PrPxSize;


float[] xymaxmin = new float[4];
xymaxmin[0] = TexturePoint3D.z + radiusMed;
xymaxmin[1] = TexturePoint3D.z - radiusMed;
xymaxmin[2] = TexturePoint3D.x + radiusMed;
xymaxmin[3] = TexturePoint3D.x - radiusMed;


int[,] map = Terrain.activeTerrain.terrainData.GetDetailLayer(0,0, Terrain.activeTerrain.terrainData.detailWidth, Terrain.activeTerrain.terrainData.detailHeight, 0);

for (int y = 0; y < Terrain.activeTerrain.terrainData.detailHeight; y++) {
for (int x = 0; x < Terrain.activeTerrain.terrainData.detailWidth; x++) {

if(xymaxmin[0] > x && xymaxmin[1] < x && xymaxmin[2] > y && xymaxmin[3] < y )
map[x,y] = 0;
}
}

Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,0,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,1,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,2,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,3,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,4,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,5,map);
}

///////////////////////////////////////////

public void CutGrassSmall(Terrain t, Vector3 position,  float xz)
{
if(t == null)
t = gameObject.GetComponent<Terrain>();

int TerrainDetailMapSize = Terrain.activeTerrain.terrainData.detailResolution;
float PrPxSize = TerrainDetailMapSize / t.terrainData.size.x;
Vector3 TexturePoint3D = position - Terrain.activeTerrain.transform.position;
TexturePoint3D = TexturePoint3D * PrPxSize;


float[] xymaxmin = new float[4];
xymaxmin[0] = TexturePoint3D.z + radiusSmall;
xymaxmin[1] = TexturePoint3D.z - radiusSmall;
xymaxmin[2] = TexturePoint3D.x + radiusSmall;
xymaxmin[3] = TexturePoint3D.x - radiusSmall;


int[,] map = Terrain.activeTerrain.terrainData.GetDetailLayer(0,0, Terrain.activeTerrain.terrainData.detailWidth, Terrain.activeTerrain.terrainData.detailHeight, 0);

for (int y = 0; y < Terrain.activeTerrain.terrainData.detailHeight; y++) {
for (int x = 0; x < Terrain.activeTerrain.terrainData.detailWidth; x++) {

if(xymaxmin[0] > x && xymaxmin[1] < x && xymaxmin[2] > y && xymaxmin[3] < y )
map[x,y] = 0;
}
}

Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,0,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,1,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,2,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,3,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,4,map);
Terrain.activeTerrain.terrainData.SetDetailLayer(0,0,5,map);
}

}
