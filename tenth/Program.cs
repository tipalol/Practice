using System;

namespace Tenth
{
    class MainClass
    {
        static void DestroyTree(Tree t, int l)
        {
            if (t != null)
            {
                DestroyTree(t.Left, l + 3);//переход к левому поддереву
                DestroyTree(t.Right, l + 3);//переход к правому поддереву
                t = null;
            }
        }
        public static void Main(string[] args)
        {
            string[] menuElements = { };
            Menu menu = new Menu(menuElements);
            int size = menu.GetInt("Размер создаваемого дерева");
            Tree tree = null;
            tree = Tree.IdealTree(size, tree);
            Tree.ShowTree(tree, size);
            DestroyTree(tree, size);
            Console.WriteLine("Дерево уничтожено.");
        }
    }
}
