using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

[ExecuteInEditMode]
public class UsPgRAYTRACER : MonoBehaviour {
private int LayerObj;
public float Radius;
private float LifeTime = 0.01f;
private float RespawnTime = 0;


void Start () {	
LayerObj = LayerMask.GetMask("Obj");
/* LayerObj = LayerMask.GetMask("BigObj" , "MedObj", "SmallObj"); */

//////////RAYCAST////////////////////////
/* Ray ray = new Ray(this.transform.position, -Vector3.up);
RaycastHit Hit;
if(Physics.Raycast(ray, out Hit, Mathf.Infinity, LayerObj)) {
CutGrass(Terrain.activeTerrain, Hit.point, Hit.collider.transform.rotation, Radius);
}  */
/////////////////////////////////////////

/////////SPHERECAST///////////////////////
RaycastHit Hit;
if(Physics.SphereCast(this.transform.position, 60f,-Vector3.up, out Hit, Mathf.Infinity, LayerObj)) {
CutGrass(Terrain.activeTerrain, Hit.point, Hit.collider.transform.rotation, Radius);
}
//////////////////////////////////////////
}


void Update () {

RespawnTime += Time.deltaTime; //RespawnTime увеличивается с каждым кадром после создания объекта
if(RespawnTime>LifeTime) // если RespawnTime больше LifeTime
{
Dead();//вызываем функцию dead
}
//////////////////////////////////
}

void Dead() // функция dead
{
Destroy(gameObject); //удаляем объект на котором висит скрипт
}

public void CutGrass(Terrain t, Vector3 position, Quaternion rotationar, float radius)
{
if(t == null)
t = gameObject.GetComponent<Terrain>();

int TerrainDetailMapSize = Terrain.activeTerrain.terrainData.detailResolution;
float PrPxSize = TerrainDetailMapSize / t.terrainData.size.x;

Vector3 TexturePoint3D = position - Terrain.activeTerrain.transform.position;


TexturePoint3D = TexturePoint3D * PrPxSize;


///основа сложение 1/2
float[] xymaxmin = new float[4];
xymaxmin[0] = TexturePoint3D.z  + radius;
xymaxmin[1] = TexturePoint3D.z  - radius;
xymaxmin[2] = TexturePoint3D.x  + radius;
xymaxmin[3] = TexturePoint3D.x  - radius;

//сложение радиусов x2
float[] xymaxmin1 = new float[4];
xymaxmin1[0] = TexturePoint3D.z  + radius / 2f;
xymaxmin1[1] = TexturePoint3D.z  - radius / 2f;
xymaxmin1[2] = TexturePoint3D.x  + radius + (radius / 3.5f);
xymaxmin1[3] = TexturePoint3D.x  - radius - (radius / 3.5f);

float[] xymaxmin2 = new float[4];
xymaxmin2[0] = TexturePoint3D.z  + radius + (radius / 3.5f);
xymaxmin2[1] = TexturePoint3D.z  - radius - (radius / 3.5f);
xymaxmin2[2] = TexturePoint3D.x  + radius / 2f;
xymaxmin2[3] = TexturePoint3D.x  - radius / 2f;

//сложение 1/4
float[] xymaxmin3 = new float[4];
xymaxmin3[0] = TexturePoint3D.z  + radius / 1.5f; /// уменьшаеться тут
xymaxmin3[1] = TexturePoint3D.z  - radius / 1.5f;
xymaxmin3[2] = TexturePoint3D.x  + radius + (radius / 5f); // увиличиваешь тут
xymaxmin3[3] = TexturePoint3D.x  - radius - (radius / 5f);

float[] xymaxmin4 = new float[4];
xymaxmin4[0] = TexturePoint3D.z  + radius + (radius / 5f);
xymaxmin4[1] = TexturePoint3D.z  - radius - (radius / 5f);
xymaxmin4[2] = TexturePoint3D.x  + radius / 1.5f;
xymaxmin4[3] = TexturePoint3D.x  - radius / 1.5f;

//сложение 1/8
float[] xymaxmin5 = new float[4];
xymaxmin5[0] = TexturePoint3D.z  + radius / 1.2f; /// уменьшаеться тут
xymaxmin5[1] = TexturePoint3D.z  - radius / 1.2f;
xymaxmin5[2] = TexturePoint3D.x  + radius + (radius / 10f); // увиличиваешь тут
xymaxmin5[3] = TexturePoint3D.x  - radius - (radius / 10f);

float[] xymaxmin6 = new float[4];
xymaxmin6[0] = TexturePoint3D.z  + radius + (radius / 10f);
xymaxmin6[1] = TexturePoint3D.z  - radius - (radius / 10f);
xymaxmin6[2] = TexturePoint3D.x  + radius / 1.2f;
xymaxmin6[3] = TexturePoint3D.x  - radius / 1.2f;

int[,] map = Terrain.activeTerrain.terrainData.GetDetailLayer(0,0, Terrain.activeTerrain.terrainData.detailWidth, Terrain.activeTerrain.terrainData.detailHeight, 0);

for (int y = 0; y < Terrain.activeTerrain.terrainData.detailHeight; y++) {
for (int x = 0; x < Terrain.activeTerrain.terrainData.detailWidth; x++) {


if(xymaxmin[0] > x && xymaxmin[1] < x && xymaxmin[2] > y && xymaxmin[3] < y ){
map[x,y] = 0;
}

if(xymaxmin1[0] > x && xymaxmin1[1] < x && xymaxmin1[2] > y && xymaxmin1[3] < y ){
map[x,y] = 0;
}

if(xymaxmin2[0] > x && xymaxmin2[1] < x && xymaxmin2[2] > y && xymaxmin2[3] < y ){
map[x,y] = 0;
}

if(xymaxmin3[0] > x && xymaxmin3[1] < x && xymaxmin3[2] > y && xymaxmin3[3] < y ){
map[x,y] = 0;
}

if(xymaxmin4[0] > x && xymaxmin4[1] < x && xymaxmin4[2] > y && xymaxmin4[3] < y ){
map[x,y] = 0;
}

if(xymaxmin5[0] > x && xymaxmin5[1] < x && xymaxmin5[2] > y && xymaxmin5[3] < y ){
map[x,y] = 0;
}

if(xymaxmin6[0] > x && xymaxmin6[1] < x && xymaxmin6[2] > y && xymaxmin6[3] < y ){
map[x,y] = 0;
}

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

