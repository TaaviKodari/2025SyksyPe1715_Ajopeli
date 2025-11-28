using UnityEngine;
using TMPro;
public class Tuomari : MonoBehaviour
{
    public TMP_Text resultText;
    private bool winnerDeclared = false;

    private void Start()
    {
        resultText.text = "";
    }

    private void OnTriggerEnter(Collider car)
    {
        CarIdentify id = car.GetComponent<CarIdentify>();
        string winnerName = id.displayName;


        if (id.kind == CarKind.Player)
        {
            PelaajanKierrostarkistus validator = car.GetComponent<PelaajanKierrostarkistus>();
            if (validator == null)
            {
                Debug.LogError("Missing PelaajanKierrostarkistus script");
                return;
            }

            if (!validator.AllVisitedThisLap)
            {
                Debug.Log("Pelaaja ylitti maalin, mutta kaikki checkpointti eivät ole kunnossa -> Ei voittoa");
                return;
            }

        }

        if (!winnerDeclared)
        {
            //Debug.Log($"WINNER:{winnerName}");
            resultText.text = $"WINNER: {winnerName}";
            GameManager.Instance.Phase = RacePhase.Finished;
            winnerDeclared = true;
        }

    }
}
