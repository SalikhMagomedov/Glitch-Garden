using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        var attacker = collision.GetComponent<Attacker>();
        if (attacker)
        {

        }
    }
}
