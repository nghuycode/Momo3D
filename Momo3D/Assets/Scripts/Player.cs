using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int PlatformID;
    public Vector3 NextPlatformPosition, OriginalPosition;
    public float DistanceToNextPlatform, TimeCounter;

    public bool IsDrag;
    private void Start() 
    {
        Init();
    }
    private void Init()
    {
        IsDrag = false;
        PlatformID = 0;
        DistanceToNextPlatform = Vector3.Distance(this.transform.position, PlatformSpawner.Instance.PlatformList[PlatformID].transform.position);
        TimeCounter = 0;
        OriginalPosition = this.transform.position;
    }
    private void Update() 
    {
        PlayerMove();
    }
    private void PlayerMove() 
    {   
        //PlayerMoveByBeat
        TimeCounter += Time.deltaTime;
        float velocity = BeatDetector.Instance.BPM / 10;
        float tmp = DistanceToNextPlatform * Mathf.Sin(Mathf.PI * velocity * TimeCounter / DistanceToNextPlatform);
        Vector3 newPos = OriginalPosition;
        newPos.y += tmp;

        //PlayerMoveByUser
        if (Input.GetMouseButtonDown(0))
        {
            IsDrag = true;
        }
        if (IsDrag)
        {
            Vector3 mousePosition = GetWorldPositionOnPlane(Input.mousePosition, this.transform.position.z);
            Debug.Log(mousePosition);
            newPos.x = mousePosition.x;
        }
        if (Input.GetMouseButtonUp(0))
        {
            IsDrag = false;
        }
        this.transform.position = newPos;
    }
    public Vector3 GetWorldPositionOnPlane(Vector3 screenPosition, float z) 
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPosition);
        Plane xy = new Plane(Vector3.forward, new Vector3(0, 0, z));
        float distance;
        xy.Raycast(ray, out distance);
        return ray.GetPoint(distance);
    }
    private void OnCollisionEnter(Collision other) 
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            PlatformID++;
            DistanceToNextPlatform = Vector3.Distance(this.transform.position, PlatformSpawner.Instance.PlatformList[PlatformID].transform.position);
            TimeCounter = 0;
        }
    }
}
