using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScroll : MonoBehaviour
{
    public GameObject Player;
    [SerializeField] private float camSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float interpolation = camSpeed * Time.deltaTime;

        Vector3 position = this.transform.position;
        position.y = Mathf.Lerp(this.transform.position.y, Player.transform.position.y, interpolation);
        position.x = Mathf.Lerp(this.transform.position.x, Player.transform.position.x +5.0f, interpolation);

        this.transform.position = position;
    }
}
