using UnityEngine;

public class DiceSript : MonoBehaviour
{
    [SerializeField]
    private float rollDuration = 1f;
    [SerializeField]
    private Vector3[] rotationsPossible = new Vector3[6];
    private Vector3 currentRotation;
    private Vector3 generatedRotation;

    private void Start()
    {
        currentRotation = this.gameObject.transform.rotation.eulerAngles;
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        currentRotation = rotationsPossible[Random.Range(1, 6)];
    }
}
