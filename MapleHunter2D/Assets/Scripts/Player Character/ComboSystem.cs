
public static class ComboSystem
{
    /*
     * Combo system integer values in array corresponds to the input enum values in PlayerInputController such that:
     * 0 = STOP
     * 1 = MOVE RIGHT
     * 2 = MOVE LEFT
     * 3 = CROUCH
     * 4 = DASH
     * 5 = JUMP
     * 6 = DEFEND
     * 7 = UP
     * 8 = PRIMARY
     * 9 = SECONDARY
     * 10 = UTILITY 1
     * 11 = UTILITY 2
     * -1 = END OF COMBO (marks end of combo and is used to pad out any extra values left in sub-array)
     */
    //holds 2D array of free combo list such that comboArray[i][j] and i is the combo sequence and j is the input (table of combos)
    private static int[,] freeComboArray = { { 1, 2 }, //
                                         { 2, 5 }, //
                                         { 2, 5 }, //
                                         { 2, 5 }, //
                                         { 2, 5 }, //
                                         { 2, 5 }, //
                                         { 2, 5 }, //
                                         { 2, 5 }, //
                                         { 2, 5 }, //
                                         { 2, 5 }, //
                                         { 2, 5 }, //
                                         { 3, 0 } }; //

    //holds 2D array of aerial combo list such that comboArray[i][j] and i is the combo sequence and j is the input (table of combos)
    private static int[,] aerialComboArray = { { 3, 8, -1 }, // quick fall { DOWN, PRIMARY }
                                         { 2, 5, -1 }, //
                                         { 3, 0, -1 } }; //
    
    //holds 2D array of ground combo list such that comboArray[i][j] and i is the combo sequence and j is the input (table of combos)
    private static int[,] groundComboArray = { { 1, 2 }, // 
                                         { 2, 5 }, //
                                         { 3, 0 } }; //



    //return true if inputValue is part of an unfinished combo, false if not part of combo or is the last input in combo (combo is finished)
    public static bool NarrowCombo(int inputValue, int inputPosition)
    {
        switch (inputPosition)
        {
            case 0: // input is 1st in combo sequence
                break;
            case 1: // input is 2nd in combo sequence
                break;
            case 2: // input is 3rd in combo sequence
                break;
            case 3: // input is 4th in combo sequence
                break;
            case 4: // input is 5th in combo sequence
                break;
            case 5: // input is 6th in combo sequence
                break;
            case 6: // input is 7th in combo sequence
                break;
            case 7: // input is 8th in combo sequence
                break;
            case 8: // input is 9th in combo sequence
                break;
            case 9: // input is 10th in combo sequence
                break;
        }
        return false;
    }
}