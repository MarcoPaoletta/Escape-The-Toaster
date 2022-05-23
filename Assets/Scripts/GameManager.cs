using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject toaster;
    private int toasterSeparation = 13;
    private float toasterOffset = -2;

    public GameObject cloud;
    private int cloudSeparation;
    private float cloudOffset = -2;

    public GameObject toast;
    private int toastSeparation;
    private float toastOffset;

    float timeElapsed;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if(timeElapsed >= 1 && Fork.started)
        {
            timeElapsed = 0;
            SpawnToasters();
            SpawnClouds();
            SpawnToasts();
        }
    }

    void SpawnToasters()
    {
        Instantiate(toaster, new Vector3(0, toasterSeparation + toasterOffset, 0), Quaternion.identity);
        Vector3 toasterPosition = toaster.transform.position;
        toasterOffset += toasterPosition.y;
    }

    public void SpawnInitialClouds()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnClouds();
        }
    }

    void SpawnClouds()
    {
        cloudSeparation = Random.Range(3, 5);
        float positionX = Random.Range(-2, 2);
        float positionY = Random.Range(2, 4) + cloudSeparation + cloudOffset;
        float scale = Random.Range(2, 4);
        Instantiate(cloud, new Vector3(positionX, positionY, 0), Quaternion.identity);
        cloud.transform.localScale = new Vector3(scale, scale, 0);
        Vector3 cloudPosition = cloud.transform.position;
        cloudOffset += cloudPosition.y;
    }

    void SpawnToasts()
    {
        int randomNumber = Random.Range(0, 100);

        if(randomNumber <= 50)
        {
            toastSeparation = Random.Range(4, 7);
            float positionX = Random.Range(-1, 1);
            float positionY = Random.Range(4, 6) + cloudSeparation + cloudOffset;
            Instantiate(toast, new Vector3(positionX, positionY, 0), Quaternion.identity);
        }
    }
}
