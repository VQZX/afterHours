using System;

namespace AfterHours
{
    public interface IVideoInteraction
    {
        Action Response { get; set; }

        void Show();

        void Hide();
    }
}
