using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInfo : MonoBehaviour
{
    public Characters character;
    bool s = true;

    void Update()
    {
        if (s != character.aktiv)
        {
            s = character.aktiv;

            if (character.aktiv == false)
            {
                gameObject.transform.position += new Vector3(-2000.0f, 0.0f, 0.0f);
            }
            else
            {
                gameObject.transform.position += new Vector3(2000.0f, 0.0f, 0.0f);
            }
        }

    }

}
