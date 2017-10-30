using System;
using Gtk;

namespace Serpis.Ad
{
    public class WindowHelper
    {
        public static bool Confirm(Window parent, string message)
        {
            MessageDialog messageDialog = new MessageDialog(
                parent,
                DialogFlags.Modal,
                MessageType.Question,
                ButtonsType.YesNo,
                message
            );
            ResponseType response;

            messageDialog.Title = parent.Title;

            response = (ResponseType)messageDialog.Run();
            messageDialog.Destroy();

            return response == ResponseType.Yes;
        }
    }
}