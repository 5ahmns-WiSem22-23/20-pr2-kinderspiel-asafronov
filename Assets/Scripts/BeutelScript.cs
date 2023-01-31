using System.Collections;
using UnityEngine;

public class BeutelScript : MonoBehaviour
{
    [SerializeField] GameObject[] apes;
    Collider2D col;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        //mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);

        if (hit.collider == col)
        {
            //Debug.Log("Hover?");
            if (Input.GetMouseButtonDown(0))
            {
                //Debug.Log("Clicked!");
                StartCoroutine(BagAnimation());
            }
        }
    }

    IEnumerator BagAnimation()
    {
        col.enabled = false;
        animator.Play("BagOpen");
        Instantiate(apes[Random.Range(1, 4)]);
        yield return new WaitForSeconds(2f);
        col.enabled = true;
        animator.Play("BagClose");
    }
}
