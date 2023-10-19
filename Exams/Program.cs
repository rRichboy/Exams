using System;

class Program
{
    static int Get_Salary(int employeeId, int[,] employeeData)
    {
        for (int i = 0; i < employeeData.GetLength(0); i++)
        {
            int id = employeeData[i, 0];
            int salary = employeeData[i, 1];

            if (id == employeeId)
            {
                return salary;
            }
        }
        return -1;
    }

    static void AllSalaries(int[,] employeeData)
    {
        int numEmployees = employeeData.GetLength(0);
        int numDays = 30;

        Console.WriteLine("Зарплата всех сотрудников за 30 дней:");

        for (int employeeIndex = 0; employeeIndex < numEmployees; employeeIndex++)
        {
            int id = employeeData[employeeIndex, 0];
            int totalSalary = 0;

            for (int day = 1; day <= numDays; day++)
            {
                totalSalary += employeeData[employeeIndex, day];
            }

            Console.WriteLine($"ID сотрудника {id}: {totalSalary}");
        }
    }

    static void Main()
    {
        int numEmployees = 5;
        int numDays = 30;
        int[,] employeeData = new int[numEmployees, numDays + 1];
        int[,] salaryByDays = new int[numEmployees, numDays];

        Random random = new Random();

        for (int i = 0; i < numEmployees; i++)
        {
            employeeData[i, 0] = i + 1;

            for (int day = 1; day <= numDays; day++)
            {
                int salary = random.Next(100, 300);
                employeeData[i, day] = salary;
                salaryByDays[i, day - 1] = salary;
            }
        }

        while (true)
        {
            Console.WriteLine(
                "1. Вывести зарплату сотрудников за 30 дней.\n" +
                "2. Вывести зарплату всех сотрудников за 30 дней.\n" +
                "3. Вывести зарплату для определенного ID и его общей зарплаты.\n" +
                "4. Выход");
            Console.Write("Выберите: ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Зарплата всех сотрудников за 30 дней по дням:");

                        for (int employeeIndex = 0; employeeIndex < numEmployees; employeeIndex++)
                        {
                            int id = employeeData[employeeIndex, 0];
                            Console.WriteLine($"ID сотрудника {id}:");

                            for (int day = 1; day <= numDays; day++)
                            {
                                Console.WriteLine($"День {day}: {salaryByDays[employeeIndex, day - 1]}");
                            }
                            Console.WriteLine();
                        }
                        break;

                    case 2:
                        AllSalaries(employeeData);
                        Console.WriteLine();
                        break;

                    case 3:
                        Console.Write("Введите ID сотрудника: ");
                        if (int.TryParse(Console.ReadLine(), out int selectedId))
                        {
                            int monthlySalary = Get_Salary(selectedId, employeeData);

                            if (monthlySalary != -1)
                            {
                                int totalSalary = 0;
                                for (int day = 1; day <= numDays; day++)
                                {
                                    totalSalary += employeeData[selectedId - 1, day];
                                }
                                Console.WriteLine($"ID сотрудника {selectedId}:");
                                Console.WriteLine($"Общая зарплата за 30 дней: {totalSalary}");
                                Console.WriteLine();
                            }
                            else
                            {
                                Console.WriteLine("Такого сотрудника не существует.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID сотрудника.");
                        }
                        break;

                        case 4:
                        return;

                    default:
                        Console.WriteLine("Некорректный выбор.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод.");
            }
        }
    }
}