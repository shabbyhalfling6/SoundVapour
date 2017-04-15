using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawnController : MonoBehaviour {

    public GameObject[] shapes = new GameObject[4];
    public Transform[] shapeSpawners = new Transform[4];

    private float spawnTimer = 0.0f;
    public float spawnThreshold = 0.17f;

    public float squareSpawnMax = 4;
    public float triangleSpawnMax = 8;
    public float circleSpawnMax = 12;

    public float spawnRate = 0.45f;

    public AudioSource sampleTrack;

    void Update ()
    {
        spawnTimer -= Time.deltaTime;

        float[] spectrum = new float[512];

        sampleTrack.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);

        if (spawnTimer <= 0)
        {

            for (int i = 1; i < spectrum.Length - 1; i++)
            {
                if (spectrum[i] >= spawnThreshold)
                {
                    if (i <= squareSpawnMax)
                    {
                        Instantiate(shapes[0], shapeSpawners[0].position, shapeSpawners[0].rotation);
                        spawnTimer = spawnRate;
                        break;
                    }
                    else if (i <= triangleSpawnMax)
                    {
                        Instantiate(shapes[1], shapeSpawners[1].position, shapeSpawners[1].rotation);
                        spawnTimer = spawnRate;
                        break;
                    }
                    else if (i <= circleSpawnMax)
                    {
                        Instantiate(shapes[2], shapeSpawners[2].position, shapeSpawners[2].rotation);
                        spawnTimer = spawnRate;
                        break;

                    }
                    else
                    {
                        Instantiate(shapes[3], shapeSpawners[3].position, shapeSpawners[3].rotation);
                        spawnTimer = spawnRate;
                        break;
                    }
                }
            }

        }
	}
}
