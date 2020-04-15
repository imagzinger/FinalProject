using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public enum DrawMode { NoiseMap, ColorMap}
    [SerializeField] DrawMode drawMode = DrawMode.ColorMap;

    [SerializeField] int mapWidth;
    [SerializeField] int mapLength;
    [SerializeField] float noiseScale;

    public bool autoUpdate;

    [SerializeField] int octaves = 4;
    [SerializeField] float persistence = .5f;
    [SerializeField] float lacunarity = 2f;
    [SerializeField] int seed = 1;
    [SerializeField] Vector2 offset;

    [SerializeField] TerrainType[] regions;


    void Start()
    {
        GenerateMap();
    }

    public void GenerateMap()
    {
        float[,] noiseMap = NoiseMap.GenerateNoiseMap(mapWidth, mapLength, noiseScale, seed, octaves, persistence, lacunarity, offset);

        Color[] colorMap = ComputeColorMap(noiseMap);


        MapDisplay display = FindObjectOfType<MapDisplay>();
        if (drawMode == DrawMode.NoiseMap)
            display.DrawTexture(TextureGenerator.GetTextureFromHeightMap(noiseMap));
        else if(drawMode == DrawMode.ColorMap)    
            display.DrawTexture(TextureGenerator.GetTextureFromColorMap(colorMap, mapWidth,mapLength));


        //display.DrawTexture(TextureGenerator.GetTextureFromHeightMap(noiseMap));
    }

    Color[] ComputeColorMap(float[,] noiseMap)
    {
		Color[]  colorMap = new Color[mapWidth* mapLength];
        for (int z = 0; z < mapLength; z++)
        {
			for (int x = 0; x < mapWidth; x++)
			{
                bool found = false;
                int i = 0;
				while (!found && i < regions.Length )
				{
					if (noiseMap[x,z] <= regions[i].height)
					{
                        colorMap[z * mapWidth + x] = regions[i].color;
                        found  = true;
					}
                    i++;
				}
			}
        }
        return colorMap;
    }
}



[System.Serializable]

public struct TerrainType 
{
    public string name;
    public float height;
    public Color color;
}
