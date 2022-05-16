using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour

{
    public float X = 300f;
    public float Amp = 30f;
    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vec = new Vector3((Amp * Mathf.Sin(Time.time)) + X, (Amp * Mathf.Sin(Time.time)) + X, (Amp * Mathf.Sin(Time.time)) + X);
        transform.localScale = vec;

        //if left mouse button is clicked
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Physics.Raycast(ray, out hit);
            if (hit.transform.gameObject.tag == "clickableGem")
            {
                renderer.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
                StartCoroutine(Rotate(2));
            }
        }
    }

    IEnumerator Rotate(float duration)
    {
        float startRotation = transform.eulerAngles.y;
        float endRotation = startRotation + 360.0f;
        float t = 0.0f;

        while (t < duration)
        {
            t += Time.deltaTime;
            float yRotation = Mathf.Lerp(startRotation, endRotation, t / duration) % 360.0f;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, yRotation, transform.eulerAngles.z);
            yield return null;
        }
    }
}



