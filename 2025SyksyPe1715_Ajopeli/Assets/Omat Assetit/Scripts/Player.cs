using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f; 

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Phase != RacePhase.Racing)
        {
            //Pelaaja ei voi liikkua jos ei olla racing tilassa
            return;
        }

        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        //Debug.Log(move);

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);
    }
}
