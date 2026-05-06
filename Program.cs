using System;

public class Student
{
    private string _fullName;
    private int _studentNumber;
    private string _recordBookNumber;
    private string _phoneNumber;

    private string[] _subjects = new string[7];
    private int[] _grades = new int[7];
    private int _subjectCount = 0; 
    public Student(string fullName, int studentNumber, string recordBookNumber, string phoneNumber)
    {
        FullName = fullName;
        StudentNumber = studentNumber;
        RecordBookNumber = recordBookNumber;
        PhoneNumber = phoneNumber;
    }
    public string FullName { get => _fullName; set => _fullName = value; }
    public int StudentNumber { get => _studentNumber; set => _studentNumber = value; }
    public string RecordBookNumber { get => _recordBookNumber; set => _recordBookNumber = value; }
    public string PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }

    public void AddGrade(string subject, int grade)
    {
        if (_subjectCount < 7)
        {
            _subjects[_subjectCount] = subject;
            _grades[_subjectCount] = grade;
            _subjectCount++;
        }
        else
        {
            Console.WriteLine("Ïîìèëêà: Ìàêñèìàëüíà ê³ëüê³ñòü äèñöèïë³í (7) äîñÿãíóòà.");
        }
    }
    public double AverageGrade
    {
        get
        {
            if (_subjectCount == 0) return 0;
            double sum = 0;
            for (int i = 0; i < _subjectCount; i++)
            {
                sum += _grades[i];
            }
            return Math.Round(sum / _subjectCount, 2);
        }
    }

    public string BestSubject
    {
        get
        {
            if (_subjectCount == 0) return "Íåìàº äàíèõ";
            int maxGrade = _grades[0];
            int maxIndex = 0;
            for (int i = 1; i < _subjectCount; i++)
            {
                if (_grades[i] > maxGrade)
                {
                    maxGrade = _grades[i];
                    maxIndex = i;
                }
            }
            return $"{_subjects[maxIndex]} ({maxGrade})";
        }
    }

    public string WorstSubject
    {
        get
        {
            if (_subjectCount == 0) return "Íåìàº äàíèõ";
            int minGrade = _grades[0];
            int minIndex = 0;
            for (int i = 1; i < _subjectCount; i++)
            {
                if (_grades[i] < minGrade)
                {
                    minGrade = _grades[i];
                    minIndex = i;
                }
            }
            return $"{_subjects[minIndex]} ({minGrade})";
        }
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Ñòóäåíò: {FullName}, ¹{StudentNumber}");
        Console.WriteLine($"Çàë³êîâà: {RecordBookNumber}, Òåë: {PhoneNumber}");
        Console.WriteLine("Îö³íêè çà ñåñ³þ:");
        for (int i = 0; i < _subjectCount; i++)
        {
            Console.WriteLine($"  - {_subjects[i]}: {_grades[i]}");
        }
        Console.WriteLine($"Ñåðåäí³é áàë: {AverageGrade}");
        Console.WriteLine($"Íàéêðàùèé ïðåäìåò: {BestSubject}");
        Console.WriteLine($"Íàéã³ðøèé ïðåäìåò: {WorstSubject}");
        Console.WriteLine(new string('-', 20));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Student st1 = new Student("Комен Віталій Андрійович", 1, "ОП-123", "+380501112233");
        st1.AddGrade("АСД", 95);
        st1.AddGrade("МТС", 80);
        st1.AddGrade("СМООП", 75);
        st1.AddGrade("Вища математика", 90);

        st1.PrintInfo();

        Student st2 = new Student("Леман Людмила Віталійовна", 2, "СЕ-124", "+380504445566");
        st2.AddGrade("АСД", 60);
        st2.AddGrade("МТС", 70);
        st2.AddGrade("СМООП", 55);

        st2.PrintInfo();
    }
}

