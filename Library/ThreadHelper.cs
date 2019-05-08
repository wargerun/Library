using System;
using System.Windows.Threading;

namespace Library
{
    public static class ThreadHelper
    {
        public static void GuiSync(this DispatcherObject o, Action action)
        {
            if (!o.Dispatcher.CheckAccess())
                o.Dispatcher.Invoke(DispatcherPriority.Normal, (Delegate)action);
            else
                action();
        }

        public static void GuiAsync(this DispatcherObject o, Action action)
        {
            if (!o.Dispatcher.CheckAccess())
                o.Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate)action);
            else
                action();
        }
    }
}