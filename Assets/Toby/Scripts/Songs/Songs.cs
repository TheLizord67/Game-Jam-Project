using NUnit.Framework;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[CreateAssetMenu(fileName = "Songs", menuName = "Scriptable Objects/Song")]
public class Songs : ScriptableObject
{
    public string name;
    public AudioClip music;
    public Leaderboard leaderboard;
    [System.Serializable]
    public struct Leaderboard
    {
        public List<string> names;
        public List<int> scores;
    }
}
