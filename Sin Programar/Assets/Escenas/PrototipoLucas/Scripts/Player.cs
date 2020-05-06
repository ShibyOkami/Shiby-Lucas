using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float velocidad;
    private Rigidbody rb;
    private int count;
    public Text ContadorTexto;
    public Text VictoriaTexto;
    public AudioClip RingSonido;


    void Start()
    {

        rb = GetComponent<Rigidbody>();
        count = 0;
        SetContadorTexto();
        VictoriaTexto.text = "";
    }


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * velocidad);
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Coleccionable"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetContadorTexto();
            AudioSource.PlayClipAtPoint(RingSonido, transform.position);
        }
    }
    void SetContadorTexto()
    {
        ContadorTexto.text = "Rings: " + count.ToString();
        if (count >=12)
        {
            VictoriaTexto.text = "¡Ganaste!";
        }
    }
}
