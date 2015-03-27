using UnityEngine;
using System.Collections;

public class Colisao : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        print(col.gameObject.name);
        print("I'm here");
    }
}
