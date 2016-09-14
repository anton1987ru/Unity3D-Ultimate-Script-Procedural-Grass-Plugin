using UnityEngine;
using System.Collections;

public class USPG_API: MonoBehaviour {
	void Start () {
//  gameObject.AddComponent<UsPg>(); //Example call function UsPg API .
	gameObject.AddComponent<UsPgAuto>(); //Example call function UsPg API AUTO inside external C# Terrain Generator Manager. Call gameObject.AddComponent<USPG_API>();
	}
	
	void Update() {
//	   UsPg USPG_API = GetComponent<UsPg>();
       UsPgAuto USPG_AUTOAPI = GetComponent<UsPgAuto>();
	   
////////////////////////////////////////////////////////////
/////////////      USPG_AUTO_API SETTINGS       ////////////
////////////////////////////////////////////////////////////

//Main Settings//
USPG_AUTOAPI.m_detailSeed = 666999666;
USPG_AUTOAPI.m_detailFrq = 2.0f;
USPG_AUTOAPI.m_noiseSpread = 256f;
USPG_AUTOAPI.m_detailObjectDistance = 200;
USPG_AUTOAPI.m_detailObjectDensity = 0.06f;
USPG_AUTOAPI.m_wavingGrassSpeed = 1f;
USPG_AUTOAPI.m_wavingGrassSize = 1f;
USPG_AUTOAPI.m_wavingGrassBending = 0.21f;
USPG_AUTOAPI.m_detailResolutionPerPatch = 128;
		 
//Color Settings//
///*
USPG_AUTOAPI.GeneralGrassTint = new Color32(0, 100, 255, 255); //default (214, 214, 214, 255);  //red (255, 0, 0, 255); //Blue (0, 100, 255, 255); //niceblue (0, 255, 230, 255); //Green (0, 255, 0, 255); //Yellow (0, 255, 255, 255); //Orange (0, 150, 255, 255); //Magenta (255, 0, 255, 255); //Pink (255, 0, 130, 255);
		 
USPG_AUTOAPI.grassHealthyColor0 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_AUTOAPI.grassDryColor0 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_AUTOAPI.grassHealthyColor1 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_AUTOAPI.grassDryColor1 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_AUTOAPI.grassHealthyColor2 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_AUTOAPI.grassDryColor2 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_AUTOAPI.grassHealthyColor3 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_AUTOAPI.grassDryColor3 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_AUTOAPI.grassHealthyColor4 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_AUTOAPI.grassDryColor4 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_AUTOAPI.grassHealthyColor5 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_AUTOAPI.grassDryColor5 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
//*/

/* //RED GRASS

USPG_AUTOAPI.GeneralGrassTint = new Color32(255, 0, 0, 255); 
USPG_AUTOAPI.grassHealthyColor0 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassDryColor0 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassHealthyColor1 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassDryColor1 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassHealthyColor2 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassDryColor2 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassHealthyColor3 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassDryColor3 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassHealthyColor4 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassDryColor4 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassHealthyColor5 = new Color32(255, 0, 0, 255);
USPG_AUTOAPI.grassDryColor5 = new Color32(255, 0, 0, 255);

*/	
	 
//Grass settings Size//		 
USPG_AUTOAPI.m_minWidth = 3f;
USPG_AUTOAPI.m_maxWidth = 4f;
USPG_AUTOAPI.m_minHeight = 0.5f;
USPG_AUTOAPI.m_maxHeight = 1f;

//No Grass Places Settings//
USPG_AUTOAPI.m_waterHeight = 15;
USPG_AUTOAPI.m_cliffHeight = 500;

// Grass Hole Raytracer settings//
USPG_AUTOAPI.Repiter = 60;
USPG_AUTOAPI.Resolution = 60f;
USPG_AUTOAPI.Height = 100000;
USPG_AUTOAPI.RAYTRASSA = 150;

////////////////////////////////////////////////////////////
//////////////      USPG_API SETTINGS       ////////////////
////////////////////////////////////////////////////////////

/*

///////Main Settings//////
USPG_API.m_detailSeed = 666999666;
USPG_API.m_detailFrq = 2.0f;
USPG_API.m_noiseSpread = 256f;
USPG_API.m_detailObjectDistance = 200;
USPG_API.m_detailObjectDensity = 0.06f;
USPG_API.m_wavingGrassSpeed = 1f;
USPG_API.m_wavingGrassSize = 1f;
USPG_API.m_wavingGrassBending = 0.21f;
USPG_API.m_detailResolutionPerPatch = 128;
		 
//////Color Settings///////
USPG_API.GeneralGrassTint = new Color32(0, 100, 255, 255); //default (214, 214, 214, 255);  //red (255, 0, 0, 255); //Blue (0, 100, 255, 255); //niceblue (0, 255, 230, 255); //Green (0, 255, 0, 255); //Yellow (0, 255, 255, 255); //Orange (0, 150, 255, 255); //Magenta (255, 0, 255, 255); //Pink (255, 0, 130, 255);
	 
USPG_API.grassHealthyColor0 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_API.grassDryColor0 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_API.grassHealthyColor1 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_API.grassDryColor1 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_API.grassHealthyColor2 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_API.grassDryColor2 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_API.grassHealthyColor3 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_API.grassDryColor3 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_API.grassHealthyColor4 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_API.grassDryColor4 = new Color32(111, 146, 91, 255); //default(111, 146, 91, 255);
USPG_API.grassHealthyColor5 = new Color32(150, 150, 150, 255); //default(150, 150, 150, 255);
USPG_API.grassDryColor5 = new Color32(111, 146, 91, 255);(111, 146, 91, 255);

///Grass settings Size//////		 
USPG_API.m_minWidth = 3f;
USPG_API.m_maxWidth = 4f;
USPG_API.m_minHeight = 0.5f;
USPG_API.m_maxHeight = 1f;

// Grass Hole Raytracer settings//
USPG_API.Repiter = 60;
USPG_API.Resolution = 60f;
USPG_API.Height = 100000;
USPG_API.RAYTRASSA = 150;

*/

/////////////////////////////////////////////////////////

}
	
	void OnApplicationQuit () {
//  Destroy (GetComponent<UsPg>());
	Destroy (GetComponent<UsPgAuto>());
    }
}
