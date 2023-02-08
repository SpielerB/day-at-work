using System;
using UnityEngine;

namespace Assets.Scripts.Computer
{
    /**
     * This class serves as base class for windows on the simulated computer
     */
    public class ComputerWindow : MonoBehaviour
    {
        /**
         * Notifies all listeners if the window has been opened
         */
        public event EventHandler OnWindowOpened;

        /**
         * Notifies all listeners if the window has been closed
         */
        public event EventHandler OnWindowClosed;
        private void CloseWindow() => OnWindowClosed?.Invoke(this, EventArgs.Empty);
        private void OpenWindow() => OnWindowOpened?.Invoke(this, EventArgs.Empty);

        /**
         * The window may only be closed if this returns true
         */
        public virtual bool CanClose() => true;

        /**
         * Closes the window if CanClose => true
         */
        public void Close()
        {
            if (!CanClose()) return;
            gameObject.SetActive(false);
            CloseWindow();
        }

        /**
         * Opens the window
         */
        public void Open()
        {
            gameObject.SetActive(true);
            OpenWindow();
        }

    }
}
