namespace TheSixthProgram3._1
{
    internal class PlanetCheck
    {
        public static int i = 0;
        // Реализация лямбда-функции переменной делегата, для защиты от частых вызовов.
        public static PlanetValidator planetValidator = Tuple<int, int, string> (string name) =>
        {
            i++;
            if (i == 3)
            {
                i = 0;
                var result = Tuple.Create(0, 0, "Вы спрашиваете слишком часто");
                return result;
            }
            else
            {
                var result = Tuple.Create(0, 0, "");
                return result;
            }
        };

        // Реализация лямбда-функции переменной делегата, для проверки допустимости найденной планеты.
        public static PlanetValidator searchForTheForbiddenPlanet = Tuple<int, int, string> (string name) =>
        {
            if (name == "Лимония")
            {
                var result = Tuple.Create(0, 0, "Это запретная планета.");
                return result;
            }
            else return (Tuple.Create(0, 0, ""));
        };
    }
}
