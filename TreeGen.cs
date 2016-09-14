using UnityEngine;
using System.Collections;
//[ExecuteInEditMode]
public class TreeGen : MonoBehaviour 
{
	public int Count;
	public int RandomX;
	public int RandomZ;
	public Transform pref;
//	private float LifeTime = 2;
//    private float RespawnTime = 0;
	void Start () 
	{
		for(int i=0; i<Count; i++)
		{
			Instantiate(pref,transform.position+new Vector3(Random.Range(-RandomX,RandomX),0,Random.Range(-RandomZ,RandomZ)), transform.rotation);
		}
		
	}
	
/*void Update ()
{
RespawnTime += Time.deltaTime; //RespawnTime увеличивается с каждым кадром после создания объекта
if(RespawnTime>LifeTime) // если RespawnTime больше LifeTime
{
Dead();//вызываем функцию dead
}
}
void Dead() // функция dead
{
Destroy(gameObject); //удаляем объект на котором висит скрипт
}
*/
}
