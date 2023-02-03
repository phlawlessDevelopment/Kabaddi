using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopupText : MonoBehaviour
{
    private float speed = 1.5f;
    private float time = 0.0f;
    private float lifeTime = 1.5f;
    private float fadeTime = 0.5f;
    private float fadeDelay = 0.2f;
    private Color color = Color.red;
    private string text = "Struggle";
    public TextMeshProUGUI textMesh;

    public void Start()
    {
        textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void SetText(string text)
    {
        textMesh.text = text;
    }

    public void SetColor(Color color)
    {
        textMesh.color = color;
    }

    void Update()
    {
        // transform.Translate(Vector3.up * speed * Time.deltaTime);
        if (time > fadeDelay)
        {
            float alpha = time / fadeTime;
            textMesh.color = new Color(color.r, color.g, color.b, alpha);
            transform.localScale += new Vector3(1.0f, 1.0f, 1.0f) * Time.deltaTime;
        }
        if (time > lifeTime)
        {
            Destroy(gameObject);
        }
        time += Time.deltaTime;
    }
}
