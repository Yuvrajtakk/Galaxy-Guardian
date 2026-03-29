using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
public class Dialouge : MonoBehaviour
{
    [SerializeField] string[] timelinesTextlines;
    [SerializeField] TMP_Text dialogueText;

    int currentLine = 0;
    public void NextDialogueLine()
    {
        currentLine++;
        dialogueText.text = timelinesTextlines[currentLine];
    }

}
