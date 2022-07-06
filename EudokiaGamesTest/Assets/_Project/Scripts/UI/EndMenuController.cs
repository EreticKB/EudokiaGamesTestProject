using SerializedStructContainer;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenuController : MonoBehaviour
{
    [SerializeField] UIController _UIRoot;
    int _points;
    [SerializeField] TMP_InputField _name;
    [SerializeField] TextMeshProUGUI _pointsUI;
    [SerializeField] TextMeshProUGUI _killsUI;
    internal void Fill(int points, int kills)
    {
        _points = points;
        _pointsUI.text = points.ToString();
        _killsUI.text = kills.ToString();
    }
    public void SaveRecord()
    {
        SaveHandler.LoadProperty(_UIRoot.RecordSaveSlotName, out SerializableRecordList save, new SerializableRecordList(new List<Record>()));
        save.Records.Add(new Record(_points, _name.text));
        save.Records.Sort();
        if (save.Records.Count > 10) save.Records.RemoveAt(save.Records.Count - 1);
        SaveHandler.SaveProperty(_UIRoot.RecordSaveSlotName, save);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//может не самое оптимальное, но самое простое в данной ситуации.

    }
}
