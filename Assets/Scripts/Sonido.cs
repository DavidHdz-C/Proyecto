using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Sonido : MonoBehaviour {
    public AudioSource fuente;
    public AudioClip clip;

    // Use this for initialization
    void Start () {
        fuente.clip = clip;
		
	}
	public void Reproducir()
    {
        fuente.Play();

    }
}
