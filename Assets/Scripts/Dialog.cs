using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class Dialog : MonoBehaviour
{
    public GameObject m_Dialogue;
    public GameObject m_TextField;
    public GameObject m_Choice;
    public GameObject m_Banner;

    public GameObject m_Option;

    bool m_isTalking;
    bool m_isDeciding;

    Text m_Name;
    Text m_DialogText;
    Text m_Text;
    Text m_BannerText;

    Characters m_character;

    static Story m_story;

    List<string> m_tags;

    static Choice m_selectedChoice;


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
    }

    void AdvanceDialogue()
    {
        print("test2");

        m_isDeciding = false;

        string currentMessage = m_story.Continue();

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
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(1.5f);

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
            yield return new WaitForSeconds(0.08f);
        }
        yield return new WaitForSeconds(1.5f);

        m_TextField.SetActive(false);
        m_isTalking = false;
    }

    public bool talkingStatus()
    {
        return m_isTalking;
    }


}
