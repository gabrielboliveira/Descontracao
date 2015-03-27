using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ContadorPontos : MonoBehaviour {

    private int pontos = 0;
    private GlobalScript globalScript;


    public int Pontos
    {
        get { return pontos; }
        set { pontos = value; }
    }

	// Use this for initialization
	void Start () {

        this.globalScript = GameObject.Find("GlobalScript").GetComponent<GlobalScript>();

        this.SetaTexto(this.pontos.ToString());
	}

    public void Adicionar(int pontos)
    {
        this.pontos += pontos;
        this.globalScript.scoreAtual = this.pontos;
        this.SetaTexto(this.pontos.ToString());
    }

    private void SetaTexto(string text)
    {
        Text textComp = this.gameObject.GetComponent<Text>(); //get the text component in the gameobject you assigned
        textComp.text = text;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
