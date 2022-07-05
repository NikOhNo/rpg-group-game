using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public float TalkSpeed = 0.05f;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    AudioClip currentVoice;

    public Animator animator;

    public Queue<string> sentences;


    bool sentenceComplete = false;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }

    private void Update()
    {
        if (sentenceComplete && Input.GetKeyDown(KeyCode.Z))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue (Dialogue dialogue)
    {
        // disable player
        GridMovement player = FindObjectOfType<GridMovement>();
        player.enabled = false;
        player.GetComponent<PlayerLooking>().enabled = false;

        animator.SetBool("IsOpen", true);

        nameText.text = dialogue.name;
        currentVoice = dialogue.voice;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    // Iterates through sentences and calls end dialogue which sets the interacting variable and animation components equal to false
    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    
    IEnumerator TypeSentence (string sentence)
    {
        sentenceComplete = false;
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;

            if(letter != ' ')
            {
                AudioSource.PlayClipAtPoint(currentVoice, Camera.main.transform.position);
            }

            yield return new WaitForSeconds(TalkSpeed);
        }
        sentenceComplete = true;
    }

    //sets interacting and animation booleans equal to false
    void EndDialogue()
    {
        // re-enable player
        GridMovement player = FindObjectOfType<GridMovement>();
        player.enabled = true;
        player.GetComponent<PlayerLooking>().enabled = true;

        animator.SetBool("IsOpen", false);
        StartCoroutine(DelaySetInteractingFalse(1f));
    }

    IEnumerator DelaySetInteractingFalse(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        FindObjectOfType<Interact>().SetInteractingFalse();
    }
}
