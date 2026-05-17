using System;

[Serializable]
public class NoteData
{
    public float time;
    public int lane;

    public NoteType type = NoteType.Tap;

    // Dung cho Hold / Slide
    public float duration;

    // Dung cho Flick
    public FlickDirection flickDirection = FlickDirection.Any;

    // Dung cho Slide: danh sach lane checkpoint
    public int[] slidePath;
}