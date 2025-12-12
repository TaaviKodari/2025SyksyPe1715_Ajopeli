using UnityEngine;
using TMPro;
public class Tuomari : MonoBehaviour
{
    public TMP_Text resultText;
    public TMP_Text lapCountText;
    public int kierrostenMara = 3;

    private bool winnerDeclared = false;

    private void Start()
    {
        resultText.text = "";
        lapCountText.text = $"LAP:0 / {kierrostenMara}";
    }

    private void OnTriggerEnter(Collider car)
    {
        CarIdentify id = car.GetComponent<CarIdentify>();
        string winnerName = id.displayName;

        LapCounter lap = car.GetComponent<LapCounter>();

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

            validator.ResetLap();
            int temp = lap.lapsCompleted;
            lapCountText.text = $"Lap: {temp++}/{kierrostenMara}";
        }
        lap.lapsCompleted++;

        if (!winnerDeclared && lap.lapsCompleted >= kierrostenMara) 
        {
            //Debug.Log($"WINNER:{winnerName}");
            resultText.text = $"WINNER: {winnerName}";
            GameManager.Instance.Phase = RacePhase.Finished;
            winnerDeclared = true;
        }

    }
}
