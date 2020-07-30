using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
{
    GameObject[] prefabCharacters = new GameObject[3];

    GameObject currentCharacter;
    bool previousFrameChange = false;
    // Start is called before the first frame update
    void Start()
    {
        prefabCharacters[0] = (GameObject)Resources.Load(@"Prefabs\Character0");
        prefabCharacters[1] = (GameObject)Resources.Load(@"Prefabs\Character1");
        prefabCharacters[2] = (GameObject)Resources.Load(@"Prefabs\Character2");

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
