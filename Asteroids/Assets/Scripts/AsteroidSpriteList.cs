using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditor;
using UnityEngine;

public static class AsteroidSpriteList
{
    static List<Sprite> asteroidSpriteList;
    static int asteroidListSize;

    public static List<Sprite> AsteroidSprites
    {
        get
        {
            return asteroidSpriteList;
        }
    }

    public static int AsteroidListSize
    {
        get
        {
            if (asteroidListSize > 0)
            {
                return asteroidListSize;
            }
            else
            {
                return -1;
            }
        }
    }
    public static void Initialize()
    {
        //load everything in meteors folder
        object[] loadedSprites = Resources.LoadAll("Meteors", typeof(Sprite));
        
        //initialize and put it in the shared static list
        asteroidSpriteList = new List<Sprite>(loadedSprites.Length);
        for (int i=0; i<loadedSprites.Length; i++)
        {
            asteroidSpriteList.Add((Sprite)loadedSprites[i]);
        }

        asteroidListSize = asteroidSpriteList.Count;
    }
}
