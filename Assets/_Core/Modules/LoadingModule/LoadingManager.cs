using System.Collections.Generic;
using System.Threading.Tasks;
using EventStruct;
using UnityEngine;
using Utilities;

namespace LoadingModule
{
    public class LoadingManager : MonoBehaviour
    {
        [SerializeField] private GameObject overlayView;
        [SerializeField] private GameObject fullScreenView;

        private readonly List<LoadingEventData> tasks = new();
        private Task loadingTask;

        private bool IsShowing { get; set; }

        private void OnEnable()
        {
            EventManager.AddEventListener<LoadingEventData>(OnAddTask);
        }

        private void OnDisable()
        {
            EventManager.RemoveEventListener<LoadingEventData>(OnAddTask);
        }

        private void OnAddTask(LoadingEventData data)
        {
            AddTask(data);
        }

        private void Show(bool isFullScreen = false)
        {
            IsShowing = true;
            overlayView.SetActive(!isFullScreen);
            fullScreenView.SetActive(isFullScreen);
        }

        private void Hide()
        {
            IsShowing = false;
            overlayView.SetActive(false);
            fullScreenView.SetActive(false);
        }

        public async void AddTask(LoadingEventData task)
        {
            if (!IsShowing) Show();

            tasks.Add(task);
            await task.Task;
            tasks.Remove(task);

            if (tasks.Count == 0) Hide();
        }
    }
}