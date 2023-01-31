using UnityEngine;

namespace PickAndDrop
{
    public class GameSettings : MonoBehaviour
    {
        [HideInInspector]
        public GameSettings instance;

        bool isHover;
        bool pick;
        Vector3 mousePosition;
        GameObject ape;
        ApeScript apeScript;

        [SerializeField] Animator bagAnimator;
        [SerializeField] string open;
        [SerializeField] string close;

        private void Start()
        {
            if (instance == null) instance = this;
            else Destroy(this);
        }

        void Update()
        {
            //bool prev = pick;

            //ape.transform.position = mousePosition;
            //if(prev && !pick)
            //{
            //    float distance = 999;
            //    Vector3 target = Vector3.zero;

            //    foreach (var field in fields)
            //    {
            //        if (field.taken) continue;
            //        float distance2 = Vector3.Distance(GameObject.Find(apeName).transform.position, field.transform.position);
            //        if (distance2 > distance) continue;
            //        distance = distance2;
            //        target = field.transform.position;
            //        field.taken = true;
            //    }

            //    GameObject.Find(apeName).GetComponent<Collider2D>().enabled = false;
        }
    }
}

