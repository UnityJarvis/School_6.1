#region
/// <summary>
/// Copyright (c) iNucom. All rights reserved.
/// </summary>
#endregion

using System.Collections.Generic;
using UnityEngine;

    /// <summary>
    /// Manages different views in the application.
    /// </summary>
    public class ViewManager : MonoBehaviour
    {
        /// <summary>
        /// Gets or sets the instance of the ViewManager.
        /// </summary>
        public static ViewManager Instance { get; private set; }
        /// <summary>
        /// Sets the instance when the ViewManager is awakened.
        /// </summary>
        private void Awake() => Instance = this;

        /// <summary>
        /// The starting view when the application launches.
        /// </summary>
        [SerializeField] private View startingView;

        /// <summary>
        /// Array of views managed by the ViewManager.
        /// </summary>
        [SerializeField] private View[] views;

        /// <summary>
        /// The currently active view.
        /// </summary>
        private View currentView;

        /// <summary>
        /// Stack to keep track of the view history.
        /// </summary>
        private readonly Stack<View> history = new Stack<View>();

        /// <summary>
        /// Gets the specified type of view.
        /// </summary>
        /// <typeparam name="T">Type of the view.</typeparam>
        /// <returns>The view of type T, or null if not found.</returns>
        public static T GetView<T>() where T : View
        {
            foreach (var view in Instance.views)
            {
                if (view is T tView)
                {
                    return tView;
                }
            }
            return null;
        }

        /// <summary>
        /// Shows the specified type of view.
        /// </summary>
        /// <typeparam name="T">Type of the view.</typeparam>
        /// <param name="remember">Whether to remember the current view in history.</param>
        public static void Show<T>(bool remember = true) where T : View
        {
            foreach (var view in Instance.views)
            {
                if (view is T)
                {
                    if (Instance.currentView != null)
                    {
                        if (remember)
                        {
                            Instance.history.Push(Instance.currentView);
                        }
                        Instance.currentView.Hide();
                    }
                    view.Show();
                    Instance.currentView = view;
                }
            }
        }

        /// <summary>
        /// Shows the specified view.
        /// </summary>
        /// <param name="view">The view to show.</param>
        /// <param name="remember">Whether to remember the current view in history.</param>
        public static void Show(View view, bool remember = true)
        {
            if (Instance.currentView != null)
            {
                if (remember)
                {
                    Instance.history.Push(Instance.currentView);
                }
                Instance.currentView.Hide();
            }
            view.Show();
            Instance.currentView = view;
        }

        /// <summary>
        /// Shows the last view in the history.
        /// </summary>
        public static void ShowLast()
        {
            if (Instance.history.Count != 0)
            {
                Show(Instance.history.Pop(), false);
            }
        }

        /// <summary>
        /// Initializes views and shows the starting view.
        /// </summary>
        private void Start()
        {
            foreach (var view in views)
            {
                view.Initialize();
                view.Hide();
            }

            if (startingView != null)
            {
                Show(startingView, true);
            }
        }
    }
