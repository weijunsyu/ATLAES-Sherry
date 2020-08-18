using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    //Config Parameters:

    // Cached References:

    // State Parameters and Objects:
    //holds 2D array of free combo list such that comboArray[i][j] and i is the combo sequence and j is the input (table of combos)
    private static ComboInput[,] freeComboArray;

    //holds 2D array of aerial combo list such that comboArray[i][j] and i is the combo sequence and j is the input (table of combos)
    private static ComboInput[,] aerialComboArray;

    //holds 2D array of ground combo list such that comboArray[i][j] and i is the combo sequence and j is the input (table of combos)
    private static ComboInput[,] groundComboArray;

    private List<ComboInput> comboInputs = new List<ComboInput>();

    // Unity Events:



}