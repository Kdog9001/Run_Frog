using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Renderer image;
    [SerializeField] private float speed;
    private void Update()
    {
        image.material.mainTextureOffset = new Vector2(speed * Time.time, 0);
    }
}
