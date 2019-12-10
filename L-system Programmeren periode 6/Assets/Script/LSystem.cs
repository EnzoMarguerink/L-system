using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class LSystem : MonoBehaviour
{
    public int iterations;
    public float angle;
    public float width;
    public float minLeafLength;
    public float maxLeafLength;
    public float minBranchLength;
    public float maxBranchLenght;
    public float variance;

    public GameObject tree;
    public GameObject branch;
    public GameObject leaf;

    private const string axiom = "X";

    private Dictionary<char, string> rules = new Dictionary<char, string>();
    private Stack<SavedTransform> savedTransforms = new Stack<SavedTransform>();
    private Vector3 initialPosition;

    private string currentPath = "";
    private float[] randomRotations;

    private void Awake()
    {
        randomRotations = new float[1000];
        for (int i = 0; i < randomRotations.Length; i++)
        {
            randomRotations[i] = Random.Range(-1.f, 1.f);
        }

        rules.Add('X', "[-FX][+FX][FX]");
        rules.Add('F', "FF");

        Generate();
    }

    private void Generate()
    {
        currentPath = axiom;

        StringBuilder stringBuilder = new StringBuilder();

        for (int i = 0; i < iterations; i++)
        {
            char[] currentPathChars = currentPath.ToCharArray();
            for (int j = 0; j < currentPathChars.Length; j++)
            {
                stringBuilder.Append(rules.ContainsKey[currentPathChars[j]) ? rules[currentPathChars[j]] : currentPathChars[j].ToString());
            }

            currentPath = stringBuilder.ToString();
            stringBuilder = new StringBuilder();
        }
    }
}
