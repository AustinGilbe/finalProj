using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class item_collector : MonoBehaviour
{
    private int points = 0;
    [SerializeField] private TextMeshProUGUI Score;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            Destroy(collision.gameObject);
            points += 500;
            Score.text = "Score: " + points;
        }
    }
}
