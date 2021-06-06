using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class Dialogue : MonoBehaviour
{
    public GameObject m_dialogueBox;
    public GameObject m_optionsBox;
    public GameObject m_optionButtons;

    bool m_isTalking;
    bool m_isDeciding;

    Text m_name;
    Text m_message;

    static Story m_story;

    List<string> m_tags;

    static Choice m_selectedChoice;

    void Start()
    {
        m_isTalking = false;
        m_isDeciding = false;

        m_name = m_dialogueBox.transform.GetChild(0).GetComponent<Text>();
        m_message = m_dialogueBox.transform.GetChild(1).GetComponent<Text>();

        m_tags = new List<string>();

        m_selectedChoice = null;

    }

    public void StartDialogue(TextAsset inkFile)
    {
        if(!m_isTalking)
        {
            //Erstellen Storyobjekt aus Ink-File
            m_story = new Story(inkFile.text);

            //Auslesen und verarbeiten globaler Tags
            m_tags = m_story.globalTags;
            ParseGlobalTags();

            //Dialogue Feld zeigen
            m_dialogueBox.SetActive(true);

            //Sprechstatus setzen und Dialogue beginnen
            m_isTalking = true;
            ContinueDialogue();
        }
        
    }

    void ParseGlobalTags()
    {
        foreach(string t in m_tags)
        {
            t.Replace(" ", string.Empty);

            string prefix = t.Split(':')[0];
            string sufix = t.Split(':')[1];
            print(prefix + "," + sufix);

            switch(prefix)
            {
                case "Items":
                    GameObject player = GameObject.Find("Inventory");
                    for(int i = 0; i < sufix.Split(',').Length; i++)
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

    public void ContinueDialogue()
    {
        if(m_story != null)
        {
            if(!m_isDeciding)
            {
                if (m_story.canContinue)
                {
                    AdvanceDialogue();

                    if (m_story.currentChoices.Count != 0)
                    {
                        m_isDeciding = true;
                        StartCoroutine(ShowChoices());
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
        m_dialogueBox.SetActive(false);
        m_story = null;
    }

    void ParseTags()
    {
        m_tags = m_story.currentTags;

        foreach (string t in m_tags)
        {
            t.Replace(" ", string.Empty);

            string prefix = t.Split(':')[0];
            string sufix = t.Split(':')[1];
            
            switch(prefix)
            {
                case "Sprecher":
                    m_name.text = t.Split(':')[1];
                    break;
                case null:
                    break;
            }
        }
    }

    void AdvanceDialogue()
    {
        m_isDeciding = false;

        string currentMessage = m_story.Continue();

        ParseTags();

        StopAllCoroutines();

        StartCoroutine(TypeScentence(currentMessage));
    }

    IEnumerator TypeScentence(string sentence)
    {
        m_message.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            m_message.text += letter;
            yield return null;
        }
    }

    IEnumerator ShowChoices()
    {
        List<Choice> choices = m_story.currentChoices;

        for(int i = 0; i < choices.Count; i++)
        {
            GameObject temp = Instantiate(m_optionButtons, m_optionsBox.transform);
            temp.transform.GetChild(0).GetComponent<Text>().text = choices[i].text;
            temp.AddComponent<Selectable>();
            temp.GetComponent<Selectable>().element = choices[i];
            temp.GetComponent<Button>().onClick.AddListener(() => { temp.GetComponent<Selectable>().Decide(); });
        }

        m_optionsBox.SetActive(true);
        yield return new WaitUntil(() => { return m_selectedChoice != null; });

        AdvanceFromDecision();
    }

    public static void SetDecision(object element)
    {
        m_selectedChoice = (Choice)element;
        m_story.ChooseChoiceIndex(m_selectedChoice.index);
    }

    void AdvanceFromDecision()
    {
        m_optionsBox.SetActive(false);

        for (int i = 0; i < m_optionsBox.transform.childCount; i++)
        {
            Destroy(m_optionsBox.transform.GetChild(i).gameObject);
        }

        m_selectedChoice = null;
        AdvanceDialogue();
    }
}
