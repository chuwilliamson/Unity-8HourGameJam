using UnityEngine;

namespace DigimonShooter
{
    /// <summary>
    ///     DigimonShooter
    ///     What is it? a turn based game of shooting Digimon
    ///     Start with one "digimon"
    ///     "shoot" other digimon
    ///     - for every digimon you "shoot"
    ///     - every digimon shoots differently
    ///     - types of shooting
    ///     -- shotgun laser grenade
    ///     click to move a digimon, they will shoot on their own
    /// </summary>
    /*ToDo:
     * 1. Make the level
     * 2. Make the click to move
     * 3. Make the AI
     * -move
     * -shoot
     * -die

     */
    [CreateAssetMenu]
    public class Global : ScriptableObject
    {
        private static Global _instance;
        public GameEvent SelectionChangeEvent;

        public Transform CurrentSelection { get; private set; }
        public Vector3 WorldMousePosition { get; set; }

        public static Global Instance
        {
            get
            {
                if (_instance == null)
                    _instance = Resources.Load<Global>("__Global");
                return _instance;
            }
        }

        private void OnEnable()
        {
            CurrentSelection = null;
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        public void Print(string value)
        {
            Debug.Log(value);
        }

        public void SetCurrentTarget(Transform target)
        {
            CurrentSelection = target;
            SelectionChangeEvent.Raise(target.gameObject);
        }
    }
}