using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("Destruir", 5);
	}

    void Destruir()
    {
        Destroy(gameObject);
    }
}
