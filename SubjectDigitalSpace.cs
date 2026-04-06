using System;

namespace Lab4_Version1
{
    public class SubjectDigitalSpace
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
    }
}