using System.Collections.Generic;
using System.Threading.Tasks;
using Constant;
using Cysharp.Threading.Tasks;
using EventStruct;
using UnityEngine;
using UnityEngine.SceneManagement;
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

        private void Show(LoadingType loadingType = LoadingType.None)
        {
            IsShowing = true;
            switch (loadingType)
            {
                case LoadingType.FullScreen:
                    fullScreenView.SetActive(true);
                    overlayView.SetActive(false);
                    break;
                case LoadingType.Overlay:
                    fullScreenView.SetActive(false);
                    overlayView.SetActive(true);
                    break;
                case LoadingType.None:
                default:
                    fullScreenView.SetActive(false);
                    overlayView.SetActive(false);
                    break;
            }
        }

        private void Hide()
        {
            IsShowing = false;
            overlayView.SetActive(false);
            fullScreenView.SetActive(false);
        }

        public async void AddTask(LoadingEventData task)
        {
            if (!IsShowing) Show(task.LoadingType);

            tasks.Add(task);
            await task.Task;
            tasks.Remove(task);

            if (tasks.Count == 0) Hide();
        }

        public Task LoadScene(SceneNameConstant.SceneName sceneName, LoadingType loadingType = LoadingType.FullScreen)
        {
            var task = SceneManager.LoadSceneAsync((int)sceneName, LoadSceneMode.Additive).ToUniTask().AsTask();
            AddTask(new LoadingEventData
            {
                Task = task,
                Message = $"Loading {sceneName}",
                LoadingType = loadingType
            });
            return task;
        }

        public Task UnloadScene(SceneNameConstant.SceneName sceneName, LoadingType loadingType = LoadingType.FullScreen)
        {
            var task = SceneManager.UnloadSceneAsync((int)sceneName).ToUniTask().AsTask();
            AddTask(new LoadingEventData
            {
                Task = task,
                Message = $"Unloading {sceneName}",
                LoadingType = loadingType
            });
            return task;
        }

        public enum LoadingType
        {
            FullScreen,
            Overlay,
            None
        }
    }
}