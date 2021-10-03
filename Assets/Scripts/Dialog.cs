using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;
using UnityEngine.AI;

public class Dialog : MonoBehaviour
{
    public GameObject m_Dialogue;
    public GameObject m_TextField;
    public GameObject m_Choice;
    public GameObject m_Banner;

    public GameObject m_Option;

    bool m_isTalking;
    bool m_isDeciding;

    public static bool dialog_aktive = false;

    Text m_Name;
    Text m_DialogText;
    Text m_Text;
    Text m_BannerText;

    Characters m_character;

    static Story m_story;

    List<string> m_tags;

    static Choice m_selectedChoice;

    public static bool kuchen = false;
    public static bool glas = false;


    void Start()
    {
        m_isTalking = false;
        m_isDeciding = false;

        m_Name = m_Dialogue.transform.GetChild(0).GetComponent<Text>();
        m_DialogText = m_Dialogue.transform.GetChild(1).GetComponent<Text>();
        m_Text = m_TextField.transform.GetChild(0).GetComponent<Text>();
        m_BannerText = m_Banner.transform.GetChild(0).GetComponent<Text>();

        m_tags = new List<string>();

        m_selectedChoice = null;

        m_Dialogue.SetActive(false);
        m_TextField.SetActive(false);
        m_Choice.SetActive(false);
        m_Banner.GetComponent<Animator>().SetBool("IsOpen", false);
    }


    public void StartDialogue(TextAsset inkFile, Characters character)
    {
        dialog_aktive = true;

        if (!m_isTalking)
        {
            m_Banner.GetComponent<Animator>().SetBool("IsOpen", false);
            m_TextField.SetActive(false);

            m_character = character;

            //Erstellen Storyobjekt aus Ink-File
            m_story = new Story(inkFile.text);

            //Auslesen und verarbeiten der Tags
            m_tags = m_story.globalTags;
            ParseGlobalTags();

            if (m_character.combine)
            {
                m_story.BindExternalFunction("Combine", (string remove) =>
                {
                    Combine(remove);
                });
            }


            m_story.BindExternalFunction("BeineAnbringen", (string remove) => {
                BeineAnbringen(remove);
            });

            m_story.BindExternalFunction("HuetteVerlassen", (string susp) => {
                HuetteVerlassen(susp);
            });
            m_story.BindExternalFunction("ZelleVerlassen", (string t) => {
                ZelleVerlassen(t);
            });
            m_story.BindExternalFunction("KuchenGeben", (string remove) => {
                KuchenGeben(remove);
            });
            m_story.BindExternalFunction("ItemBekommen", (string remove) => {
                ItemBekommen(remove);
            });
            m_story.BindExternalFunction("TakePicture", () => {
                TakePicture();
            });
            m_story.BindExternalFunction("BildAnschauen", () => {
                BildAnschauen();
            });
            m_story.BindExternalFunction("Jeffrey_weg", () => {
                Jeffrey_weg();
            });
            m_story.BindExternalFunction("Tipp_gegeben", () => {
                Tipp_gegeben();
            });
            m_story.BindExternalFunction("Start_boss", () => {
                Start_boss();
            });




            //Dialogue Feld zeigen
            m_Dialogue.SetActive(true);

            //Sprechstatus setzen und Dialogue beginnen
            m_isTalking = true;
            ContinueDialogue();
        }
    }

    void ParseGlobalTags()
    {
        if(m_tags == null)
        {
            return;
        }

        foreach (string t in m_tags)
        {
            t.Replace(" ", string.Empty);

            string prefix = t.Split(':')[0];
            string sufix = t.Split(':')[1];
            print(prefix + "," + sufix);

            switch (prefix)
            {
                case "Items":
                    GameObject player = GameObject.Find("Inventory");
                    for (int i = 0; i < sufix.Split(',').Length; i++)
                    {
                        string variable = sufix.Split(',')[i];
                        bool vorhanden = player.GetComponent<Inventory>().searchItem(variable);
                        m_story.variablesState[variable] = vorhanden;
                    }
                    break;
                case "Variable":
                    m_story.variablesState["glas"] = glas;
                    m_story.variablesState["kuchen"] = kuchen;
                    break;
                case "Variable2":
                    m_story.variablesState["tipp_Matt"] = Matthaeus.tipp_Matt;
                    m_story.variablesState["mary_weg"] = RandyStatus.mary_weg;
                    break;
                case "Variable3":
                    m_story.variablesState["insekten_besiegt"] = true;
                    break;
                case null:
                    break;
            }
        }
    }

    private void Combine(string remove)
    {
        GameObject.Find("Inventory").GetComponent<Inventory>().addItem(m_character.list[0]);

        GameObject player = GameObject.Find("Inventory");
        for (int i = 0; i < remove.Split(',').Length; i++)
        {
            string variable = remove.Split(',')[i];
            bool vorhanden = player.GetComponent<Inventory>().searchItem(variable);
            if (vorhanden)
            {
                Item item = ItemDatabaseInstance.getItemByName(variable);
                GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(item);
            }
        }

    }


    public void ContinueDialogue()
    {
        print("test1");

        if (m_story != null)
        {
            print("sda");
            if (!m_isDeciding)
            {
                if (m_story.canContinue)
                {
                    AdvanceDialogue();

                    if (m_story.currentChoices.Count != 0)
                    {
                        print("test6");
                        m_isDeciding = true;
                        //StartCoroutine(ShowChoices());
                    }
                    
                }
                else
                {
                    EndDialogue();
                }
            }
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        m_isTalking = false;
        m_Dialogue.SetActive(false);
        m_story = null;

        dialog_aktive = false;
    }

    void AdvanceDialogue()
    {
        print("test2");

        m_isDeciding = false;

        string currentMessage = m_story.Continue();

        if(currentMessage == "")                        //Ungetestet möglicherweise fehlerhaft.
        {
            EndDialogue();
            return;
        }

        ParseTags();

        StopAllCoroutines();

        StartCoroutine(TypeScentence(currentMessage));
    }

    IEnumerator TypeScentence(string sentence)
    {
        print(sentence);

        m_Dialogue.SetActive(true);

        m_DialogText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            m_DialogText.text += letter;
            yield return new WaitForSeconds(0.0f);   //0.065
        }
        yield return new WaitForSeconds(0f);         ///2.3

        m_Dialogue.SetActive(false);

        if(!m_isDeciding)
        {
            ContinueDialogue();
        }
        else
        {
            print("7");
            dec();
        }
        
    }


    void dec()
    {
        print("8");
        StopAllCoroutines();
        StartCoroutine(ShowChoices());
    }


    IEnumerator ShowChoices()
    {
        print("9");
        List <Choice> choices = m_story.currentChoices;

        for (int i = 0; i < choices.Count; i++)
        {
            GameObject temp = Instantiate(m_Option, m_Choice.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = choices[i].text;
            temp.AddComponent<Selectable>();
            temp.GetComponent<Selectable>().element = choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
        }

        m_Choice.SetActive(true);
        yield return new WaitUntil(() => { return m_selectedChoice != null; });

        AdvanceFromDecision();
    }

    void AdvanceFromDecision()
    {
        m_Choice.SetActive(false);
        m_isDeciding = false;

        for (int i = 0; i < m_Choice.transform.childCount; i++)
        {
            Destroy(m_Choice.transform.GetChild(i).gameObject);
        }

        m_selectedChoice = null;

        m_Dialogue.SetActive(true);

        ContinueDialogue();
    }


    void ParseTags()
    {

        m_tags = m_story.currentTags;


        if(m_tags == null)
        {
            return;
        }

        foreach (string t in m_tags)
        {
            t.Replace(" ", string.Empty);

            string prefix = t.Split(':')[0];
            string sufix = t.Split(':')[1];

            switch (prefix)
            {
                case "Sprecher":
                    m_Name.text = t.Split(':')[1];
                    break;
                case null:
                    break;
            }
        }
    }

    public static void SetDecision(object element)
    {
        m_selectedChoice = (Choice)element;
        m_story.ChooseChoiceIndex(m_selectedChoice.index);
    }

    public void showBannerText(string text)
    {
        if (!m_isTalking)
        {
            StopAllCoroutines();
            //m_isTalking = true;
            m_BannerText.text = text;

            m_Banner.GetComponent<Animator>().SetBool("IsOpen", true);

            StartCoroutine(wait());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(4.0f);
        m_Banner.GetComponent<Animator>().SetBool("IsOpen", false);
        m_isTalking = false;
    }

    public void showText(string text)
    {
        if (!m_isTalking)
        {
            StopAllCoroutines();
            //m_isTalking = true;
            m_TextField.SetActive(true);
            StartCoroutine(showTextFeld(text));
        }
    }

    public IEnumerator showTextFeld(string text)
    {
        m_Text.text = "";
        foreach (char letter in text.ToCharArray())
        {
            m_Text.text += letter;
            yield return new WaitForSeconds(0.065f);
        }
        yield return new WaitForSeconds(2.3f);

        m_TextField.SetActive(false);
        m_isTalking = false;
    }

    public bool talkingStatus()
    {
        return m_isTalking;
    }

    private void BeineAnbringen(string remove)
    {
        GameObject.Find("Inventory").GetComponent<Inventory>().addItem(m_character.list[0]);

        GameObject player = GameObject.Find("Inventory");
        for (int i = 0; i < remove.Split(',').Length; i++)
        {
            string variable = remove.Split(',')[i];
            bool vorhanden = player.GetComponent<Inventory>().searchItem(variable);
            if (vorhanden)
            {
                Item item = ItemDatabaseInstance.getItemByName(variable);
                GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(item);
            }
        }


        FindObjectOfType<RandyStatus>().beinedran();
    }

    private void HuetteVerlassen(string susp)
    {
        if (susp == "sonst")
        {
            FindObjectOfType<RandyStatus>().anzeige();
            GameObject.Find("key").transform.position += new Vector3(2000.0f, 0.0f, 0.0f);
        }
        else if (susp == "mary" && !RandyStatus.mary_weg)
        {
            if (Mary.recordet)
            {
                FindObjectOfType<RandyStatus>().anzeige();
                FindObjectOfType<RandyStatus>().maryweg();
                ScenenChange.remove += ("mary" + ",");
            }
            else
            {
                FindObjectOfType<RandyStatus>().anzeige();
            }

            GameObject.Find("key").transform.position += new Vector3(2000.0f, 0.0f, 0.0f);
        }
        else if (susp == "spieler")
        {
            GameObject.Find("PlayerPos").GetComponent<NavMeshAgent>().Warp(new Vector3(-500.0f, -420.0f, 0.0f));
            GameObject.Find("ZelleCollider").transform.position += new Vector3(-3000.0f, 0.0f, 0.0f);
            GameObject.Find("ShackCollider").transform.position += new Vector3(-3000.0f, 0.0f, 0.0f);
        }
    }


    private void ZelleVerlassen(string t)
    {
        if (t == "trueA")
        {
            GameObject.Find("PlayerPos").GetComponent<NavMeshAgent>().Warp(new Vector3(100.0f, -420.0f, 0.0f));
            GameObject.Find("ZelleCollider").transform.position += new Vector3(3000.0f, 0.0f, 0.0f);
            GameObject.Find("ShackCollider").transform.position += new Vector3(3000.0f, 0.0f, 0.0f);

            FindObjectOfType<prisonHandler>().closeGitter();
        }
        else
        {
            FindObjectOfType<prisonHandler>().closeGitter();
        }

        
    }

    private void KuchenGeben(string remove)
    {
        Item item = ItemDatabaseInstance.getItemByName(remove);
        GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(item);

        kuchen = true;
    }

    private void ItemBekommen(string itemadd)
    {
        Item item = ItemDatabaseInstance.getItemByName(itemadd);
        if(item.name == "mutterkorn")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(item);
            kuchen = false;
        }
        if(item.name == "jar")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(item);
            glas = true;
        }
    }

    private void BildAnschauen()
    {
        FindObjectOfType<FarmStartDialog>().bildzeigen(0);
    }
    private void Jeffrey_weg()
    {
        GameObject.Find("camera").transform.position = new Vector3(339.0f, 7.0f, 0.0f);
        GameObject.Find("key_barn").transform.position = new Vector3(51.0f, 127.0f, 0.0f); //muss geändert werden

        StartCoroutine(schwarz());
        GameObject.Find("jeffrey").SetActive(false);
    }

    IEnumerator schwarz()
    {
        GameObject.Find("Schwarzblende").transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(1.0f);
        GameObject.Find("Schwarzblende").transform.position = new Vector3(3000, 0, 0);
    }


    private void TakePicture()
    {
        FindObjectOfType<FarmStartDialog>().bildzeigen(6.0f);
    }


    private void Start_boss()
    {
        Matthaeus.boss_start();
        Destroy(GameObject.Find("matthew_dark"));
        StartCoroutine(schwarz());
    }

    private void Tipp_gegeben()
    {
        Matthaeus.tipp_Matt = true;
    }
}
