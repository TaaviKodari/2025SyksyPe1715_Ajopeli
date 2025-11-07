using UnityEngine;

public class Tuomari : MonoBehaviour
{
    private bool winnerDeclared = false;

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
            Debug.Log($"WINNER:{winnerName}");
            winnerDeclared = true;
        }

    }
}
