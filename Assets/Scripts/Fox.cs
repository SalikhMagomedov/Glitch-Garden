using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    private Attacker attacker;

    private void Awake() => attacker = GetComponent<Attacker>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Gravestone>() != null)
        {
            gameObject.GetComponent<Animator>().SetTrigger("JumpTrigger");
        }

        else if (otherObject.GetComponent<Defender>() != null)
        {
            attacker.Attack(otherObject);
        }
    }
}
