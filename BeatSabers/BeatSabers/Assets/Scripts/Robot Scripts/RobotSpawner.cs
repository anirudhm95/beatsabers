using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AudioHelm
{
    public class RobotSpawner : MonoBehaviour
    {
        [AddComponentMenu("")]
        public GameObject Robot;
        // Use this for initialization
        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void SpawnRobot(Note note) {
            Vector3 SpawnLocation = new Vector3(Random.Range(-3,4),Random.Range(0, 5), 12);
            GameObject spawnedNote = Instantiate(Robot, SpawnLocation+transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
        }
    }
}
