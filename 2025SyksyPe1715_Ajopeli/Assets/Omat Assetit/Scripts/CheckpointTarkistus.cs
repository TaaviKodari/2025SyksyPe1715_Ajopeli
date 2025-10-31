using UnityEngine;

public class CheckpointTarkistus : MonoBehaviour
{
    public int orderIndex = 0;

    private void OnTriggerEnter(Collider other)
    {
        PelaajanKierrostarkistus validator = other.GetComponent<PelaajanKierrostarkistus>();
        if(validator != null)
        {
            validator.MarkVisited(orderIndex);
            //Debug.Log($"Portti: {orderIndex} osui: {other.name}");
        }
    }
}
