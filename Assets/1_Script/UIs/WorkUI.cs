using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkUI : MonoBehaviour
{

    [SerializeField] private Transform player;

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

    void Update()
    {
        transform.position = player.position + new Vector3(1.2f, 1, 0);
        transform.rotation = Camera.main.transform.rotation;
    }
}
