using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Threading;

[AddComponentMenu("ULTIMATE SCRIPTS/ULTIMATE GENERATOR/AUTOPROCEDURAL GRASS FOR INFINITE TERRAIN")]
public class UsPgAuto : MonoBehaviour 
{
	//Вызов переменных
[HideInInspector]
    public Texture2D m_detail0; //Текстура травы 1
[HideInInspector]
	public Texture2D m_detail1;
[HideInInspector]	//Текстура травы 2
	public Texture2D m_detail2;
[HideInInspector]	//Текстура травы 3
	public Texture2D m_detail3;
[HideInInspector]	//Текстура травы 4
	public Texture2D m_detail4;
[HideInInspector]	//Текстура травы 5
	public Texture2D m_detail5; //Текстура травы 6
	//[Header("                   Генератор шума")]
	public static float grassSizer = 1;
	public int m_detailSeed = 481516234; //Генератор случайного числа для распределения по поверхности земли
	public float  m_detailFrq = 4f; //Разрешение шума Генератора случайного числа
	public float m_noiseSpread = 256f; //Генератор случайного числа для Размера травы
	//[Header("               Общие настройки травы")]
	public Color GeneralGrassTint = new Color32(214, 214, 214, 255); //Общий оттенок травы
	public DetailRenderMode detailMode; //Тип отображения спрайтов травы
	//public DetailRenderMode.Grass; //Тип отображения спрайтов травы
	public int m_detailObjectDistance = 256; //дальность прорисовки травы
	public float m_minWidth = 3f; //Минимальная ширина травы
	public float m_maxWidth = 4f; //Максимальная ширина травы
	public float m_minHeight = 0.5f; //Минимальная высота травы
	public float m_maxHeight = 1f; //Максимальная высота травы
	public float m_waterHeight = 15; //Высота воды
	public float m_cliffHeight = 500; //Высота гор
	[HideInInspector]//настройка анимации травы
	public float m_wavingGrassSpeed = 1f; //0.3f;
	[HideInInspector]
	public float m_wavingGrassSize = 1f; //0.09
	[HideInInspector]
	public float m_wavingGrassBending = 0.21f; //0.2f
	//настройка количества отображаемой травы по прозрачности - по умолчанию 4.0f;
	public float m_detailObjectDensity = 0.06f;
	[HideInInspector]//настройка количества отображаемой травы на патч - по умолчанию 32;
	public int m_detailResolutionPerPatch = 64;
	[HideInInspector] // Индевидуальные цвета для травы
	public Color grassHealthyColor0 = new Color32(150, 150, 150, 255);
	[HideInInspector]
	public Color grassDryColor0 = new Color32(111, 146, 91, 255);
	[HideInInspector]
	public Color grassHealthyColor1 = new Color32(150, 150, 150, 255);
	[HideInInspector]
	public Color grassDryColor1 = new Color32(111, 146, 91, 255);
	[HideInInspector]
	public Color grassHealthyColor2 = new Color32(150, 150, 150, 255);
	[HideInInspector]
	public Color grassDryColor2 = new Color32(111, 146, 91, 255);
	[HideInInspector]
	public Color grassHealthyColor3 = new Color32(150, 150, 150, 255);
	[HideInInspector]
	public Color grassDryColor3 = new Color32(111, 146, 91, 255);
	[HideInInspector]
	public Color grassHealthyColor4 = new Color32(150, 150, 150, 255);
	[HideInInspector]
	public Color grassDryColor4 = new Color32(111, 146, 91, 255);
	[HideInInspector]
	public Color grassHealthyColor5 = new Color32(150, 150, 150, 255);
	[HideInInspector]
	public Color grassDryColor5 = new Color32(111, 146, 91, 255);
	//Private
    DetailPrototype[] m_detailProtoTypes; // Тут утверждаеться что Текстурки которые мы задали - являються травой для террейна.
	Terrain[,] m_terrain; //Называем что абстрактный террейн называеться  m_terrain
	UsPgNoise  m_detailNoise; //Вызываем шум перлина
	private int m_tilesX = 1; //НЕ ТРОГАТЬ!
	private int m_tilesZ = 1; //НЕ ТРОГАТЬ!
	private int m_terrainSize = 2048; // Задаём размер Террейна (Должен совпадать с Размером Террейна)
	//private int m_terrainHeight = 400; // Задаём высоту Террейна (Должен совпадать с Размером Террейна)
	private int m_detailMapSize = 4096; //Размер карты покрытия травой (ВНИМАНИЕ!! не менять) чтобы не было ошибок в террейне должно стоять -> Terrain Width 2000 ; Terrain Length 2000; Terrain Height 400; Heightmap Resolution 513; Detail Resolution 4096; Detail Resolution Per Patch 32; Base Texture Resolution 1024;
	//////////////////////////////////////////////
	[HideInInspector]
     private int gridWidth;
     private int gridLenght;
     private GameObject[] cells;
     public GameObject pref;
	 public int Repiter = 60;
	 public float Resolution = 60f;
	 public int Height = 100000;
	 public float RAYTRASSA = 150;
	//////////////////////////////////////////////
	///////////////ДЕРЕВЬЯ/////////
	public GameObject FallingTreePrefab;
    public GameObject player;
	public List < TreeInstance > treeList;
	////////
	
	void Start() 
	{
	///////////////ДЕРЕВЬЯ/////////
	treeList = new List<TreeInstance>(Terrain.activeTerrain.terrainData.treeInstances);
	////////
		//***********   ИНИЦИАЛИЗИРУЕМ ТЕКСТУРЫ   ********//
		m_detail0 = Resources.Load<Texture2D>("Ultimate scripts Procedural Grass/grass");//ТУТ УКАЗЫВАЕМ ИМЯ ТЕКСТУРЫ КОТОРАЯ ДОЛЖНА ЛЕЖАТЬ СТРОГО В ПАПКЕ Resources //
		m_detail1 = Resources.Load<Texture2D>("Ultimate scripts Procedural Grass/grass1");//ТУТ УКАЗЫВАЕМ ИМЯ ТЕКСТУРЫ КОТОРАЯ ДОЛЖНА ЛЕЖАТЬ СТРОГО В ПАПКЕ Resources //
		m_detail2 = Resources.Load<Texture2D>("Ultimate scripts Procedural Grass/grass2");//ТУТ УКАЗЫВАЕМ ИМЯ ТЕКСТУРЫ КОТОРАЯ ДОЛЖНА ЛЕЖАТЬ СТРОГО В ПАПКЕ Resources //
		m_detail3 = Resources.Load<Texture2D>("Ultimate scripts Procedural Grass/grass3");//ТУТ УКАЗЫВАЕМ ИМЯ ТЕКСТУРЫ КОТОРАЯ ДОЛЖНА ЛЕЖАТЬ СТРОГО В ПАПКЕ Resources //
		m_detail4 = Resources.Load<Texture2D>("Ultimate scripts Procedural Grass/grass4");//ТУТ УКАЗЫВАЕМ ИМЯ ТЕКСТУРЫ КОТОРАЯ ДОЛЖНА ЛЕЖАТЬ СТРОГО В ПАПКЕ Resources //
		m_detail5 = Resources.Load<Texture2D>("Ultimate scripts Procedural Grass/grass5");//ТУТ УКАЗЫВАЕМ ИМЯ ТЕКСТУРЫ КОТОРАЯ ДОЛЖНА ЛЕЖАТЬ СТРОГО В ПАПКЕ Resources //
		
		m_detailNoise = new UsPgNoise(m_detailSeed); //говорим что m_detailNoise это шум перлина с параметром Генератора случайного числа
		m_terrain = new Terrain[m_tilesX,m_tilesZ]; // говорим что m_terrain это новый террейн с координатами m_tiles
		Terrain CurrentTerrain = gameObject.GetComponent<Terrain>();//говорим что Террейн с названием CurrentTerrain это Террейн в сцене 
			
/////////////////////////////////////////////////////////


			CreateProtoTypes(); //создание прототипов травы

		for(int x = 0; x < m_tilesX; x++)
		{
			for(int z = 0; z < m_tilesZ; z++)
			{		
				TerrainData terrainData = Terrain.activeTerrain.terrainData; //говорим что Данные некого TerrainData равны данным нашего активного терейна.
				terrainData.size = Terrain.activeTerrain.terrainData.size;  //говорим что Размер terrainData равны размеру нашего активного террейна
				terrainData.detailPrototypes = m_detailProtoTypes;	//говорим что трава terrainData равна нашей траве из прототипов
                m_terrain[x,z] = CurrentTerrain;//говорим что m_terrain[x,z] равен Нашему террейну в сцене
				FillDetailMap(m_terrain[x,z], x, z); // говорим что FillDetailMap равен m_terrain[x,z] с параметрами x z
				//////////////ДЕРЕВЬЯ/////////
				treeList = new List< TreeInstance >();
				Terrain.activeTerrain.terrainData.treeInstances = treeList.ToArray();
				//////////////
			}
		}
	

/////////////HOLE//////////////////////
		 GameObject Raytrassert = GameObject.CreatePrimitive(PrimitiveType.Sphere);
		 Raytrassert.AddComponent<UsPgRAYTRACER>();
		 UsPgRAYTRACER RAY = Raytrassert.GetComponent<UsPgRAYTRACER>();
		 RAY.Radius = RAYTRASSA;
		 
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
///////////////////////////////////////////////////////	
	}
		
	
	
	void CreateProtoTypes()
	{

		m_detailProtoTypes = new DetailPrototype[6];

		m_detailProtoTypes[0] = new DetailPrototype();
		m_detailProtoTypes[0].prototypeTexture = m_detail0;
		//m_detailProtoTypes[0].renderMode = detailMode;
		m_detailProtoTypes[0].healthyColor = grassHealthyColor0;
		m_detailProtoTypes[0].dryColor = grassDryColor0;
		m_detailProtoTypes[0].noiseSpread = m_noiseSpread;
		m_detailProtoTypes[0].minWidth = m_minWidth;
		m_detailProtoTypes[0].maxWidth = m_maxWidth;
		m_detailProtoTypes[0].minHeight = m_minHeight;
		m_detailProtoTypes[0].maxHeight = m_maxHeight;
		
		m_detailProtoTypes[1] = new DetailPrototype();
		m_detailProtoTypes[1].prototypeTexture = m_detail1;
		//m_detailProtoTypes[1].renderMode = detailMode;
		m_detailProtoTypes[1].healthyColor = grassHealthyColor1;
		m_detailProtoTypes[1].dryColor = grassDryColor1;
		m_detailProtoTypes[1].noiseSpread = m_noiseSpread;
		m_detailProtoTypes[1].minWidth = m_minWidth;
		m_detailProtoTypes[1].maxWidth = m_maxWidth;
		m_detailProtoTypes[1].minHeight = m_minHeight;
		m_detailProtoTypes[1].maxHeight = m_maxHeight;
		
		m_detailProtoTypes[2] = new DetailPrototype();
		m_detailProtoTypes[2].prototypeTexture = m_detail2;
		//m_detailProtoTypes[2].renderMode = detailMode;
		m_detailProtoTypes[2].healthyColor = grassHealthyColor2;
		m_detailProtoTypes[2].dryColor = grassDryColor2;
		m_detailProtoTypes[2].noiseSpread = m_noiseSpread;
		m_detailProtoTypes[2].minWidth = m_minWidth;
		m_detailProtoTypes[2].maxWidth = m_maxWidth;
		m_detailProtoTypes[2].minHeight = m_minHeight;
		m_detailProtoTypes[2].maxHeight = m_maxHeight;
		
		m_detailProtoTypes[3] = new DetailPrototype();
		m_detailProtoTypes[3].prototypeTexture = m_detail3;
		//m_detailProtoTypes[3].renderMode = detailMode;
		m_detailProtoTypes[3].healthyColor = grassHealthyColor3;
		m_detailProtoTypes[3].dryColor = grassDryColor3;
		m_detailProtoTypes[3].noiseSpread = m_noiseSpread;
		m_detailProtoTypes[3].minWidth = m_minWidth;
		m_detailProtoTypes[3].maxWidth = m_maxWidth;
		m_detailProtoTypes[3].minHeight = m_minHeight;
		m_detailProtoTypes[3].maxHeight = m_maxHeight;
		
		m_detailProtoTypes[4] = new DetailPrototype();
		m_detailProtoTypes[4].prototypeTexture = m_detail4;
		//m_detailProtoTypes[4].renderMode = detailMode;
		m_detailProtoTypes[4].healthyColor = grassHealthyColor4;
		m_detailProtoTypes[4].dryColor = grassDryColor4;
		m_detailProtoTypes[4].noiseSpread = m_noiseSpread;
		m_detailProtoTypes[4].minWidth = m_minWidth;
		m_detailProtoTypes[4].maxWidth = m_maxWidth;
		m_detailProtoTypes[4].minHeight = m_minHeight;
		m_detailProtoTypes[4].maxHeight = m_maxHeight;
		
		m_detailProtoTypes[5] = new DetailPrototype();
		m_detailProtoTypes[5].prototypeTexture = m_detail5;
		//m_detailProtoTypes[5].renderMode = detailMode;
		m_detailProtoTypes[5].healthyColor = grassHealthyColor5;
		m_detailProtoTypes[5].dryColor = grassDryColor5;
		m_detailProtoTypes[5].noiseSpread = m_noiseSpread;
		m_detailProtoTypes[5].minWidth = m_minWidth;
		m_detailProtoTypes[5].maxWidth = m_maxWidth;
		m_detailProtoTypes[5].minHeight = m_minHeight;
		m_detailProtoTypes[5].maxHeight = m_maxHeight;

		
	}
	
	
	void FillDetailMap(Terrain terrain, int tileX, int tileZ)
	{
		int[,] detailMap0 = new int[m_detailMapSize,m_detailMapSize];
		int[,] detailMap1 = new int[m_detailMapSize,m_detailMapSize];
		int[,] detailMap2 = new int[m_detailMapSize,m_detailMapSize];
		int[,] detailMap3 = new int[m_detailMapSize,m_detailMapSize];
		int[,] detailMap4 = new int[m_detailMapSize,m_detailMapSize];
		int[,] detailMap5 = new int[m_detailMapSize,m_detailMapSize];
//		gameObject.AddComponent<UsPgEraser>();
		
		float ratio = (float)m_terrainSize/(float)m_detailMapSize;
		
		UnityEngine.Random.seed = 481516234;
///////////////Генерация травы////////////////////////////////////////	
		for(int x = 0; x < m_detailMapSize; x++) 
		{
            for (int z = 0; z < m_detailMapSize; z++) 
			{
/////////////////////////////////////////////////////////////////////
				
				/////////Переменные размерности от угла земли/////////	
				float unit = 1f / (m_detailMapSize - 1);
                float normX = x * unit;
                float normZ = z * unit;           
                float angle = terrain.terrainData.GetSteepness(normX, normZ);
				float height = terrain.terrainData.GetInterpolatedHeight(normX, normZ);
                float frac = angle / 65.0f;

				
						
///////////////////Плейсить траву если угол меньше 90 градусов c учётом высоты водной поверхности ///////
			
				if(frac < 0.6f && height > 1.1f * m_waterHeight) 
				{
					
					float worldPosX = (x+tileX*(m_detailMapSize-1))*ratio;
					float worldPosZ = (z+tileZ*(m_detailMapSize-1))*ratio;
					
					float noise = m_detailNoise.FractalNoise2D(worldPosX, worldPosZ, 3, m_detailFrq, 1.0f);
					float noise1 = m_detailNoise.FractalNoise2Dver2(worldPosX, worldPosZ, 3, m_detailFrq, 1.0f);
					float result = Mathf.Lerp(noise1, noise, 0.9f);
					
					///////////////Распределение шума////////////////
					if(result > 0.0f) 
					{
						float rnd = UnityEngine.Random.value;
						if(rnd < 0.23f)
						detailMap0[z,x] = 3;
						else if(rnd < 0.36f)
						detailMap1[z,x] = 3;
						else if(rnd < 0.46f)
						detailMap2[z,x] = 3;				
						else if(rnd < 0.56f)
						detailMap3[z,x] = 3;					
						else if(rnd < 0.66f)
						detailMap4[z,x] = 3;
						else
						detailMap5[z,x] = 3;
					}
					
					if( height > m_cliffHeight)
					{
						detailMap0[z,x] = 0;
						detailMap1[z,x] = 0;
						detailMap2[z,x] = 0;				
						detailMap3[z,x] = 0;					
						detailMap4[z,x] = 0;
						detailMap5[z,x] = 0;	
					}
					
				}

/////////////////////////////////////////////////////////////////////			
			}
		}
/////////////////////////////////////////////////////////////////////////////			
		
		terrain.terrainData.wavingGrassStrength = m_wavingGrassSize;
		terrain.terrainData.wavingGrassAmount = m_wavingGrassBending;
		terrain.terrainData.wavingGrassSpeed = m_wavingGrassSpeed;
		terrain.terrainData.wavingGrassTint = GeneralGrassTint;
		terrain.detailObjectDensity = m_detailObjectDensity;
		detailMode = DetailRenderMode.Grass;
		terrain.detailObjectDistance = m_detailObjectDistance;
		terrain.terrainData.SetDetailResolution(m_detailMapSize, m_detailResolutionPerPatch);
		terrain.terrainData.SetDetailLayer(0,0,0,detailMap0);
		terrain.terrainData.SetDetailLayer(0,0,1,detailMap1);
		terrain.terrainData.SetDetailLayer(0,0,2,detailMap2);
		terrain.terrainData.SetDetailLayer(0,0,3,detailMap3);
		terrain.terrainData.SetDetailLayer(0,0,4,detailMap4);
		terrain.terrainData.SetDetailLayer(0,0,5,detailMap5);
		terrain.terrainData.RefreshPrototypes();
		terrain.Flush();
		
	}
	
	void OnApplicationQuit () {
Terrain.activeTerrain.terrainData.RefreshPrototypes();
Terrain.activeTerrain.Flush();
}
	
/*	void OnApplicationQuit () {
	Destroy (GetComponent<UsPgEraser>());
}
*/
///////////ДЕРЕВЬЯ/////////
void Update(){
//float Pseudovoronoi = Mathf.Lerp(m_detailNoise.FractalNoise2D(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.z, 3, m_detailFrq, 1.0f),m_detailNoise.FractalNoise2Dver2(Terrain.activeTerrain.transform.position.x, Terrain.activeTerrain.transform.position.z, 3, m_detailFrq, 1.0f), 0.9f);
player = GameObject.FindWithTag("Player");
Vector3 treeposition = player.transform.position;
Vector3 treeDisplacement = Vector3.zero;
TreeInstance newtree = new TreeInstance();
TreeInstance[] treeInstances = Terrain.activeTerrain.terrainData.treeInstances;
	var RanddomF = Mathf.Floor(UnityEngine.Random.Range(0,3));
	int RanddomI = Convert.ToInt32(RanddomF);
	///////////
	var RanddomF2 = Mathf.Floor(UnityEngine.Random.Range(-100, 100));
	int RanddomI2 = Convert.ToInt32(RanddomF2);
	var RanddomF3 = Mathf.Floor(UnityEngine.Random.Range(-100, 100));
	int RanddomI3 = Convert.ToInt32(RanddomF3);
	///////////
    newtree.prototypeIndex = RanddomI; // From terrain tree prototypes list index
    newtree.color = new Color (1, 1, 1);
	newtree.lightmapColor = new Color (1, 1, 1); 
    newtree.heightScale = 1;
    newtree.widthScale = 1;
	treeDisplacement = new Vector3(RanddomI3,0,RanddomI2); // World Space Coords Random around player transform
    newtree.position = new Vector3(player.transform.position.x + treeDisplacement.x,player.transform.position.y + treeDisplacement.y,player.transform.position.z + treeDisplacement.z );
	newtree.position.y = Terrain.activeTerrain.terrainData.GetInterpolatedHeight(newtree.position.x, newtree.position.z);  // Dont sure if I have to normalize coords
	var newtreeterrainLocalPos = newtree.position - Terrain.activeTerrain.transform.position;
    var newtreenormalizedPos = new Vector2(Mathf.InverseLerp(0.0f, Terrain.activeTerrain.terrainData.size.x, newtreeterrainLocalPos.x), Mathf.InverseLerp(0.0f, Terrain.activeTerrain.terrainData.size.z, newtreeterrainLocalPos.z));
    var newtreeterrainNormal = Terrain.activeTerrain.terrainData.GetInterpolatedNormal(newtreenormalizedPos.x, newtreenormalizedPos.y);
	var playerLocalPos = player.transform.position - Terrain.activeTerrain.transform.position;
    var playernormalizedPos = new Vector2(Mathf.InverseLerp(0.0f, Terrain.activeTerrain.terrainData.size.x, playerLocalPos.x), Mathf.InverseLerp(0.0f, Terrain.activeTerrain.terrainData.size.z, newtreeterrainLocalPos.z));
    var playerterrainNormal = Terrain.activeTerrain.terrainData.GetInterpolatedNormal(playernormalizedPos.x, playernormalizedPos.y);    
 	newtree.position = new Vector3(newtreenormalizedPos.x , 0 ,newtreenormalizedPos.y );
	treeList.Add(newtree);
//	treeList.Remove(newtree);
    Terrain.activeTerrain.terrainData.treeInstances = treeList.ToArray();
	var numTrees = treeList.Count;
    var newtreeList = new List< TreeInstance >();
	for ( var t = 0; t < numTrees; t ++ ){
	var vecreal = Vector3.Scale(Terrain.activeTerrain.terrainData.treeInstances[t].position,Terrain.activeTerrain.terrainData.size) + Terrain.activeTerrain.transform.position;
	var distance = Vector3.Distance (player.transform.position, vecreal);
	  		if(distance<80)
		{
				newtreeList.Add(Terrain.activeTerrain.terrainData.treeInstances[t]);	
		} 
	}
    Terrain.activeTerrain.terrainData.treeInstances = newtreeList.ToArray();
    treeList = newtreeList;
}


}
