using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class UsPgEraserBETA2 : MonoBehaviour {
private int LayerObj;
public float Radius = 10;
private float LifeTime = 1;
private float RespawnTime = 0;

void Start () {
LayerObj = LayerMask.GetMask("BigObj" , "MedObj", "SmallObj");
Ray ray = new Ray(this.transform.position, -Vector3.up);
RaycastHit Hit;
if(Physics.Raycast(ray, out Hit, Mathf.Infinity, LayerObj)) {
//Debug.Log(Hit.collider.name);
CutGrass(Terrain.activeTerrain, Hit.point, Radius);
} 
/*
else {
Dead();//вызываем функцию dead
}
*/
}
void Update () {
//////////////////////////////////
RespawnTime += Time.deltaTime; //RespawnTime увеличивается с каждым кадром после создания объекта
if(RespawnTime>LifeTime) // если RespawnTime больше LifeTime
{
Dead();//вызываем функцию dead
}
//////////////////////////////////
}

public void CutGrass(Terrain t, Vector3 position, float radius)
{
if(t == null)
t = gameObject.GetComponent<Terrain>();

int TerrainDetailMapSize = Terrain.activeTerrain.terrainData.detailResolution;
float PrPxSize = TerrainDetailMapSize / t.terrainData.size.x;

Vector3 TexturePoint3D = position - Terrain.activeTerrain.transform.position;
TexturePoint3D = TexturePoint3D * PrPxSize;

float[] xymaxmin = new float[4];
xymaxmin[0] = TexturePoint3D.z + radius;
xymaxmin[1] = TexturePoint3D.z - radius;
xymaxmin[2] = TexturePoint3D.x + radius;
xymaxmin[3] = TexturePoint3D.x - radius;

int[,] map = Terrain.activeTerrain.terrainData.GetDetailLayer(0,0, Terrain.activeTerrain.terrainData.detailWidth, Terrain.activeTerrain.terrainData.detailHeight, 0);

for (int y = 0; y < Terrain.activeTerrain.terrainData.detailHeight; y++) {
for (int x = 0; x < Terrain.activeTerrain.terrainData.detailWidth; x++) {

if(xymaxmin[0] > x && xymaxmin[1] < x && xymaxmin[2] > y && xymaxmin[3] < y)
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

void Dead() // функция dead
{
Destroy(gameObject); //удаляем объект на котором висит скрипт
}


}

