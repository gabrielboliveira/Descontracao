using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class MainMenu : MonoBehaviour {

    public AudioClip clickSound;

    private AudioSource source;

    private int status = -1;
    private int totalStatus = 3;

    private int mapaEscolhido = -1;

    private int tipoSkybox = -1;

    private int pontos = 0;

    private GlobalScript globalScript;

	// Use this for initialization
	void Start () {
        this.Iniciar();

        print("Start está ok!");

        Screen.showCursor = true;

        this.globalScript = GameObject.Find("GlobalScript").GetComponent<GlobalScript>();

        AudioSource globalAS = this.globalScript.gameObject.GetComponent<AudioSource>();
        globalAS.Stop();
        globalAS.volume = 1F;
        globalAS.Play();

        this.status = -1;

        source = GetComponent<AudioSource>();

        this.ChangeStatus();

        Invoke("MudaStatus", 5F);
	}

    public void Iniciar()
    {
        
    }

    void MudaStatus()
    {
        print("MudaStatus está ok! " + this.status.ToString());
        this.GoToStatus(this.status + 1);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKeyDown && this.status == 0)
        {
            this.GoToStatus(1);
        }
	}

    private void ChangeStatus()
    {
        for (int i = 1; i <= (this.totalStatus + 1); i++)
        {
            gameObject.transform.GetChild(i).gameObject.SetActive((this.status + 1) == i);
        }

        //Text status = GameObject.Find("Teste").GetComponent<Text>();
        //status.text = "Mapa escolhido = " + this.mapaEscolhido.ToString();
    }

    public void GoToStatus(int stat)
    {
        source.PlayOneShot(this.clickSound, 1F);
        this.status = stat;
        this.ChangeStatus();
    }

    public void EscolherMapa(int mapa)
    {
        
        this.mapaEscolhido = mapa;

        this.GoToStatus(2);
    }

    public void EscolherTipoSkybox(int tipo)
    {
        this.tipoSkybox = tipo;
        this.CarregarCena();
    }

    public void CarregarCena()
    {
        // Temporário
        this.GoToStatus(3);

        InvokeRepeating("MostraPontos", 0F, 0.5F);

        this.globalScript.mapaEscolhido = this.mapaEscolhido;
        this.globalScript.tipoDiaEscolhido = this.tipoSkybox;

        Application.LoadLevel("Mapa" + this.mapaEscolhido.ToString());
    }

    void MostraPontos()
    {
        
        string t = Environment.NewLine;
        
        // Gambiarra alert
        Text texto = gameObject.transform.GetChild(4).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).GetComponent<Text>();
        // End Gambiarra

        for (int i = 0; i < pontos; i++)
        {
            t += ".";
        }
        texto.text = t;
        
        this.pontos++;
        
        if (this.pontos > 10) this.pontos = 0;

        
    }
}
