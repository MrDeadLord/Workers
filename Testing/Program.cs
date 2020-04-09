using System;
using System.Collections.Generic;

namespace Lesson_1
{
    class Lesson_4
    {
        class Employee
        {
            public int id { get; set; }
            public string name { get; set; }
            public string surname { get; set; }
            public string depart { get; set; }
            public int solary { get; set; }
            public DateTime hired { get; set; }
            public DateTime fired { get; set; }
        }

        static void Main()
        {
            List<Employee> parts = new List<Employee>();

            List<string> departs = new List<string>();
            List<int> depWorkers = new List<int>(); //Кол-во работников в департаменте
            List<int> solaryList = new List<int>();
            List<string> fullnameList = new List<string>();

            do
            {
                Console.WriteLine("Create a new one? y/n");
                if (Console.ReadLine() != "y") { break; }

                parts.Add(new Employee());

                int n = parts.Count - 1;

                Console.WriteLine("Enter id:");
                parts[n].id = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the name:");
                parts[n].name = Console.ReadLine();

                Console.WriteLine("Enter surname:");
                parts[n].surname = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("Fullname is: {0} {1}", parts[n].name, parts[n].surname);
                fullnameList.Add(parts[n].name + " " + parts[n].surname);
                Console.WriteLine("-----");

                Console.WriteLine("Solary:");
                parts[n].solary = int.Parse(Console.ReadLine());

                Console.WriteLine("Department id:");
                parts[n].depart = Console.ReadLine();

                Console.WriteLine();
                Console.WriteLine("-----------------------------------");
                Console.WriteLine();

                if (departs.Contains(parts[n].depart))
                {
                    int a = departs.IndexOf(parts[n].depart);  //Узнаем индекс существующего деп-та и присваеваем его к n 
                    solaryList[a] += parts[n].solary;          //Добавляем з/п к существующей в n-ячейке
                    depWorkers[a]++;                          //+1 работник к n-департаменту
                }
                else
                {
                    departs.Add(parts[n].depart);              //Добавляем новый деп-т
                    depWorkers.Add(1);                         //Теперь в новой ячейке деп-тов 1 работник
                    solaryList.Add(parts[n].solary);           //В новой ячейке з/п з/п этого работника
                }                                     //Проверяем существует ли деп-т
            } while (true);                                   //Создание новых бойцов

            void Info()
            {
                float sumGlobal = 0;
                float avarageSolary = 0;

                int sumWorkers = 0;
                foreach (int __a in depWorkers)
                {
                    sumWorkers += __a;
                }  //Высчитывание общего кол-ва работников в фирме

                Console.WriteLine("-----------------------");
                Console.WriteLine();

                Console.WriteLine("What do you want to see? 1 - solary, 2 - employee counts.");
                int _answer = int.Parse(Console.ReadLine());

                if (_answer == 1)
                {
                    Console.WriteLine("Total(1) or avarage(2)?");
                    int answerSolary = int.Parse(Console.ReadLine());

                    if (answerSolary == 1)
                    {
                        Console.WriteLine("1 - Global, 2 - total by departments");
                        int answerTotal = int.Parse(Console.ReadLine());

                        if (answerTotal == 1)
                        {
                            foreach (int departSolary in solaryList)
                            {
                                sumGlobal += departSolary;
                            }

                            Console.WriteLine("Global solary is: " + sumGlobal);
                        }       //Общая з/п по всей фирме
                        else if (answerTotal == 2)
                        {
                            Console.WriteLine("What department do you need? Enter the name:");
                            int _n = departs.IndexOf(Console.ReadLine());

                            Console.WriteLine("Total solary in this department is:" + solaryList[_n]);
                        }  //Общяя з/п по деп-ту

                    }          //Общая з/п. Сумма
                    else if (answerSolary == 2)
                    {
                        Console.WriteLine("1 - Global avarage, 2 - Department avarage.");
                        int answerAvarage = int.Parse(Console.ReadLine());

                        if (answerAvarage == 1)
                        {
                            foreach (int _a in solaryList)
                            {
                                avarageSolary += _a;
                            }

                            Console.WriteLine("Avarage global solary is: " + avarageSolary / sumWorkers);
                        }       //Средняя з/п по всей фирме
                        else if (answerAvarage == 2)
                        {
                            Console.WriteLine("what department? Enter the name:");
                            int __n = departs.IndexOf(Console.ReadLine());

                            float avarageDepSolary = solaryList[__n] / depWorkers[__n];

                            Console.WriteLine("Avarage by selecter department is: " + avarageDepSolary);
                        }  //Средняя з/п по деп-ту
                    }     //Средняя з/п
                }       //Инфа по з/п
                else if (_answer == 2)
                {
                    Console.WriteLine("1 - Global, 2 - selecter department.");

                    if (int.Parse(Console.ReadLine()) == 1)
                    {
                        Console.WriteLine("There are {0} workers now.", sumWorkers);
                    }      //Общее число работников в фирме
                    else if (int.Parse(Console.ReadLine()) == 2)
                    {
                        Console.WriteLine("What department? Enter the name.");
                        int __a = departs.IndexOf(Console.ReadLine());

                        Console.WriteLine("In selected department {0} workers.", depWorkers[__a]);
                    } //Общее число работников в выбранном департаменте
                }  //Инфа по работникам
            }                          //Показ инфы

            void Edit()
            {
                Console.WriteLine("What do you want to change? 1 - Worker, 2 - department.");
                int answerChange = int.Parse(Console.ReadLine());
                if (answerChange == 1)
                {
                    Console.WriteLine("-Change the worker-");
                    Console.WriteLine("Enter his fullname:");
                    var answerEditEmpl = Console.ReadLine();

                    if (fullnameList.Contains(answerEditEmpl))
                    {
                        Console.WriteLine(fullnameList[fullnameList.IndexOf(answerEditEmpl)] + " selected.");
                        Console.WriteLine("New one is:");
                        fullnameList[fullnameList.IndexOf(answerEditEmpl)] = Console.ReadLine();
                        Console.WriteLine();
                    }
                }   //Изменяем имя/фамилию работника
                else if (answerChange == 2)
                {
                    Console.WriteLine("-Change the department-");
                    Console.WriteLine("Enter department name you want to change:");
                    var answerEditDep = Console.ReadLine();

                    if (departs.Contains(answerEditDep))
                    {
                        Console.WriteLine("-found-");
                        Console.WriteLine("New name is:");
                        departs[departs.IndexOf(answerEditDep)] = Console.ReadLine();
                    }
                }
            }                          //Изменение имен или департаментов

            void Delete()
            {
                Console.WriteLine("Delete 1 - worker, 2 - department?");
                int answerDelete = int.Parse(Console.ReadLine());

                if (answerDelete == 1)
                {
                    Console.WriteLine("Enter fulname of worker:");
                    var answerDeleteWorker = Console.ReadLine();
                    if (fullnameList.Contains(answerDeleteWorker))
                    {
                        Console.WriteLine("-found-");
                        fullnameList.Remove(answerDeleteWorker);
                        Console.WriteLine("-deleted-");
                    }
                }           //Удаление работника
                else if (answerDelete == 2)
                {
                    Console.WriteLine("Which department you want to delite?");
                    var answerDeleteDep = Console.ReadLine();

                    if (departs.Contains(answerDeleteDep))
                    {
                        Console.WriteLine("-found-");
                        departs.Remove(answerDeleteDep);
                        Console.WriteLine("-deleted-");
                        solaryList.RemoveAt(departs.IndexOf(answerDeleteDep));
                    }
                }      //Удаление департамента, а так же з/п по тому же id
            }                       //Удаление бойцов или департамента

            int answer;

            do
            {
                Console.WriteLine("What do you want to do? 1 - Show info, 2 - Edit, 3 - De-lete");
                answer = int.Parse(Console.ReadLine());

                switch (answer)
                {
                    case 1:
                        Info();
                        break;
                    case 2:
                        Edit();
                        break;
                    case 3:
                        Delete();
                        break;
                }
            } while (answer == 1 || answer == 2 || answer == 3);                                 //Основная часть работы с юзером. Что сделать? Кроме создания

            Console.ReadKey();
        }
    }
}
