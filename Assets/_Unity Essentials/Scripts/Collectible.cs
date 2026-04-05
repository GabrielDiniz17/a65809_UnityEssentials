using UnityEngine;

public class Collectible : MonoBehaviour
{
    public float rotationSpeed;
    public GameObject onCollectEffect;

    // Update is called once per frame
    void Update()
    {
        // No 2D, a gente gira o eixo Z (o terceiro número) para ele rodar como um pneu
        transform.Rotate(0, 0, rotationSpeed);
    }

    // O "D" tem que ser maiúsculo aqui e no Collider2D!
    private void OnTriggerEnter2D(Collider2D other) 
    {
        // ESSA LINHA É O NOSSO DEDO-DURO:
        Debug.Log("O colisor encostou em: " + other.gameObject.name + " | E a Tag é: " + other.tag);

        if (other.CompareTag("Player"))        
        {
            if (onCollectEffect != null) 
            {
                Instantiate(onCollectEffect, transform.position, transform.rotation);
            }
            Destroy(gameObject);
        }
    }
}