using UnityEngine;

namespace PickAndDrop
{
    public class GameSettings : MonoBehaviour
    {
        bool isHover;
        bool pick;
        Vector3 targetPosition;
        string apeName;

        [SerializeField] FieldScript[] fields;

        [SerializeField] Animator bagAnimator;
        [SerializeField] string open;
        [SerializeField] string close;

        void Update()
        {
            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);
            if (hit.collider != null)
            {
                apeName = hit.collider.name;
                isHover = true;
            }
            else isHover = false;

            bool prev = pick;
            if (Input.GetMouseButtonDown(0) && isHover) pick = !pick;
            if(pick) GameObject.Find(apeName).transform.position = targetPosition;
            if(prev && !pick)
            {
                float distance = 999;
                Vector3 target = Vector3.zero;

                foreach (var field in fields)
                {
                    if (field.taken) continue;
                    float distance2 = Vector3.Distance(GameObject.Find(apeName).transform.position, field.transform.position);
                    if (distance2 > distance) continue;
                    distance = distance2;
                    target = field.transform.position;
                    field.taken = true;
                }
                GameObject.Find(apeName).transform.position = target;
            }
        }
    }
}

