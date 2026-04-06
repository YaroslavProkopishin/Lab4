using System;

namespace Lab4_Version3
{
    public class SubjectDigitalSpace : IDigitalEntity
    {
        private string name;
        private bool isActive;

        protected SubjectDigitalSpace()
        {
            name = "";
            isActive = false;
        }

        protected SubjectDigitalSpace(string name, bool isActive)
        {
            this.name = name;
            this.isActive = isActive;
        }

        protected SubjectDigitalSpace(SubjectDigitalSpace other)
        {
            name = other.name;
            isActive = other.isActive;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public virtual string GetInfo()
        {
            return "Назва: " + name + ", Активність: " + (isActive ? "Так" : "Ні");
        }

        public virtual void StartInteraction()
        {
            Console.WriteLine("Початок взаємодії із суб'єктом цифрового простору.");
        }

        public virtual void CheckStatus()
        {
            Console.WriteLine("Статус активності: " + (isActive ? "активний" : "неактивний"));
        }

        public virtual void EndAction()
        {
            Console.WriteLine("Взаємодію завершено.");
        }
    }
}