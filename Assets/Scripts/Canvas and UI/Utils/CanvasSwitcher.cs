using UnityEngine;
using UnityEngine.UI;

namespace Inucom.SchoolVR.UI
{
    /// <summary>
    /// Manages the switching and transition of canvas positions and appearances.
    /// </summary>
    public class CanvasSwitcher
    {
        /// <summary>
        /// Gets or sets the toggle state for the canvas position.
        /// </summary>
        public static bool IsCanvasOnWall { get; set; }

        /// <summary>
        /// Toggles the canvas screen position.
        /// </summary>
        internal static void ToggleCanvasPosition()
        {
            IsCanvasOnWall = !IsCanvasOnWall;
        }

        /// <summary>
        /// Transitions the canvas position and appearance based on the toggle state.
        /// </summary>
        /// <param name="initialBoardPosition">The initial position of the board.</param>
        /// <param name="largeBoardScale">The scale of the board in a large state.</param>
        /// <param name="smallBoardScale">The scale of the board in a small state.</param>
        /// <param name="leftHandModelPosition">The position of the left hand model.</param>
        /// <param name="worldCanvasHolderPosition">The position of the world canvas holder.</param>
        /// <param name="canvasTransform">The canvas transform.</param>
        /// <param name="isCanvasOnWall">The canvas position state.</param>
        /// <param name="toggleButtonText">The text component of the toggle button.</param>
        internal static void TransitionCanvasPosition(Vector3 initialBoardPosition, Vector3 largeBoardScale, Vector3 smallBoardScale, Transform leftHandModelPosition, Transform worldCanvasHolderPosition, Transform canvasTransform, bool isCanvasOnWall, Text toggleButtonText)
        {
            Transform targetTransform;
            Vector3 targetPosition;
            Quaternion targetRotation;
            Vector3 targetScale;
            string buttonText;

            if (isCanvasOnWall)
            {
                targetTransform = worldCanvasHolderPosition;
                targetPosition = initialBoardPosition;
                targetRotation = Quaternion.Euler(0, 180, 0);
                targetScale = largeBoardScale;
                buttonText = "Hand Tablet";
            }
            else
            {
                targetTransform = leftHandModelPosition;
                targetPosition = leftHandModelPosition.position;
                targetRotation = leftHandModelPosition.rotation;
                targetScale = smallBoardScale;
                buttonText = "Large Screen";
            }

            canvasTransform.SetParent(targetTransform);
            canvasTransform.position = Vector3.MoveTowards(canvasTransform.position, targetPosition, 0.5f);
            canvasTransform.rotation = targetRotation;
            canvasTransform.localScale = targetScale;
            toggleButtonText.text = buttonText;
        }

        /// <summary>
        /// Toggles the sprite of an image component based on the canvas position state.
        /// </summary>
        /// <param name="imageComponent">The image component to toggle.</param>
        /// <param name="smallToLargeSprite">The sprite for transitioning from small to large.</param>
        /// <param name="largeToSmallSprite">The sprite for transitioning from large to small.</param>
        /// <param name="isCanvasOnWall">The canvas position state.</param>
        internal static void ToggleImageSprite(Image imageComponent, Sprite smallToLargeSprite, Sprite largeToSmallSprite, bool isCanvasOnWall)
        {
            imageComponent.sprite = isCanvasOnWall ? largeToSmallSprite : smallToLargeSprite;
        }
    }
}
