using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class AiChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float distanceBetween;

    private float distance;
    private float horizantal;

    private bool isFacingRight = true;

    SpriteRenderer SR;
    public Sprite S1, S2;
    public bool IsHit;

    private void Start()
    {
        SR = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (IsHit)
        {
            SR.sprite = S2;
        }
        else
        {
            SR.sprite = S1;
        }
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;


        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
        }

        //Flip();


        //void Flip()
        //{
        //    float movementSign = Mathf.Sign(horizantal);

        //    // Check if the sign of the movement is opposite to the current facing direction
        //    if (movementSign != 0 && movementSign != (isFacingRight ? 1 : -1))
        //    {
        //        // Flip the facing direction
        //        isFacingRight = !isFacingRight;

        //        // Flip the local scale
        //        Vector3 localScale = transform.localScale;
        //        localScale.x *= -1f;
        //        transform.localScale = localScale;

        //        // Log to verify that the method is being called and the flip occurs
        //        Debug.Log("Flipped");
        //    }
        //}

    }
}