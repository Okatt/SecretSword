using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;
    
	void Update ()
	{
	    transform.position = new Vector3(Target.position.x, Target.transform.position.y, transform.position.z);
	}
}
