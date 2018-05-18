using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AudioHelm {
    public class Spawner : MonoBehaviour
    {
        [AddComponentMenu("")]
        public GameObject[] enemies;
        public AudioHelmClock clock;
        public Vector3 spawnValues;
        public Vector3[] spawnPositions = new Vector3[2];
        public float spawnWait;
        public float spawnMostWait;
        public float spawnLeastWait;
        public int startWait;
        public bool stop;
        private float modifier;
        private float spawnZvalue;

        int randEnemy;

        void Start()
        {
            clock = FindObjectOfType<AudioHelmClock>();
            updateMoveSpeed(110f, 0.0f);
            //StartCoroutine(waitSpawner());
        }


        void Update()
        {
        }

        public int startingNote = 20;
        public int[] scale = { 0, 2, 4, 5, 7, 9, 11 };

        int GetNoteIndex(int note)
        {
            int noteAdjusted = (note - startingNote + Utils.kMidiSize) % Utils.kMidiSize;
            int octave = noteAdjusted / Utils.kNotesPerOctave;
            int noteInOctave = noteAdjusted - Utils.kNotesPerOctave * octave;

            for (int scaleNote = 0; scaleNote < scale.Length; ++scaleNote)
            {
                if (scale[scaleNote] >= noteInOctave)
                    return octave * scale.Length + scaleNote;
            }
            return octave;
        }

        public void spawnNote(Note note)
        {
            randEnemy = Random.Range(0, 2);
            int randVertLane = Random.Range(0, 2);
            int lastHorLocation = (int)spawnPositions[randEnemy].x;
            int lastHorLocationOther;
            if (randEnemy == 0)
                lastHorLocationOther = (int)spawnPositions[1].x;
            else
                lastHorLocationOther = (int)spawnPositions[0].x;
            int randHorLane = Random.Range(Mathf.Max(-3, lastHorLocation - 1, lastHorLocationOther - 3), Mathf.Min(4, lastHorLocation + 2, lastHorLocationOther + 4));
           // Debug.Log(Mathf.Max(-3, lastHorLocation - 2) + ", " + randHorLane + ", " + Mathf.Min(4, lastHorLocation + 2));
            spawnPositions[randEnemy] = new Vector3(randHorLane, randVertLane * 1.18f, spawnZvalue);
            GetComponent<DifficultyManager>().incrementNotesSpawned();
            GameObject spawnedNote = Instantiate(enemies[randEnemy], spawnPositions[randEnemy] + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            spawnedNote.GetComponent<cubemove>().setModifier(modifier);
        }

        public void updateMoveSpeed(float tempo, float moveSpeed) {
            float distance = 240.0f / clock.bpm;
            modifier = moveSpeed;
            spawnZvalue = distance * (9.0f+moveSpeed);
        }
    }
}

