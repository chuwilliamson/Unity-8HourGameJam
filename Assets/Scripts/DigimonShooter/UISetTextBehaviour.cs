using UnityEngine;
using UnityEngine.UI;

namespace DigimonShooter
{
    public class UISetTextBehaviour : MonoBehaviour
    {
        [SerializeField] private string prependText = "Score: ";

        private Text text;

        [SerializeField] private IntVariable variable;

        private void Start()
        {
            text = GetComponent<Text>();
        }

        // Update is called once per frame
        private void Update()
        {
            text.text = prependText + variable.Value;
        }
    }
}