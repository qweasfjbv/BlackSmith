using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkUI : MonoBehaviour
{

    [SerializeField] private Transform player;

    [SerializeField] private GameObject timingPin;
    [SerializeField] private GameObject corrTImingPrefab;


    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void SetWorkUI(int facId, Transform player)
    {
        this.player = player;

        // TODO : write on TMP
        Debug.Log("Set!! : " + facId);
    }

    public void SetPinPos(float ratio)
    {

    }

    void Update()
    {
        transform.position = player.position + new Vector3(0, 2.5f, -0.5f);
        transform.rotation = Camera.main.transform.rotation;
    }
}
