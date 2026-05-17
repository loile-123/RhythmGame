using UnityEngine;

public class ChartVisualizer : MonoBehaviour
{
    [Header("Visual")]
    [SerializeField] private GameObject notePrefab;
    [SerializeField] private Transform noteParent;
    private ChartData currentChart;

    [Header("Layout")]
    [SerializeField] private float laneSpacing = 1.2f;
    [SerializeField] private float timeSpacing = 1f;

    public void Draw(ChartData chart)
    {
        Clear();
        currentChart = chart;
        if (chart == null || chart.notes == null)
        {
            Debug.LogWarning("Chart is empty.");
            return;
        }

        for (int i = 0; i < chart.notes.Count; i++)
        {
            NoteData note = chart.notes[i];

            Vector3 position = new Vector3(
                note.lane * laneSpacing,
                note.time * timeSpacing,
                0f
            );

            GameObject noteObject = Instantiate(notePrefab, position, Quaternion.identity, noteParent);

            ChartPreviewNote previewNote = noteObject.GetComponent<ChartPreviewNote>();

            if (previewNote == null)
            {
                previewNote = noteObject.AddComponent<ChartPreviewNote>();
            }

            previewNote.Initialize(i, note, this);
        }
    }

    public void Clear()
    {
        if (noteParent == null)
        {
            return;
        }

        for (int i = noteParent.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(noteParent.GetChild(i).gameObject);
        }
    }
    public void UpdateNoteFromPreview(ChartPreviewNote previewNote)
    {
        NoteData note = previewNote.NoteData;

        int lane = Mathf.RoundToInt(previewNote.transform.position.x / laneSpacing);
        float time = previewNote.transform.position.y / timeSpacing;

        lane = Mathf.Clamp(lane, 0, 3);
        time = Mathf.Max(0f, time);

        note.lane = lane;
        note.time = time;

        previewNote.transform.position = new Vector3(
            note.lane * laneSpacing,
            note.time * timeSpacing,
            0f
        );
    }
    public ChartData GetCurrentChart()
    {
        return currentChart;
    }
}