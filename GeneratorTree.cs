using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class GeneratorTree : MonoBehaviour {
public Transform IObject;
private int LayerGround;
private bool CastRays = true;
void Start () {
LayerGround = LayerMask.NameToLayer("Terrain");
}
void Update () {
if (CastRays) {
Ray ray = new Ray(transform.position, -transform.up);
RaycastHit Hit;
// Raycast
if(Physics.Raycast(ray,out Hit,1000)) {
if (Hit.transform.gameObject.layer == LayerGround) {
// Debug.Log(«Terain»);
// Make a path
Transform cloneObject = Instantiate(IObject, Hit.point, new Quaternion(0, Random.Range(0,360),0,Random.Range (0,360))) as Transform;
cloneObject.parent = Hit.transform;
}
}
}
}
}