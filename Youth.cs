using System;

namespace Lab4_Version3
{
    public class Youth : SubjectDigitalSpace
    {
        private int age;
        private string id;
        private string[] skills;
        private int skillsCount;
        private double rating;
        private int completedProjectsCount;
        private string profileStatus;
        private bool isBusy;

        public Youth() : base()
        {
            age = 0;
            id = "";
            skills = new string[10];
            skillsCount = 0;
            rating = 0;
            completedProjectsCount = 0;
            profileStatus = "";
            isBusy = false;
        }

        public Youth(string fullName, bool isActive, int age, string id, string[] skills, int skillsCount,
            double rating, int completedProjectsCount, string profileStatus, bool isBusy) : base(fullName, isActive)
        {
            this.age = age;
            this.id = id;
            this.skills = new string[10];
            this.skillsCount = skillsCount;

            for (int i = 0; i < skillsCount; i++)
            {
                this.skills[i] = skills[i];
            }

            this.rating = rating;
            this.completedProjectsCount = completedProjectsCount;
            this.profileStatus = profileStatus;
            this.isBusy = isBusy;
        }

        public Youth(Youth other) : base(other)
        {
            age = other.age;
            id = other.id;
            skills = new string[10];
            skillsCount = other.skillsCount;

            for (int i = 0; i < other.skillsCount; i++)
            {
                skills[i] = other.skills[i];
            }

            rating = other.rating;
            completedProjectsCount = other.completedProjectsCount;
            profileStatus = other.profileStatus;
            isBusy = other.isBusy;
        }

        public string FullName
        {
            get { return Name; }
            set { Name = value; }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value >= 0)
                    age = value;
            }
        }

        public string Id
        {
            get { return id; }
            set { id = value; }
        }

        public double Rating
        {
            get { return rating; }
            set
            {
                if (value >= 0)
                    rating = value;
            }
        }

        public int CompletedProjectsCount
        {
            get { return completedProjectsCount; }
            set
            {
                if (value >= 0)
                    completedProjectsCount = value;
            }
        }

        public string ProfileStatus
        {
            get { return profileStatus; }
            set { profileStatus = value; }
        }

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; }
        }

        public string[] Skills
        {
            get { return skills; }
        }

        public int SkillsCount
        {
            get { return skillsCount; }
        }

        public void AddSkill(string skill)
        {
            if (string.IsNullOrWhiteSpace(skill))
                return;

            if (skillsCount >= skills.Length)
            {
                Console.WriteLine("Максимум можна додати 10 навичок");
                return;
            }

            skills[skillsCount] = skill;
            skillsCount++;
        }

        public double CalculateRating(int[] marks, double[] difficulty, int count)
        {
            if (count <= 0)
            {
                rating = 0;
                return rating;
            }

            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += marks[i] * difficulty[i];
            }

            rating = sum / count;
            return rating;
        }

        public void EvaluateExperience()
        {
            if (completedProjectsCount == 0)
                profileStatus = "Новачок";
            else if (completedProjectsCount <= 2)
                profileStatus = "Стабільний";
            else
                profileStatus = "Топ";
        }

        public string GetSkillsText()
        {
            string result = "";

            for (int i = 0; i < skillsCount; i++)
            {
                result += skills[i];
                if (i < skillsCount - 1)
                    result += ", ";
            }

            return result;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + ", Тип: Молодь";
        }

        public override void StartInteraction()
        {
            Console.WriteLine("Молодь починає роботу на цифровій платформі.");
        }

        public override void CheckStatus()
        {
            Console.WriteLine("Статус молоді: " + (IsActive ? "профіль активний" : "профіль неактивний"));
        }

        public override void EndAction()
        {
            Console.WriteLine("Молодь завершила поточну дію.");
        }

        public override string ToString()
        {
            return "Ім'я: " + FullName + "\n" +
                   "Вік: " + age + "\n" +
                   "ID: " + id + "\n" +
                   "Навички: " + GetSkillsText() + "\n" +
                   "Рейтинг: " + rating.ToString("F2") + "\n" +
                   "Кількість завершених проєктів: " + completedProjectsCount + "\n" +
                   "Статус: " + profileStatus + "\n" +
                   "Активний профіль: " + (IsActive ? "Так" : "Ні") + "\n" +
                   "Зайнятість: " + (isBusy ? "У роботі" : "Вільний");
        }
    }
}