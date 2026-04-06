using System;

namespace Lab4_Version1
{
    public partial class DigitalPlatform : SubjectDigitalSpace
    {
        public class Project
        {
            private string name;
            private string sphere;
            private double difficulty;
            private string requiredSkill;
            private string status;
            private string performerId;
            private string performerName;
            private int grade;
            private DateTime assignmentDate;
            private DateTime deadline;
            private bool trackerActive;
            private string briefLink;
            private string requirements;
            private string coordinatorContact;

            public Project()
            {
                name = "";
                sphere = "";
                difficulty = 1.0;
                requiredSkill = "";
                status = "Вільний";
                performerId = "";
                performerName = "";
                grade = 0;
                assignmentDate = DateTime.MinValue;
                deadline = DateTime.MinValue;
                trackerActive = false;
                briefLink = "";
                requirements = "";
                coordinatorContact = "";
            }

            public Project(string name, string sphere, double difficulty, string requiredSkill, string status)
            {
                this.name = name;
                this.sphere = sphere;
                this.difficulty = difficulty;
                this.requiredSkill = requiredSkill;
                this.status = status;
                performerId = "";
                performerName = "";
                grade = 0;
                assignmentDate = DateTime.MinValue;
                deadline = DateTime.MinValue;
                trackerActive = false;
                briefLink = "brief/" + name.Replace(" ", "_");
                requirements = "Виконати проєкт згідно з вимогами.";
                coordinatorContact = "coordinator@platform.com";
            }

            public Project(Project other)
            {
                name = other.name;
                sphere = other.sphere;
                difficulty = other.difficulty;
                requiredSkill = other.requiredSkill;
                status = other.status;
                performerId = other.performerId;
                performerName = other.performerName;
                grade = other.grade;
                assignmentDate = other.assignmentDate;
                deadline = other.deadline;
                trackerActive = other.trackerActive;
                briefLink = other.briefLink;
                requirements = other.requirements;
                coordinatorContact = other.coordinatorContact;
            }

            public string Name
            {
                get { return name; }
                set { name = value; }
            }

            public string Sphere
            {
                get { return sphere; }
                set { sphere = value; }
            }

            public double Difficulty
            {
                get { return difficulty; }
                set
                {
                    if (value > 0)
                        difficulty = value;
                }
            }

            public string RequiredSkill
            {
                get { return requiredSkill; }
                set { requiredSkill = value; }
            }

            public string Status
            {
                get { return status; }
                set { status = value; }
            }

            public string PerformerId
            {
                get { return performerId; }
                set { performerId = value; }
            }

            public string PerformerName
            {
                get { return performerName; }
                set { performerName = value; }
            }

            public int Grade
            {
                get { return grade; }
                set
                {
                    if (value >= 0)
                        grade = value;
                }
            }

            public DateTime AssignmentDate
            {
                get { return assignmentDate; }
                set { assignmentDate = value; }
            }

            public DateTime Deadline
            {
                get { return deadline; }
                set { deadline = value; }
            }

            public bool TrackerActive
            {
                get { return trackerActive; }
                set { trackerActive = value; }
            }

            public string BriefLink
            {
                get { return briefLink; }
                set { briefLink = value; }
            }

            public string Requirements
            {
                get { return requirements; }
                set { requirements = value; }
            }

            public string CoordinatorContact
            {
                get { return coordinatorContact; }
                set { coordinatorContact = value; }
            }

            public bool AssignPerformer(string performerId, string performerName)
            {
                if (status != "Вільний" && status != "Очікує виконавця")
                    return false;

                this.performerId = performerId;
                this.performerName = performerName;
                assignmentDate = DateTime.Now;
                deadline = DateTime.Now.AddDays(14);
                trackerActive = true;
                status = "У роботі";
                return true;
            }

            public void ChangeStatus(string newStatus)
            {
                status = newStatus;
            }

            public void EvaluateResult(int grade)
            {
                if (grade >= 0)
                    this.grade = grade;
            }

            public string GetAssignmentMessage()
            {
                return "Підтвердження призначення:\n" +
                       "Проєкт: " + name + "\n" +
                       "Виконавець: " + performerName + "\n" +
                       "ID виконавця: " + performerId + "\n" +
                       "Дата призначення: " + assignmentDate.ToString("dd.MM.yyyy HH:mm") + "\n" +
                       "Дедлайн: " + deadline.ToString("dd.MM.yyyy") + "\n" +
                       "Бриф: " + briefLink + "\n" +
                       "Вимоги: " + requirements + "\n" +
                       "Контакт координатора: " + coordinatorContact;
            }

            public override string ToString()
            {
                return "Проєкт: " + name +
                       ", Сфера: " + sphere +
                       ", Складність: " + difficulty +
                       ", Статус: " + status +
                       ", Виконавець: " + (performerName == "" ? "не призначено" : performerName) +
                       ", ID: " + (performerId == "" ? "немає" : performerId) +
                       ", Оцінка: " + grade;
            }
        }

        private int participantsCount;
        private Project[] projects;
        private int projectsCount;
        private string courseName;

        public DigitalPlatform() : base()
        {
            participantsCount = 0;
            projects = new Project[10];
            projectsCount = 0;
            courseName = "";
        }

        public DigitalPlatform(string platformName, bool isActive, int participantsCount, string courseName)
            : base(platformName, isActive)
        {
            this.participantsCount = participantsCount;
            this.courseName = courseName;
            projects = new Project[10];
            projectsCount = 0;
        }

        public DigitalPlatform(DigitalPlatform other) : base(other)
        {
            participantsCount = other.participantsCount;
            courseName = other.courseName;
            projectsCount = other.projectsCount;
            projects = new Project[10];

            for (int i = 0; i < projectsCount; i++)
                projects[i] = new Project(other.projects[i]);
        }

        public string PlatformName
        {
            get { return Name; }
            set { Name = value; }
        }

        public int ParticipantsCount
        {
            get { return participantsCount; }
            set
            {
                if (value >= 0)
                    participantsCount = value;
            }
        }

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public void AddProject(string name, string sphere, double difficulty, string requiredSkill, string status)
        {
            if (projectsCount < projects.Length)
            {
                projects[projectsCount] = new Project(name, sphere, difficulty, requiredSkill, status);
                projectsCount++;
            }
        }

        public Project SelectProjectForYouth(Youth youth)
        {
            for (int i = 0; i < projectsCount; i++)
            {
                if (projects[i].Status == "Вільний" || projects[i].Status == "Очікує виконавця")
                {
                    for (int j = 0; j < youth.SkillsCount; j++)
                    {
                        if (projects[i].RequiredSkill.ToLower() == youth.Skills[j].ToLower())
                            return projects[i];
                    }
                }
            }
            return null;
        }

        public bool AssignProject(Youth youth)
        {
            if (!youth.IsActive)
            {
                Console.WriteLine("Профіль не активний.");
                return false;
            }

            if (youth.IsBusy)
            {
                Console.WriteLine("Користувач не може бути призначений на кілька проєктів одночасно.");
                return false;
            }

            Project selectedProject = SelectProjectForYouth(youth);

            if (selectedProject == null)
            {
                Console.WriteLine("Проєкт недоступний для призначення.");
                return false;
            }

            if (selectedProject.Status != "Вільний" && selectedProject.Status != "Очікує виконавця")
            {
                Console.WriteLine("Проєкт недоступний для призначення.");
                return false;
            }

            if (!selectedProject.AssignPerformer(youth.Id, youth.FullName))
            {
                Console.WriteLine("Проєкт недоступний для призначення.");
                return false;
            }

            youth.IsBusy = true;

            Console.WriteLine("Користувачу " + youth.FullName + " призначено проєкт: " + selectedProject.Name);
            Console.WriteLine(selectedProject.GetAssignmentMessage());
            return true;
        }

        public string GetProjectsText()
        {
            string result = "";
            for (int i = 0; i < projectsCount; i++)
                result += projects[i].ToString() + "\n";
            return result;
        }

        public string GenerateReport(Youth youth)
        {
            return "=== ЗВІТ ЦИФРОВОЇ ПЛАТФОРМИ ===\n" +
                   "Платформа: " + PlatformName + "\n" +
                   "Активність платформи: " + (IsActive ? "Так" : "Ні") + "\n" +
                   "Кількість учасників: " + participantsCount + "\n" +
                   "Користувач:\n" + youth.ToString() + "\n" +
                   "Проєкти:\n" + GetProjectsText() +
                   "Рекомендований курс: " + courseName;
        }
    }
}