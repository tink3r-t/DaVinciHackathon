using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeHandler : MonoBehaviour
{
    public TextAsset textData;

    public const short Choices = 3;
    public int languageInt;

    [SerializeField]
    public List<Character> characters;
    public List<Character> witches;

    public EventSystem eS;

    string[] clines;
    int index = 0;


    // Start is called before the first frame update
    void Start()
    {
        string fileData = textData.text;
        clines  = fileData.Split('\n');
        index++;
        languageInt = Preferences.LanguageInt;
    }

    private void OnMouseDown()
    {
        InventorySystem.Instance.interactionEnabled = false;
        NextDialouge(0);
        this.GetComponent<BoxCollider2D>().enabled = false;
    }


    private void OnMouseEnter()
    {
        Pointer.Instance.ChangeState(CursorState.Talk);
    }

    private void OnMouseExit()
    {
        Pointer.Instance.ChangeState(CursorState.Idle);
    }


    void NextDialouge(int choice = 0) {
        if (index >= clines.Length)
        {
            Debug.LogError("Dialouge Manager ! Reached end of file.");
            return;
        }

        var tokens = clines[index].Split('\t');

        if (tokens[0] == "Event") {
            index++;
            eS.HandleEvent(() => { NextDialouge(choice); }, tokens[1][0], tokens[2], tokens[3]);        
            return;
        } 

        if (tokens[0].Contains("you (choose)"))
        {
            CommunicationSystem.Instance.AskUser(tokens[languageInt + 0], tokens[languageInt + 1], tokens[languageInt + 2], NextDialouge);
            index++;
            return;
        }
        if (tokens[0].Contains("internal")) {
            CommunicationSystem.Instance.InternalMonolouge("(internal monologue)", tokens[languageInt + 1], () => { NextDialouge(choice); });
            index++;
            return;
        }
        else {
            foreach (Character c in characters) {
                if (c.name.Equals(tokens[0]))
                {
                    index++;
                    if (tokens[languageInt + choice].Length != 0)
                        c.Talk(tokens[languageInt + choice] + "   ", () => { NextDialouge(choice); });
                    else
                        NextDialouge(choice);
                    return;
                }

            }

        }

    }


}
