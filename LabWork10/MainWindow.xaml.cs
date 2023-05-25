using System;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Media3D;

namespace LabWork10
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        float _speed = 10;
        object locker = new object();

        public MainWindow()
        {
            InitializeComponent();
            Draw3DModel();
        }

        /// <summary>
        /// Метод, который позволяет отрисовать металлический кубик-рубика
        /// </summary>
        public void Draw3DModel()
        {
            ClearAll();

            // Thread - чтобы следить за построением, а не ожидать минуту компиляции
            Thread thread = new Thread(() =>
            {
                lock (locker)
                {
                    // рисуем кубики 9х9
                    for (int i = -1; i < 2; i++)
                    {
                        for (int j = -1; j < 2; j++)
                        {
                            for (int k = -1; k < 2; k++)
                            {
                                DrawCube(
                                    new Point3D(-0.06 + (0.125 * i), -0.06 + (0.125 * j), -0.06 + (0.125 * k)),
                                    new Point3D(0.06 + (0.125 * i), 0.06 + (0.125 * j), 0.06 + (0.125 * k))
                                );
                            }
                        }
                    }
                }
            });

            thread.Start();
        }

        /// <summary>
        /// Метод, который позволяет очистить 3D модель от точек и соединений
        /// </summary>
        public void ClearAll()
        {
            My3d.Positions.Clear();
            My3d.TriangleIndices.Clear();
        }

        /// <summary>
        /// Метод, который позволяет построить куб
        /// </summary>
        /// <param name="botLeft">Нижняя леввая точка куба</param>
        /// <param name="topRight">Верхняя правая точка куба</param>
        public void DrawCube(Point3D botLeft, Point3D topRight)
        {
            Thread.Sleep((int)(1000 / _speed));
            // задняя сторона
            AddRectangle(
                new Point3D(botLeft.X, topRight.Y, topRight.Z),
                new Point3D(topRight.X, topRight.Y, topRight.Z),
                new Point3D(topRight.X, botLeft.Y, topRight.Z),
                new Point3D(botLeft.X, botLeft.Y, topRight.Z)
            );

            Thread.Sleep((int)(1000 / _speed));
            // передняя сторона
            AddRectangle(
                new Point3D(botLeft.X, botLeft.Y, botLeft.Z),
                new Point3D(topRight.X, botLeft.Y, botLeft.Z),
                new Point3D(topRight.X, topRight.Y, botLeft.Z),
                new Point3D(botLeft.X, topRight.Y, botLeft.Z)
            );

            Thread.Sleep((int)(1000 / _speed));
            // левая сторона
            AddRectangle(
                new Point3D(botLeft.X, botLeft.Y, botLeft.Z),
                new Point3D(botLeft.X, topRight.Y, botLeft.Z),
                new Point3D(botLeft.X, topRight.Y, topRight.Z),
                new Point3D(botLeft.X, botLeft.Y, topRight.Z)
            );

            Thread.Sleep((int)(1000 / _speed));
            // правая сторона
            AddRectangle(
                new Point3D(topRight.X, topRight.Y, topRight.Z),
                new Point3D(topRight.X, topRight.Y, botLeft.Z),
                new Point3D(topRight.X, botLeft.Y, botLeft.Z),
                new Point3D(topRight.X, botLeft.Y, topRight.Z)
            );

            Thread.Sleep((int)(1000 / _speed));
            // Верхняя сторона
            AddRectangle(
                new Point3D(topRight.X, topRight.Y, botLeft.Z),
                new Point3D(topRight.X, topRight.Y, topRight.Z),
                new Point3D(botLeft.X, topRight.Y, topRight.Z),
                new Point3D(botLeft.X, topRight.Y, botLeft.Z)
            );

            Thread.Sleep((int)(1000 / _speed));
            // Нижняя сторона
            AddRectangle(
                new Point3D(botLeft.X, botLeft.Y, botLeft.Z),
                new Point3D(botLeft.X, botLeft.Y, topRight.Z),
                new Point3D(topRight.X, botLeft.Y, topRight.Z),
                new Point3D(topRight.X, botLeft.Y, botLeft.Z)
            );
        }

        /// <summary>
        /// Метод, который позволяет создать прямоугольник почетырем вершинам
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        /// <param name="D"></param>
        public void AddRectangle(Point3D A, Point3D B, Point3D C, Point3D D)
        {
            AddTriangleToModel(A, B, C);
            AddTriangleToModel(A, C, D);
        }

        /// <summary>
        /// Метод, который позволяет добавить треугольнй полигон в модель
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <param name="C"></param>
        public void AddTriangleToModel(Point3D A, Point3D B, Point3D C)
        {
            foreach (Point3D point in new Point3D[] { A, B, C })
            {
                My3d.Dispatcher.Invoke(new Action(() => My3d.Positions.Add(point)));
            }

            int count = 0;

            My3d.Dispatcher.Invoke(new Action(() => count = My3d.TriangleIndices.Count));
            My3d.Dispatcher.Invoke(new Action(() => My3d.TriangleIndices.Add(count + 2)));
            My3d.Dispatcher.Invoke(new Action(() => My3d.TriangleIndices.Add(count + 1)));
            My3d.Dispatcher.Invoke(new Action(() => My3d.TriangleIndices.Add(count)));
        }












        /// <summary>
        /// Метод, который задает вращение модели скроллингом в зависимости от выранных чекбоксов
        /// </summary>
        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            rotate.Axis = new Vector3D(
                isXRotate == null ? 0 : (bool)isXRotate.IsChecked ? 1 : 0,
                isYRotate == null ? 0 : (bool)isYRotate.IsChecked ? 1 : 0,
                isZRotate == null ? 0 : (bool)isZRotate.IsChecked ? 1 : 0
            );
        }


        /// <summary>
        /// Метод, который реализует приближение (удаление) камеры к (от) объекту(а) 
        /// </summary>
        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                MainCamera.Position = new Point3D(
                    MainCamera.Position.X,
                    MainCamera.Position.Y,
                    MainCamera.Position.Z - 0.1
                );
            }

            if (e.Delta < 0)
            {
                MainCamera.Position = new Point3D(
                    MainCamera.Position.X,
                    MainCamera.Position.Y,
                    MainCamera.Position.Z + 0.1
                );
            }
        }





        private Point lastPos;

        /// <summary>
        /// Метод, который позволяет создать вращение при зажатой левой мыши
        /// </summary>
        private void Window_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                float xDiff = (float)(lastPos.X - e.GetPosition(null).X * 1.5);
                float yDiff = (float)(lastPos.Y - e.GetPosition(null).Y * 1.5);

                rotate.Angle = (xDiff + yDiff) % 360;
            } 
            lastPos = e.GetPosition(null);
        }
    }
}
