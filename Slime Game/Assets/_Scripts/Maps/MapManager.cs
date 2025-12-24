using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Maps
{
    [Serializable]
    public class MapManager
    {
        public List<string> mapNames = new();

        private List<string> _unusedMaps = new();

        public MapManager()
        {
            GetAllMaps();
        }

        private void GetAllMaps()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;

            for (int i = 0; i < sceneCount; i++)
            {
                string path = SceneUtility.GetScenePathByBuildIndex(i);
                string sceneName = Path.GetFileNameWithoutExtension(path);
                if (sceneName.Split('_')[0] == "Map")
                {
                    mapNames.Add(sceneName);
                }
            }

            _unusedMaps = mapNames;
        }

        public void LoadMap()
        {
            int randIndex = Random.Range(0, _unusedMaps.Count);
            string selectedMap = _unusedMaps[randIndex];

            // if (_unusedMaps.Count == 0)
            // {
            //     _unusedMaps = mapNames;
            // }
            //
            // _unusedMaps.RemoveAt(randIndex);
            
            SceneManager.LoadScene(selectedMap);
        }
    }
}