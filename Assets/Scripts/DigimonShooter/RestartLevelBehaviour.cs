using UnityEngine;
using UnityEngine.SceneManagement;

namespace DigimonShooter
{
    public class RestartLevelBehaviour : MonoBehaviour
    {
        public IntVariable score;

        private void Start()
        {
            score = Resources.Load<IntVariable>("Score");
        }

        private void Update()
        {
            if (score.Value > 5)
            {
                score.Value = 0;
                SceneManager.LoadScene(0);
            }
        }
    }
}