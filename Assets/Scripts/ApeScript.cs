using PickAndDrop;
using UnityEngine;

public class ApeScript : MonoBehaviour
{
    public string colorName;
    GameSettings settings;
    [SerializeField] GameObject[] fields;
    Vector3 mousePosition;
    bool isHover;
    bool pick;

    private void Start()
    {
        fields = GameObject.FindGameObjectsWithTag("Field");
    }

    private void Update()
    {
        float distanceToNextField = 0f;
        foreach (var field in fields)
        {
            distanceToNextField = Vector2.Distance(this.transform.position, field.transform.position);
        }

        if (distanceToNextField <= 0.2) Debug.Log("short!");

        Debug.Log("pick is: " + pick + " and hove is: " + isHover);
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mouseRay.origin, mouseRay.direction);

        if (hit.collider == this.gameObject.GetComponent<Collider2D>())
        {
            isHover = true;
        }
        else isHover = false;

        if (Input.GetMouseButtonDown(0) && isHover) pick = !pick;
        if (pick) transform.position = mousePosition;
    }
}