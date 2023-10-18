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

    static void Main()
    {
        int[,] employeeData = 
        {
            {1, 2000},
            {2, 2200},
            {3, 1800},
            {4, 2500},
            {5, 1900}
        };

        Console.WriteLine("Сотрудники и их месячная зарплата:");
        for (int i = 0; i < employeeData.GetLength(0); i++)
        {
            int id = employeeData[i, 0];
            int monthlySalary = employeeData[i, 1];
            Console.WriteLine($"ID сотрудника: {id} - Зарплата за месяц: {monthlySalary}");
        }

        Console.WriteLine("Введите ID сотрудника для получения месячной зарплаты:");
        if (int.TryParse(Console.ReadLine(), out int selectedId))
        {
            int monthlySalary = Get_Salary(selectedId, employeeData);

            if (monthlySalary != -1)
            {
                Console.WriteLine($"ID сотрудника: {selectedId} - Зарплата за месяц: {monthlySalary}");
            }
            else
            {
                Console.WriteLine("Такого сотрудника нет :(");
            }
        }
        else
        {
            Console.WriteLine("Некорректный ввод.");
        }
    }
}