using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clipboard : MonoBehaviour
{
    private void Awake()
    {
        List<List<int>> data_01 = CSVReader.Read("11");

        for (int i = 0; i < data_01.Count; i++) 
        { 
            for (int j = 0; j < data_01.Count; j++)
            {
                print(data_01[i][j].ToString());
            }
            
        }
    }
}
