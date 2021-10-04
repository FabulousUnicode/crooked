using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandyStatus : MonoBehaviour
{
    public static bool feld = true;
    public static bool feld_beine = false;
    public static bool huette = false;

    public static bool mary_weg = false;

    public static bool knast = false;

    public List<Characters> cara;
    public TextAsset inkFile_korn;

    void Start()
    {
        cara[0].aktiv = feld;
        cara[1].aktiv = feld_beine;
        cara[2].aktiv = huette;
    }

    public void beinedran()
    {
        feld = false;
        feld_beine = true;

        StartCoroutine(schwarz());

        cara[0].aktiv = feld;
        cara[1].aktiv = feld_beine;
    }

    IEnumerator schwarz()
    {
        GameObject.Find("Schwarzblende").transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1.0f);
        GameObject.Find("Schwarzblende").transform.position = new Vector3(3000, 0, 0);
    }

    public void korngesammelt()
    {
        feld_beine = false;
        huette = true;

        FindObjectOfType<Dialog>().StartDialogue(inkFile_korn, FindObjectOfType<CharacterInfo>().character);

        StartCoroutine(kg());
    }

    private IEnumerator kg()
    {
        yield return new WaitForSeconds(30.0f);

        StartCoroutine(schwarz());

        cara[1].aktiv = feld_beine;
        cara[2].aktiv = huette;
    }

    public void anzeige()
    {
        StartCoroutine(schwarz());
        GameObject.Find("randy_shack").SetActive(false);
    }

    public void selbstAnzeige()
    {
        knast = true;
    }

    public void maryweg()
    {
        mary_weg = true;
    }

    public void ausbruch()
    {
        knast = false;
        StartCoroutine(schwarz());
    }
}
