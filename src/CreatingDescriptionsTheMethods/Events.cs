using System;

namespace CreatingDescriptionsTheMethods
{
    public delegate void ProcessTextInClipboardEvent();
    public class ProcessTextInClipboardEvents : EventArgs
    {
        public static event ProcessTextInClipboardEvent ProcessTextInClipboardEvent;
        public static void EvokeProcess() => ProcessTextInClipboardEvent?.Invoke();
    }
}
