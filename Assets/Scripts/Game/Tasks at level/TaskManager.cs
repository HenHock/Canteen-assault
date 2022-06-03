using System.Collections.Generic;
using UnityEngine;

namespace Game.Tasks_at_level
{
    public class TaskManager : MonoBehaviour
    {
        [SerializeField]
        private LevelInfo levelInfo;

        [SerializeField] private List<TaskAbstract> tasksDescriptions = new List<TaskAbstract>();

        private void Awake()
        {
            tasksDescriptions.Add(Instantiate(levelInfo.task_1, transform));
            tasksDescriptions.Add(Instantiate(levelInfo.task_2, transform));
        }

        public LevelInfo getLevelInfo()
        {
            return levelInfo;
        }

        public TaskAbstract TaskDescription(int index)
        {
            if (index < 0 || index >= tasksDescriptions.Count)
                return tasksDescriptions[0];

            return tasksDescriptions[index];
        }
    }
}
