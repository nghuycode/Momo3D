using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Vector3 TargetPosition;
    public Material NormalMat;
    public Material[] TriggerMats = new Material[5];
    public ParticleSystem Particle;
    public void Respawn() 
    {
        this.gameObject.SetActive(true);
        TargetPosition = this.transform.position + new Vector3(0, 0, -40);
    }
    private void Awake() 
    {
        Respawn();
    }
    private void Update() 
    {
        Move();
    }
    public void Move()
    {
        if (this.gameObject.activeSelf)
        {
            float speed = BeatDetector.Instance.BPM / 10 * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, TargetPosition, speed);

            //Check go to target
            if (Mathf.Abs(this.transform.position.z - TargetPosition.z) < 1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void TouchByPlayer()
    {
        StartCoroutine(CRTouchByPlayer());
    }
    private IEnumerator CRTouchByPlayer() 
    {
        Particle.Play();
        this.transform.position -= new Vector3(0, 0.5f, 0);
        this.GetComponent<MeshRenderer>().material = TriggerMats[Random.Range(0, TriggerMats.Length)];
        yield return new WaitForSeconds(.2f);
        this.transform.position += new Vector3(0, 0.5f, 0);
        this.GetComponent<MeshRenderer>().material = NormalMat;
    }
}
