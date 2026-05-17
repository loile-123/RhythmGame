using System.Collections.Generic;
using UnityEngine;

public static class ChartDebugPrinter
{
    public static void PrintSpawnData(List<ChartNoteSpawnData> spawnDataList, int maxCount = 10)
    {
        if (spawnDataList == null)
        {
            Debug.LogWarning("Spawn data list is null.");
            return;
        }

        int count = Mathf.Min(maxCount, spawnDataList.Count);

        Debug.Log($"=== Spawn Data Preview | Showing {count}/{spawnDataList.Count} notes ===");

        for (int i = 0; i < count; i++)
        {
            ChartNoteSpawnData data = spawnDataList[i];

            Debug.Log(
                $"ID: {data.noteId} | " +
                $"Time: {data.hitTime:F2}s | " +
                $"Lane: {data.laneIndex} | " +
                $"Type: {data.noteType} | " +
                $"Duration: {data.duration:F2}s | " +
                $"Flick: {data.flickDirection}"
            );
        }
    }
}