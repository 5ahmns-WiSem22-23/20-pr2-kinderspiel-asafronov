using UnityEngine;

public class DiceSript : MonoBehaviour
{
    [SerializeField]
    private float rollDuration = 1f;
    [SerializeField]
    private Vector3 rotationTaken;

    private Collider diceCollider;

    private void Start()
    {
        diceCollider = GetComponent<Collider>();
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Roll the dice
            CreateRotation(rotationTaken, this.gameObject);
        }
    }

    public void CreateRotation(Vector3 rotationOfDice, GameObject dice)
    {
        Vector3 currentRotation = dice.transform.rotation.eulerAngles;

        var x = Random.Range(0, 360);
        var y = Random.Range(0, 360);
        var z = Random.Range(0, 360);

        rotationOfDice = new Vector3(x, y, z);

        dice.transform.rotation = Quaternion.FromToRotation(currentRotation, rotationOfDice);
    }
}
