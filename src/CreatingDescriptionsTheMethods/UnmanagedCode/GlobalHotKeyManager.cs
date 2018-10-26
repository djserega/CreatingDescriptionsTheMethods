using CreatingDescriptionsTheMethods.UnmanagedCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CreatingDescriptionsTheMethods
{
    internal partial class GlobalHotKeyManager : IDisposable
    {
        private LowLevelKeyboardListener _listener;

        internal bool PressedLeftCtrl { get; private set; }
        internal bool PressedLeftAlt { get; private set; }
        internal bool PressedC { get; private set; }
        
        private const Key _keyLeftCtrl = Key.LeftCtrl;
        private const Key _keyLeftAlt = Key.LeftAlt;
        private const Key _keyC = Key.C;

        internal GlobalHotKeyManager()
        {
            _listener = new LowLevelKeyboardListener();
            _listener.OnKeyDown += _listener_OnKeyDown;
            _listener.OnKeyUp += _listener_OnKeyUp;

            _listener.HookKeyboard();
        }

        void _listener_OnKeyDown(object sender, KeyDownArgs e)
        {
            switch (e.KeyDown)
            {
                case _keyLeftCtrl:
                    PressedLeftCtrl = true;
                    break;
                case _keyLeftAlt:
                    PressedLeftAlt = true;
                    break;
                case _keyC:
                    PressedC = true;
                    break;
            }

            if (PressedLeftCtrl && PressedLeftAlt)
            {
                if (PressedC)
                {
                    ProcessTextInClipboardEvents.EvokeProcess();

                    PressedLeftCtrl = false;
                    PressedLeftAlt = false;
                    PressedC = false;
                }
            }
        }

        void _listener_OnKeyUp(object sender, KeyUpArgs e)
        {
            switch (e.KeyUp)
            {
                case _keyLeftCtrl:
                    PressedLeftCtrl = false;
                    break;
                case _keyLeftAlt:
                    PressedLeftAlt = false;
                    break;
                case _keyC:
                    PressedC = false;
                    break;
            }
        }

        public void Dispose()
        {
            _listener.UnHookKeyboard();
        }
    }
}
