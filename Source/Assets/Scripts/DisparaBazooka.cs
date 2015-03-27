using UnityEngine;
using System.Collections;
using System;

public class DisparaBazooka : MonoBehaviour {

    public GameObject balaBazooka;
    public float fatorTiro;
    public float tempoEspera;
    public AudioClip shootSound;

    private bool atirou = false;
    private AudioSource source;
    private float volLowRange = 0.2f;
    private float volHighRange = 0.5f;

    private GlobalScript globalScript;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        this.globalScript = GameObject.Find("GlobalScript").GetComponent<GlobalScript>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !atirou && this.globalScript.playerMove)
        {
            Atirar();
        }
	}

    void Atirar()
    {
        this.atirou = true;

        float vol = UnityEngine.Random.Range(volLowRange, volHighRange);

        source.PlayOneShot(shootSound, vol);

        GameObject novaBomba = Instantiate(balaBazooka, transform.position, transform.rotation * balaBazooka.transform.rotation) as GameObject;
        novaBomba.transform.parent = transform;
        novaBomba.rigidbody.AddForce(transform.forward * fatorTiro, ForceMode.Impulse);
        
        Invoke("Libera",this.tempoEspera);
    }

    void Libera()
    {
        this.atirou = false;
    }

}
