using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    [SerializeField]
    Text HPText;

    int hp;
    const string HPPrefix = "HP: ";
    // Start is called before the first frame update
    void Start()
    {

       // HPText.text = HPPrefix + hp.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setHP(int hp)
    {
        this.hp = hp;
        HPText.text = HPPrefix + hp.ToString();
    }
}
