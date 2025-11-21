using UnityEngine;
using System.Collections;
using TMPro;
public class Countdown : MonoBehaviour
{
    public TMP_Text uiText;
    public int countdownFrom = 3;
    public float stepSeconds = 1f;

    IEnumerator Start()
    {
        //Debug.Log("Laskenta aloitettu");

        for(int i = countdownFrom; i > 0; i--)
        {
            uiText.text = i.ToString();
            yield return new WaitForSeconds(stepSeconds);
        }

        //Debug.Log("Laskenta lopetettu");

        uiText.text = "GO!";

        yield return new WaitForSeconds(0.5f);

        uiText.text = "";
        uiText.gameObject.SetActive(false);
        
        GameManager.Instance.Phase = RacePhase.Racing;
    }
    
}
