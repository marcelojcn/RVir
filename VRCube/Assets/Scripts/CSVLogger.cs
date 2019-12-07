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
        private KeyboardTypeEnum _keyboardType;
        private string _fileName;

        private void OnEnable()
        {
            var manager = GameObject.Find("Manager")?.GetComponent<GameManager>();
            var cubeController = GameObject.Find("Controller")?.GetComponent<CubeController>();

            _playerName = manager.theName;
            _keyboardType = cubeController.KeyboardType;

            _fileName = $"{_playerName}_{_keyboardType.ToString()}.csv";

            using (var writer = new StreamWriter($"/mnt/sdcard/KeyboardTests/{_fileName}", append: true))
            using (var csv = new CsvWriter(writer))
            {
                csv.WriteHeader<Metric>();

                writer.WriteLine();
            }
        }

        public void Write(string action, string description = null) 
        {
            var rightControllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.RTrackedRemote);
            var leftControllerPosition = OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTrackedRemote);

            using (var writer = new StreamWriter($"/mnt/sdcard/KeyboardTests/{_fileName}", append: true))
            using (var csv = new CsvWriter(writer))
            {
                csv.Configuration.HasHeaderRecord = true;

                csv.WriteRecord(new Metric
                {
                    Action = action,
                    Timestamp = Time.time,
                    Description = description,
                    Keyboard = _keyboardType.ToString(),
                    PlayerId = _playerName,

                    RightControllerX = rightControllerPosition.x,
                    RightControllerY = rightControllerPosition.y,
                    RightControllerZ = rightControllerPosition.z,
                    
                    LeftControllerX = leftControllerPosition.x,
                    LeftControllerY = leftControllerPosition.y,
                    LeftControllerZ = leftControllerPosition.z,
                });

                writer.WriteLine();
            }
        }
    }
}
