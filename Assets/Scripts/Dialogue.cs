using UnityEngine;
using TMPro;

public class Dialouge : MonoBehaviour
{
    [SerializeField] string[] timelinesTextlines;
    [SerializeField] TMP_Text dialogueText;

    int currentLine = 0;
    public void NextDialogueLine()
    {
        if (timelinesTextlines == null || dialogueText == null) return;
        if (currentLine >= timelinesTextlines.Length) return;
        dialogueText.text = timelinesTextlines[currentLine];
        currentLine++;
    }

}
