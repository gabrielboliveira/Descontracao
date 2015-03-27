using UnityEngine;
using System.Collections;

public class PlayerInteraction : MonoBehaviour {

    public AudioClip walkSound;
    public AudioClip jumpSound;

    private AudioSource source;
    private float volLowRange = 0.5f;
    private float volHighRange = 1.0f;
    private bool walk = false;

    private CharacterController controller;

    private GlobalScript globalScript;

	// Use this for initialization
	void Start () {

        Screen.showCursor = false;

        this.globalScript = GameObject.Find("GlobalScript").GetComponent<GlobalScript>();

        this.source = GetComponent<AudioSource>();
        this.controller = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
        if (controller.isGrounded && this.globalScript.playerMove)
        {
            if(Input.GetButtonDown("Jump"))
            {
                float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
                source.PlayOneShot(jumpSound, vol);
            }
            if ( (Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && !this.walk)
            {
                float vol = UnityEngine.Random.Range(volLowRange, volHighRange);
                this.walk = true;
                source.PlayOneShot(walkSound, vol);
                Invoke("Libera", 0.5F);
            }
        }
	}

    void Libera()
    {
        this.walk = false;
    }
}
