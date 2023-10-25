using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public static class SaveScoreScript 
{
    public const string TABLE_KEY = "highscore";

    private static HighScoreTable current;
    public static HighScoreTable Current
    {
        get
        {
            if (current == null)
            {
                current = LoadScore();
            }
            return current;
        }
    }

    public static void SaveScore()
    {
        PlayerPrefs.SetString(TABLE_KEY, JsonUtility.ToJson(Current));
    }

    public static HighScoreTable LoadScore()
    {
        if (PlayerPrefs.HasKey(TABLE_KEY))
        {
            return JsonUtility.FromJson<HighScoreTable>(PlayerPrefs.GetString(TABLE_KEY));
        }
        else
        {
            return new HighScoreTable();
        }
    }

    public static void AddScore(int score)
    {
        var date = DateTime.Now.Ticks;
        var newScore = new Score(date, score);
        Current.Scores = Current.Scores
            .OrderByDescending(s => s.Value)
            .Take(4)
            .Append(newScore)
            .OrderByDescending(s => s.Value)
            .ToList();
        SaveScore();
    }

    public static int GetLatestScoreNumber()
    {
        Score score = Current.Scores.OrderByDescending(s => s.Date).FirstOrDefault();
        if (score != null)
        {
            return Current.Scores.IndexOf(score);
        }
        return -1;
    }

    [Serializable]
    public class HighScoreTable
    {
        public List<Score> Scores = new List<Score>();
    }

    [Serializable]
    public class Score
    {
        public long Ticks;
        public int Value;

        public DateTime Date
        {
            get { return new DateTime(Ticks); }
        }

        public Score(long date, int value)
        {
            this.Ticks = date;
            this.Value = value;
        }
    }
}