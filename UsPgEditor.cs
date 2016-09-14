using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(UsPg))]
public class UsPgEditor : Editor
{
      ///////Инициализация стилей и Лого/////////////
     private Texture2D MakeTex(int width, int height, Color col)
   {
        Color[] pix = new Color[width * height];

       for (int i = 0; i < pix.Length; i++)
            pix[i] = col;

        Texture2D result = new Texture2D(width, height);
        result.hideFlags = HideFlags.HideAndDontSave;
        result.SetPixels(pix);
        result.Apply();

        return result;
  }

   GUIStyle m_Background1;
   GUIStyle m_Background2;
   GUIStyle m_Background3;
   GUIStyle Depthstyle;
   Texture2D m_Logo;
	
    void OnEnable()
    {
        m_Background1 = new GUIStyle();
        m_Background1.normal.background = MakeTex(900, 1, new Color(0f, 1.75f, 0f, 0.1f));
        m_Background2 = new GUIStyle();
        m_Background2.normal.background = MakeTex(900, 1, new Color(0f, 1.75f, 0f, 0.0f));
        m_Background3 = new GUIStyle();
        m_Background3.normal.background = MakeTex(900, 1, new Color(0f, 1.75f, 0f, 0.05f));
		Depthstyle = new GUIStyle();
        Depthstyle.normal.background = MakeTex(900, 1, new Color(0.2f, 0.2f, 0.2f, 0.2f));
	    m_Logo = (Texture2D)AssetDatabase.LoadAssetAtPath("Assets/Ultimate scripts Procedural Grass/ResPool/Media/pg.psd", typeof(Texture2D));//ТУТ УКАЗЫВАЕМ ПУТЬ ДЛЯ ТЕКСТУРЫ

        if (m_Logo != null)
            m_Logo.hideFlags = HideFlags.HideAndDontSave;

    }
   /////////////////////////////////////

    public override void OnInspectorGUI()
    {
		//////////РИСУЕМ ЛОГО ////////////
		       if (m_Logo != null)
       {
        GUILayout.BeginVertical(m_Background1);
        Rect rect = GUILayoutUtility.GetRect(m_Logo.width, m_Logo.height);
        GUI.DrawTexture(rect, m_Logo, ScaleMode.ScaleToFit);
		GUILayout.EndVertical();
        }
		///////////////////////////////////////////
		   GUI.color = Color.white; //Цвет интерфейса	
		   GUI.backgroundColor = Color.green;		   
				  ///////Версия продукта////////////
		  GUILayout.BeginVertical(m_Background1);
         EditorGUILayout.HelpBox("Version 1.1                           Kryzhan.ru © 2016",MessageType.None);
		  GUILayout.EndVertical();
		////////////////////////////////////
          GUI.color = Color.white; //Цвет интерфейса
		  GUI.backgroundColor = Color.green;		
		
	//////////САМОЕ ГЛАВНОЕ - СВЯЗЬ СКРИПТОВ,GRASS можно задать своё, tаrget - не менять////////////
        UsPg Grass = (UsPg)target;
   //////////////////////////////////
   
   ///// Интоефейс ОКНО С ТЕКСТУРАМИ///////////
   GUILayout.BeginVertical(m_Background1);
   GUILayout.BeginVertical("Box");
   
   
   GUILayout.BeginHorizontal("Box");
   GUILayout.BeginHorizontal(m_Background1);
   GUILayout.Label("                Grass Textures", EditorStyles.boldLabel);
   GUILayout.EndHorizontal();
   GUILayout.EndHorizontal();
   
   
   GUI.color = Color.gray;
   GUILayout.BeginVertical("Box");
   GUILayout.BeginVertical(Depthstyle);
   GUILayout.BeginHorizontal("Box");
   GUILayout.BeginHorizontal(Depthstyle);
		Grass.m_detail0 = (Texture2D) EditorGUILayout.ObjectField (Grass.m_detail0, typeof(Texture2D), true, GUILayout.Width (72), GUILayout.Height (72));
		Grass.m_detail1 = (Texture2D) EditorGUILayout.ObjectField (Grass.m_detail1, typeof(Texture2D), true, GUILayout.Width (72), GUILayout.Height (72));
		Grass.m_detail2 = (Texture2D) EditorGUILayout.ObjectField (Grass.m_detail2, typeof(Texture2D), true, GUILayout.Width (72), GUILayout.Height (72));
   GUILayout.EndHorizontal();
   GUILayout.EndVertical();
 
      GUILayout.BeginHorizontal("Box");
	  GUILayout.BeginHorizontal(Depthstyle);
		Grass.m_detail3 = (Texture2D) EditorGUILayout.ObjectField (Grass.m_detail3, typeof(Texture2D), true, GUILayout.Width (72), GUILayout.Height (72));
		Grass.m_detail4 = (Texture2D) EditorGUILayout.ObjectField (Grass.m_detail4, typeof(Texture2D), true, GUILayout.Width (72), GUILayout.Height (72));
		Grass.m_detail5 = (Texture2D) EditorGUILayout.ObjectField (Grass.m_detail5, typeof(Texture2D), true, GUILayout.Width (72), GUILayout.Height (72));
		GUILayout.EndHorizontal();
   GUILayout.EndHorizontal();
   GUILayout.EndVertical();
   GUILayout.EndVertical();
   GUILayout.EndVertical();
   GUILayout.EndVertical();
   
   GUI.backgroundColor = Color.white;
   GUI.color = Color.white;
   //////////////////////////////////
   //Grass.GeneralGrassTint = (Color) EditorGUILayout.ObjectField (Grass.GeneralGrassTint, typeof(Color), true, GUILayout.Width (72), GUILayout.Height (72));
         //////////////////////////////////
		//Grass.m_detail5 = (Texture2D) EditorGUILayout.ObjectField("Вид травы", Grass.m_detail5, typeof (Texture2D), false, null);
		///////////////////////////////////
		
		////////БЛОК СТИЛЯ ПАРАМЕТРОВ//////////
		GUILayout.BeginVertical(m_Background1);
		GUILayout.BeginVertical("Box");
		GUILayout.BeginHorizontal("Box");
		GUILayout.BeginHorizontal(m_Background1);
		GUILayout.Label("                Grass settings", EditorStyles.boldLabel);
		GUILayout.EndHorizontal();
		GUILayout.EndHorizontal();
		////////БЛОК СТИЛЯ ПАРАМЕТРОВ//////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical("Box");
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
		Grass.detailMode = (DetailRenderMode)EditorGUILayout.EnumPopup("",Grass.detailMode);
		EditorGUILayout.HelpBox("Grass render type. Render - 'Grass' best qulity, VertexLit - better speed.",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
        Grass.GeneralGrassTint = EditorGUILayout.ColorField("Grass tone", Grass.GeneralGrassTint);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
        ////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
        Grass.m_detailSeed = EditorGUILayout.IntField(" ", Grass.m_detailSeed);
		EditorGUILayout.HelpBox("Constanta variety - the number of unique value which will spawn the grass in different places in different ways.",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
		Grass.m_detailFrq = EditorGUILayout.FloatField(" ", Grass.m_detailFrq);
		EditorGUILayout.HelpBox("Grass Distribution - this parameter is responsible for the quality of the grass applied to the earth surface",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
		Grass.m_noiseSpread = EditorGUILayout.FloatField(" ", Grass.m_noiseSpread);
		EditorGUILayout.HelpBox("A variety of Grass - this option displays the variation in the height and width of the grass",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.m_detailObjectDistance = EditorGUILayout.IntField(" ", Grass.m_detailObjectDistance);
		EditorGUILayout.HelpBox("Range rendering grass on the map",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.m_minWidth = EditorGUILayout.FloatField(" ", Grass.m_minWidth);
		EditorGUILayout.HelpBox("The minimum width of the sprite grass",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.m_maxWidth = EditorGUILayout.FloatField(" ", Grass.m_maxWidth);
		EditorGUILayout.HelpBox("The maximum width of the sprite grass",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.m_minHeight = EditorGUILayout.FloatField(" ", Grass.m_minHeight);
		EditorGUILayout.HelpBox("The minimum height of the sprite grass",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.m_maxHeight = EditorGUILayout.FloatField(" ", Grass.m_maxHeight);
		EditorGUILayout.HelpBox("The maximum height of the sprite grass",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		EditorGUILayout.Space();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.m_waterHeight = EditorGUILayout.FloatField(" ", Grass.m_waterHeight);
		EditorGUILayout.HelpBox("The height of the water - indicating the height underneath the grass will not be rendered",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.m_cliffHeight = EditorGUILayout.FloatField(" ", Grass.m_cliffHeight);
		EditorGUILayout.HelpBox("The height of the snow cliff - over this height value grass no rendering",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.m_detailObjectDensity = EditorGUILayout.FloatField(" ", Grass.m_detailObjectDensity);
		EditorGUILayout.HelpBox("Density - Grass Density",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.Repiter = EditorGUILayout.IntField(" ", Grass.Repiter);
		EditorGUILayout.HelpBox("Repiter - value of Raytracers, must be = Resolution",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.Resolution = EditorGUILayout.FloatField(" ", Grass.Resolution);
		EditorGUILayout.HelpBox("Resolution - grid of raytracers , lower value = better quality . 60 = best perfomance",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		////////////////////////////
		GUILayout.BeginVertical(Depthstyle);
		GUILayout.BeginVertical(Depthstyle);
	    Grass.RAYTRASSA = EditorGUILayout.FloatField(" ", Grass.RAYTRASSA);
		EditorGUILayout.HelpBox("RAY Zone - Zone of no grass , if you use Resolution = 1 , RAY Zone must by = 1 , default value 150 ",MessageType.None);
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndHorizontal();
		
		GUILayout.EndVertical();
		GUILayout.EndVertical();
		
GUILayout.BeginVertical(m_Background1);		
EditorGUILayout.Space();
GUI.color = Color.cyan;
if(GUILayout.Button("Visit our website",EditorStyles.miniButtonMid))
{
Application.OpenURL("http://kryzhan.ru");
}
GUILayout.EndVertical();
//



    }
}