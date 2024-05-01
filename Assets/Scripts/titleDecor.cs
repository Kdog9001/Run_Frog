using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class titleDecor : MonoBehaviour
{
    public GameObject playButton;
    public TextMeshPro playText;

    public float spinSpeed;
    public float bigSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playButton.transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime, Space.Self);

        float fontChange = Mathf.PingPong(Time.time * bigSpeed, 2);
        playText.fontSize = fontChange + 16;
    }
}
