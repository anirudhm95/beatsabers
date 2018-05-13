using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AudioHelm
{
    public class EndGame : MonoBehaviour
    {
        [AddComponentMenu("")]
        public static GameObject DifficultyManager;

        // Use this for initialization
        void Start()
        {
            DifficultyManager = GameObject.Find("Spawner");
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SongEnded(Note note) {
            DifficultyManager.GetComponent<DifficultyManager>().SetGameEnded(true);
        }
    }
}
