using UnityEngine;
using SerializedStructContainer;
using TMPro;
using System.Text;
public class RecordPanelController : MonoBehaviour
{
    [SerializeField] UIController _UIRoot;
    [SerializeField] Transform _listRoot;
    [SerializeField] GameObject[] _recordLines;

    private void OnEnable()
    {
        SaveHandler.LoadProperty(_UIRoot.RecordSaveSlotName, out SerializableRecordList save, new SerializableRecordList());
        if (save.Records !=null)
        {
            for (int i = 0; i < 10; i++)
            {
                if (i < save.Records.Count) _recordLines[i].GetComponent<TextMeshProUGUI>().text = buildString(save.Records[i]);
                else _recordLines[i].GetComponent<TextMeshProUGUI>().text = "Here can be your name, Pirate.";
            }
        }
    }

    private string buildString(Record record)
    {
        StringBuilder myString = new StringBuilder();
        myString.Append("\"");
        myString.Append(record.Points);
        myString.Append(" pts.   ");
        myString.Append(record.Name);
        myString.Append("\"");
        return myString.ToString();
    }
}
