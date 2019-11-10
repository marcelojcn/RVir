using Assets.Utilities.Enums;
using Assets.Utilities.Models;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Utilities
{
    public class CSVLogger : MonoBehaviour
    {
        private string _playerName;
        private DifficultyEnum _difficulty;
        private KeyboardTypeEnum _keyboardType;
        private string _fileName;

        public CSVLogger(string playerName, DifficultyEnum difficulty, KeyboardTypeEnum keyboardType) 
        {
            _playerName = playerName;
            _difficulty = difficulty;
            _keyboardType = keyboardType;

            _fileName = $"{_playerName}_{_difficulty.ToString()}_{_keyboardType.ToString()}.csv";

            using (var writer = new StreamWriter($"C:\\{_fileName}", append: true))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteHeader<Metric>();

                writer.WriteLine();
            }
        }

        public void Write(string action, string description = null) 
        {
            using (var writer = new StreamWriter($"C:\\Code\\{_fileName}", append: true))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.HasHeaderRecord = true;

                csv.WriteRecord(new Metric 
                {
                    Action = action,
                    Timestamp = DateTime.Now,
                    Description = description
                });

                writer.WriteLine();
            }
        }
    }
}
