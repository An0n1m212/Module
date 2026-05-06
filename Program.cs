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
            Console.WriteLine("Помилка: Максимальна кількість дисциплін (7) досягнута.");
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
            if (_subjectCount == 0) return "Немає даних";
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
            if (_subjectCount == 0) return "Немає даних";
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
        Console.WriteLine($"Студент: {FullName}, №{StudentNumber}");
        Console.WriteLine($"Залікова: {RecordBookNumber}, Тел: {PhoneNumber}");
        Console.WriteLine("Оцінки за сесію:");
        for (int i = 0; i < _subjectCount; i++)
        {
            Console.WriteLine($"  - {_subjects[i]}: {_grades[i]}");
        }
        Console.WriteLine($"Середній бал: {AverageGrade}");
        Console.WriteLine($"Найкращий предмет: {BestSubject}");
        Console.WriteLine($"Найгірший предмет: {WorstSubject}");
        Console.WriteLine(new string('-', 20));
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Student st1 = new Student("Іванов Іван Іванович", 1, "ЗК-123", "+380501112233");
        st1.AddGrade("Програмування", 95);
        st1.AddGrade("Математика", 80);
        st1.AddGrade("Фізика", 75);
        st1.AddGrade("Бази даних", 90);

        st1.PrintInfo();

        Student st2 = new Student("Петров Петро Петрович", 2, "ЗК-124", "+380504445566");
        st2.AddGrade("Програмування", 60);
        st2.AddGrade("Математика", 70);
        st2.AddGrade("Фізика", 55);

        st2.PrintInfo();
    }
}

