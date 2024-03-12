#region
/// <summary>
/// Copyright (c) iNucom. All rights reserved.
/// </summary>
#endregion

using UnityEngine;

/// <summary>
/// Base class for managing different views in the application.
/// </summary>
public abstract class View : MonoBehaviour
{
    /// <summary>
    /// Initializes the view. This method should be implemented in derived classes.
    /// </summary>
    public abstract void Initialize();

    /// <summary>
    /// Hides the view by deactivating its game object.
    /// </summary>
    public virtual void Hide() => gameObject.SetActive(false);

    /// <summary>
    /// Shows the view by activating its game object.
    /// </summary>
    public virtual void Show() => gameObject.SetActive(true);
}