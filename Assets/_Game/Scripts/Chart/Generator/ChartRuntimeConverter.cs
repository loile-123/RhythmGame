using System.Collections.Generic;
using UnityEngine;

public static class ChartRuntimeConverter
{
    public static List<ChartNoteSpawnData> ConvertToSpawnData(ChartData chart)
    {
        List<ChartNoteSpawnData> spawnDataList = new List<ChartNoteSpawnData>();

        if (chart == null)
        {
            Debug.LogError("Cannot convert chart. Chart is null.");
            return spawnDataList;
        }

        if (chart.notes == null)
        {
            Debug.LogError("Cannot convert chart. Notes list is null.");
            return spawnDataList;
        }

        for (int i = 0; i < chart.notes.Count; i++)
        {
            NoteData note = chart.notes[i];

            ChartNoteSpawnData spawnData = new ChartNoteSpawnData
            {
                noteId = i,
                hitTime = note.time,
                laneIndex = note.lane,
                noteType = note.type,
                duration = note.duration,
                flickDirection = note.flickDirection,
                slidePath = note.slidePath
            };

            spawnDataList.Add(spawnData);
        }

        Debug.Log($"Converted chart to spawn data. Count: {spawnDataList.Count}");

        return spawnDataList;
    }
}