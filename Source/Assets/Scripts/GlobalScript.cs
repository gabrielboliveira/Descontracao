using UnityEngine;
using System.Collections;
using System;

public class GlobalScript : MonoBehaviour {

    // Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int mapaEscolhido = -1;

    public int tipoDiaEscolhido = -1;

    public bool playerMove = false;

    public int scoreAtual = 0;

    void OnLevelWasLoaded(int level)
    {
        print("Level was loaded: " + level.ToString());
        AudioSource globalAS = gameObject.GetComponent<AudioSource>();
        globalAS.Stop();
        if (level == 0)
        {
            GameObject.Find("Fundo Preto").GetComponent<MainMenu>().Iniciar();
            this.playerMove = false;
        }
        else
        {
            globalAS.volume = 0.2F;
            this.playerMove = true;
            ContadorTempo tempo = GameObject.Find("Tempo").GetComponent<ContadorTempo>();
            tempo.SetEndTime(1F);
        }   
        globalAS.Play();
    }
}