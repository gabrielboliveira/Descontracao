using UnityEngine;
using System.Collections;

public class ExplodeBala : MonoBehaviour {

    public GameObject explosao;
    public AudioClip shootSound;

    public float fator;

    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;
    
	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
        Invoke("Explodir", 5);
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Colisao"))
        {
            CancelInvoke();
            Explodir();
        }
    }

    void Explodir()
    {
        float vol = UnityEngine.Random.Range(volLowRange, volHighRange);

        source.PlayOneShot(shootSound, vol);

        Instantiate(explosao, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
