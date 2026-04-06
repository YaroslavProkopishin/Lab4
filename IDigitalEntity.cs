using System;

namespace Lab4_Version3
{
    public interface IDigitalEntity
    {
        string Name { get; set; }
        bool IsActive { get; set; }

        string GetInfo();
        void StartInteraction();
        void CheckStatus();
        void EndAction();
    }
}