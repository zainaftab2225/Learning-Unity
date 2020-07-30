using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacterByList : MonoBehaviour
{
    List<GameObject> prefabCharacters = new List<GameObject>();


    GameObject currentCharacter;
    bool previousFrameChange = false;
    // Start is called before the first frame update
    void Start()
    {
        prefabCharacters.Add((GameObject)Resources.Load(@"Prefabs\Character0"));
        prefabCharacters.Add((GameObject)Resources.Load(@"Prefabs\Character1"));
        prefabCharacters.Add((GameObject)Resources.Load(@"Prefabs\Character2"));
        currentCharacter = Instantiate<GameObject>(prefabCharacters[0], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeCharacterOnInput();
    }

    void ChangeCharacterOnInput()
    {
        int prefabRandomer = Random.Range(0, 3);
        Vector3 characterPosition = currentCharacter.transform.position;

        if (Input.GetAxis("ChangeCharacter") > 0)
        {
            if (!previousFrameChange)
            {
                Destroy(currentCharacter);
                currentCharacter = Instantiate<GameObject>(prefabCharacters[prefabRandomer], characterPosition, Quaternion.identity);
                previousFrameChange = true;
            }
        }
        else
        {
            previousFrameChange = false;
        }
    }
}
