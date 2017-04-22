using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeSpawnController : MonoBehaviour {

    public GameObject[] shapes = new GameObject[4];
    public Transform[] shapeSpawners = new Transform[4];

    private float squareSpawnTimer = 0.45f;
    private float circleSpawnTimer = 0.45f;
    private float triangleSpawnTimer = 0.45f;
    private float xSpawnTimer = 0.45f;

    public float squareSpawnThreshold = 0.17f;
    public float circleSpawnThreshold = 0.17f;
    public float triangleSpawnThreshold = 0.17f;
    public float xSpawnThreshold = 0.17f;

    private int square = 0;
    private int circle = 1;
    private int triangle = 2;
    private int x = 3;

    public int squareSpawnMin = 1;
    public int squareSpawnMax = 4;
    public int triangleSpawnMin = 3;
    public int triangleSpawnMax = 8;
    public int circleSpawnMin = 7;
    public int circleSpawnMax = 12;
    public int xSpawnMin = 11;
    public int xSpawnMax = 13;

    public float squareSpawnRate = 0.45f;
    public float circleSpawnRate = 0.45f;
    public float triangleSpawnRate = 0.45f;
    public float xSpawnRate = 0.45f;

    public AudioSource sampleTrack;

    float[] spectrum = new float[512];
    float[] spawnTimers;

    void Start()
    {
        spawnTimers = new float[4] { squareSpawnTimer, circleSpawnTimer, triangleSpawnTimer, xSpawnTimer };
    }

    void Update ()
    {
        for(int i = 0; i < spawnTimers.Length; i++)
        {
            spawnTimers[i] -= Time.deltaTime;
        }

        //populate the spectrum array with the window date from current audio source
        sampleTrack.GetSpectrumData(spectrum, 0, FFTWindow.Rectangular);


        //Call the spawn shape function for each shape
        SpawnShapes(square, squareSpawnRate, squareSpawnMin, squareSpawnMax, squareSpawnThreshold);
        SpawnShapes(circle, circleSpawnRate, circleSpawnMin, circleSpawnMax, circleSpawnThreshold);
        SpawnShapes(triangle, triangleSpawnRate, triangleSpawnMin, triangleSpawnMax, triangleSpawnThreshold);
        SpawnShapes(x, xSpawnRate, xSpawnMin, xSpawnMax, xSpawnThreshold);
    }

    void SpawnShapes(int shapeType, float spawnRate, int shapeSpawnMin, int shapeSpawnMax, float spawnThreshold)
    {
        //checks if the type of shape is ready to spawn yet
        if (spawnTimers[shapeType] <= 0)
        {
            //loop through the audio source data in the array between the min and max the shape spawns for
            for (int i = shapeSpawnMin; i < shapeSpawnMax; i++)
            {
                //checks if the audio has peaked above a certain level
                if (spectrum[i] >= spawnThreshold)
                {
                    //spawns the shape type
                    Instantiate(shapes[shapeType], shapeSpawners[shapeType].position, shapeSpawners[shapeType].rotation);
                    //set this shape types spawn timer back
                    spawnTimers[shapeType] = spawnRate;
                    //break the loop
                    break;
                }
            }
        }
    }
}
