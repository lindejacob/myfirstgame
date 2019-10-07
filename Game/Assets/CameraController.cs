using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject Player;
    // Start is called before the first frame update
    public void Start()
    {  
    }

    // Update is called once per frame
    public void Update()
    {
		transform.LookAt(Player.transform);
    }
}
