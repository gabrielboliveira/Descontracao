using UnityEngine;
using System.Collections;

public class ColisaoCarro : MonoBehaviour {

    //public float Vida;

    public GameObject explosion;
    public int totalPontos;
    public AudioClip shootSound;
    public int maxDestruicao;

    private int nivelDestruicao = 0;
    private AudioSource source;

	// Use this for initialization
	void Start () {
        source = GetComponent<AudioSource>();
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag.Equals("Bala"))
        {
            //if (this.Vida > 0)
            //    this.Vida -= col.gameObject.GetComponent<ExplodeBala>().fator;
            //GameObject carroInteiro;
            if (this.nivelDestruicao < (this.maxDestruicao - 1))
            {
                ContadorPontos pontos = GameObject.Find("Pontos").GetComponent<ContadorPontos>();
                pontos.Adicionar(this.totalPontos);

                //float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(shootSound, 1F);

                Instantiate(explosion, transform.position, transform.rotation);
                gameObject.transform.GetChild(this.nivelDestruicao++).gameObject.SetActive(false);
                //gameObject.transform.GetChild(this.nivelDestruicao++).GetComponent<FadeObjectInOut>().FadeOut();
                gameObject.transform.GetChild(this.nivelDestruicao).gameObject.SetActive(true);
                //gameObject.transform.GetChild(this.nivelDestruicao).GetComponent<FadeObjectInOut>().FadeIn();


            }
            //print("Acertou! vida=" + this.Vida.ToString());
        }
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
