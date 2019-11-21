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
        private string _difficulty;
        private KeyboardTypeEnum _keyboardType;
        private string _fileName;


        private void Awake()
        {
            //var manager = GameObject.Find("Manager")?.GetComponent<GameManager>();

            //_playerName = manager.theName;
            //_difficulty = manager.difficulty;
            //_keyboardType = KeyboardTypeEnum.MonoCubic;

            //_fileName = $"{_playerName}_{_difficulty}_{_keyboardType.ToString()}.csv";

            //using (var writer = new StreamWriter($"C:\\{_fileName}", append: true))
            //using (var csv = new CsvWriter(writer))
            //{
            //    csv.WriteHeader<Metric>();

            //    writer.WriteLine();
            //}
        }

        public void Write(string action, string description = null) 
        {
            //using (var writer = new StreamWriter($"C:\\Code\\{_fileName}", append: true))
            //using (var csv = new CsvWriter(writer))
            //{
            //    csv.Configuration.HasHeaderRecord = true;

            //    csv.WriteRecord(new Metric 
            //    {
            //        Action = action,
            //        Timestamp = DateTime.Now,
            //        Description = description
            //    });

            //    writer.WriteLine();
            //}
        }
    }
}
