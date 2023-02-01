using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace GameSettingNamespace
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

        GameObject[] apes;
        public int blueVariable;
        public int greenVariable;
        public int yellowVariable;
        public int redVariable;

        BeutelScript bagObject;

        [SerializeField] Animator bagAnimator;
        [SerializeField] string open;
        [SerializeField] string close;

        public Text blue;
        public Text green;
        public Text yellow;
        public Text red;

        public GameObject blueWin;
        public GameObject greenWin;
        public GameObject yellowWin;
        public GameObject redWin;

        private void Start()
        {
            if (instance == null) instance = this;
            else Destroy(this);

            bagObject = FindObjectOfType<BeutelScript>();
        }

        void Update()
        {
            blue.text = "Blau: " + blueVariable.ToString();
            green.text = "Grün: " + greenVariable.ToString();
            yellow.text = "Gelb: " + yellowVariable.ToString();
            red.text = "Rot: " + redVariable.ToString();

            if (blueVariable >= 6 || greenVariable >= 6 || yellowVariable >= 6 || redVariable >= 6) bagObject.enabled = false;

            if (blueVariable >= 6)
            {
                Debug.Log("BLUE");
                blueWin.gameObject.SetActive(true);
            }
            if (greenVariable >= 6)
            {
                Debug.Log("GRÜN!");
                greenWin.gameObject.SetActive(true);
            }

            if (yellowVariable >= 6) 
            {
                Debug.Log("GELB");
                yellowWin.gameObject.SetActive(true);
            }
            
            if (redVariable >= 6) 
            {
                Debug.Log("ROT");
                redWin.gameObject.SetActive(true);
            }
        }

        public void RestartGame(string SceneName)
        {
            SceneManager.LoadScene(SceneName);
        }
    }
}

