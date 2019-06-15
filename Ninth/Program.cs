using System;

namespace Ninth
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int size = Convert.ToInt32(Console.ReadLine());
            //Создаем однонаправленный список
            Point list = Point.MakeList(ofSize: size);
            //Делаем его циклическим
            Point p = list;
            while (p.Next != null)
                p = p.Next;
            p.Next = list;

            string[] menuElements = {
                "Найти элемент в списке",
                "Удалить элемент из списка"
            };
            Menu menu = new Menu(menuElements);
            int input = menu.GetChoose();
            while (input != 0)
            {
                switch (input)
                {
                    case 1:
                        int searchingElement = menu.GetInt("искомый элемент");
                        Point temp = list.Next;
                        do
                        {
                            if (temp.Info == searchingElement)
                            {
                                Console.WriteLine("Элемент найден");
                                break;
                            }
                            temp = temp.Next;
                        } while (temp != null && temp != list);

                        break;
                    case 2:
                        int removingElement = menu.GetInt("удаляемый элемент");
                        Point.DeleteElement(list, removingElement);
                        Point.ShowList(list);
                        Console.WriteLine("Элемент удален");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу для продолжения..");
                Console.ReadKey();
                Console.Clear();
                input = menu.GetChoose();
            }
        }
    }
}
