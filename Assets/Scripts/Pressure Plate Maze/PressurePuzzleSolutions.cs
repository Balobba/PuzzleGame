using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePuzzleSolutions : MonoBehaviour
{
    private List<Vector2Int> solution0 = new List<Vector2Int> {
        new Vector2Int(4, 5),
        new Vector2Int(4, 4),
        new Vector2Int(4, 3),
        new Vector2Int(4, 2),
        new Vector2Int(4, 1),
        new Vector2Int(4, 0)

    };
    private List<Vector2Int> solution1 = new List<Vector2Int> {
        new Vector2Int(4, 5),
		new Vector2Int(3, 5),
		new Vector2Int(2, 5),
		new Vector2Int(1, 5),
		new Vector2Int(0, 5),
		new Vector2Int(0, 4),
		new Vector2Int(0, 3),
		new Vector2Int(1, 3),
		new Vector2Int(2, 3),
		new Vector2Int(3, 3),
		new Vector2Int(4, 3),
		new Vector2Int(5, 3),
		new Vector2Int(6, 3),
		new Vector2Int(7, 3),
		new Vector2Int(7, 2),
		new Vector2Int(6, 2),
		new Vector2Int(5, 2),
		new Vector2Int(4, 2),
		new Vector2Int(4, 1),
		new Vector2Int(4, 0)
   };

    public List<Vector2Int> GetSolution(int solutionID)
    {
        switch (solutionID)
        {
            case 0:
                Debug.Log("RETURNING SOL0");

                return solution0;
            case 1:
                Debug.Log("RETURNING SOL1");
                return solution1;
            default:
                return solution0;
        }
    }
}
