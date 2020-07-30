using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterChangerIM : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCharacter0;

    [SerializeField]
    GameObject prefabCharacter1;

    [SerializeField]
    GameObject prefabCharacter2;

    bool previousFrameChangeCharacterInput = false;

    GameObject currentCharacter;

    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = Instantiate<GameObject>(prefabCharacter0, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        //change character on left mouse button
        if (Input.GetAxis("ChangeCharacter") > 0)
        {
            if (!previousFrameChangeCharacterInput)
            {
                previousFrameChangeCharacterInput = true;
                Vector3 characterPosition = currentCharacter.transform.position;
                Destroy(currentCharacter);
                int randomNumber = Random.Range(0, 3);
                if (randomNumber == 0)
                {
                    currentCharacter = Instantiate<GameObject>(prefabCharacter0, characterPosition, Quaternion.identity);
                }
                else if (randomNumber == 1)
                {
                    currentCharacter = Instantiate<GameObject>(prefabCharacter1, characterPosition, Quaternion.identity);
                }
                else if (randomNumber == 2)
                {
                    currentCharacter = Instantiate<GameObject>(prefabCharacter2, characterPosition, Quaternion.identity);
                }
            }
        }
        else
        {
            //no change character input
            previousFrameChangeCharacterInput = false;
        }
    }
}
