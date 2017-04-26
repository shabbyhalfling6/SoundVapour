using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVisualiser : MonoBehaviour {

    

    private int numberOfSamples = 1024;
    public float lightIntensity = 1.4f;
    public float range = 250.0f;
    public float rotateSpeed = 3.0f;

    public GameObject[] audioSpectrumObjects;
    public GameObject sphere;

    AudioSource currentSong;

    public FFTWindow fftWindow;

	// Use this for initialization
	void Start ()
    {
        audioSpectrumObjects = new GameObject[numberOfSamples];

        currentSong = Camera.main.GetComponent<AudioSource>();

        for(int i = 0; i < audioSpectrumObjects.Length; i++)
        {
            GameObject newSphere = Instantiate(sphere, new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range)), sphere.transform.rotation);
            audioSpectrumObjects[i] = newSphere;

            var mat = newSphere.GetComponent<Renderer>().material;
            mat.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        this.transform.Rotate(Vector3.right * Time.deltaTime * rotateSpeed);

        float[] spectrum = new float[numberOfSamples];
        currentSong.GetSpectrumData(spectrum, 0, fftWindow);

        for(int i = 0; i < audioSpectrumObjects.Length; i++)
        {
            var rend = audioSpectrumObjects[i].gameObject.GetComponent<Renderer>();
            var mat = rend.material;
            var col = mat.color;

            float h, s, v;
            Color.RGBToHSV(col, out h, out s, out v);

            v = spectrum[i] * lightIntensity;

            mat.color = Color.HSVToRGB(h, s, v);

        }
	}
}
