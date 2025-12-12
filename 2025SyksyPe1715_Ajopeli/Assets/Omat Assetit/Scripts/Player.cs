using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10f;
    public float turnSpeed = 50f; 

    //Audio
    public AudioClip engineSFX;

    private bool isMovingSoundPlaying = false;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.Phase != RacePhase.Racing)
        {
            //Pelaaja ei voi liikkua jos ei olla racing tilassa
            AudioManager.Instance.StopSFX();
            return;
        }

        float move = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        float turn = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        //Debug.Log(move);

        transform.Translate(Vector3.forward * move);
        transform.Rotate(Vector3.up * turn);

        if(move != 0 && !isMovingSoundPlaying)
        {
            AudioManager.Instance.PlaySFXLoop(engineSFX);
            isMovingSoundPlaying = true;
        }

        if(move == 0)
        {
            AudioManager.Instance.StopSFX();
            isMovingSoundPlaying = false;
        }


    }
}
