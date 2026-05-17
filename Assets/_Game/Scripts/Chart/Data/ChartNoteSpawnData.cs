using System;

[Serializable]
public struct ChartNoteSpawnData
{
    public int noteId;
    public float hitTime;
    public int laneIndex;
    public NoteType noteType;
    public float duration;
    public FlickDirection flickDirection;
    public int[] slidePath;
}