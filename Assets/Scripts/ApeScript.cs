using GameSettingNamespace;
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
        settings = FindObjectOfType<GameSettings>();
        fields = GameObject.FindGameObjectsWithTag("Field");

        if (colorName == "blue") settings.blueVariable++;
        if (colorName == "green") settings.greenVariable++;
        if (colorName == "yellow") settings.yellowVariable++;
        if (colorName == "red") settings.redVariable++;
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