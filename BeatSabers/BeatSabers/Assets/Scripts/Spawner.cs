using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AudioHelm {
    public class Spawner : MonoBehaviour
    {
        [AddComponentMenu("")]
        public GameObject[] orbTypes;
        public AudioHelmClock clock;
        public Vector3[] spawnPositions = new Vector3[2];
        private float modifier;
        private float spawnZvalue;
        int randOrbType;
        public int startingNote = 20;
        public int[] scale = { 0, 2, 4, 5, 7, 9, 11 };

        void Start()
        {
            clock = FindObjectOfType<AudioHelmClock>();
            UpdateMoveSpeed(0.0f);
        }


        void Update()
        {
        }

        //determine note with audio helm (not used in current build)
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

        public void SpawnNote(Note note)
        {
            //randomly determine orb type and lane
            randOrbType = Random.Range(0, 2);
            int randVertLane = Random.Range(0, 2);
            int lastHorLocation = (int)spawnPositions[randOrbType].x;
            int lastHorLocationOther;
            if (randOrbType == 0)
                lastHorLocationOther = (int)spawnPositions[1].x;
            else
                lastHorLocationOther = (int)spawnPositions[0].x;
            int randHorLane = Random.Range(Mathf.Max(-3, lastHorLocation - 1, lastHorLocationOther - 3), Mathf.Min(4, lastHorLocation + 2, lastHorLocationOther + 4));
           // Debug.Log(Mathf.Max(-3, lastHorLocation - 2) + ", " + randHorLane + ", " + Mathf.Min(4, lastHorLocation + 2));
            spawnPositions[randOrbType] = new Vector3(randHorLane, randVertLane * 1.18f, spawnZvalue);

            //spawn orb with determined values
            GetComponent<DifficultyManager>().IncrementNotesSpawned();
            GameObject spawnedNote = Instantiate(orbTypes[randOrbType], spawnPositions[randOrbType] + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
            spawnedNote.GetComponent<cubemove>().setModifier(modifier);
        }

        public void UpdateMoveSpeed(float moveSpeed) {
            float distance = 240.0f / clock.bpm;
            modifier = moveSpeed;
            spawnZvalue = distance * (9.0f+moveSpeed);
        }
    }
}

